﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WXSendMessageAllPanel.aspx.cs" Inherits="AppModules_WXSendMessagePanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>微信消息推送列表</title>
    <link href="../../../Style/List.css" rel="stylesheet" type="text/css" />
    <link href="../../../css/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <link href="../../../css/redmond/jquery-ui-custom.css" rel="stylesheet" type="text/css" />
    <script src="../../../js/jquery-1.9.0.min.js" type="text/javascript"></script>
    <script src="../../../js/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="../../../js/jquery.jqGrid.src.js" type="text/javascript"></script>
    <script src="../../../js/iframe_height_reset.js" type="text/javascript"></script>
    <script src="../../../js/grid.locale-cn.js" type="text/javascript"></script>
    <script src="../../../js/layer-v1-8-3/layer/layer.min.js" type="text/javascript"></script>
    <script src="../../../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .divSearch{ float:left; width:190px}
        .divSearch span{color: #2871a4; float:left; font-weight:bold;}
        .divSearch input{background: none repeat scroll 0 0 #fff;
    border: 1px solid #ccc;
    height: 20px;
    line-height: 20px; float:left;}
    .divSearchUC{float:left; width:325px; height:30px;}
    .divSearch select{background: none repeat scroll 0 0 #fff;
    border: 1px solid #ccc;
    height: 22px;float:left;}
    .divSearchUC .SelectBut{border:none;width:65px;height:25px;background:url(../../../Images/LogOutN.png);color:#9b0700;text-shadow:0 1px #ffe191;margin:0 10px;padding:0;text-align:center;cursor:pointer;float:left;}
    .divSearchUC .SelectBut:hover{background:url(../../../Images/LogOutA.png);}
    .spanSearch{padding:0 0 0 10px;font-weight:bold;color:#2871a4;float:left; line-height:25px;}
    .InputClass{background:url(../../../Images/Opera.png) repeat-x;border:1px solid #d0d0d0;float:left;margin:3px 0 0 7px;display:inline;padding:0 0;line-height:22px; height:22px; overflow:hidden;}
    .InputClass:hover{text-decoration:underline}
    .Gray{color:#5a5a5a;}
    .LightGray{color:#969696}
    .Green{color:#0f7e00;}
    .LightGr{color:#2aa21a;}
    .DarkRed{color:#b22300}
    .Red{color:#f00}
    </style>
    <script language="javascript">
        function select_userid() {
            if (confirm("确定要发送消息吗？") == false) { return false; }
            var id_array = new Array();
            $('input[name="cb_user"]:checked').each(function () {
                id_array.push($(this).val()); //向数组中添加元素  
            });
            var idstr = id_array.join('|'); //将数组元素连接起来以构建一个字符串  
            //alert(idstr);
            if (idstr.length < 2) {
                alert("请选择要发送的用户");
                return false;
            }
            $("#hidSelectIds").val(idstr);
            return true;
        }

        function select_all() {
            $('input[name="cb_user"]').prop('checked', 'true');
        }

        function select_all2() {
            $('input[name="cb_user"]').each(function () {
                $(this).prop("checked", !$(this).prop("checked"));
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField  runat="server" ID="hidSelectIds"/>
    <div class="PosiBar">
        <p>
            微信消息推送</p>
    </div>
    
    
    <div class="SosoBar Left">
        <table>
            <tr>
                <td>
                   <div class="divSearchUC"> <asp:Button ID="btnSend" runat="server" Text="发送消息（今日首次）" CssClass="Green InputClass" 
                            onclick="btnSend_Click" OnClientClick="return select_userid()"  />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnSend2" runat="server" Text="发送消息（重复发送）" 
                        CssClass="Red InputClass" onclick="btnSend2_Click" OnClientClick="return select_userid()"  />
                        &nbsp;&nbsp;
                        
                  </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="SosoBar Left">
        <table>
            <tr>
                <td>
                    标题：<asp:TextBox runat="server" ID="txtTitle" Width="700px">您好，您预约的试听课程已经为您开通。</asp:TextBox><br />
                    课程：<asp:TextBox runat="server" ID="txtMsg" Width="700px">《初级会计实务任务》7.4要素费用的分配，并完成课后练习。</asp:TextBox><br />
                    时间：<asp:TextBox runat="server" ID="txtTime" Width="700px">2018年4月21日 20:00之前</asp:TextBox><br />
                    备注：<asp:TextBox runat="server" ID="txtRemarks" Width="700px">考试临近，购买才通天下吧VIP课，可以获得考前冲刺培训，并保留2年学习资格，包你轻松通过初级考试。</asp:TextBox><br />
                    链接：<asp:TextBox runat="server" ID="txtUrl" Width="700px">http://www.yiqixkj.com/NGWeiXinRoot/YqxkjHome.aspx</asp:TextBox><br />
                <asp:Button ID="btnTest" runat="server" Text="测试只发给（手机号）" 
                           CssClass="Green InputClass" onclick="btnTest_Click" 
                             />(手机号：<asp:TextBox runat="server" ID="txtTel" Width="100px">18157137701</asp:TextBox>)
                            &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
        <div class="SosoBar Left">
        <table>
            <tr>
                <td>
                <div style="height:400px; overflow:scroll">
                <input type="button" value="全选" onclick="select_all()" /> <input type="button" value="取消" onclick="select_all2()" />&nbsp;&nbsp;
                   <asp:Literal runat="server" ID="ltHtml"></asp:Literal>
                   </div>
                </td>
                
            </tr>
        </table>
    </div>

    <div class="TableBox Left">
        <table id="startech_table_jqgrid">
        </table>
        <div id="startech_table_jqgrid_pager">
        </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    jQuery("#startech_table_jqgrid").jqGrid({
        url: 'WXSendMessageLog.ashx?flag=list&searchfilter=' + escape("createTime$$<%=DateTime.Now.ToString("yyyy-MM-dd") %>") + '',
        datatype: "json",
        colNames: ['编号', '接收人', '消息类型', '时间', '标题', '描述', '操作'],
        colModel: [
            { name: 'sysnumber', index: 'sysnumber', width: 70, hidden: true },
            { name: 'TrueName', index: 'TrueName', width: 40, align: 'center' },
            { name: 'type', index: 'type', width: 50, align: 'center' },
   		    { name: 'createTime', index: 'createTime', width: 50, align: 'center' },
            { name: 'title', index: 'title', width: 150 },
            { name: 'remark', index: 'remark' },
            { name: 'cmd_col', align: 'center',hidden:true }
   	    ],
        rowList: [10, 15, 20],
        pager: '#startech_table_jqgrid_pager',
        sortname: 'createTime',
        viewrecords: true,
        sortorder: "desc",
        height: "100%",
        autowidth: true,
        edittype: 'checkbox',
        multiselect: true,
        onSelectRow: function (rowid) {
            if (rowid) {
                var gr = $("#startech_table_jqgrid").getGridParam("selrow");
                var id = $("#startech_table_jqgrid").getCell(gr, "id");
            }
        },
        gridComplete: function () {
            var ids = $('#startech_table_jqgrid').jqGrid('getDataIDs');  //得到行id数组行号
            for (var i = 0; i < ids.length; i++) {
                var rowData = $("#startech_table_jqgrid").getRowData(ids[i]);
                if (rowData) {
                    var id = rowData.id;
                    //var writeData = { cmd_col: "<input type='button' class='CommonButon' value='编辑' onclick=\"button_actions('edit','" + id + "')\"> <input type='button' class='CommonButon' value='删除' onclick=\"button_actions('delete','" + id + "')\">" }
                    var writeData = { cmd_col: "<input type='button' class='CommonButon' value='编辑' onclick=\"button_actions('edit','" + id + "')\">" }
                    $('#startech_table_jqgrid').jqGrid('setRowData', ids[i], writeData);
                    //<input type='button' class='CommonButon' value='查看' onclick=\"button_actions('show','" + id + "')\">
                }
            }
        }
    });
    jQuery("#startech_table_jqgrid").jqGrid('navGrid', '#startech_table_jqgrid_pager', { edit: false, add: false, del: false });

    //刷新当前页面
    function freshCurrentPage() {
        jQuery("#startech_table_jqgrid").trigger("reloadGrid");
    }

    //button_actions
    function button_actions(flag, id, lang) {
        // id = safeReplace(id);
        if (flag == "add") {
            add_method();
            jQuery("#startech_table_jqgrid").trigger("reloadGrid");
        }
        else if (flag == "edit") {
            edit_method(id);
            jQuery("#startech_table_jqgrid").trigger("reloadGrid");
        } else if (flag == "show") {
            show_method(id);
        }
        else if (flag == "download") {
            //download_method(id, lang);
            var str = $.ajax({ url: "StandardHandle.ashx?flag=delete&lang='" + lang + "'id=" + id + "", async: false }).responseText;
        }
        else if (flag == "delete") {
            delete_method(id);
        }
        else if (flag == "approve") {
            approve_method(id);
        }
        else if (flag == "approveAll") {
            approveAll();
            return false;
        }
        if (flag == "deleteAll") {
            deleteAction();
            return false;
        }
    }

    //审核
    function approve_method(id) {
        $.layer({
            type: 2,
            shade: [0.1, '#000'],
            fix: false,
            title: ['请选择审核结果', true],
            maxmin: true,
            iframe: { src: 'Approve.aspx?Qid=' + id },
            area: ['175px', '80px'],
            offset: ['0px', ''],
            close: function (index) {
                //layer.msg('您获得了子窗口标记：' + layer.getChildFrame('#name', index).val(), 3, 1);
                jQuery("#startech_table_jqgrid").trigger("reloadGrid");
            }
        });
    }

    //查询
    function grid_search() {
        var _txtName = "";
        var _searchfilter = "TrueName$$" + _txtName + "";
        var _searchfilter = escape(_searchfilter);

        jQuery("#startech_table_jqgrid").jqGrid('setGridParam', { url: "WXSendMessageLog.ashx?flag=list&searchfilter=" + _searchfilter + "", page: 1 }).trigger("reloadGrid");
    }

    //添加
    function add_method() {
        $.layer({
            type: 2,
            shade: [0.1, '#000'],
            fix: false,
            title: ['添加', true],
            maxmin: true,
            iframe: { src: 'AddAd.aspx?r=' + Math.random() },
            area: [document.body.scrollWidth - 20, $(document).height()],
            offset: ['0px', ''],
            close: function (index) {
                //layer.msg('您获得了子窗口标记：' + layer.getChildFrame('#name', index).val(), 3, 1);
                jQuery("#startech_table_jqgrid").trigger("reloadGrid");
            }
        });
    }

    //修改
    function edit_method(id) {
        $.layer({
            type: 2,
            shade: [0.1, '#000'],
            fix: false,
            title: ['修改', true],
            maxmin: true,
            iframe: { src: 'AddAd.aspx?id=' + id },
            area: [document.body.scrollWidth - 20, $(document).height()],
            offset: ['0px', ''],
            close: function (index) {
                //layer.msg('您获得了子窗口标记：' + layer.getChildFrame('#name', index).val(), 3, 1);
                jQuery("#startech_table_jqgrid").trigger("reloadGrid");
            }
        });
    }

    //删除
    function delete_method(id) {
        layer.confirm('确定要删除吗?', function () {
            var str = $.ajax({ url: "AdHandler.ashx?flag=delete&id=" + id + "&r=" + Math.random(), async: false }).responseText;
            if (str == "true") {
                alert("删除成功！");
            }
            else {
                alert("删除失败！");
            }
            jQuery("#startech_table_jqgrid").trigger("reloadGrid");
            var index = layer.index; //获取当前弹出窗索引
            layer.close(index); //关闭弹出窗
        });
    }
    //查看
    function show_method(id) {
        $.layer({
            type: 2,
            shade: [0.1, '#000'],
            fix: false,
            title: ['查看', true],
            maxmin: true,
            iframe: { src: 'AddPeriodical.aspx?rd=1&id=' + id },
            area: ['1000px', '550px'],
            offset: ['0px', ''],
            close: function (index) {
                //layer.msg('您获得了子窗口标记：' + layer.getChildFrame('#name', index).val(), 3, 1);
                //jQuery("#startech_table_jqgrid").trigger("reloadGrid");
            }
        });
    }

    //查看文件
    function download_method(id, lang) {
        $.layer({
            type: 2,
            shade: [0.1, '#000'],
            fix: false,
            title: ['查看', true],
            maxmin: true,
            iframe: { src: 'StandardHandle.ashx?lang=' + lang + '&id=' + id },
            area: ['1000px', '550px'],
            offset: ['0px', ''],
            close: function (index) {
                //layer.msg('您获得了子窗口标记：' + layer.getChildFrame('#name', index).val(), 3, 1);
                jQuery("#startech_table_jqgrid").trigger("reloadGrid");
            }
        });
    }


    //批量审核
    function approveAll() {
        var IsCheck = false;
        var inputList = document.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            var oInput = inputList[i];
            if (oInput.type == "checkbox" && oInput.checked) {
                IsCheck = true;
            }
        }
        if (!IsCheck) {
            alert("对不起，您尚未选择要审核的选项");
            return IsCheck;
        } else {
            var rowData = jQuery('#startech_table_jqgrid').jqGrid('getGridParam', 'selarrrow');
            var id = "";
            for (var i = 0; i < rowData.length; i++) {
                id += jQuery('#startech_table_jqgrid').jqGrid('getCell', rowData[i], 'IDX') + "|"; //获取所有选中的id值
            }
            $.layer({
                type: 2,
                shade: [0.1, '#000'],
                fix: false,
                title: ['请选择审核结果', true],
                maxmin: true,
                iframe: { src: 'Approve.aspx?Qid=' + id },
                area: ['175px', '80px'],
                offset: ['0px', ''],
                close: function (index) {
                    //layer.msg('您获得了子窗口标记：' + layer.getChildFrame('#name', index).val(), 3, 1);
                    jQuery("#startech_table_jqgrid").trigger("reloadGrid");
                }
            });
        }
    }


    //批量删除
    function deleteAction() {
        var IsCheck = false;
        var inputList = document.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            var oInput = inputList[i];
            if (oInput.type == "checkbox" && oInput.checked) {
                IsCheck = true;
            }
        }
        if (!IsCheck) {
            alert("对不起，您尚未选择要删除的选项");
            return IsCheck;
        }
        else {
            if (confirm('确定要批量删除这些吗?')) {
                var rowData = jQuery('#startech_table_jqgrid').jqGrid('getGridParam', 'selarrrow');
                var id = "";
                for (var i = 0; i < rowData.length; i++) {
                    id += jQuery('#startech_table_jqgrid').jqGrid('getCell', rowData[i], 'AdId') + "|"; //获取所有选中的id值
                }
                var str = $.ajax({ url: "AdHandler.ashx?flag=delete&id=" + id + "", async: false }).responseText;
                jQuery("#startech_table_jqgrid").trigger("reloadGrid");
                if (str == "true") {
                    alert("删除成功!");
                }
                else {
                    alert("删除失败!");
                }
            }
        }
    }

</script>
