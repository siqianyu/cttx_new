using System;
using System.Collections.Generic;
using System.Text;

namespace Startech.Link
{
    /// <summary>
    /// ʵ����LinkModel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class LinkModel
    {
        public LinkModel()
        { }
        #region Model
        private long _linkid;
        private string _title;
        private string _link;
        private string _image;
        private int? _displaymode;
        private int? _sort;
        private int? _categoryid;
        /// <summary>
        /// ���id
        /// </summary>
        public long LinkId
        {
            set { _linkid = value; }
            get { return _linkid; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public string Link
        {
            set { _link = value; }
            get { return _link; }
        }
        /// <summary>
        /// ͼƬ��ַ
        /// </summary>
        public string Image
        {
            set { _image = value; }
            get { return _image; }
        }
        /// <summary>
        /// �Ƿ���ʾ
        /// </summary>
        public int? DisplayMode
        {
            set { _displaymode = value; }
            get { return _displaymode; }
        }
        /// <summary>
        ///����
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// ���id
        /// </summary>
        public int? CategoryId
        {
            set { _categoryid = value; }
            get { return _categoryid; }
        }
        #endregion Model

    }
}
