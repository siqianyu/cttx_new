using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Web .UI .WebControls ;
using System.Collections;
using System.Web;
using Startech.Utils;


namespace Startech.Category
{
    /// <summary>
    /// ҵ���߼���CategoryBLL ��ժҪ˵����
    /// </summary>
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
    public class CategoryBLL
    {
        private readonly CategoryDAL dal = new CategoryDAL();
        public CategoryBLL()
        { }
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(CategoryModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(CategoryModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public CategoryModel GetModel(int CategoryId)
        {

            return dal.GetModel(CategoryId);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }


        #region ��������������������

        public ArrayList GetSortedArticleCategoryItems(int maxLevel, string strCategoryId)
        {
            try
            {
                ArrayList sortedCategoryItems = new ArrayList();//����һ���Զ�������
                // DataSet allCategoryItems = dal.GetAllCategoryItems();//�õ������������
                DataSet allCategoryItems = dal.GetCategoryItems();
                DataRow[] drs = allCategoryItems.Tables[0].Select(string.Format("categoryId={0}", strCategoryId), "sort");
                sortedCategoryItems.Add(new CategoryEntity("--" + drs[0]["categoryname"].ToString() + "", drs[0]["categoryId"].ToString()));//����һ��
                this.RecursionFill(allCategoryItems, sortedCategoryItems, drs[0]["categoryId"].ToString(), 1, maxLevel);
                return sortedCategoryItems;
            }
            catch
            {
                //Response.Redirect("/sysadmin/error.htm");
            }
            return null;
        }

        private void RecursionFill(DataSet dataSource, ArrayList targetToFill, string parentCategoryId, int currentLevel, int maxLevel)
        {
            if (currentLevel == maxLevel && currentLevel != 1) return;
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId), "Sort desc");//���ո������Ž�������
            foreach (DataRow categoryItems in childCategoryItems)
            {
                string categoryName = GetAppropriateCategoryName(categoryItems["categoryname"].ToString(), currentLevel);
                string categoryId = categoryItems["CategoryId"].ToString();
                targetToFill.Add(new CategoryEntity(categoryName, categoryId));
                RecursionFill(dataSource, targetToFill, categoryId, currentLevel + 1, maxLevel);
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
        public TreeNode GetCategoryTreeAll()
        {
            TreeNode root = new TreeNode("�������", "0");
            root.SelectAction = TreeNodeSelectAction.Expand;
            DataSet categoryItems = GetList(" 1=1  order by sort");
            AddChildNode(categoryItems, root, root.Value);
            return root;
        }
        //��ģ�����
        public TreeNode GetCategoryTree(int nCategoryId)
        {
            string nodeValue = "";
            switch (nCategoryId)
            {
                case 1: nodeValue = "�������"; break;
                case 2: nodeValue = "�������"; break;
            }
            TreeNode root = new TreeNode(nodeValue, "0");
            root.SelectAction = TreeNodeSelectAction.Expand;

            // DataSet categoryItems = dal.GetAllCategoryItems();
            DataSet categoryItems = dal.GetCategoryItems();

            AddChildNode(categoryItems, root, nCategoryId.ToString());
            return root;
        }
        /// <summary>
        /// �ݹ�ȡ�����ڵ������нڵ�
        /// </summary>
        /// <param name="dataSource">����Դ</param>
        /// <param name="parentNode">���ڵ�</param>
        /// <param name="parentCategoryId">���ڵ�id</param>
        private void AddChildNode(DataSet dataSource, TreeNode parentNode, string parentCategoryId)
        {
            DataRow[] childCategoryItems = dataSource.Tables[0].Select(String.Format("ParentCategoryId={0}", parentCategoryId), "Sort desc ");

            if (childCategoryItems.Length > 0)
            {
                foreach (DataRow dr in childCategoryItems)
                {
                    string title = dr["categoryname"].ToString();
                    string categoryId = dr["CategoryId"].ToString();
                    TreeNode childNode = new TreeNode(title, categoryId);
                    childNode.ShowCheckBox = true;
                    childNode.SelectAction = TreeNodeSelectAction.Expand;
                    parentNode.ChildNodes.Add(childNode);
                    AddChildNode(dataSource, childNode, categoryId);
                }
            }
        }
        #endregion

        public ArrayList GetSelectedTreeNodes(TreeNode root)
        {
            return TreeNodeUtil.GetSelectedTreeNodes(root);
        }
        public int AddCategory(CategoryModel detail)
        {
            return Add(detail);
        }

        public bool UpdateCategory(CategoryModel detail)
        {
            return Update(detail);
        }

        public bool DeleteCategory(int[] categoryIds)
        {
            return dal.DeleteCategory(categoryIds);
        }
        /// <summary>
        /// ����ýڵ�Ϊ���ڵ㣬�����ӽڵ�������ɾ��
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <returns></returns>
        public bool DeleteCategoryParent(string categoryId)
        {
            return dal.DeleteCategoryParent(categoryId);
        }

        /// <summary>
        /// ����ýڵ�Ϊ������㣬������ɾ��
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <returns></returns>
        public bool DeleteCategorySecond(string categoryId, string parentId)
        {
            return dal.DeleteCategorySecond(categoryId, parentId);
        }
        /// <summary>
        /// ������Ȩ��
        /// </summary>
        /// <param name="categoryId">���id</param>
        public void UpdateCategoryPermission(string categoryId)
        {
            dal.UpdateCategoryPermission(categoryId);
        }
        #endregion
    }
}