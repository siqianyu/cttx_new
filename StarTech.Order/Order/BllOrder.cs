using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace StarTech.Order.Order
{
    public class BllOrder
    {
        private DalOrder dal = new DalOrder();

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(ModOrder model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(ModOrder model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public ModOrder GetModel(string orderId)
        {
            return dal.GetModel(orderId);
        }

        /// <summary>
        /// ֧������
        /// </summary>
        public int PayOrder(string memberId, string orderId, string payInterfaceCode)
        {
            int r = 0;
            ModOrder mod = GetModel(orderId);
            if ((mod != null) && (mod.IsPay == 0))
            {
                r = new BllTableObject("T_Order_Info").Util_UpdateBat("IsPay=1,PayTime=getdate(),PayInterfaceCode='" + payInterfaceCode + "'", "isPay=0 and orderId='" + orderId + "' and memberId='" + memberId + "'");
                
                //��һ���ж�,�����������Ϳ������
                UpdateGoodsStock(orderId);
            }
            return r;
        }


        /// <summary>
        /// ����������
        /// </summary>
        /// <returns></returns>
        public void UpdateGoodsStock(string orderId)
        {
            if (new BllTableObject("T_Order_Info").Util_CheckIsExsitData("orderId='" + orderId + "' and (IsComplete=1 or IsPay=1)") == true)
            {
                DataTable dtDetail = new BllTableObject(" T_Order_InfoDetail").Util_GetList("OrderType,GoodsId,GoodsCode,Quantity,GoodsFormate", "orderId='" + orderId + "'");
                foreach (DataRow row in dtDetail.Rows)
                {
                    int quantity = Int32.Parse(row["Quantity"].ToString());
                    if (row["OrderType"].ToString() == "PT")
                    {
                        if (row["GoodsFormate"].ToString() == "")
                        {
                            new BllTableObject("T_Goods_Info").Util_UpdateBat("TotalSaleCount=TotalSaleCount+" + quantity + ",Sotck=Sotck-" + quantity + "", "GoodsId='" + row["GoodsId"].ToString() + "'");
                        }
                        else
                        {
                            new BllTableObject("T_Goods_Info").Util_UpdateBat("TotalSaleCount=TotalSaleCount+" + quantity + "", "GoodsId='" + row["GoodsId"].ToString() + "'");
                            new BllTableObject("T_Goods_Formate").Util_UpdateBat("Stock=Stock-" + quantity + "", "GoodsId='" + row["GoodsId"].ToString() + "' and GoodsCode='" + row["GoodsCode"].ToString() + "'");
                        }
                    }
                    else if (row["OrderType"].ToString() == "TG")
                    {
                        new BllTableObject("T_Group_GoodsInfo").Util_UpdateBat("GroupNumber=GroupNumber+" + quantity + ",Stock=Stock-" + quantity + "", "GoodsId='" + row["GoodsId"].ToString() + "'");
                    }
                }
            }
        }

        /// <summary>
        /// �����а�����ȫ������
        /// </summary>
        public string GetOrderAllGoods(string orderId)
        {
            string s = "";
            DataTable dtCate = new BllTableObject("T_Order_InfoDetail").Util_GetList("GoodsName,GoodsFormate,GoodsPic", "OrderId='" + orderId + "'");
            foreach (DataRow row in dtCate.Rows)
            {
                if (row["GoodsFormate"].ToString() != "")
                {
                    s += row["GoodsName"].ToString() + "(���" + row["GoodsFormate"].ToString() + "),";
                }
                else
                {
                    s += row["GoodsName"].ToString() + ",";
                }
            }
            if (s != "") { s = s.TrimEnd(','); }
            return s;
        }

        /// <summary>
        /// ��ʾ��Ա�Ķ���״̬
        /// </summary>
        public string GetOrderStatusByMember(string IsPay, string IsSend, string IsGet, string IsMemberCancel, string IsComplete)
        {
            if (IsMemberCancel == "1") { return "��ȡ��"; }
            if (IsComplete == "1") { return "�����"; }
            if (IsPay == "0")
            {
                return "δ����";
            }
            else if (IsPay == "1")
            {
                if (IsSend == "0")
                {
                    return "�Ѹ���,δ����";
                }
                else
                {
                    if (IsGet == "0")
                    {
                        return "�ѷ���";
                    }
                    else
                    {
                        return "�����";
                    }
                }
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// ��ʾ��̨����Ķ���״̬
        /// </summary>
        public string GetOrderStatusByAdmin(string IsPay, string IsSend, string IsGet, string IsMemberCancel, string IsComplete)
        {
            if (IsMemberCancel == "1") { return "��ȡ��"; }
            if (IsComplete == "1") { return "�����"; }
            if (IsPay == "0")
            {
                if (IsSend == "1")
                {
                    return "δ����,�ѷ���";
                }
                else
                {
                    return "δ����";
                }
            }
            else if (IsPay == "1")
            {
                if (IsSend == "0")
                {
                    return "�Ѹ���,δ����";
                }
                else if (IsSend == "1")
                {
                    if (IsGet == "1")
                    {
                        return "���ջ�";
                    }
                    else
                    {
                        return "�ѷ���";
                    }
                }
                else 
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }
    }
}
