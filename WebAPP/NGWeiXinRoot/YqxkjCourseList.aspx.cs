﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NGWeiXinRoot_YqxkjCourseList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.hid_dirId.Value = Common.NullToZero(Request["dirId"]).ToString();
    }
}