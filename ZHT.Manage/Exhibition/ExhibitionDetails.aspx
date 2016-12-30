<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ExhibitionDetails.aspx.cs" Inherits="ZHT.Manage.Exhibition.ExhibitionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    展会详情
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightNav" runat="server">
    <ul>
        <li class="current"><a href="/Exhibition/ExhibitionList.aspx?ExhibitionId=<%=exhibitionId %>">展会详情</a></li>
        <li><a href="/Exhibition/SellerList.aspx?ExhibitionId=<%=exhibitionId %>">展商管理</a></li>
        <li><a href="/Exhibition/BaseTypeManage.aspx?ExhibitionId=<%=exhibitionId %>">分类管理</a></li>
        <li><a href="/Exhibition/ProductList.aspx?ExhibitionId=<%=exhibitionId %>">展品管理</a></li>
        <li><a href="/Exhibition/EnrollList.aspx?ExhibitionId=<%=exhibitionId %>">报名管理</a></li>
        <li><a href="/Exhibition/MomentList.aspx?ExhibitionId=<%=exhibitionId %>">动态管理</a></li>
        <li><a href="/Exhibition/OrderList.aspx?ExhibitionId=<%=exhibitionId %>">订单管理</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SearchBar1" runat="server">
    <table style="width: 100%">
        <tbody>
            <tr>
                <td>
                    <img id="exhibitionLogo"  height="120" width="150" style="float: left" />
                    <span>
                        <p id="Name"></p>
                        <p id="TimeRange"></p>
                        <p id="Address"></p>
                        <p id="Seller"></p>
                        <p id="Moment"></p>
                        <p id="SalesDiscount"></p>
                    </span>
                </td>
            </tr>
            <tr>
                <td>展会详情
                    <hr />
                    <p id="intro"></p>
                    <p id="introImg">
                    </p>
                </td>
            </tr>
            <tr>
                <td>展位详情
                <hr />
                    展位分布图：<img id="seatMap" height="60" width="60" />
                </td>
            </tr>
            <tr>
                <td id="seatInfos">                    
                </td>
            </tr>
            <tr>
                <td id="ticketIntro">
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="SearchBar2" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="TopGroup" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Content" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ExtScript" runat="server">

    <script type="text/javascript">
        var ExhibitionId = '<%=exhibitionId %>';

        $(function () {

            getAggrementInfo();
        });
        function getAggrementInfo() {

            if (ExhibitionId != "-1") {
                $.ajax({
                    type: "Post",
                    url: "Exhibition.ashx?type=getEInfo",
                    data: { "ExhibitionId": ExhibitionId },
                    dataType: "json",
                    success: function (result) {
                        if (result != null) {
                            $("#Name").html("展会名称: " + result.Name);
                            $("#TimeRange").html("时间: " + result.TimeRange);
                            $("#Address").html("地点: " + result.Address);
                            $("#Seller").html("参展商家：" + result.SellerCount + "      " + "报名人数：" + result.UserCount);
                            $("#Moment").html("动态数：" + result.MomentCount + "      " + "收藏数：" + result.FollowCount);
                            $("#SalesDiscount").html("展品最低折扣：" + result.LowDiscount + "      " + "销售分成比例" + result.SaleProportion);
                            $("#intro").html(result.ExhibitionIntro);
                            $("#exhibitionLogo").attr("src", result.HeadImg);                            
                            //详情图片
                            var introImgStr = '';
                            $(eval(result.IntroImgs)).each(function (i) {
                                introImgStr += '<img src="' + this["ImgUr"] + '" height="50" width="50" />';
                            });
                            $("#introImg").html(introImgStr);
                            //展位设置
                            $("#seatMap").attr("src", result.SeatSetImg);
                            var seatInfroStr = '';
                            $(eval(result.SeatSets)).each(function (i) {
                                seatInfroStr += '<p style="clear: both">' + this["SeatName"] + '   ' + this["SeatPrice"] + '￥/个</p>';
                                $(eval(this["SeatNos"])).each(function (j) {
                                    seatInfroStr += '<span style="border-style: solid">' + this["SeatNoName"] + '</span>';
                                });
                            });
                            $('#seatInfos').html(seatInfroStr);
                            //门票详情
                            var ticketIntroStr = '门票详情 <hr />';
                            $(eval(result.TicketIntros)).each(function (i) {
                                ticketIntroStr += '<span style="border-style: solid; width: 25%">'
                                               + '<p>' + this["TicktePrice"] + '|' + this["TicketTypeName"] + '</p>'
                                               + this["TicketPrivilege"] + '</span>';
                            });
                            $("#ticketIntro").html(ticketIntroStr);
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
