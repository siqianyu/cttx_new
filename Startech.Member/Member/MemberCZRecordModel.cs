using System;
using System.Collections.Generic;
using System.Text;

namespace Startech.Member.Member
{
    public class MemberCZRecordModel
    {
        public MemberCZRecordModel()
		{}
		#region Model
		private string _sysnumber;
		private int? _memberid;
		private decimal? _money;
		private string _moneytype;
		private string _remarks;
        private DateTime? _addtime;
		private string _addperson;
		private int? _shflag;
		private string _shperson;
		private DateTime? _shtime;
		/// <summary>
		/// Guid
		/// </summary>
		public string sysnumber
		{
			set{ _sysnumber=value;}
			get{return _sysnumber;}
		}
		/// <summary>
		/// ��Ա���
		/// </summary>
		public int? memberId
		{
			set{ _memberid=value;}
			get{return _memberid;}
		}
		/// <summary>
		/// ��ֵ���
		/// </summary>
		public decimal? money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// ��ֵ���ͣ��ֽ�XJ,���ͣ�ZS,����ȯ��XFQ
		/// </summary>
		public string moneyType
		{
			set{ _moneytype=value;}
			get{return _moneytype;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// �����
		/// </summary>
        public string addPerson
		{
			set{ _addperson=value;}
			get{return _addperson;}
		}
		/// <summary>
		/// ���״̬:1:��ˣ�0:δ���
		/// </summary>
		public int? shFlag
		{
			set{ _shflag=value;}
			get{return _shflag;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public string shPerson
		{
			set{ _shperson=value;}
			get{return _shperson;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? shTime
		{
			set{ _shtime=value;}
			get{return _shtime;}
		}
		#endregion Model
    }
}
