using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using StarTech.DBUtility;

namespace Startech.Member.Member
{
    public class DALStamp
    {
        public AdoHelper adoHelper = AdoHelper.CreateHelper("DB_Instance");
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ModStamp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into N_Stamp(");
            strSql.Append("StampNo,Password,IsUsed,StampMoney,StampOutTime,StampType,AddTime)");
            strSql.Append(" values (");
            strSql.Append("@StampNo,@Password,@IsUsed,@StampMoney,@StampOutTime,@StampType,@AddTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@StampNo", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@IsUsed", SqlDbType.Int,4),
					new SqlParameter("@StampMoney", SqlDbType.Int,4),
					new SqlParameter("@StampOutTime", SqlDbType.DateTime),
					new SqlParameter("@StampType", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.StampNo;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.IsUsed;
            parameters[3].Value = model.StampMoney;
            parameters[4].Value = model.StampOutTime;
            parameters[5].Value = model.StampType;
            parameters[6].Value = model.AddTime;

            return adoHelper.ExecuteSqlNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(ModStamp model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update N_Stamp set ");
            strSql.Append("StampNo=@StampNo,");
            strSql.Append("Password=@Password,");
            strSql.Append("IsUsed=@IsUsed,");
            strSql.Append("StampMoney=@StampMoney,");
            strSql.Append("StampOutTime=@StampOutTime,");
            strSql.Append("StampType=@StampType,");
            strSql.Append("AddTime=@AddTime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@StampNo", SqlDbType.VarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,50),
					new SqlParameter("@IsUsed", SqlDbType.Int,4),
					new SqlParameter("@StampMoney", SqlDbType.Int,4),
					new SqlParameter("@StampOutTime", SqlDbType.DateTime),
					new SqlParameter("@StampType", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.StampNo;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.IsUsed;
            parameters[4].Value = model.StampMoney;
            parameters[5].Value = model.StampOutTime;
            parameters[6].Value = model.StampType;
            parameters[7].Value = model.AddTime;

            return adoHelper.ExecuteSqlNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete N_Stamp ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return adoHelper.ExecuteSqlNonQuery(strSql.ToString(), parameters);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ModStamp GetModel(string StampNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,StampNo,Password,IsUsed,StampMoney,StampOutTime,StampType,AddTime from N_Stamp ");
            strSql.Append(" where StampNo=@StampNo ");
            SqlParameter[] parameters = {
					new SqlParameter("@StampNo", SqlDbType.VarChar,50)
            };
            parameters[0].Value = StampNo;

            ModStamp model = new ModStamp();
            DataSet ds = adoHelper.ExecuteSqlDataset(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.StampNo = ds.Tables[0].Rows[0]["StampNo"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                if (ds.Tables[0].Rows[0]["IsUsed"].ToString() != "")
                {
                    model.IsUsed = int.Parse(ds.Tables[0].Rows[0]["IsUsed"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StampMoney"].ToString() != "")
                {
                    model.StampMoney = int.Parse(ds.Tables[0].Rows[0]["StampMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StampOutTime"].ToString() != "")
                {
                    model.StampOutTime = DateTime.Parse(ds.Tables[0].Rows[0]["StampOutTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["StampType"].ToString() != "")
                {
                    model.StampType = int.Parse(ds.Tables[0].Rows[0]["StampType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,StampNo,Password,IsUsed,StampMoney,StampOutTime,StampType,AddTime ");
            strSql.Append(" FROM N_Stamp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return adoHelper.ExecuteSqlDataset(strSql.ToString());
        }


        /// <summary>
        /// ������֤��1��ͨ����֤��-1�����Ŵ���-2���������
        /// </summary>
        public int CheckStamp(string stampNum, string stampPwd)
        {
            DataSet ds = GetList("stampNo='" + stampNum + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["password"].ToString() == stampPwd)
                { return 1; }
                else { return -2; }
            }
            else { return -1; }
        }

        /// <summary>
        /// ��֤�����Ƿ�Ϊ��ʹ��(true:��ʹ�ã�false:δʹ��)
        /// </summary>
        public bool CheckIsUse(string stampNum)
        {
            DataSet ds = adoHelper.ExecuteSqlDataset("select stampNo from N_Stamp where stampNo='" + stampNum + "' and isUsed=1");
            if (ds.Tables[0].Rows.Count > 0) { return true; }
            else { return false; }
        }

        /// <summary>
        /// ���¿���Ϊ��ʹ��
        /// </summary>
        public int UpdateToUse(string stampNum)
        {
            return adoHelper.ExecuteSqlNonQuery("update N_Stamp set isUsed=1 where stampNo='" + stampNum + "'");
        }


        /// <summary>
        /// ʹ������ȯ��ֵ��1����ֵ�ɹ���С��0��ֵʧ�ܣ�
        /// </summary>
        public int RegStamp(string stampNum, string userID)
        {
            //��ȡ����ȯ��Ϣ
            ModStamp modStamp = GetModel(stampNum);
            if (modStamp != null)
            {
                if (modStamp.IsUsed == 1) { return -3; }
                //��¼����ֵ��ϸ��
                MemberCZRecordBLL bllMember = new MemberCZRecordBLL();
                MemberCZRecordModel modMoney = new MemberCZRecordModel();
                MemberCZRecordDAL dalMoney = new MemberCZRecordDAL();
                modMoney.memberId =int.Parse(userID);
                modMoney.addTime = DateTime.Now;
                modMoney.addPerson = "ƽ̨��Ա";
                modMoney.moneyType = "XFQ";
                modMoney.shFlag = 1;//�Զ���˳ɹ�
                modMoney.shTime = DateTime.Now;
                modMoney.shPerson = "�Զ����";
                modMoney.remarks = "";  //ʹ������ȯ
                modMoney.money = (int)(modStamp.StampMoney / 100);
                string s=Convert.ToString(modStamp.StampMoney / 100);
               
                if (bllMember.Add(modMoney) > 0)
                {
                    //�޸Ļ�Ա�ܽ��
                    if (dalMoney.UpdateMemberCount("XFQ",s,userID) > 0) { UpdateToUse(stampNum); return 1; }
                    else { return -2; }
                }
                else { return -1; }
            }
            else { return -9999; }
        }

        /// <summary>
        /// ͳ���û�ʹ�����ѿ��Ĵ���
        /// </summary>
        public int CountStampUseNumber(string userID)
        {
            DataSet ds = adoHelper.ExecuteSqlDataset("select count(*) as totalCount from T_Member_AccountRecord where memberId='" + userID + "' and moneyType='XFQ'");
            return Int32.Parse(ds.Tables[0].Rows[0]["totalCount"].ToString());
        }

        /// <summary>
        /// �����ƿ�
        /// </summary>
        public int BatCreateCard(int stampMoney, int stampType, DateTime stampOutTime, int batCerateNum)
        {
            int resultInt = 0;
            int startNum = 0;
            string stampNumStr = "";
            string stampPwd = "";
            string sql = "";
            for (int i = 0; i < batCerateNum; i++)
            {
                if (startNum == 0)
                {
                    sql = "select top 1 StampNo from N_Stamp order by id desc";
                    DataSet ds = adoHelper.ExecuteSqlDataset(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try { startNum = 1 + Int32.Parse(ds.Tables[0].Rows[0]["StampNo"].ToString()); }
                        catch { startNum = 1; }
                    }
                    else { startNum = 1; }
                }
                else
                {
                    startNum++;
                }

                if (startNum < 10) { stampNumStr = "0000" + startNum; }
                else if (startNum < 100) { stampNumStr = "000" + startNum; }
                else if (startNum < 1000) { stampNumStr = "00" + startNum; }
                else if (startNum < 10000) { stampNumStr = "0" + startNum; }
                else { stampNumStr = "" + startNum; }
                stampPwd = GetStampOnlyPwd();
                sql = "insert into N_Stamp(StampNo,Password,IsUsed,StampMoney,StampOutTime,StampType,AddTime) values('" + stampNumStr + "','" + stampPwd + "',0," + stampMoney + ",'" + stampOutTime.ToString() + "'," + stampType + ",'" + DateTime.Now.ToString() + "')";
                resultInt += adoHelper.ExecuteSqlNonQuery(sql);
            }
            return resultInt;
        }

        private string GetStampOnlyPwd()
        {
            string password = "";
            bool hasCreate = false;
            DataSet ds;
            while (!hasCreate)
            {
                Random ran = new Random();
                password = ran.Next(10000000, 99999999).ToString();
                ds = adoHelper.ExecuteSqlDataset("select id from N_Stamp where Password='" + password + "'");
                if (ds.Tables[0].Rows.Count == 0) { hasCreate = true; }
            }
            return password;
        }
    }
}
