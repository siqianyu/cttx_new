using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.Collections;

namespace Startech.Log
{
    public class LogBLL
    {
        /// <summary>
        /// �����־(��½��,�û�Ʊ�ݴ���ʱʹ��)
        /// </summary>
        /// <param name="description">��־��������</param>
        /// <returns>�ɹ�,������־��ʶ,����,����-1</returns>
        public static int AddLog(string description)
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;
            string url = HttpContext.Current.Request.Path;
            //int userId = Convert.ToInt32(HttpContext.Current.Request.Cookies["__UserInfo"]["userId"]);
            int userId = 1;
            return LogBLL.AddLog(description, ipAddress, url, userId);
        }
        /// <summary>
        /// �����־ (��½ǰʹ��)
        /// </summary>
        /// <param name="description"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int AddLog(string description, int userId)
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;
            string url = HttpContext.Current.Request.Path;
            return LogBLL.AddLog(description, ipAddress, url, userId);
        }

        public static int AddLog(string description, string ip, string url, int userId)
        {
            return new LogDAL().Add(userId, ip, url, description);
        }

        /// <summary>
        /// �û������������־
        /// </summary>
        /// <param name="model"></param>
        public void InsertLog(Startech.Log.LogModel model)
        {
            model.UserId = HttpContext.Current.Session["UserId"] == null ? 0 : int.Parse(HttpContext.Current.Session["UserId"].ToString());
            model.OperationDate = DateTime.Now;
            model.Url = HttpContext.Current.Request.Path;
            model.IP = HttpContext.Current.Request.UserHostAddress;

            new LogDAL().InsertLog(model);
        }

        /// <summary>
        /// ɾ����־
        /// </summary>
        /// <param name="logIdList"></param>
        public void Delete(int[] logIdList)
        {
            new LogDAL().Delete(logIdList);
        }

        /// <summary>
        /// ɾ����־
        /// </summary>
        /// <param name="logId"></param>
        public bool DeleteLog(int logId)
        {
            return new LogDAL().DeleteLog(logId);
        }

        /// <summary>
        /// ��������ɾ����¼
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        public bool Delete(string strWhere)
        {
            return new LogDAL().Delete(strWhere);
        }

        /// <summary>
        /// ������־��¼
        /// </summary>
        /// <param name="where">��������</param>
        /// <param name="order">��������</param>
        /// <returns>������������־��¼��¼��</returns>
        //public DataSet Select(string where, string order)
        //{
        //    return new LogDAL().Select(where, order);
        //}
        public DataSet GetLogList(string fields, string filter, string sort, int currentPageIndex, int pageSize, out int recordCount)
        {
            return new LogDAL().GetLogList(fields, filter, sort, currentPageIndex, pageSize, out recordCount);
        }
    }
}
