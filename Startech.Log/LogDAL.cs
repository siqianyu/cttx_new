using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StarTech.DBUtility;
using System.Collections;
using StarTech.Util;

namespace Startech.Log
{
    public class LogDAL
    {    
        /// <summary>
        /// �����־
        /// </summary>
        /// <param name="userId">�û���ʶ</param>
        /// <param name="ip">��½�û����ڻ��ӵ�IP��ַ</param>
        /// <param name="url">������־�������ڵ�ҳ���ַ</param>
        /// <param name="description">��������</param>
        /// <returns>��ӳɹ�,������־��ʶ,���򷵻�-1</returns>
        public int Add(int userId, string ip, string url, string description)
        {
            AdoHelper helper = AdoHelper.CreateHelper("DB_Instance");
            SqlParameter[] paras = new SqlParameter[5];
            paras[0] = new SqlParameter("@UserId", userId);
            paras[1] = new SqlParameter("@IP", ip);
            paras[2] = new SqlParameter("@Url", url);
            paras[3] = new SqlParameter("@Description", description);
            paras[4] = new SqlParameter("@LogId", SqlDbType.Int, 4);
            paras[4].Direction = ParameterDirection.Output;

            if (helper.ExecuteSPNonQuery("sp_Log_Add", (IDataParameter[])paras) == 1) return (int)paras[4].Value;
            return -1;
        }


        /// <summary>
        ///ɾ����־
        /// </summary>
        /// <param name="logIdList">��־��ʶ����</param>
        public void Delete(int[] logIdList)
        {
            AdoHelper helper = AdoHelper.CreateHelper("DB_Instance");
            StringBuilder sql = new StringBuilder();
            sql.Append("delete from T_Log where LogId ");
            if (logIdList.Length == 1)
                sql.AppendFormat("={0}", logIdList[0]);
            else if (logIdList.Length > 1)
            {
                string[] strLogIdList = StringUtility.TranslateToStringArray(logIdList);
                sql.AppendFormat("in({0})", String.Join(",", strLogIdList));
            }

            helper.ExecuteSqlNonQuery(sql.ToString());
        }

        /// <summary>
        ///ɾ����־
        /// </summary>
        /// <param name="logId">��־��ʶ</param>
        public bool DeleteLog(int logId)
        {
            string sql = String.Format("delete T_Log where LogId={0}", logId);
            return AdoHelper.CreateHelper("DB_Instance").ExecuteSqlNonQuery(sql) > 0;
        }

        /// <summary>
        /// ��������ɾ����¼
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        public bool Delete(string strWhere)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append(" delete T_Log ");
            if (strWhere != null && strWhere.Length > 0)
                sbSql.Append(" where " + strWhere);
            return AdoHelper.CreateHelper("DB_Instance").ExecuteSqlNonQuery(sbSql.ToString()) > 0;
        }

        public DataSet GetLogList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return PaginationUtility.GetPaginationList(fields, "V_Log", filter, sort, currentPageIndex, pageSize, out recordCount);
        }


        /// <summary>
        /// �û������������־
        /// </summary>
        /// <param name="model"></param>
        public void InsertLog(Startech.Log.LogModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Log(");
            strSql.Append("ApplicationName,FirstItem,SecondItem,ActionType,Description,UserId,OperationDate,Url,IP)");
            strSql.Append(" values (");
            strSql.Append("@ApplicationName,@FirstItem,@SecondItem,@ActionType,@Description,@UserId,@OperationDate,@Url,@IP)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ApplicationName", SqlDbType.VarChar,50),
					new SqlParameter("@FirstItem", SqlDbType.VarChar,50),
					new SqlParameter("@SecondItem", SqlDbType.VarChar,50),
					new SqlParameter("@ActionType", SqlDbType.VarChar,50),
					new SqlParameter("@Description", SqlDbType.Text),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@OperationDate", SqlDbType.DateTime),
					new SqlParameter("@Url", SqlDbType.VarChar,150),
					new SqlParameter("@IP", SqlDbType.VarChar,50)};
            parameters[0].Value = model.ApplicationName;
            parameters[1].Value = model.FirstItem;
            parameters[2].Value = model.SecondItem;
            parameters[3].Value = model.ActionType;
            parameters[4].Value = model.Description;
            parameters[5].Value = model.UserId;
            parameters[6].Value = model.OperationDate;
            parameters[7].Value = model.Url;
            parameters[8].Value = model.IP;

            AdoHelper.CreateHelper("DB_Instance").ExecuteSqlNonQuery(strSql.ToString(), parameters);
        }
    }
}
