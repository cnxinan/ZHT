<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="ZHT.Manage.Exhibition.ProductDetails" %>

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
        <li class="current"><a href="/Exhibition/ProductList.aspx?ExhibitionId=<%=exhibitionId %>">展品管理</a></li>
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
    <table border="0" align="left" cellpadding="0" cellspacing="0" ><!--class="content_info"-->
        <tr>
            <td align="left" width="100" height="50" valign="middle">
                <input type="button" value="返回" />
            </td>
        </tr>
        <tr>
            <td align="left" width="100" height="50" valign="middle">
                商品图片：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <img id="HeadImg" />
            </td>
        </tr>        
        <tr>
            <td align="left" valign="top">
                商品名称：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="ProductName"></span>
            </td>
        </tr> 
        <tr>
            <td align="left" valign="top">
                单位：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="Unit"></span>                
            </td>
        </tr> 
        <tr>
            <td align="left" valign="top">
                分类：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="ProductClass"></span>                                
            </td>
        </tr>           
        <tr>
            <td align="left" valign="top">
                现价：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="NPrice"></span>
            </td>
        </tr>  
        <tr>
            <td align="left" valign="top">
                原价：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="OPrice"></span>
            </td>
        </tr> 
         <tr>
            <td align="left" valign="top">
                数量：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="Count"></span>
            </td>
        </tr> 
        <tr>
            <td align="left" valign="top">
                商品详情：&nbsp;&nbsp;&nbsp; 
            </td>
            <td>
                <span id="ProductIntro"></span>
            </td>
        </tr>         
    </table>
    </form>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ExtScript" runat="server">

<script type="text/javascript">
    var ExhibitionId = '<%=exhibitionId %>';
    var ExhibitionProductId = '<%=exhibitionProductId %>';

    $(function () {
        getInfo();
    });
    function getInfo() {
        if (ExhibitionProductId != "-1") {
            $.ajax({
                type: "Post",
                url: "Product.ashx?type=getInfo",
                data: { "ExhibitionProductId": ExhibitionProductId },
                dataType: "json",
                success: function (result) {
                    if (result != null) {
                        $("#HeadImg").attr('src', result.HeadImg);
                        $("#ProductName").html(result.ProductName);
                        $("#Unit").html(result.Unit);
                        $("#ProductClass").html(result.ProductClass);
                        $("#NPrice").html(result.NPrice);
                        $("#OPrice").html(result.OPrice);
                        $("#Count").html(result.Count);
                        $("#ProductIntro").html(result.ProductIntro);
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
