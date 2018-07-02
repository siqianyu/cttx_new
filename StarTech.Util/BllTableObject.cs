using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using StarTech.DBUtility;


namespace StarTech.Util
{
    public class BllTableObject
    {
        private string _tableName;

        public BllTableObject(string tableName)
        {
            this._tableName = tableName;
        }

        #region ͨ����������
        /// <summary>
        /// ������������
        /// </summary>
        public int Util_UpdateBat(string updateDesc, string updateFilter)
        {
            AdoHelper adoHelper = AdoHelper.CreateHelper(AppConfig.DBInstance);
            string sql = "update " + this._tableName + " set " + updateDesc + " where " + updateFilter + "";
            return adoHelper.ExecuteSqlNonQuery(sql);
        }

        /// <summary>
        /// ����ɾ������
        /// </summary>
        public int Util_DeleteBat(string filter)
        {
            AdoHelper adoHelper = AdoHelper.CreateHelper(AppConfig.DBInstance);
            string sql = "delete " + this._tableName + "  where " + filter + "";
            return adoHelper.ExecuteSqlNonQuery(sql);
        }

        /// <summary>
        /// �ж�ĳ�������Ƿ����
        /// </summary>
        public bool Util_CheckIsExsitData(string filter)
        {
            AdoHelper adoHelper = AdoHelper.CreateHelper(AppConfig.DBInstance);
            string sql = "select count(*) count1 from " + this._tableName + "  where " + filter + "";
            DataSet ds = adoHelper.ExecuteSqlDataset(sql);
            if (ds.Tables[0].Rows[0]["count1"].ToString() == "0") { return false; }
            return true;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataTable Util_GetList(string fields, string fielter)
        {
            AdoHelper adoHelper = AdoHelper.CreateHelper(AppConfig.DBInstance);
            string sql = "select " + fields + "  from " + this._tableName + " where " + fielter + "";
            DataSet ds = adoHelper.ExecuteSqlDataset(sql);
            return ds.Tables[0];
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataTable Util_GetList(string fields, string fielter, string sort)
        {
            AdoHelper adoHelper = AdoHelper.CreateHelper(AppConfig.DBInstance);
            string sql = "select " + fields + "  from " + this._tableName + " where " + fielter + " order by " + sort + "";
            DataSet ds = adoHelper.ExecuteSqlDataset(sql);
            return ds.Tables[0];
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet Util_GetList2(string fields, string fielter, string sort)
        {
            AdoHelper adoHelper = AdoHelper.CreateHelper(AppConfig.DBInstance);
            string sql = "select " + fields + "  from " + this._tableName + " where " + fielter + " order by " + sort + "";
            DataSet ds = adoHelper.ExecuteSqlDataset(sql);
            return ds;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataTable Util_GetList(string fields, string fielter, string sort, int top)
        {
            AdoHelper adoHelper = AdoHelper.CreateHelper(AppConfig.DBInstance);
            string sql = "select top " + top + " " + fields + "  from " + this._tableName + " where " + fielter + " order by " + sort + "";
            DataSet ds = adoHelper.ExecuteSqlDataset(sql);
            return ds.Tables[0];
        }

        /// <summary>
        /// ��������б�������
        /// </summary>
        public DataTable Util_GetGroupByList(string groupbyDesc, string fielter)
        {
            AdoHelper adoHelper = AdoHelper.CreateHelper(AppConfig.DBInstance);
            string sql = "select " + groupbyDesc + "  from " + this._tableName + " where " + fielter + " group by  " + groupbyDesc + "";
            DataSet ds = adoHelper.ExecuteSqlDataset(sql);
            return ds.Tables[0];
        }

        /// <summary>    
        /// ͳ��ĳ���ֶε��ܺ�
        /// </summary>
        public DataTable Util_SumFields(string fields, string fielter)
        {
            AdoHelper adoHelper = AdoHelper.CreateHelper(AppConfig.DBInstance);
            string fieldsDesc = "";
            string[] fieldsArr = fields.Split(',');
            for (int i = 0; i < fieldsArr.Length; i++)
            {
                fieldsDesc += "nvl(sum(" + fieldsArr[i] + "),0) " + fieldsArr[i] + ",";
            }
            if (fieldsDesc != "")
            {
                fieldsDesc = fieldsDesc.Substring(0, fieldsDesc.Length - 1);
                string sql = "select " + fieldsDesc + " from " + this._tableName + " ";
                if (fielter != "") { sql += " where " + fielter; }
                DataSet ds = adoHelper.ExecuteSqlDataset(sql);
                return ds.Tables[0];
            }
            else { return null; }
        }
        #endregion

    }
}
