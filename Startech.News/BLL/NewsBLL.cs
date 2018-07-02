using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Startech.News
{
    public class NewsBLL
    {
        private readonly NewsDAL dal = new NewsDAL();

        public NewsBLL()
		{}

		#region  ��Ա����
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(NewsModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public void Update(NewsModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int NewsID)
		{
			
			dal.Delete(NewsID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public NewsModel GetModel(int NewsID)
		{
			
			return dal.GetModel(NewsID);
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
        public DataSet GetNewsList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return dal.GetNewsList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }

        /// <summary>
        /// ȫѡ���ͨ��
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="state"></param>
        public void ApproveArticleAll(string newsIds)
        {
            dal.ApproveArticleAll(newsIds);
        }
        
        /// <summary>
        /// ȫѡȡ�����
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="state"></param>
        public void ApproveCellArticleAll(string newsIds)
        {
            dal.ApproveCellArticleAll(newsIds);
        }
          /// <summary>
        /// ���µ����
        /// </summary>
        /// <param name="nid">���ű��</param>
        public void UpdateHits(int nid)
        {
             dal.UpdateHits(nid);
        }
		#endregion  ��Ա����

        /// <summary>
        /// �����ض�����������
        /// </summary>
        /// <param name="num">����</param>
        /// <param name="fields">�����ֶ�</param>
        /// <param name="filter">����</param>
        /// <param name="sort">����</param>
        /// <returns>����DataSet����</returns>
        public DataSet GetNewsByTop(int num, string fields, string filter, string sort)
        {
            return dal.GetNewsByTop(num, fields, filter, sort);
        }

        /// <summary>
        /// ���غ����������ض�����������
        /// </summary>
        /// <param name="num">����</param>
        /// <param name="fields">�����ֶ�</param>
        /// <param name="table">����</param>
        /// <param name="filter">����</param>
        /// <param name="sort">����</param>
        /// <returns>����DataSet����</returns>
        public DataSet GetNewsTopById_hzzlw(int num, string fields, string table, string filter, string sort)
        {
            return dal.GetNewsTopById_hzzlw(num, fields, table, filter, sort);
        }

        /// <summary>
        /// �������ŵ��������
        /// </summary>
        /// <param name="newsid">���ű��</param>
        /// <returns></returns>
        public int Update_hzzlw(string newsid)
        {
            return dal.Update_hzzlw(newsid);
        }
        //������ʧ����
        public DataSet GetCodeLost(int intTop)
        {
            return dal.GetCodeLost(intTop);
        }
        public DataSet GetCodeLost_hzzlw(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return dal.GetCodeLost_hzzlw(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }
    }
}
