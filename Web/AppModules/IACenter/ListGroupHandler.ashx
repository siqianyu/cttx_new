﻿<%@ WebHandler Language="C#" Class="ListGroupHandler" %>

using System;
using System.Web;
using StarTech.DBUtility;
using System.Data;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web.UI;



public class ListGroupHandler : IHttpHandler
{
    AdoHelper adoHelper = AdoHelper.CreateHelper("DB_Instance");

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string flag = context.Request["flag"] == null ? "" : context.Request["flag"].ToLower();
        string id = context.Request["id"] == null ? "" : context.Request["id"].ToLower();
        string lang = context.Request["lang"] == null ? "" : context.Request["lang"].ToLower();

        //查询条件searchfilter,前台须encode下
        string searchfilter = context.Request["searchfilter"] == null ? "" : context.Server.UrlDecode(context.Request["searchfilter"]);

        //jggrid内部参数rows=10&page=2&sidx=id&sord=desc
        string rows = context.Request["rows"] == null ? "15" : context.Request["rows"];     //显示数量
        string page = context.Request["page"] == null ? "1" : context.Request["page"];      //当前页
        string sidx = context.Request["sidx"] == null ? "" : context.Request["sidx"];       //排序字段
        string sord = context.Request["sord"] == null ? "desc" : context.Request["sord"];   //排序规则

        if (flag == "list")
        {
            context.Response.Write(List(page, rows, sidx, sord, searchfilter));
        }
        else if (flag == "delete")
        {
            context.Response.Write(DeleteData(id));
        }
        //else if (flag == "download")
        //{
        //    context.Response.Write(showFile(id, lang, context));
        //}
        else
        {
            context.Response.Write(List(page, rows, sidx, sord, searchfilter));
        }
    }

    /// <summary>
    /// 列表检索
    /// </summary>
    /// <param name="curPage"></param>
    /// <param name="pageSize"></param>
    /// <param name="orderBy"></param>
    /// <param name="orderByRole"></param>
    /// <param name="searchFilter"></param>
    /// <returns></returns>
    public string List(string curPage, string pageSize, string orderBy, string orderByRole, string searchFilter)
    {
        string table = " IACenter_Group";
        string fields = "uniqueid,uniqueid,groupName,'操作' as cmd_col";//字段顺序和必须前台jggrid设置的一样
        string filter = GetFilter(searchFilter);
        string sort = "order by " + orderBy + " " + orderByRole + "";
        int totalRecords = 0;
        DataTable dtSource = new PaginationUtility().GetPaginationList(fields, table, filter, sort, Int32.Parse(curPage), Int32.Parse(pageSize), out totalRecords);
        EditDataSource(ref dtSource);
        int totalPages = JSONHelper.GetTotalPages(totalRecords, Int32.Parse(pageSize));

        return JSONHelper.ToJGGridJson(curPage, totalPages.ToString(), totalRecords.ToString(), dtSource, fields.Replace("'操作' as ", "").Split(','), "uniqueid");
    }

    public string GetFilter(string searchfilter)
    {
        Hashtable hTable = JSONHelper.GetSearchFilter(searchfilter);
        string filter = " 1=1 ";
        if (hTable != null && hTable.Count > 0)
        {
            if (hTable.Contains("uniqueId") && hTable["uniqueId"].ToString().Trim() != "") { filter += " and uniqueId like '%" + hTable["uniqueId"].ToString().Trim() + "%'"; }
            if (hTable.Contains("groupName") && hTable["groupName"].ToString().Trim() != "") { filter += " and groupName like '%" + hTable["groupName"].ToString().Trim() + "%'"; }
        }
        return filter;
    }

    public void EditDataSource(ref DataTable dt)
    {
        dt.Columns.Add("ID");
        
        foreach (DataRow row in dt.Rows)
        {
            row["id"] = row["uniqueid"];
            row["groupName"] = "<a style='text-decoration:underline' href='GroupMenuSet.aspx?id=" + row["uniqueid"] + "&isShow=1\'>" + row["groupName"] + "</a>";
        }
    }


    /// <summary>
    /// 删除数据(多个编号用逗号(|)隔开)
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    public string DeleteData(string ids)
    {
        if (ids.IndexOf("|") < 0)
        {
            int i = adoHelper.ExecuteSqlNonQuery("delete from IACenter_Group where uniqueid in('" + ids.Replace(",", "','") + "')");
            return i.ToString();
        }
        else
        {
            string[] idList = ids.Split(new char[] { '|' });

            for (int i = 0; i < idList.Length - 1; i++)
            {
                if (ids[i].ToString() != "")
                {
                    int id = Convert.ToInt32(idList[i].ToString());
                    int res = adoHelper.ExecuteSqlNonQuery("delete from IACenter_Group where uniqueid=" + id);
                }
            }
            return "true";
        }
    }





    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}