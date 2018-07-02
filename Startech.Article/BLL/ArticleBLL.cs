using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Startech.Category;

namespace Startech.Article
{
    public class ArticleBLL
    {
        private readonly ArticleDAL dal = new ArticleDAL();

        public ArticleBLL()
		{}

		#region  ��Ա����
        public int Add(ArticleModel model)
        {
            ArticleDAL article = new ArticleDAL();

            int categoryId = model.CategoryId;
            Startech.Category.CategoryModel Ctymodel = new CategoryDAL().GetCategoryDetail(categoryId);
            if (Ctymodel.Type == 1)
                return new ArticleDAL().Add(model);
            else
            {
                int count = article.GetRecordCount(String.Format("CategoryId={0}", categoryId));
                if (count == 0)
                    return new ArticleDAL().Add(model);
                else return -2;
            }

        }

		/// <summary>
		/// ����һ������
		/// </summary>
        //public void  Add(ArticleModel model)
        //{
        //    dal.Add(model);
        //}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(ArticleModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ArticleId)
		{
			
			dal.Delete(ArticleId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public ArticleModel GetModel(int ArticleId)
		{
			
			return dal.GetModel(ArticleId);
		}

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// �õ����������б�
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="filter"></param>
        /// <param name="sort"></param>
        /// <param name="currentPageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataSet GetArticleList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return new ArticleDAL().GetArticleList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }

        /// <summary>
        /// ȫѡ���ͨ��
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="state"></param>
        public void ApproveArticleAll(string articleIds)
        {
            ArticleDAL article = new ArticleDAL();
            article.ApproveArticleAll(articleIds);
        }
        /// <summary>
        /// ȫѡȡ�����
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="state"></param>
        public void ApproveCellArticleAll(string articleIds)
        {
            ArticleDAL article = new ArticleDAL();
            article.ApproveCellArticleAll(articleIds);
        }

		#endregion  ��Ա����
    }
}
