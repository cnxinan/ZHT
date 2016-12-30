<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ExhibitionList.aspx.cs" Inherits="ZHT.Manage.Exhibition.ExhibitionList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Head" runat="server">
    <link rel ="Stylesheet" type="text/css" href="../Style/exhibition.css" />
    <script src="../Javascript/Common/DateTime.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightNav" runat="server">
    <ul>
        <li class="<%=current1 %>"><a href="ExhibitionList.aspx?type=0">进行中</a></li>
        <li class="<%=current2 %>"><a href="ExhibitionList.aspx?type=1">已结束</a></li>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SearchBar1" runat="server">

    <div class="block">
        <label for="Title">
            关键字：</label>
        <input id="Title" type="text" value="<%=Title %>" />
    </div>    

    <div class="search nomore">
        <input type="button" id="btnSearch" /></div>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="TopGroup" runat="server" >    
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="Content" runat="server">

    <div class="editbar">
        <ul class="iconitem editbaricon clearfix">
            <li id="Li1" style="width: 140px;display:none">
                <input type="checkbox" value="" id="showOnlyApproval" checked="checked" />
                只显示有效成员</li>

        </ul>
    </div>
    <div class="datalist zhanhui_gl">
    </div>
    <div class="page clearfix">
        <input type="button" class="input_button" value="跳转" id="btnNum" style="cursor: pointer" />
        <input type="text" class="input_text" id="numText" />
        <img src="../images/arrow-left.png" alt="" id="btnPre" style="cursor: pointer" />
        <img src="../images/arrow-right.png" alt="" id="btnNext" style="cursor: pointer" />
        <span id="spanPage"></span>
    </div>

</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ExtScript" runat="server">
    <script type="text/javascript">
        var pagesize = 10;
        var pageindex = 1;
        var pagecount = 0;
        var exhibitionType = <%=exhibitionType %>

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
            $.ajax({
                type: "Post",
                url: "Exhibition.ashx?type=GetList",
                data: {
                    "ExhibitionType":exhibitionType,
                    "ValidStatus": ValidStatus,
                    "PageSize": pagesize,
                    "PageIndex": pageindex,
                    "Title": Title,
                },
                dataType: "json",
                success: GetProtocolRruleInfo,
                error: function (err) {
                    showerrortip(err);
                }
            });
            function GetProtocolRruleInfo(result) {

                var valueStr = "<table>";
                valueStr += "<tbody id='data'>";
                var listdata = result.ListData;
                if (listdata != null && listdata != "") {

                    $(eval(listdata)).each(function (i) {
                        valueStr += "</tr>"
                             + "<td><img src='" + this['HeadImg'] + "' /></td>"
                             + "<td><dl>"
                             + "<dt>" + this["ExhibitionName"] + "</dt>"
                             + "<dd>时间:" + this["TimeRange"] + "</dd>"
                             + "<dd>地点:" + this["Address"] + "</dd>"
                             + "</dl></td>"
                             + "<td>"
                             + "<div>参展商家 <span class='m-l-10'><label>" + this["SellerNumber"] + "</label>家</span></div>"
                             + "<div>报名用户 <span class='m-l-10'><label>" + this["EnrollNumber"] + "</label>人</span></div>"
                             + "<div><span>动态" + this["MomentCount"] + "个</span>  <span class='m-l-10'>收藏" + this["FollowCount"] + "</span></div>"
                             + "</td>"
                             + "<td class='text-center'><div>" + this["Status"] + "</div><div>" + this["PublishDate"] + "</div></td>"
                             + "<td><button onclick='ToDetails(\"" + this["ExhibitionCode"] + "\")'>管理</button></td>"
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

        function ModifyStatus() {

            var chkdata = GetChecked();
            if (chkdata.count != 1) {
                showerrortip("请只选中一个要更改状态的数据！");
                return;
            }
            var NewsCode = chkdata.value;

            $.ajax({
                type: "Post",
                url: "Aggrement.ashx?type=ModifyStatus",
                data: {
                    "NewsCode": NewsCode
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
            var NewsCode = chkdata.value;

            if (confirm("确认删除吗？")) {
                $.ajax({
                    type: "Post",
                    url: "Aggrement.ashx?type=delAggrement",
                    data: {
                        "NewsCode": NewsCode
                    },
                    dataType: "json",
                    success: function (req) {

                        showerrortip(req.msg);
                        PageMethod();
                    }
                });
            }

        }

        function ToDetails(id) {
            window.location = "/Exhibition/ExhibitionDetails.aspx?ExhibitionId=" + id;
        }
        $("#showOnlyApproval").change(function () {
            pageindex = 1;
            PageMethod();
        });
    </script>
</asp:Content>
