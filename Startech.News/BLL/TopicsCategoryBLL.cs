using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using Startech.Utils;
using System.Web;

namespace Startech.News
{
    public class CategoryEntity
    {
        public CategoryEntity(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        public string Name;
        public string Id;
    }

    public class TopicsCategoryBLL
    {
        private readonly TopicsCategoryDAL dal = new TopicsCategoryDAL();

        public TopicsCategoryBLL()
		{}

		#region  ��Ա����
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(TopicsCategoryModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public void Update(TopicsCategoryModel model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int TopicsCategoryId)
		{
			
			dal.Delete(TopicsCategoryId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public TopicsCategoryModel GetModel(int TopicsCategoryId)
		{
			
			return dal.GetModel(TopicsCategoryId);
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

		/// <summary>
		/// ��������б�
		/// </summary>
        public DataSet GetTopicsCategoryList(string fields, string filter, string sort, int currentPage, int pageSize, out int count)
        {
            return dal.GetTopicsCategoryList(fields, filter, sort, currentPage, pageSize, out count);
        }

		#endregion  ��Ա����

        #region ��ר����������������

        public ArrayList GetSortedTopicsCategoryItems(int maxLevel,string strWhere)
        {
            try
            {
                ArrayList sortedCategoryItems = new ArrayList();//����һ���Զ�������
                DataSet allCategoryItems = dal.GetAllCategoryItems();//�õ��������
                DataRow[] drs = allCategoryItems.Tables[0].Select(strWhere, "TopicsCategoryId");
                sortedCategoryItems.Add(new CategoryEntity("--" + drs[0]["title"].ToString() + "", drs[0]["TopicsCategoryId"].ToString()));//����һ��
                this.RecursionFill(allCategoryItems, sortedCategoryItems, drs[0]["TopicsCategoryId"].ToString(), 1, maxLevel,strWhere);
                return sortedCategoryItems;
            }
            catch
            {
                //Response.Redirect("/sysadmin/error.htm");
            }
            return null;
        }

        private void RecursionFill(DataSet dataSource, ArrayList targetToFill, string parentCategoryId, int currentLevel, int maxLevel,string strWhere)
        {
            if (currentLevel == maxLevel && currentLevel != 1) return;
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0} and {1}", parentCategoryId,strWhere), "Sort desc");//���ո������Ž�������
            foreach (DataRow categoryItems in childCategoryItems)
            {
                string categoryName = GetAppropriateCategoryName(categoryItems["Title"].ToString(), currentLevel);
                string categoryId = categoryItems["TopicsCategoryId"].ToString();
                targetToFill.Add(new CategoryEntity(categoryName, categoryId));
                RecursionFill(dataSource, targetToFill, categoryId, currentLevel + 1, maxLevel,strWhere);
            }
        }

        private string GetAppropriateCategoryName(string categoryName, int level)
        {
            StringBuilder sb = new StringBuilder();
            for (; level > 0; level--)
            {
                sb.Append("����");
            }
            sb.Append(categoryName);
            return sb.ToString();
        }

        #endregion

        #region  ��ȡ�����
        /// <summary>
        /// ����������ڵ�
        /// </summary>
        /// <returns></returns>
        public TreeNode GetCategoryTreeAll(int nCategoryId,int typeid)
        {
            string nodeValue = "";
            switch (nCategoryId)
            {
                case 1: nodeValue = "ר�����"; break;
            }
            TreeNode root = new TreeNode(nodeValue, "0");
            root.SelectAction = TreeNodeSelectAction.Expand;
            DataSet categoryItems = dal.GetAllCategoryItems();
            AddChildNode(categoryItems, root, nCategoryId.ToString(),typeid);
            return root;
        }
        /// <summary>
        /// �ݹ�ȡ�����ڵ������нڵ�
        /// </summary>
        /// <param name="dataSource">����Դ</param>
        /// <param name="parentNode">���ڵ�</param>
        /// <param name="parentCategoryId">���ڵ�id</param>
        private void AddChildNode(DataSet dataSource, TreeNode parentNode, string parentCategoryId,int typeid)
        {
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId), "Sort desc ");
            if (childCategoryItems.Length > 0)
            {
                foreach (DataRow dr in childCategoryItems)
                {
                    string title = dr["Title"].ToString();
                    string categoryId = dr["TopicsCategoryId"].ToString();
                    TreeNode childNode = new TreeNode(title, categoryId);
                    if (dr["Typeid"].ToString() == typeid.ToString())
                    {
                        childNode.ShowCheckBox = true;
                    }
                    childNode.SelectAction = TreeNodeSelectAction.Expand;
                    parentNode.ChildNodes.Add(childNode);
                    AddChildNode(dataSource, childNode, categoryId,typeid);
                }
            }
        }
        #endregion

        /// <summary>
        /// ������Ȩ��
        /// </summary>
        /// <param name="categoryId">���id</param>
        public void UpdateCategoryPermission(string categoryId)
        {
            dal.UpdateCategoryPermission(categoryId);
        }
        public ArrayList GetSelectedTreeNodes(TreeNode root)
        {
            return TreeNodeUtil.GetSelectedTreeNodes(root);
        }
        #region ɾ��
        /// <summary>
        /// ����ýڵ�Ϊ���ڵ㣬�����ӽڵ�������ɾ��
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <returns></returns>
        public bool DeleteCategoryParent(string categoryId)
        {
            return dal.DeleteCategoryParent(categoryId);
        }
        public bool DeleteCategory(int[] categoryIds)
        {
            return dal.DeleteCategory(categoryIds);
        }
        #endregion
    }
}
