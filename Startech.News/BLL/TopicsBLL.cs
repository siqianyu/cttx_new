using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Startech.News
{
    public class TopicsBLL
    {
        private readonly TopicsDAL dal = new TopicsDAL();

        public TopicsBLL()
		{}
		#region  ��Ա����
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(TopicsModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public void Update(TopicsModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int TopicsId)
		{
			
			dal.Delete(TopicsId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public TopicsModel GetModel(int TopicsId)
		{
			
			return dal.GetModel(TopicsId);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		
		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

        public void UpdateHits(int nid)
        {
            dal.UpdateHits(nid);
        }

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataSet GetTopicsList(string fields, string filter, string sort, int currentPage, int pageSize, out int count)
        {
            return dal.GetTopicsList(fields, filter, sort, currentPage, pageSize, out count);
        }

		#endregion  ��Ա����
    }
}
