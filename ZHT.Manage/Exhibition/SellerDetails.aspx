<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SellerDetails.aspx.cs" Inherits="ZHT.Manage.Exhibition.SellerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
  展商详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightNav" runat="server">
    <ul>
        <li><a href="/Exhibition/ExhibitionList.aspx?ExhibitionId=<%=exhibitionId %>">展会详情</a></li>
        <li class="current"><a href="/Exhibition/SellerList.aspx?ExhibitionId=<%=exhibitionId %>">展商管理</a></li>
        <li><a href="/Exhibition/BaseTypeManage.aspx?ExhibitionId=<%=exhibitionId %>">分类管理</a></li>
        <li><a href="/Exhibition/ProductList.aspx?ExhibitionId=<%=exhibitionId %>">展品管理</a></li>
        <li><a href="/Exhibition/EnrollList.aspx?ExhibitionId=<%=exhibitionId %>">报名管理</a></li>
        <li><a href="/Exhibition/MomentList.aspx?ExhibitionId=<%=exhibitionId %>">动态管理</a></li>
        <li><a href="/Exhibition/OrderList.aspx?ExhibitionId=<%=exhibitionId %>">订单管理</a></li>
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
    <table border="0" align="left" cellpadding="0" cellspacing="0"><!--class="content_info"-->
        <tr>
            <td align="left" width="100" height="50" valign="middle">
                <input type="button" value="返回" />
            </td>
        </tr>
        <tr>
            <td align="left" width="100" height="50" valign="middle">
                商家logo：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <img id="HeadImg" />
            </td>
        </tr>        
        <tr>
            <td align="left" valign="top">
                商家名称：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="SellerName"></span>
            </td>
        </tr> 
        <tr>
            <td align="left" valign="top">
                商家地址：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="Address"></span>
            </td>
        </tr> 
        <tr>
            <td align="left" valign="top">
                联系人：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="SName"></span>
            </td>
        </tr>           
        <tr>
            <td align="left" valign="top">
                手机号：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="SPhone"></span>
            </td>
        </tr>  
        <tr>
            <td align="left" valign="top">
                经营范围：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="BusinessScope"></span>
            </td>
        </tr> 
         <tr>
            <td align="left" valign="top">
                商家介绍：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="SellerIntro"></span>
            </td>
        </tr> 
        <tr>
            <td align="left" valign="top">
                营业执照：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <img id="BusinessImg" />
            </td>
        </tr> 
        <tr>
            <td align="left" valign="top">
                预定展位：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="SeatInfo"></span>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top">
                支付金额：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="TotalPrice"></span>
            </td>
        </tr>
        <tr>
            <td height="50">
            </td>
            <%--<td align="left">
                <a class="surebtn" id="submitbtn" onclick="savedata()">接受参展</a> 
                
                <a class="surebtn"
                    id="reback" style="margin-left: 20px;" onclick="reback()">拒绝参展</a> 
       
            </td>--%>
        </tr>
    </table>
    </form>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ExtScript" runat="server">

<script type="text/javascript">
    var ExhibitionId = '<%=exhibitionId %>';
    var SellerOrderId = '<%=sellerOrderId %>';

    $(function () {
        getInfo();
    });
    function getInfo() {
        if (ExhibitionId != "-1" && SellerOrderId != "-1") {
            $.ajax({
                type: "Post",
                url: "Seller.ashx?type=getInfo",
                data: { "ExhibitionId": ExhibitionId, "SellerOrderId": SellerOrderId },
                dataType: "json",
                success: function (result) {
                    if (result != null) {
                        $("#SellerName").html(result.SellerName);
                        $("#Address").html(result.Address);
                        $("#SName").html(result.SName);
                        $("#SPhone").html(result.SPhone);
                        $("#BusinessScope").html(result.BusinessScope);
                        $("#SellerIntro").html(result.SellerInfo);
                        $("#BusinessImg").html(result.BusinessImg);
                        $("#SeatInfo").html(result.SeatInfo);
                        $("#TotalPrice").html(result.TotalPrice);
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
    
    function reback() {
        window.history.go(-1);
    }   
    
    </script>

</asp:Content>
