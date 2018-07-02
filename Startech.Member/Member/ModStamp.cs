using System;
using System.Collections.Generic;
using System.Text;

namespace Startech.Member.Member
{
    public class ModStamp
    {
        #region Model
        private int _id;
        private string _stampno;
        private string _password;
        private int? _isused;
        private int? _stampmoney;
        private DateTime? _stampouttime;
        private int? _stamptype;
        private DateTime? _addtime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StampNo
        {
            set { _stampno = value; }
            get { return _stampno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsUsed
        {
            set { _isused = value; }
            get { return _isused; }
        }
        /// <summary>
        /// ��ֵ���ѷ�Ϊ��λ��
        /// </summary>
        public int? StampMoney
        {
            set { _stampmoney = value; }
            get { return _stampmoney; }
        }
        /// <summary>
        /// ʧЧʱ��
        /// </summary>
        public DateTime? StampOutTime
        {
            set { _stampouttime = value; }
            get { return _stampouttime; }
        }
        /// <summary>
        /// ����ȯ����(�����ֶ�)
        /// </summary>
        public int? StampType
        {
            set { _stamptype = value; }
            get { return _stamptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        #endregion Model
    }
}
