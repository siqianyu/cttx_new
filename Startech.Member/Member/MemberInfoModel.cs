using System;
using System.Collections.Generic;
using System.Text;

namespace Startech.Member.Member
{
    public class MemberInfoModel
    {
        public MemberInfoModel()
        { }
        #region Model
        private int _memberid;
        private string _membername;
        private string _password;
        private string _memberstatus;
        private string _memberinplatfroms;
        private string _membertype;
        private string _membercompanytype;
        private string _areaname;
        private string _membercompanyname;
        private string _membercompanycode;
        private string _membertruename;
        private string _sex;
        private string _tel;
        private string _fax;
        private string _mobile;
        private string _address;
        private string _post;
        private string _email;
        private DateTime _regtime = DateTime.Now;
        private string _regtype;
        private int _shflag = 0;
        private DateTime _shtime = DateTime.Parse("1900-01-01");
        private string _shperson;
        private string _unpassreason;
        private decimal _buymoneyaccount = 0;
        private decimal _buymoneyaccountused = 0;
        private decimal _freemoenyaccount = 0;
        private decimal _freemoenyaccountused = 0;
        private string _memberlevel;
        private DateTime _levelservicestarttime = DateTime.Now;
        private DateTime _levelserviceendtime = DateTime.Now;
        private int _ishangzhou = 0;
        private int _iscompany = 0;
        private string _companyinfo;
        private string _url_qy;
        private string _url_business;
        private int _downloadNumber;
        private int _trustNumber;
        private int _ischeckcardid;
        /// <summary>
        /// ��Ա��ţ�Guid��
        /// </summary>
        public int memberId
        {
            set { _memberid = value; }
            get { return _memberid; }
        }
        /// <summary>
        /// ��Ա��
        /// </summary>
        public string memberName
        {
            set { _membername = value; }
            get { return _membername; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// ��Ա״̬��������ZC,���ã�JY
        /// </summary>
        public string memberStatus
        {
            set { _memberstatus = value; }
            get { return _memberstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string memberInPlatfroms
        {
            set { _memberinplatfroms = value; }
            get { return _memberinplatfroms; }
        }
        /// <summary>
        /// ��Ա���ͣ�������Gov,��ҵ��Com,���ˣ�Person
        /// </summary>
        public string memberType
        {
            set { _membertype = value; }
            get { return _membertype; }
        }
        /// <summary>
        /// ��Ա����ҵ���ֱ��д���ģ�
        /// </summary>
        public string memberCompanyType
        {
            set { _membercompanytype = value; }
            get { return _membercompanytype; }
        }
        /// <summary>
        /// ���ڵ�����ֱ��д���ģ�
        /// </summary>
        public string areaName
        {
            set { _areaname = value; }
            get { return _areaname; }
        }
        /// <summary>
        /// ��Ա����ҵ����
        /// </summary>
        public string memberCompanyName
        {
            set { _membercompanyname = value; }
            get { return _membercompanyname; }
        }
        /// <summary>
        /// ��Ա����ҵ��֯��������
        /// </summary>
        public string memberCompanyCode
        {
            set { _membercompanycode = value; }
            get { return _membercompanycode; }
        }
        /// <summary>
        /// ��ʵ����
        /// </summary>
        public string memberTrueName
        {
            set { _membertruename = value; }
            get { return _membertruename; }
        }
        /// <summary>
        /// �Ա�
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// �绰
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// ���Ͷ�����
        /// </summary>
        public string mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// �ʱ�
        /// </summary>
        public string post
        {
            set { _post = value; }
            get { return _post; }
        }
        /// <summary>
        /// email
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// ע��ʱ��
        /// </summary>
        public DateTime regTime
        {
            set { _regtime = value; }
            get { return _regtime; }
        }
        /// <summary>
        ///  ע������ 1��Աע�� 2����ȯע��
        /// </summary>
        public string regType
        {
            set { _regtype = value; }
            get { return _regtype; }
        }
        /// <summary>
        /// ��˱�ʾ��1ͨ����0δͨ��
        /// </summary>
        public int shFlag
        {
            set { _shflag = value; }
            get { return _shflag; }
        }

        /// <summary>
        /// �Ƿ���֤�˷������֤:1 �� ���� ����
        /// </summary>
        public int ischeckcardid
        {
            set { _ischeckcardid = value; }
            get { return _ischeckcardid; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public int downloadNumber
        {
            set { _downloadNumber = value; }
            get { return _downloadNumber; }
        }

        /// <summary>
        /// �й�����
        /// </summary>
        public int trustNumber
        {
            set { _trustNumber = value; }
            get { return _trustNumber; }
        }

        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime shTime
        {
            set { _shtime = value; }
            get { return _shtime; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public string shPerson
        {
            set { _shperson = value; }
            get { return _shperson; }
        }
        /// <summary>
        /// δͨ�����ԭ��
        /// </summary>
        public string unPassReason
        {
            set { _unpassreason = value; }
            get { return _unpassreason; }
        }
        /// <summary>
        /// �ֽ��˻������ֽ��ֵ��
        /// </summary>
        public decimal buyMoneyAccount
        {
            set { _buymoneyaccount = value; }
            get { return _buymoneyaccount; }
        }
        /// <summary>
        /// �ֽ��˻������ֽ��ֵ���ۼ�ʹ�ü�¼
        /// </summary>
        public decimal buyMoneyAccountUsed
        {
            set { _buymoneyaccountused = value; }
            get { return _buymoneyaccountused; }
        }
        /// <summary>
        /// ���͵��˻���������ȯ�ȣ�
        /// </summary>
        public decimal freeMoenyAccount
        {
            set { _freemoenyaccount = value; }
            get { return _freemoenyaccount; }
        }
        /// <summary>
        /// ���͵��˻���������ȯ�ȣ��ۼ�ʹ�ü�¼
        /// </summary>
        public decimal freeMoenyAccountUsed
        {
            set { _freemoenyaccountused = value; }
            get { return _freemoenyaccountused; }
        }
        /// <summary>
        /// ��Ա�ȼ��������ֶΣ�Ĭ��1��
        /// </summary>
        public string memberLevel
        {
            set { _memberlevel = value; }
            get { return _memberlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime levelServiceStartTime
        {
            set { _levelservicestarttime = value; }
            get { return _levelservicestarttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime levelServiceEndTime
        {
            set { _levelserviceendtime = value; }
            get { return _levelserviceendtime; }
        }

        /// <summary>
        /// �Ƿ��ݻ�Ա
        /// </summary>
        public int ishangzhou
        {
            set { _ishangzhou = value; }
            get { return _ishangzhou; }
        }

        /// <summary>
        /// �Ƿ���ҵ
        /// </summary>
        public int iscompany
        {
            set { _iscompany = value; }
            get { return _iscompany; }
        }

        /// <summary>
        /// ��ҵ���
        /// </summary>
        public string companyInfo
        {
            set { _companyinfo = value; }
            get { return _companyinfo; }
        }

        /// <summary>
        /// ��ҵ��ַ
        /// </summary>
        public string url_qy
        {
            set { _url_qy = value; }
            get { return _url_qy; }
        }

        /// <summary>
        /// ������ַ
        /// </summary>
        public string url_business
        {
            set { _url_business = value; }
            get { return _url_business; }
        }

        #endregion Model


    }
}
