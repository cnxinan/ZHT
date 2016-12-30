<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="ZHT.Manage.Exhibition.OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
  展商详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightNav" runat="server">
    <ul>
        <li><a href="/Exhibition/ExhibitionList.aspx?ExhibitionId=<%=exhibitionId %>">展会详情</a></li>
        <li><a href="/Exhibition/SellerList.aspx?ExhibitionId=<%=exhibitionId %>">展商管理</a></li>
        <li><a href="/Exhibition/BaseTypeManage.aspx?ExhibitionId=<%=exhibitionId %>">分类管理</a></li>
        <li><a href="/Exhibition/ProductList.aspx?ExhibitionId=<%=exhibitionId %>">展品管理</a></li>
        <li><a href="/Exhibition/EnrollList.aspx?ExhibitionId=<%=exhibitionId %>">报名管理</a></li>
        <li><a href="/Exhibition/MomentList.aspx?ExhibitionId=<%=exhibitionId %>">动态管理</a></li>
        <li class="current"><a href="/Exhibition/OrderList.aspx?ExhibitionId=<%=exhibitionId %>">订单管理</a></li>
    </ul>    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SearchBar1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="SearchBar2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="TopGroup" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Content" runat="server">

    <form id="form1" name="form1" action="" method="post">
    <table border="0" align="left" cellpadding="0" cellspacing="0" width="100%"><!--class="content_info"-->
        <tr>
            <td align="left" width="100" height="50" valign="middle">
                <input type="button" value="返回" />
            </td>
        </tr>
        <tr>
            <td align="left" width="20%" height="50" valign="middle">
                订单编号：&nbsp;&nbsp;&nbsp; 
            </td>
            <td width="30%">
                <span id="OrderNo"></span>
            </td>
            <td align="left" valign="middle">
                展商名称：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="SellerName"></span>
            </td>
        </tr> 
        <tr>
            <td align="left" width="20%" height="50" valign="middle">
                用户姓名：&nbsp;&nbsp;&nbsp; 
            </td>
            <td width="30%">
                <span id="Name"></span>
            </td>
            <td align="left" valign="middle">
                用户手机号：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="Phone"></span>
            </td>
        </tr> 
        <tr>
            <td align="left" width="20%" height="50" valign="middle">
                下单时间：&nbsp;&nbsp;&nbsp; 
            </td>
            <td width="30%">
                <span id="CreateDate"></span>
            </td>
            <td align="left" valign="middle">
                总金额：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="TotalAmount"></span>
            </td>
        </tr>               
    </table>
    <br />
    <hr />
    <p>产品明细</p>
    <table border="1" width="100%">
        <thead>
            <tr>
                <th></th>
                <th>商品名称</th>
                <th>数量</th>
                <th>小计</th>
            </tr>
        </thead>
        <tbody id="orderDetails">                       
        </tbody>
    </table>
    </form>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ExtScript" runat="server">

<script type="text/javascript">
    var ExhibitionId = '<%=exhibitionId %>';
    var OrderId = '<%=orderid %>';

    $(function () {

        getInfo();
    });
    function getInfo() {

        if (OrderId != "-1") {
            $.ajax({
                type: "Post",
                url: "Order.ashx?type=getInfo",
                data: { "OrderId": OrderId },
                dataType: "json",
                success: function (result) {
                    if (result != null) {
                        $("#SellerName").html(result.SellerName);
                        $("#OrderNo").html(result.OrderNo);
                        $("#Name").html(result.Name);
                        $("#Phone").html(result.Phone);
                        $("#TotalAmount").html(result.TotalAmount);
                        $("#CreateDate").html(result.CreateDate);

                        var valueStr = '';
                        var i = 1;
                        var listdata = result.orderDetails;
                        if (listdata != null && listdata != "") {
                            $(eval(listdata)).each(function (i) {
                                valueStr += "<td>" + i + "</td>"
                                + "<td>" + this["ProductName"] + "</td>"
                                + "<td>" + this["Count"] + "</td>"
                                + "<td>" + this["Charge"] + "</td>"
                            });
                            alert(valueStr);
                        }
                        $("#orderDetails").html(valueStr);
                    } else {
                        showerrortip("错误：无数据");
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    showerrortip("错误:" + errorThrown);
                }
            });
        }
    }

    function savedata() {
        //绑定数据后要获取当前下拉框所选的值：
        var title = $("#txt_title").val();
        var Content = editor.html();
        if (title == null || title == "") {
            showerrortip("标题不能为空！");
            return;
        }
        if (Content == null || Content == "") {
            showerrortip("内容不能为空！");
            return;
        }
        if (title.length > 36) {
            showerrortip("标题长度超出范围,最大长度为36字符");
            return;
        }
        $.ajax({
            beforeSend: function () {
                //3.让提交按钮失效，以实现防止按钮重复点击 
                // $("#submitbtn").attr('disabled', 'disabled');
                //4.给用户提供友好状态提示 
                $("#submitbtn").hide();
                $("#reback").hide();
      
            },

            type: "Post",
            data: {
                "NewsCode": NewsCode,
                "Title": title,
                "Content": encodeURI(Content),
            },
            url: "Aggrement.ashx?type=InsertAggrement",
            dataType: "text",
            success: function (result) {
                if (result == "true") {
                    showoktip("提交成功");
                } else {
                    showerrortip("提交失败,内容包含特殊字符");
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                showerrortip("err:" + errorThrown);
            }
        });
    }
    function reback() {
        window.history.go(-1);
    }
   
    
    </script>

</asp:Content>
