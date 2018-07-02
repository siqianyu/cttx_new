using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Startech.Link
{
    public class LinkCategoryBLL
    {
        private readonly LinkCategoryDAL dal = new LinkCategoryDAL();

        public LinkCategoryBLL()
		{}

		#region  ��Ա����
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(LinkCategoryModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public int Update(LinkCategoryModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public int Delete(int ID)
		{
			
			return dal.Delete(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public LinkCategoryModel GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataSet GetLinkCategoryList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return dal.GetLinkCategoryList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }

        /// <summary>
        /// ������Ȩ��
        /// </summary>
        /// <param name="categoryId">���id</param>
        public void UpdateCategoryPermission(int categoryId)
        {
            dal.UpdateCategoryPermission(categoryId);
        }

        public DataSet GetAllCategoryItems()
        {
            return dal.GetAllCategoryItems();
        }

        #endregion  ��Ա����
    }
}
