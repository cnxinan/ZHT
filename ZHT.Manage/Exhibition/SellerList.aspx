<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SellerList.aspx.cs" Inherits="ZHT.Manage.Exhibition.SellerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
    <script src="../Javascript/Common/DateTime.js" type="text/javascript"></script>
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

    <div class="block">
        <label for="Title">
            关键字：</label>
        <input id="Title" type="text" />
    </div>

    <label for="Title">
            状态：</label>
    <div class="list_select" id="ddlStatus" style="width: 190px;">
        <input type="hidden" id="ddlStatus_value" value="" />
        <input type="hidden" id="ddlStatus_text" />
        <p class="show">--</p>
        <ul class="list" id="ddlStatus_list" style="width: 190px;">
            <li val="">--</li>
            <li val="0">未确认</li>
            <li val="1">已确认</li>
            <li val="2">已拒绝</li>
        </ul>
    </div>

    <div class="search nomore">
        <input type="button" id="btnSearch" /></div>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="TopGroup" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Content" runat="server">

    <div class="editbar">
        <ul class="iconitem editbaricon clearfix">
            <li id="Li2" style="background: url(../images/Export.png) no-repeat;" onclick="Export()">
                <div class="tip">
                    <div class="tip_title">
                        导出
                    </div>
                    <div class="tip_icon">
                    </div>
                </div>
            </li>
            <li id="test3" style="background: url(../images/searchmore-up.png) no-repeat;" onclick="ModifyStatus(1)">
                <div class="tip">
                    <div class="tip_title">
                        接受参展
                    </div>
                    <div class="tip_icon">
                    </div>
                </div>
            </li>
            <li id="test1" style="background: url(../images/searchmore-down.png) no-repeat;" onclick="ModifyStatus(2)">
                <div class="tip">
                    <div class="tip_title">
                        拒绝参展
                    </div>
                    <div class="tip_icon">
                    </div>
                </div>
            </li>
            <li id="test4" style="background: url(../images/edit3.png) no-repeat;" onclick="delAggrement()">
                <div class="tip">
                    <div class="tip_title">
                        删除
                    </div>
                    <div class="tip_icon">
                    </div>
                </div>
            </li>

            <li id="Li1" style="width: 140px;display:none">
                <input type="checkbox" value="" id="showOnlyApproval" checked="checked" />
                只显示有效成员</li>

        </ul>
    </div>
    <div class="datalist">
    </div>
    <div class="page clearfix">
        <input type="button" class="input_button" value="跳转" id="btnNum" style="cursor: pointer" />
        <input type="text" class="input_text" id="numText" />
        <img src="../images/arrow-left.png" alt="" id="btnPre" style="cursor: pointer" />
        <img src="../images/arrow-right.png" alt="" id="btnNext" style="cursor: pointer" />
        <span id="spanPage"></span>
    </div>
    <form id="export" method="post" action="Seller.ashx">
        <input type="hidden" name="type" value="export" />
        <input type="hidden" name="ids" id="ids" />
    </form>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ExtScript" runat="server">
    <script type="text/javascript">
        var pagesize = 10;
        var pageindex = 1;
        var pagecount = 0;

        $(function () {

            //分页
            PageMethod();
            $("#btnPre").click(function () {
                pageindex = parseInt(pageindex) - 1;
                PageMethod();
            });
            $("#btnNext").click(function () {
                pageindex = parseInt(pageindex) + 1;
                PageMethod();
            });
            $("#btnSearch").click(function () {
                pageindex = 1;
                PageMethod();
            });
            $("#btnNum").click(function () {
                var newpageindex = $("#numText").val();
                if (newpageindex <= 0) {
                    pageindex = 1;
                } else if (newpageindex > pagecount) {
                    pageindex = pagecount;
                }
                else {
                    pageindex = newpageindex;
                }
                PageMethod();
            });
            $("#numText").blur(toFixedNumber);
            function toFixedNumber() {
                var value = $(this).val();
                if (value != "") {
                    if (Number(value).toFixed(0) == "NaN") { $(this).val("0"); }
                    else { $(this).val(Number(value).toFixed(0)); }
                }
            }

            //点击搜索
            //$("#btnSearch").click(function () {

            //    PageMethod();
            //})


        });

        //切割字符串
        function cutStr(content) {

            content = content.replace(/(\n)/g, "");
            content = content.replace(/(\t)/g, "");
            content = content.replace(/(\r)/g, "");
            content = content.replace(/<\/?[^>]*>/g, "");
            content = content.replace(/\s*/g, "");
            var len = content.length;
            if (len > 20) {
                return content.substring(0, 20) + "...";
            }
            return content;
        }

        function PageMethod() {
            $(".sellerlist").html("");
            var ValidStatus = $("#showOnlyApproval").is(':checked');
            var Title = $("#Title").val();
            var Content = $("#Content").val();
            var ExhibitionId = '<%=exhibitionId %>';
            var Status = $('#ddlStatus_value').val();
            $.ajax({
                type: "Post",
                url: "Seller.ashx?type=GetList",
                data: {
                    "ExhibitionId":ExhibitionId,
                    "ValidStatus": ValidStatus,
                    "PageSize": pagesize,
                    "PageIndex": pageindex,
                    "Title": Title,
                    "Status": Status,
                },
                dataType: "json",
                success: GetProtocolRruleInfo,
                error: function (err) {
                    showerrortip(err);
                }
            });
            function GetProtocolRruleInfo(result) {

                var valueStr = "<table>";
                valueStr += "<thead><tr><th><div class='checkbox chk_all' onclick='checkAll(this);'>";
                valueStr += "<input type='checkbox' id='chk_all'/><label for='chk_all'></label></div>";
                valueStr += "<th>展商名称</th><th>展位信息</th><th>姓名</th><th>手机号</th><th>状态</th><th>操作</th>";
                valueStr += "</tr></thead><tbody id='data'>";
                var listdata = result.ListData;
                if (listdata != null && listdata != "") {
                    $(eval(listdata)).each(function (i) {

                        valueStr += "</tr>"
                             + "<td><div class='checkbox' value='" + this['Code'] + "' onclick='check(this);'><input type='checkbox' id='" + this['SellerOrderId'] + "' name='items' /></div></td>"
                             + "<td>" + this['SellerName'] + "&nbsp;</td>"
                             + "<td>" + this['SeatInfo'] + "&nbsp;</td>"
                             + "<td>" + this['SName'] + "&nbsp;</td>"
                             + "<td>" + this['SPhone'] + "&nbsp;</td>"
                             + "<td>" + this['Status'] + "&nbsp;</td>"
                             + "<td><a href='/Exhibition/SellerDetails.aspx?ExhibitionId=" + ExhibitionId + "&SellerOrderId=" + this['SellerOrderId'] + "' target='_self'>" + "查看" + "</a>&nbsp;</td>"
                             + "</tr>";

                    });
                }
                valueStr += "</tbody></table>"
                $(".datalist").html(valueStr);
                pagecount = result.PageCount;
                if (pagecount == 0) pagecount = 1;
                ShowPageButton(pageindex, pagecount);
            }
        }
        function showdetail() {
            var chkdata = GetChecked();
            var CommissionCodearr = "";
            if (chkdata.count != 1) {
                showerrortip("请只选中一个要查看的数据！");
                return;
            }
            var NewsCode = chkdata.value;
            window.location = "AggrementEdit.aspx?i=11&NewsCode=" + NewsCode;
        }

        function Export() {
            var chkdata = GetChecked();
            
            if (chkdata.count == 0) {
                showerrortip("请至少选中一个要导出的数据！");
                return;
            }
            
            if (confirm("确认导出吗？")) {
                $('#ids').val(chkdata.value);
                $('#export').submit();
            }
        }

        function ModifyStatus(statusType) {

            var chkdata = GetChecked();
            
            if (chkdata.count != 1) {
                showerrortip("请只选中一个要更改状态的数据！");
                return;
            }
            var ids = chkdata.value;

            $.ajax({
                type: "Post",
                url: "Seller.ashx?type=ModifyStatus",
                data: {
                    "statusType": statusType,
                    "ids": ids
                },
                dataType: "json",
                success: function (req) {
                    showerrortip(req.msg);
                    PageMethod();
                }
            });

        }

        function delAggrement() {

            var chkdata = GetChecked();
            if (chkdata.count != 1) {
                showerrortip("请只选中一个要删除的数据！");
                return;
            }
            var ids = chkdata.value;

            if (confirm("确认删除吗？")) {
                $.ajax({
                    type: "Post",
                    url: "Seller.ashx?type=delInfo",
                    data: {
                        "ids": ids
                    },
                    dataType: "json",
                    success: function (req) {
                        showerrortip(req.msg);
                        PageMethod();
                    }
                });
            }

        }

        function addAggrement() {
            window.location = "AggrementEdit.aspx";
        }
        $("#showOnlyApproval").change(function () {
            pageindex = 1;
            PageMethod();
        });
    </script>
</asp:Content>
