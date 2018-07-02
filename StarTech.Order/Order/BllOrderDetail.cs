using System;
using System.Collections.Generic;
using System.Text;


namespace StarTech.Order
{
    public class BllOrderDetail
    {
        private DalOrderDetail dal = new DalOrderDetail();
       
       /// <summary>
        /// ����һ������
        /// </summary>
       public int Add(ModOrderDetail model)
       {
           return dal.Add(model);
       }

                   
       /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(ModOrderDetail model)
        {
            return dal.Update(model);
        }

            
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ModOrderDetail GetModel(string sysnumber)
        {
            return dal.GetModel(sysnumber);
        }
    }
}
