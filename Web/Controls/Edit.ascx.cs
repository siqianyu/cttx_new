﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sysadmin_Controls_Edit : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //对象调用
    public Button MyButton
    {
        get { return this.btnEdit; }
    }

    //方法调用
    public delegate void EditClickHandler(object sender, EventArgs e);
    public event EditClickHandler EditClickEvent;
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (EditClickEvent != null) { EditClickEvent(sender, e); }
    }

    //权限控制Code
    public string AuthCode
    {
        set { ViewState["AutoCode"] = value; }
        get { return (ViewState["AutoCode"] == null) ? "" : ViewState["AutoCode"].ToString(); }
    }

    //权限控制开关
    public int AuthFlag
    {
        set { ViewState["AuthFlag"] = value; }
        get { return (ViewState["AuthFlag"] == null) ? 0 : Int32.Parse(ViewState["AuthFlag"].ToString()); }
    }

    /*权限控制函数由引用页面决定*/
}