using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Startech.Link
{
    public class LinkBLL
    {
        private readonly LinkDAL dal = new LinkDAL();

        public LinkBLL()
		{}

		#region  ��Ա����

		/// <summary>
		/// ����һ������
		/// </summary>
        public int Add(LinkModel model)
        {
            return dal.Add(model);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
        public int Update(LinkModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public int Delete(int LinkId)
		{
			return 
			dal.Delete(LinkId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public LinkModel GetModel(int LinkId)
		{
			return dal.GetModel(LinkId);
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
        public DataSet GetLinkList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return dal.GetLinkList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }

		#endregion  ��Ա����
    }
}
