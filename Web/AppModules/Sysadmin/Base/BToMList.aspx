﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BToMList.aspx.cs" Inherits="AppModules_Sysadmin_Base_BToMList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>区域列表</title>
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
</head>
<body>
    <form id="form1" runat="server">
    <div class="PosiBar">
        <p>
            小区对应农贸市场关系列表</p>
    </div>

    
    <div class="SosoBar Left">
        <table>
            <tr>
                <td style=" width:80%">
                    <div class="divSearch"><div class="spanSearch" >小区名称：</div><input style="width: 100px;" id="txtBuildingName" /></div>
                    <div class="divSearch"><div class="spanSearch" >市场名称：</div><input style="width: 100px;" id="txtMarketName" /></div>
                    <%--<div class="divSearch"><div class="spanSearch" style="width:65px; float:left;"><span style="padding-right:25px;">标</span>题：</div><input style="width: 100px;" id="txtTitle" /></div>
                    <div class="divSearch"><span class="spanSearch">期刊类型：</span><asp:DropDownList ID="ddlCategory" runat="server" Width="102">
                        <asp:ListItem Value="" Selected="True" Text="--请选择--"></asp:ListItem>
                    </asp:DropDownList></div>
                    <div class="divSearch"><span class="spanSearch">所属期刊：</span><asp:DropDownList ID="ddlQikan" runat="server" Width="102">
                        <asp:ListItem Value="" Selected="True" Text="--请选择--"></asp:ListItem>
                    </asp:DropDownList></div>
                    <div class="divSearch"><span class="spanSearch">审核状态：</span><asp:DropDownList ID="ddlApproved" runat="server" Width="104px">
                        <asp:ListItem Value="" Selected="True" Text="--请选择--"></asp:ListItem>
                        <asp:ListItem Value="0" Text="未通过"></asp:ListItem>
                        <asp:ListItem Value="1" Text="通过"></asp:ListItem>
                    </asp:DropDownList></div>
                    <div class="divSearch"><div class="spanSearch" style="width:65px; float:left;"><span style="padding-right:25px;">编</span>辑：</div><input style="width: 100px;" id="txtAuthor" /></div>
                    <div class="divSearch"><span class="spanSearch">发表时间：</span>
                    <input id="txtAddDateBegin" runat="server" onclick="WdatePicker()" class="input_add" style="width: 100px" /></div>
                    <div class="divSearch"><div class="spanSearch" style="width:65px; float:left;"><span style="padding-right:25px;"></span>至：</div>
                    <input id="txtAddDateEnd" runat="server" onclick="WdatePicker()" class="input_add" style="width: 100px" /></div>--%>
                </td>
                <td style=" width:20%">
                    <div class="divSearchUC"><input type="button" class="SelectBut" value="查&nbsp;询" title="查询" onclick="grid_search()" />
                    
                    <asp:Button ID="btnAdd" runat="server" Text=" 添 加 " OnClientClick="button_actions('add'); return false;" CssClass="Green InputClass"/>
                    <asp:Button ID="BtnApprove" runat="server" Visible="false"  Text="批量审核"  OnClientClick="return button_actions('approveAll')"  CssClass="DarkRed InputClass" />
                    <asp:Button ID="btnDelete" runat="server" Text="批量删除" OnClientClick="return button_actions('deleteAll')" CssClass="Red InputClass"/>
                    
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
        url: 'BToMHandler.ashx?flag=list',
        datatype: "json",
        colNames: ['区域编号', '小区/大厦名称', '区域名称', '排序', '操作'],
        colModel: [
            { name: 'BuildingToMarket_id', index: 'area_id', hidden: true },
            { name: 'BuildingName', index: 'BuildingName', width: 70, align: 'left' },
   		    { name: 'MarketName', index: 'MarketName', width: 70, align: 'left' },
            { name: 'orderby', index: 'orderby', width: 30, align: 'center' },
            { name: 'cmd_col', align: 'center' }
   	    ],
        rowList: [10, 15, 20],
        pager: '#startech_table_jqgrid_pager',
        sortname: 'orderby',
        viewrecords: true,
        sortorder: "asc",
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
                    var id = rowData.BuildingToMarket_id;
                    var writeData = { cmd_col: "<input type='button' class='CommonButon' value='配送费' onclick=\"button_actions('price','" + id + "')\"> <input type='button' class='CommonButon' value='编辑' onclick=\"button_actions('edit','" + id + "')\"> <input type='button' class='CommonButon' value='删除' onclick=\"button_actions('delete','" + id + "')\">" }
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
        else if (flag == "price") {
            setPrice(id);
            return false;
        }
        else if (flag == "deleteAll") {
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
        var _BuildingName = $("#txtBuildingName").val();
        var _MarketName = $("#txtMarketName").val();
        var _searchfilter = "BuildingName$$" + _BuildingName + "_$$_MarketName$$" + _MarketName;
        var _searchfilter = escape(_searchfilter);

        jQuery("#startech_table_jqgrid").jqGrid('setGridParam', { url: "BToMHandler.ashx?flag=list&searchfilter=" + _searchfilter + "", page: 1 }).trigger("reloadGrid");
    }

    //添加
    function add_method() {
        $.layer({
            type: 2,
            shade: [0.1, '#000'],
            fix: false,
            title: ['添加', true],
            maxmin: true,
            iframe: { src: 'AddBToM.aspx?r=' + Math.random() },
            area: [document.body.scrollWidth - 20, $(document).height()],
            offset: ['0px', ''],
            close: function (index) {
                //layer.msg('您获得了子窗口标记：' + layer.getChildFrame('#name', index).val(), 3, 1);
                jQuery("#startech_table_jqgrid").trigger("reloadGrid");
            }
        });
    }

    //配送费设置
    function setPrice(id) {
        $.layer({
            type: 2,
            shade: [0.1, '#000'],
            fix: false,
            title: ['配送费设置', true],
            maxmin: true,
            iframe: { src: 'SetBToMPrice.aspx?id=' + id },
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
            iframe: { src: 'AddBToM.aspx?id=' + id },
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
            var str = $.ajax({ url: "BToMHandler.ashx?flag=delete&id=" + id + "&r=" + Math.random(), async: false }).responseText;
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
                    id += jQuery('#startech_table_jqgrid').jqGrid('getCell', rowData[i], 'BuildingToMarket_id') + "|"; //获取所有选中的id值
                }
                var str = $.ajax({ url: "BToMHandler.ashx?flag=delete&id=" + id + "", async: false }).responseText;
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

