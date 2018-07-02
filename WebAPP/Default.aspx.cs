using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StarTech.ELife.ShortMsg;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str_yzm = new Random().Next(1000, 9999).ToString();
        //先在后台设置默认发送方式
        new ShortMsgModel()
        {
            flag = "reg",
            tel = "13336677383",
            yzm = str_yzm,
            outSendTime = DateTime.Now.AddHours(1) 
        }.SendSms();

    }
}