<%@ WebHandler Language="C#" Class="CTTXUser" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Collections;
using System.Data;
using StarTech.DBUtility;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Web.DynamicData;
using System.Collections.Generic;
using StarTech.ELife.ShortMsg;
using System.Configuration;

public class CTTXUser : IHttpHandler, IRequiresSessionState
{
    AdoHelper ado = AdoHelper.CreateHelper("DB_Instance");

    Dictionary<string, string> dic = new Dictionary<string, string>();
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        try
        {
            string flag = Common.NullToEmpty(context.Request["flag"]);
            if (string.IsNullOrEmpty(flag))
            {
                dic.Clear();
                dic.Add("status", "-2");
                dic.Add("msg", "接口名称不能为空！");
                return;
            }
            switch (flag.ToLower())
            {
                case "user_reg": //注册
                    Register(context);
                    break;
                case "user_login": //登陆
                    Login(context);
                    break;
                case "user_changeinfo": //修改基础信息
                    ChangeInfo(context);
                    break;
                case "user_changecareer": //修改画历
                    ChangeCareer(context);
                    break;
                case "user_gettag": //获取画像
                    GetTag(context);
                    break;
                default:
                    Nothing(context);
                    break;
            }
        }
        catch (Exception ex)
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", ex.Message);
        }
        finally
        {
            string strJson = JSONHelper.ObjectToJSON(dic);
            context.Response.Write(strJson);
            context.Response.End();
        }

    }
    private void Nothing(HttpContext context)
    {
        dic.Clear();
        dic.Add("status", "-1");
        dic.Add("msg", "没有您想要的方法");
    }
    #region 会员注册
    /// <summary>
    /// 会员注册
    /// </summary>
    /// <param name="context"></param>
    private void Register(HttpContext context)
    {
        //action=sendcode 验证码 action=reg 注册
        string action = Common.NullToEmpty(context.Request["action"]);
        if (string.IsNullOrEmpty(action))
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "action is Empty");
            return;
        }
        string phone = Common.NullToEmpty(context.Request["phone"]);
        if (string.IsNullOrEmpty(phone))
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "phone is Empty");
            return;
        }
        if (action.Equals("sendcode")) //发送验证码
        {
            string strSql = @"select * from T_Member_Info where MemberName=@tel";
            int exists = ado.ExecuteSqlDataset(strSql, new SqlParameter("@tel", phone)).Tables[0].Rows.Count;
            if (exists > 0)
            {
                dic.Clear();
                dic.Add("status", "-1");
                dic.Add("msg", "手机号已存在");
                return;
            }

            new ShortMsgModel()
            {
                flag = MsgType.reg.ToString(),
                yzm = new Random().Next(1001, 9999).ToString(),
                tel = phone,
                outSendTime = DateTime.Now.AddMinutes(5)
            }.SendSms();
            dic.Clear();
            dic.Add("status", "1");
            dic.Add("msg", "短信已发送");
        }
        else if (action == "reg")  //正式注册用户
        {
            string wxopenId = Common.NullToEmpty(context.Request["wxopenid"]);
            string pwd = Common.NullToEmpty(context.Request["pwd"]);
            string trueName = Common.NullToEmpty(context.Request["truename"]);
            string code = Common.NullToEmpty(context.Request["code"]);
            string headImg = Common.NullToEmpty(context.Request["headImg"]);
            int memberFlag = Common.NullToZero(context.Request["memberFlag"]);
            string strSql = @"select top 1 yzm from T_ShortMessage_Log where tel=@tel and outSendTime>getdate() order by sendTime desc";
            object yzm = ado.ExecuteSqlScalar(strSql, new SqlParameter("@tel", phone));
            if (!code.Equals(yzm))
            {
                dic.Clear();
                dic.Add("status", "-1");
                dic.Add("msg", "验证码错误");
                return;
            }
            if (string.IsNullOrEmpty(pwd))
            {
                dic.Clear();
                dic.Add("status", "-1");
                dic.Add("msg", "密码不能为空");
                return;
            }
            strSql = @"select * from T_Member_Info where MemberName=@tel";
            int exists = ado.ExecuteSqlDataset(strSql, new SqlParameter("@tel", phone)).Tables[0].Rows.Count;
            if (exists > 0)
            {
                dic.Clear();
                dic.Add("status", "-1");
                dic.Add("msg", "手机号已存在");
                return;
            }
            string memberId = IdCreator.CreateId("T_Member_Info", "MemberId");
            pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
            strSql = @"insert into T_Member_Info(MemberId,MemberName,Password,Mobile,Tel,LevelId,LevelName,TrueName,WXOpenId,HeadImg,MemberFlag,MemberStatus) values(@MemberId,@Tel,@Pwd,@Tel,@Tel,'1000','普通会员',@TrueName,@WXOpenId,@HeadImg,@MemberFlag,1)";
            SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@MemberId",memberId),
                    new SqlParameter("@Pwd",pwd),
                    new SqlParameter("@tel",phone),
                    new SqlParameter("@TrueName",trueName),
                    new SqlParameter("@WXOpenId",wxopenId),
                    new SqlParameter("@HeadImg",headImg),
                    new SqlParameter("@MemberFlag",memberFlag)
                };
            int result = ado.ExecuteSqlNonQuery(strSql, p);
            if (result == 1)
            {
                HttpContext.Current.Session["MemberId"] = memberId;
                dic.Clear();
                dic.Add("status", "1");
                dic.Add("msg", "注册成功");
            }
            else
            {
                dic.Clear();
                dic.Add("status", "-1");
                dic.Add("msg", "系统执行错误");
            }
        }
        else
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "action can't find");
        }
    }
    #endregion

    #region 会员登陆
    /// <summary>
    /// 会员登陆
    /// </summary>
    /// <param name="context"></param>
    private void Login(HttpContext context)
    {
        string wxopenId = Common.NullToEmpty(context.Request["wxopenid"]);
        string phone = Common.NullToEmpty(context.Request["phone"]);
        string pwd = Common.NullToEmpty(context.Request["pwd"]);
        if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(pwd))
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "手机号和密码不能为空");
        }
        pwd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
        string strSql = @"select * from T_Member_Info where MemberName=@tel and Password=@Pwd";
        SqlParameter[] p = new SqlParameter[] {
            new SqlParameter("@Pwd",pwd),
            new SqlParameter("@tel",phone)
        };
        DataTable dt = ado.ExecuteSqlDataset(strSql, p).Tables[0];
        if (dt.Rows.Count == 0)
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "帐号或密码错误");
            return;
        }
        if (dt.Rows[0]["isUse"].ToString() == "0")
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "帐号已被禁用");
            return;
        }
        //string mid = Common.NullToEmpty(context.Request["mid"]);
        string trueName = Common.NullToEmpty(context.Request["truename"]);
        //在微信外注册并未在微信内登陆时 绑定微信openId 应在登陆中
        int result = 0;
        if (!string.IsNullOrEmpty(wxopenId))
        {
            strSql = @"update T_Member_Info set WXOpenId=@WXOpenId where MemberName=@MemberName";
            SqlParameter[] p1 = new SqlParameter[] {
                    new SqlParameter("@WXOpenId",wxopenId),
                    new SqlParameter("@MemberName",phone)
                };
            result = ado.ExecuteSqlNonQuery(strSql, p1);
        }
        HttpContext.Current.Session["MemberId"] = dt.Rows[0]["MemberId"].ToString();
        dic.Clear();
        dic.Add("status", "1");
        dic.Add("msg", "登陆成功");
    }
    #endregion

    #region 修改基础信息
    /// <summary>
    /// 基础信息
    /// </summary>
    /// <param name="context"></param>
    private void ChangeInfo(HttpContext context)
    {
        string memberId = Common.NullToEmpty(context.Request["memberId"]);
        string headImg = Common.NullToEmpty(context.Request["headImg"]); //可以为空先不改
        string trueName = Common.NullToEmpty(context.Request["trueName"]);
        string sex = Common.NullToEmpty(context.Request["sex"]);
        string birthDay = Common.NullToEmpty(context.Request["birthDay"]);
        if (string.IsNullOrEmpty(memberId))
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "需要重新登陆");
            return;
        }
        string strSql = "select top 1 * from t_member_info where memberId=@memberId";
        DataTable dtUser = ado.ExecuteSqlDataset(strSql, new SqlParameter("@memberId", memberId)).Tables[0];
        if (dtUser.Rows.Count == 0)
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "您的帐号不存在");
            return;
        }
        if (string.IsNullOrEmpty(trueName))
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "请填写姓名");
            return;
        }
        if (string.IsNullOrEmpty(sex) || string.IsNullOrEmpty(birthDay))
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "性别和生日要填写");
            return;
        }
        strSql = "update t_member_info set trueName=@trueName,sex=@sex,birthDay=@birthDay where memberId=@memberId";
        SqlParameter[] p ={
                    new SqlParameter("@trueName",trueName),
                    new SqlParameter("@sex",sex),
                    new SqlParameter("@birthDay",birthDay),
                    new SqlParameter("@memberId",memberId)
        };
        int r = ado.ExecuteSqlNonQuery(strSql, p);
        if (r == 0)
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "系统错误请稍后再试试");
            return;
        }
        dic.Clear();
        dic.Add("status", "1");
        dic.Add("msg", "保存成功了");
    }
    /// <summary>
    /// 修改职历
    /// </summary>
    /// <param name="context"></param>
    private void ChangeCareer(HttpContext context)
    {
        string memberId = Common.NullToEmpty(context.Request["memberId"]);
        string lists = Common.NullToEmpty(context.Request["careers"]);
        if (string.IsNullOrEmpty(memberId))
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "请重新登陆帐号！");
            return;
        }
        string strSql = @"select * from T_Member_Info where memberId=@memberId";
        int exists = ado.ExecuteSqlDataset(strSql, new SqlParameter("@memberId", memberId)).Tables[0].Rows.Count;
        if (exists == 0)
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "您的帐号不存在");
            return;
        }
        if (string.IsNullOrEmpty(lists))
        {
            dic.Clear();
            dic.Add("status", "-1");
            dic.Add("msg", "您似乎什么都没有写！");
            return;
        }
        int caculate = 0;//插入数据次数
        // 公司1|职位1,公司2|职位2
        string[] careers = lists.Split(',');
        foreach (string career in careers)
        {
            string[] tmp = career.Split('|');
            string companyName = tmp[0];
            string jobName = tmp[1];
            strSql = "insert into T_Member_Job(sysnumber,memberId,companyName,jobName)values(@sysnumber,@memberId,@companyName,@jobName)";
            SqlParameter[] p ={
                    new SqlParameter("@sysnumber",Guid.NewGuid().ToString()),
                    new SqlParameter("@memberId",memberId),
                    new SqlParameter("@companyName",companyName),
                    new SqlParameter("@jobName",companyName)
            };
            int r = ado.ExecuteSqlNonQuery(strSql, p);
            if (r > 0)
            {
                caculate++;
            }
        }
        dic.Clear();
        dic.Add("status", "1");
        dic.Add("msg", caculate + "记录已经保存");
        return;
    }
    /// <summary>
    /// 获取画像
    /// </summary>
    /// <param name="context"></param>
    private void GetTag(HttpContext context)
    {

    }
    #endregion
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}