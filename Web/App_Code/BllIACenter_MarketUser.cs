using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace StarTech.IACenter
{
    public class BllIACenter_MarketUser
    {
        private DalIACenter_MarketUser dal = new DalIACenter_MarketUser();
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ModIACenter_MarketUser model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(ModIACenter_MarketUser model)
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
        public ModIACenter_MarketUser GetModel(int uniqueId)
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
