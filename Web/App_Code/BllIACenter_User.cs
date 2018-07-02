using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace StarTech.IACenter
{
    public class BllIACenter_User
    {
        private DalIACenter_User dal = new DalIACenter_User();
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ModIACenter_User model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(ModIACenter_User model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int uniqueId)
        {
            return dal.Delete(uniqueId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ModIACenter_User GetModel(int uniqueId)
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

        #endregion  ��Ա����
        
    }
}
