using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Startech.Member.Member
{
    public class MemberCZRecordBLL
    {
        private readonly MemberCZRecordDAL dal = new MemberCZRecordDAL();
        public MemberCZRecordBLL()
		{}
		#region  ��Ա����
		/// <summary>
		/// ����һ������
		/// </summary>
        public int Add(MemberCZRecordModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
        public int Update(MemberCZRecordModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string sysnumber)
		{
			dal.Delete(sysnumber);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public MemberCZRecordModel GetModel(string sysnumber)
		{
			return dal.GetModel(sysnumber);
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
    }
}
