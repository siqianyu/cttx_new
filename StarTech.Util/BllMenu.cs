using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

namespace StarTech.Util
{

    public class BllMenu
    {
        private readonly DalMenu dal = new DalMenu();
        public BllMenu()
		{}

		/// <summary>
		/// ����һ������
		/// </summary>
        public void Add(ModMenu model)
		{
            dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public void Update(ModMenu model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int uniqueId)
		{
			return dal.Delete(uniqueId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public ModMenu GetModel(int uniqueId)
		{
			
			return dal.GetModel(uniqueId);
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}
        /// <summary>
        /// ��ȡ���в˵���
        /// </summary>
        /// <param name="showDetail"></param>
        /// <returns></returns>
        public TreeNode GetMenuTree(bool showDetail)
        {
            TreeNode root = new TreeNode("վ��", "0");
            root.SelectAction = TreeNodeSelectAction.Expand;
            DataSet childMenuItem = dal.GetList("1=1");
            AddChildNode(childMenuItem, root, root.Value, showDetail);
            return root;
        }

        /// <summary>
        /// ���Ӳ˵���ݹ���ӵ����˵�����
        /// </summary>
        /// <param name="dataSource">������Դ</param>
        /// <param name="parentNode">���ڵ�</param>
        /// <param name="parentMenuId">���ڵ��ʶ</param>
        private void AddChildNode(DataSet dataSource, TreeNode parentNode, string parentMenuId, bool showDetail)
        {
            DataRow[] childMenuItems = dataSource.Tables[0].Select(String.Format("ParentMenuId={0}", parentMenuId), "orderindex");
            if (childMenuItems.Length > 0)
            {
                foreach (DataRow dr in childMenuItems)
                {
                    string menuName = dr["menuName"].ToString();
                    string UniqueId = dr["UniqueId"].ToString();
                    string orderIndex = dr["orderIndex"].ToString();
                    string IsShow = Convert.ToBoolean(dr["IsShow"]) ? "��" : "��";
                    string text;
                    if (showDetail)
                        text = String.Format("{0} <span style=\"color:red;\">[ ��ʶ:{1},�����:{2},�ɼ�:{3} ]</span>", menuName, UniqueId, orderIndex, IsShow);
                    else
                        text = menuName;
                    TreeNode childNode = new TreeNode(text, UniqueId);
                    childNode.ShowCheckBox = true;
                    childNode.SelectAction = TreeNodeSelectAction.Expand;
                    parentNode.ChildNodes.Add(childNode);
                    AddChildNode(dataSource, childNode, UniqueId, showDetail);
                }
            }
        }

        /// <summary>
        /// ��ȡ���б�ѡ�еĽڵ�
        /// </summary>
        /// <param name="root">���ĸ��ڵ�</param>
        /// <returns>��ѡ�еĽڵ�</returns>
        public ArrayList GetSelectedTreeNodes(TreeNode root)
        {
            return TreeNodeUtil.GetSelectedTreeNodes(root);

        }
        public bool Delete(int[] menuIds)
        {
            return dal.Delete(menuIds);
        }

        public ArrayList AllMenuItemForUpdate()
        {
            ArrayList validMenuItems = new ArrayList();
            DataSet allMenu = dal.RetrieveAllMenuItem();
            validMenuItems.Add(new MenuEntity("<վ��>", "0"));
            this.RecursionFill(allMenu, validMenuItems, "0", 1);
            return validMenuItems;
        }
        private void RecursionFill(DataSet dataSource, ArrayList targetToFill, string parentMenuId, int level)
        {
            if (level == 5) return;
            DataRow[] childMenuItems = dataSource.Tables[0].Select(String.Format("ParentMenuId={0}", parentMenuId));
            foreach (DataRow menuItems in childMenuItems)
            {
                string menuName = GetAppropriateMenuName(menuItems["menuName"].ToString(), level);
                string menuId = menuItems["uniqueId"].ToString();
                targetToFill.Add(new MenuEntity(menuName, menuId));
                RecursionFill(dataSource, targetToFill, menuId, level + 1);
            }
        }
        private string GetAppropriateMenuName(string menuName, int level)
        {
            StringBuilder sb = new StringBuilder();
            for (; level > 0; level--)
            {
                sb.Append("����");
            }
            sb.Append(menuName);
            return sb.ToString();
        }
    }

    public class MenuEntity
    {
        public MenuEntity(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }
        public string Name;
        public string Id;
    }
}
