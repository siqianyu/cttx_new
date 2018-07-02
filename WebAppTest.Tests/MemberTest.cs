using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTcms.Common;
using System.Text;
using System.Collections.Generic;
using StarTech.ELife.ShortMsg;

namespace WebAppTest.Tests
{
    [TestClass]
    public class MemberTest
    {
        string url = "http://localhost:8092";

        /*
        会员相关步骤
        1、注册
         * 1>发送短信
         * 2>找回密码
         * 3>绑定微信
         
        2、登陆 
          
         */

        [TestMethod]
        public void TestMsg()
        {
            url = url + "/MsgInterface/SendMsg.ashx";


        }

        [TestMethod]
        public void TestLogin()
        {
            url = url + "/CTTXServerInterface/UserRegAndLogin.ashx";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("flag", "user_login");
            dic.Add("phone", "13336677383");
            dic.Add("pwd", "123456");
            string result = Utils.HttpPost(url, Utils.BuildQuery(dic));
            Assert.AreEqual(result, "1");
        }
        [TestMethod]
        public void TestReg()
        {
            url = url + "/CTTXServerInterface/UserRegAndLogin.ashx";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("flag", "user_reg");
            dic.Add("phone", "13336677383");
            dic.Add("pwd", "123456");
            dic.Add("truename", "斯钱余");
            dic.Add("wxopenid", "oKiw2txqGW6Pk5IwyME8EWT1HHtw");
            dic.Add("code", "m100406");
            string result = Utils.HttpPost(url, Utils.BuildQuery(dic));
            Assert.AreNotEqual(result, "1");
        }
        [TestMethod]
        public void TestShortMsg()
        {
            string rn = new Random().Next(1001, 9999).ToString();
            url = url + "/Default.aspx";
            string result = Utils.HttpPost(url, "r=" + rn);
            Assert.AreNotEqual(result, "1");
            //StarTech.ELife.ShortMsg.ShortMsgBll bll = new StarTech.ELife.ShortMsg.ShortMsgBll();
            //StarTech.ELife.ShortMsg.ShortMsgModel ShortMsg = new StarTech.ELife.ShortMsg.ShortMsgModel();
            //ShortMsg.supplier = "ali";
            //ShortMsg.statu = "sending";
            //ShortMsg.sysnumber = Guid.NewGuid().ToString();
            //ShortMsg.tel = "13336677383";
            //ShortMsg.template = "";
            //ShortMsg.smsSign = "远鉴才通";
            //ShortMsg.sendTime = DateTime.Now;
            //ShortMsg.yzm = "123456";
            //ShortMsg.outSendTime = DateTime.Now.AddHours(1);
            //bool success = bll.Add(ShortMsg);
            //if (success)
            //{
            //    ShortMsg.SendSms();
            //}
            //else
            //{
            //    //添加到数据库失败
            //}

        }
    }

}
