using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Startech.Member.Member
{
    public class BLLStamp
    {
        private DALStamp dal = new DALStamp();

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ModStamp model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(ModStamp model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ModStamp GetModel(string stampNo)
        {
            return dal.GetModel(stampNo);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ������֤��1��ͨ����֤��-1�����Ŵ���-2���������
        /// </summary>
        public int CheckStamp(string stampNum, string stampPwd)
        {
            return dal.CheckStamp(stampNum, stampPwd);
        }

        /// <summary>
        /// ���¿���Ϊ��ʹ��
        /// </summary>
        public int UpdateToUse(string stampNum)
        {
            return dal.UpdateToUse(stampNum);
        }

        /// <summary>
        /// �����ƿ�
        /// </summary>
        public int BatCreateCard(int stampMoney, int stampType, DateTime stampOutTime, int batCerateNum)
        {
            return dal.BatCreateCard(stampMoney, stampType, stampOutTime, batCerateNum);
        }

        /// <summary>
        /// ʹ������ȯ��ֵ��1����ֵ�ɹ���С��0��ֵʧ�ܣ�
        /// </summary>
        public int RegStamp(string stampNum, string userID)
        {
            return dal.RegStamp(stampNum, userID);
        }

        /// <summary>
        /// ��֤�����Ƿ�Ϊ��ʹ��(true:��ʹ�ã�false:δʹ��)
        /// </summary>
        public bool CheckIsUse(string stampNum)
        {
            return dal.CheckIsUse(stampNum);
        }

        /// <summary>
        /// ͳ���û�ʹ�����ѿ��Ĵ���
        /// </summary>
        public int CountStampUseNumber(string userID)
        {
            return dal.CountStampUseNumber(userID);
        }
    }
}
