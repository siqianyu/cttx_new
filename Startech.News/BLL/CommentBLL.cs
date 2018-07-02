using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Startech.News
{
    public class CommentBLL
    {
        private static readonly CommentDAL dal = new CommentDAL();

        public CommentBLL()
        { }
        #region  ��Ա����

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(CommentModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(CommentModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int CommentID)
        {
            dal.Delete(CommentID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public CommentModel GetModel(int CommentID)
        {
            return dal.GetModel(CommentID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataSet GetArticleList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return new CommentDAL().GetArticleList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }

        #endregion  ��Ա����
    }
}
