using System;
using System.Collections.Generic;
using System.Text;

namespace Startech.Link
{
    /// <summary>
    /// ʵ����LinkCategoryModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class LinkCategoryModel
    {
        public LinkCategoryModel()
        { }
        #region Model
        private int _id;
        private string _category;
        private DateTime? _addeddate;
        private int? _sort;
        private int? _type;
        /// <summary>
        /// ���id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string Category
        {
            set { _category = value; }
            get { return _category; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? AddedDate
        {
            set { _addeddate = value; }
            get { return _addeddate; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        #endregion Model

    }
}
