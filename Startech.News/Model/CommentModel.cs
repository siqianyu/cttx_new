using System;
using System.Collections.Generic;
using System.Text;

namespace Startech.News
{
    public class CommentModel
    {
        public CommentModel()
        { }
        #region Model
        private int _commentid;
        private int _newsid;
        private string _commentname;
        private string _commentcontent;
        /// <summary>
        /// 
        /// </summary>
        public int CommentID
        {
            set { _commentid = value; }
            get { return _commentid; }
        }
        /// <summary>
        /// ���ű��
        /// </summary>
        public int NewsID
        {
            set { _newsid = value; }
            get { return _newsid; }
        }
        /// <summary>
        /// ����������
        /// </summary>
        public string CommentName
        {
            set { _commentname = value; }
            get { return _commentname; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string CommentContent
        {
            set { _commentcontent = value; }
            get { return _commentcontent; }
        }
        #endregion Model
    }
}
