using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StarTech.DBUtility;

namespace StarTech.Util
{
    public class DalMenu
    {

        AdoHelper adoHelper = AdoHelper.CreateHelper(AppConfig.DBInstance);
        public DalMenu()
		{}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(ModMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into IACenter_Menu(");
			strSql.Append("menuName,menuTarget,parentMenuId,orderIndex,isShow)");
			strSql.Append(" values (");
			strSql.Append("@menuName,@menuTarget,@parentMenuId,@orderIndex,@isShow)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@menuName", SqlDbType.VarChar,50),
					new SqlParameter("@menuTarget", SqlDbType.VarChar,500),
					new SqlParameter("@parentMenuId", SqlDbType.Int,4),
					new SqlParameter("@orderIndex", SqlDbType.Int,4),
					new SqlParameter("@isShow", SqlDbType.Int,4)};
			parameters[0].Value = model.menuName;
			parameters[1].Value = model.menuTarget;
			parameters[2].Value = model.parentMenuId;
			parameters[3].Value = model.orderIndex;
			parameters[4].Value = model.isShow;

            adoHelper.ExecuteSqlNonQuery(strSql.ToString(), parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
        public void Update(ModMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update IACenter_Menu set ");
			strSql.Append("menuName=@menuName,");
			strSql.Append("menuTarget=@menuTarget,");
			strSql.Append("parentMenuId=@parentMenuId,");
			strSql.Append("orderIndex=@orderIndex,");
			strSql.Append("isShow=@isShow");
			strSql.Append(" where uniqueId=@uniqueId ");
			SqlParameter[] parameters = {
					new SqlParameter("@uniqueId", SqlDbType.Int,4),
					new SqlParameter("@menuName", SqlDbType.VarChar,50),
					new SqlParameter("@menuTarget", SqlDbType.VarChar,500),
					new SqlParameter("@parentMenuId", SqlDbType.Int,4),
					new SqlParameter("@orderIndex", SqlDbType.Int,4),
					new SqlParameter("@isShow", SqlDbType.Int,4)};
			parameters[0].Value = model.uniqueId;
			parameters[1].Value = model.menuName;
			parameters[2].Value = model.menuTarget;
			parameters[3].Value = model.parentMenuId;
			parameters[4].Value = model.orderIndex;
			parameters[5].Value = model.isShow;

            adoHelper.ExecuteSqlNonQuery(strSql.ToString(), parameters);
		}


        /// <summary>
        /// ɾ��Ҷ�ڵ�˵����Ҷ�ڵ��޷�ɾ��
        /// </summary>
        /// <param name="menuId">�˵����ʶ</param>
        /// <returns>ɾ�� ����true ,����false</returns>
        public bool Delete(int menuId)
        {
            int r = adoHelper.ExecuteSqlNonQuery("delete IACenter_Menu where uniqueId=" + menuId + "");
            return r > 0 ? true : false;
        }
        /// <summary>
        /// ɾ��Ҷ�ڵ�˵������Ҷ�ڵ��޷�ɾ��
        /// </summary>
        /// <param name="menuIds">�˵����ʶ��</param>
        /// <returns>ȫ��ɾ�� ����true ,����false</returns>
        public bool Delete(int[] menuIds)
        {
            int count = 0;
            foreach (int menuId in menuIds)
            {
                if (Delete(menuId)) count++;
            }
            return count == menuIds.Length;
        }


        /// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public ModMenu GetModel(int uniqueId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 uniqueId,menuName,menuTarget,parentMenuId,orderIndex,isShow from IACenter_Menu ");
			strSql.Append(" where uniqueId=@uniqueId ");
			SqlParameter[] parameters = {
					new SqlParameter("@uniqueId", SqlDbType.Int,4)};
			parameters[0].Value = uniqueId;

            ModMenu model = new ModMenu();

            DataSet ds = adoHelper.ExecuteSqlDataset(strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["uniqueId"].ToString()!="")
				{
					model.uniqueId=int.Parse(ds.Tables[0].Rows[0]["uniqueId"].ToString());
				}
				model.menuName=ds.Tables[0].Rows[0]["menuName"].ToString();
				model.menuTarget=ds.Tables[0].Rows[0]["menuTarget"].ToString();
				if(ds.Tables[0].Rows[0]["parentMenuId"].ToString()!="")
				{
					model.parentMenuId=int.Parse(ds.Tables[0].Rows[0]["parentMenuId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["orderIndex"].ToString()!="")
				{
					model.orderIndex=int.Parse(ds.Tables[0].Rows[0]["orderIndex"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isShow"].ToString()!="")
				{
					model.isShow=int.Parse(ds.Tables[0].Rows[0]["isShow"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select uniqueId,menuName,menuTarget,parentMenuId,orderIndex,isShow ");
			strSql.Append(" FROM IACenter_Menu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return adoHelper.ExecuteSqlDataset(strSql.ToString());
		}

        /// <summary>
        /// ��ȡ����վ������в˵���
        /// </summary>
        /// <returns>����վ������в˵���</returns>
        public DataSet RetrieveAllMenuItem()
        {

            StringBuilder query = new StringBuilder();

                query.Append("select *");
                query.Append(" from IACenter_Menu ");
                query.Append(" where 1=1 ");

            return adoHelper.ExecuteSqlDataset(query.ToString());
        }


       
    }


}
