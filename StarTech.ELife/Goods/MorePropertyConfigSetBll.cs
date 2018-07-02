using System;
using System.Collections.Generic;
using System.Text;

namespace StarTech.ELife.Goods
{
    public class MorePropertyConfigSetBll
    {
        private MorePropertyConfigSetDal dal = new MorePropertyConfigSetDal();
       
       /// <summary>
        /// ����һ������
        /// </summary>
       public int Add(MorePropertyConfigSetModel model)
       {
           return dal.Add(model);
       }

                   
       /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(MorePropertyConfigSetModel model)
        {
            return dal.Update(model);
        }

            
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public MorePropertyConfigSetModel GetModel(string propertyId)
        {
            return dal.GetModel(propertyId);
        }
    }
}
