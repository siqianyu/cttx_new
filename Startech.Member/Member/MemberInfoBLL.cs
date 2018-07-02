using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Startech.Member.Member
{
    public class MemberInfoBLL
    {
        private readonly MemberInfoDAL dal=new MemberInfoDAL();
        public MemberInfoBLL()
		{}
		#region  ��Ա����
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(MemberInfoModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public int Update(MemberInfoModel model)
        {
            return dal.Update(model);
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int memberId)
		{
			dal.Delete(memberId);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public MemberInfoModel GetModel(int memberId)
		{
			return dal.GetModel(memberId);
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
        public DataSet GetPageList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return dal.GetPageList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }

		#endregion  ��Ա����

        #region �Զ��巽��
        public int CheckUserName(string name)
        {
            return dal.CheckUserName(name);
        }
        public string CheckUserPwd(string name, string pwd)
        {
            return dal.CheckUserPwd(name,pwd);
        }
        public int UpdatePwd(string name, string pwd)
        {
            return dal.UpdatePwd(name, pwd);
        }
        public void Buy(double moeny, int id, int type)
        {
            dal.Buy(moeny, id, type);
        }
        #endregion
    }
}
