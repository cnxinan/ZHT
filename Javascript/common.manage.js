/***************************************
后台页面js文件
本文件由v-wangdongd维护
***************************************/

function showerrortip(msg) {
    if ($(".jstiperror").length > 0) {
        $(".jstiperror").remove();
    }
    var id = "jstip_" + (+(new Date));
    $('<div class="jstiperror" id="' + id + '">' + msg + '</div>').appendTo("body").fadeIn().delay(1500).fadeOut();
    $("#" + id).css("left", $("body").width() / 2 - ($("#" + id).width() + 60) / 2);
    setTimeout('$("#' + id + '").remove()', 2000);
}

function showoktip(msg) {
    if ($(".jstipok").length > 0) {
        $(".jstipok").remove();
    }
    var id = "jstip_" + (+(new Date));
    $('<div class="jstipok" id="' + id + '">' + msg + '</div>').appendTo("body").fadeIn().delay(1500).fadeOut();
    $("#" + id).css("left", $("body").width() / 2 - ($("#" + id).width() + 60) / 2);
    setTimeout('$("#' + id + '").remove()', 2000);
}

function ClearCheckAll() {
    $(".chk_all").removeClass("checkbox_checked");
    $(".chk_all").attr("checked", false);
}

function BindPageData(BindData) {
    BindData();
    $("#btnPre").click(function () {
        if (pageindex > 1) {
            pageindex = parseInt(pageindex) - 1;
        } else {
            pageindex = 1;
        }
        BindData();
        ClearCheckAll();
    });
    $("#btnNext").click(function () {
        if (pageindex < pagecount) {
            pageindex = parseInt(pageindex) + 1;
        } else {
            pageindex = pagecount;
        }
       
        BindData();
        ClearCheckAll();
    });
    $("#btnSearch").click(function () {
        pageindex = 1;
        BindData();
        ClearCheckAll();
    });
    $("#btnNum").click(function () {
        var newpageindex = $("#numText").val();
        if (newpageindex > 0 && newpageindex <= pagecount) {
            pageindex = newpageindex;
            BindData();
            ClearCheckAll();
        }
        else if (newpageindex <= 0) {
            showerrortip("页数不能小于1");
        }
        else if (newpageindex > pagecount) {
            showerrortip("页数超出总页数");
        }
    });
}

function ShowPageButton(pageindex, pagecount) {
    if (pagecount == 0) {
        $(".page").hide();
    }
    else {
        $(".page").show();
        $("#numText").val(pageindex);
        $("#spanPage").html(pageindex + "/" + pagecount);

        if (pageindex > 1) {
            $("#btnPre").show();
        }
        else {
            $("#btnPre").hide();
        }
        if (pageindex < pagecount) {
            $("#btnNext").show();
        }
        else if (pageindex >= pagecount) { /* 20150119更改了(pageindex == pagecount) */
            $("#btnNext").hide();
        }
    }
}

function GetChecked() {
    var len = 0;
    var selvalue = "";
    $(".content_main input[name=items]").each(function () {
        if ($(this).attr("checked")) {
            selvalue += "," + $(this).attr("id");
            len++;
        }
    });
    if (selvalue != "") {
        selvalue = selvalue.substring(1, selvalue.length);
    }

    return { "count": len, "value": selvalue };
}

function GetMoneyValue(moneyStr) {
   return parseInt(moneyStr / 100) == (moneyStr / 100) ? (moneyStr / 100) + ".00" : (moneyStr / 100);
}

/*更多条件展开*/
$("#btn_more").bind("click", function () {
    $("#block_more").slideToggle(1000);
    $("#btn_more").toggleClass("searchmore_up");
});

$(document).click(function (e) {
    if (e != null) {
        if ($(".list_select").length > 0) {
            if ($(e.target).parent().attr("class") != "list_select" && $(e.target).parent().parent().attr("class") != "list_select") {
                $(".list_select ul").hide();
            }
        }
        if ($(".list_selectGroup").length > 0) {
            if ($(e.target).parent().attr("class") != "list_selectGroup" && $(e.target).parent().parent().attr("class") != "list_selectGroup") {
                $(".list_selectGroup ul").hide();
            }
        }
        if ($(".list_select_chk").length > 0) {
            if ($(e.target).parent().attr("class") != "list_select_chk" && $(e.target).parent().parent().attr("class") != "list_select_chk" && $(e.target).parent().parent().parent().parent().attr("class") != "list_select_chk") {
                $(".list_select_chk ul").hide();
            }
        }
    }
});
//自动绑定下拉框
function showlist(obj) {
    if ($(obj).parent().attr("disable") != "false") {
        var top = parseInt($(obj).offset().top) + 30;
        var left = parseInt($(obj).offset().left);
        var pos = $(obj).parent().css("position");
        var $list = $(obj).parent().find(".list");
        var datatype = $list.attr("data-type");
        if (datatype == "seller") {
            //                $list.css("top", "30px");
            //                $list.css("left", "-1px");
        }
        //            if (pos == "relative") {
        //                $list.css("top", "30px");
        //                $list.css("left", "-1px");
        //            }
        else {
            $list.css("top", top + "px");
            $list.css("left", left + "px");
        }
        $(".list_select .list").slideUp();
        var ul = $(obj).parent().children(".list");
        if (ul.css("display") == "none" && ul.children("li").length > 0) {
            ul.slideDown();
        } else {
            ul.slideUp();
        }
    }
}

$(function () {

    $("body").delegate(".list_select .show", "click", function () {
        showlist(this);
    });
    $("body").delegate(".list_select_chk .show", "click", function () {
        showlist(this);
    });

    $("body").delegate(".list_select .list li", "click", function () {
        var $this = $(this);
        var id = $this.parent().parent().attr("id");
        var selected = $this.parent().children(".selected");
        if (selected) {
            selected.removeClass("selected");
        }
        $this.addClass("selected");
        var txt = $this.text();

        var $input = $this.parent().parent().children(".show").find("input");
        var ival = $input.val();
        if (ival == null) {
            $this.parent().parent().children(".show").html(txt);
        }
        else {
            $input.val(txt);
        }
        $this.parent().parent().children(".list").hide(txt);
        var value = $this.attr("val");
        $("#" + id + "_value").val(value);
        $("#" + id + "_text").val(txt);
        $this.parent().attr("val", value);
    });

    $("body").delegate(".list_select_chk .list li", "click", function () {
        var $this = $(this);
        var c = $this.attr("class");
        if (c == "last") {
            $this.parent().parent().children(".list").hide();
        }
        else {
            var id = $this.parent().parent().attr("id");
            //alert(id);

            var text = "", value = "";
            $("#" + id + " li").each(function () {
                var chk = $(this).find("input:checkbox");
                if (chk.attr("checked") == "checked") {
                    //alert(chk.attr("id"));
                    if (text != "") {
                        text += ",";
                    }
                    if (value != "") {
                        value += ",";
                    }
                    text += $(this).find("b").html();
                    value += $(this).attr("val");
                }
            });

            //var txt = $this.text();
            $this.parent().parent().children(".show").html(text);
            //$this.parent().parent().children(".list").hide(txt);
            //var value = $this.attr("val");
            $("#" + id + "_value").val(value);
            $("#" + id + "_text").val(text);
            $this.parent().attr("val", value);
        }
    });
});

/*手动绑定下拉框的回调事件 paramDic为json*/
function BindSelectCallback(id, callBack, paramDic) {
    var c = $("#" + id).attr("class");
    if (c == "list_select_chk") {
        $("body").delegate("#" + id + " li:last", "click", function () {
            var value = $("#" + id).find("#" + id + "_value").val();
            callBack(value, paramDic);
        });
    }
    else {
        $("body").delegate("#" + id + " li", "click", function () {
            callBack($(this).attr("val"), paramDic);
        });
    }
}

/*小弹框*/
function ShowPopup(objid) {
    var divid = objid + "_data";
    var $popup = $("#" + divid);
    var $obj = $("#" + objid);
    var offset = $obj.offset();
    var yOffset = offset.top, xOffset = offset.left;
    xOffset = xOffset - ($popup.width()) / 2 + $obj.width() / 2;
    yOffset = yOffset + $obj.height() + 12;
    $popup.css({ top: yOffset, left: xOffset });

    $("#" + objid + "_ext").html('<div class="icon"></div><div class="popbar"><a href="javascript:void(0)" class="sure">确定</a><a href="javascript:void(0)" class="cancel">取消</a></div><script type="text/javascript">' + $("#" + objid + "_js").html() + '</script>');

    $popup.css("display", "block");

    $("#" + divid + " .cancel").click(function () { $("#" + divid).hide(); });

}

function CreateLayer(newbox, backcolor) {
    var isIE = (document.all) ? true : false;
    var isIE6 = isIE;
    //var isIE6 = isIE && ([/MSIE (\d)\.0/i.exec(navigator.userAgent)][0][1] == 6);
    var layer = document.createElement("div");
    layer.id = "layer";
    var sel = document.getElementsByTagName("select");
    if ($("#layer").length == 0) {
        layer.style.width = layer.style.height = "100%";
        layer.style.position = !isIE6 ? "fixed" : "absolute";
        layer.style.top = layer.style.left = 0;
        if (backcolor != "") {
            layer.style.backgroundColor = backcolor;
        }
        layer.style.zIndex = "9997";
        layer.style.opacity = "0.6";
        document.body.appendChild(layer);
        for (var i = 0; i < sel.length; i++) {
            sel[i].style.visibility = "hidden";
        }
        function layer_iestyle() {
            layer.style.width = Math.max(document.documentElement.scrollWidth, document.documentElement.clientWidth)
    + "px";
            layer.style.height = Math.max(document.documentElement.scrollHeight, document.documentElement.clientHeight) +
    "px";
        }
        function newbox_iestyle() {
            //newbox.style.marginTop = document.documentElement.scrollTop - newbox.offsetHeight / 2 + "px";
            //newbox.style.marginLeft = document.documentElement.scrollLeft - newbox.offsetWidth / 2 + "px";
        }
        if (isIE) {
            layer.style.filter = "alpha(opacity=60)";
        }
        if (isIE6) {
            layer_iestyle()
            newbox_iestyle();
            window.attachEvent("onscroll", function () {
                newbox_iestyle();
            })
            window.attachEvent("onresize", layer_iestyle)
        }

    }

    layer.onclick = function () {
        newbox.style.display = "none";
        //newbox.css("display", "none");
        $("#layer").remove();
        for (var i = 0; i < sel.length; i++) {
            sel[i].style.visibility = "visible";
        }
    }
}

function CreateLayer2(newbox) {
    var isIE = (document.all) ? true : false;
    var isIE6 = isIE;
    //var isIE6 = isIE && ([/MSIE (\d)\.0/i.exec(navigator.userAgent)][0][1] == 6);
    newbox.style.zIndex = "9998";
    newbox.style.display = "block"
    newbox.style.position = !isIE6 ? "fixed" : "absolute";
    newbox.style.top = newbox.style.left = "50%";
    newbox.style.marginTop = -newbox.offsetHeight / 2 + "px";
    //newbox.style.marginLeft = -newbox.offsetWidth / 2 + "px";

    var layer = document.createElement("div");
    layer.id = "layer";
    newbox.style.marginLeft = -$(newbox).width() / 2 + "px";
    var sel = document.getElementsByTagName("select");
    if ($("#layer").length == 0) {
        layer.style.width = layer.style.height = "100%";
        layer.style.position = !isIE6 ? "fixed" : "absolute";
        layer.style.top = layer.style.left = 0;
        layer.style.backgroundColor = "#000";
        layer.style.zIndex = "9997";
        layer.style.opacity = "0.6";
        document.body.appendChild(layer);
        for (var i = 0; i < sel.length; i++) {
            sel[i].style.visibility = "hidden";
        }
        function layer_iestyle() {
            layer.style.width = Math.max(document.documentElement.scrollWidth, document.documentElement.clientWidth)
    + "px";
            layer.style.height = Math.max(document.documentElement.scrollHeight, document.documentElement.clientHeight) +
    "px";
        }
        function newbox_iestyle() {
            newbox.style.marginTop = document.documentElement.scrollTop - newbox.offsetHeight / 2 + "px";
            newbox.style.marginLeft = document.documentElement.scrollLeft - newbox.offsetWidth / 2 + "px";
        }
        if (isIE) {
            layer.style.filter = "alpha(opacity=60)";
        }
        if (isIE6) {
            layer_iestyle()
            newbox_iestyle();
            window.attachEvent("onscroll", function () {
                newbox_iestyle();
            })
            window.attachEvent("onresize", layer_iestyle)
        }
    }
    $("#layer").css("display", "block");
    $("#layer").css("background-color", "#000");

    layer.onclick = function () {
        newbox.style.display = "none";
        //newbox.css("display", "none");
        $("#layer").remove();
        for (var i = 0; i < sel.length; i++) {
            sel[i].style.visibility = "visible";
        }
    }
}


/*小弹框 带回调函数*/
function ShowPopupCallBack(objid, popupid, callback) {
    var divid = popupid + "_data";
    var $popup = $("#" + divid);
    var $obj = $("#" + objid);


    var offset = $obj.offset();
    var yOffset = offset.top, xOffset = offset.left;
    xOffset = xOffset - ($popup.width()) / 2 + $obj.width() / 2;
    yOffset = yOffset + $obj.height() + 12;
    $popup.css({ "top": yOffset + "px", "left": xOffset + "px" });

    $("#" + popupid + "_ext").html('<div class="icon"></div><div class="popbar"><a href="javascript:void(0)" class="sure">确定</a><a href="javascript:void(0)" class="cancel">取消</a></div><script type="text/javascript">' + $("#" + popupid + "_js").html() + '</script>');

    $popup.css("display", "block");

    $("#" + divid + " .cancel").click(function () {
        $popup.hide();
        if ($("#layer").css("background-color") != "rgb(0, 0, 0)") {
            $("#layer").remove();
            $("#sellerPopup_data").css("display", "none");
        };
    });
    $("#" + divid + " .sure").click(function () {
        callback();
        $popup.hide();
        if ($("#layer").css("background-color") != "rgb(0, 0, 0)") {
            $("#layer").remove();
            $("#sellerPopup_data").css("display", "none");
        };
    });

    CreateLayer(document.getElementById(divid), "");
}

function DisplayPopup(popid) {
    for (var id in popid) {
        $("#" + popid[id]).bind("click", function () {
            ShowPopup(this.id);
        });
    }
}

/*大弹框*/
function ShowBigPopup(objid) {
    var divid = objid + "_data";
    var $popup = $("#" + divid);
    var newbox = document.getElementById(objid + "_data");

    $("#" + objid + "_ext").html('<center><input class="sure" type="button" value="确定"/><input class="cancel" type="button" value="取消"/></center><script type="text/javascript">' + $("#" + objid + "_js").html() + '</script>');

    $("#" + divid + " .cancel").click(function () {
        newbox.style.display = "none";
        layer.style.display = "none";
    });
    CreateLayer2(newbox);
}

function DisplayBigPopup(popidArray) {
    for (var id in popidArray) {
        $("#" + popidArray[id]).bind("click", function () {
            ShowBigPopup(this.id);
        });
    }
}

/*弹框popup_3*/
function ShowBigPopupCollback(objid) {
    var divid = objid + "_data";
    var $popup = $("#" + divid);
    var newbox = document.getElementById(objid + "_data");

    $("#" + objid + "_ext").html('<center><input class="sure" type="button" value="确定"/><input class="cancel" type="button" value="取消"/></center><script type="text/javascript">' + $("#" + objid + "_js").html() + '</script>');


    $("#" + divid + " .cancel").click(function () {
        newbox.style.display = "none";
        layer.style.display = "none";
        $("#sellerPopup_data").css("display", "none");
        $("#layer").css("background-color", "");
    });

    CreateLayer2(newbox);

}

//加了回调函数的弹窗
function DisplayBigPopupCallback(popupid, callBack, value) {
    ShowBigPopupCollback(popupid);
    callBack(value);
}

$(".iconitem li").mouseover(function () {
    var $divid = $(this).find(".tip");
    var offset = $(this).offset();
    var yOffset = offset.top, xOffset = offset.left;
    xOffset = xOffset - ($divid.width()) / 2 + $(this).width() / 2;
    yOffset = yOffset - $(this).height() - 10;
    $divid.css({ top: yOffset, left: xOffset });

    $(this).find(".tip_icon").css("left", ($divid.width() / 2 - 6) + "px");
    $divid.css("display", "block");
});
$(".iconitem li").mouseout(function () {
    $(this).find(".tip").css("display", "none");
});


function check(obj) {
    if ($(obj).attr('checked') == "checked") {
        $(obj).removeClass("checkbox_checked");
        $(obj).find("input").attr("checked", false);
        $(obj).attr("checked", false);
    } else {
        $(obj).addClass("checkbox_checked");
        $(obj).find("input").attr("checked", true);
        $(obj).attr("checked", "checked");
    }

    var selnum = GetChecked().count;
    var checkboxnum = $(".content_main .checkbox").length - 1;
    if (typeof (pagesize) != "undefined") {
        var num = pagesize;
        if (num > checkboxnum) {
            num = checkboxnum;
        }
        if (selnum < num) {
            $(".chk_all").removeClass("checkbox_checked");
            $(".chk_all").attr("checked", false);
        }
        else {
            $(".chk_all").addClass("checkbox_checked");
            $(".chk_all").attr("checked", true);
        }
    }
}

function checkAll(obj) {
    var objChkBox = $(".content_main .checkbox");
    var objChkInput = $(".checkbox input");
    if ($(obj).attr('checked') == "checked") {
        $(obj).removeClass("checkbox_checked");
        $(obj).find("input").attr("checked", false);
        $(obj).attr("checked", false);
        objChkBox.removeClass("checkbox_checked");
        objChkBox.attr("checked", false);
        objChkInput.attr("checked", false);

    } else {
        $(obj).addClass("checkbox_checked");
        $(obj).find("input").attr("checked", true);
        $(obj).attr("checked", "checked");
        objChkBox.addClass("checkbox_checked");
        objChkBox.attr("checked", "checked");
        objChkInput.attr("checked", true);
    }
}

function clearAll() {
    var objChkBox = $(".content_main .chk_all");
    if ($(objChkBox).attr('checked') == "checked") {
        $(objChkBox).removeClass("checkbox_checked");
        $(objChkBox).find("input").attr("checked", false);
        $(objChkBox).attr("checked", false);
    }
}


//滚动到知道DOM节点
function scrollToLocation(obj) {
    var scroll_offset = obj.offset();  //得到pos这个div层的offset，包含两个值，top和left
    $("body,html").animate({
        scrollTop: scroll_offset.top - 10  //让body的scrollTop等于pos的top，就实现了滚动
    }, 1000);
}


/***************************************
功能：javascript验证表单
调用方法：formvalidate(string);
返回值：布尔
参数格式：
var obj = { "controls": "[{ 'id': 'txtName','info':'名称','required':true,'minlength':6,'maxlength':16},{ 'id': 'txtAge','type': 'int','info':'年龄','required':false},{ 'id': 'txtNum','type': 'decimal','info':'数字','required':true},{ 'id': 'txtEmail','type': 'email','info':'Email','required':true},{ 'id': 'txtMobile','type': 'mobile','info':'手机号','required':true}]" }
参数说明：
id和info必填
id：控件ID
info 控件名称，（用于提示，不需包括“请填写”）
type：int（大于0的正整数），email，mobile（手机号），decimal（小数）
required：是否必填，值为true/false
minlength：最小长度
maxlength：最大长度
***************************************/
function formvalidate(obj) {
    obj = eval(obj.controls);
    var flag = true, typeFlag = true, minLengthFlag = true, maxLengthFlag = true, minLengthValue = 0, maxLengthValue = 0;
    var intreg = /^[1-9]\d*$/;
    //    var decimalreg = new RegExp("^([0-9]+[\.]?[0-9]+|\\d+)$"); //正负/^[+-]?(0|([1-9]\d*))(\.\d+)?$/g;
    var decimalreg = new RegExp("^[0-9]+[\.]?[0-9]{0,2}?$");

    var $id = null;
    for (var i in obj) {
        $id = $("#" + obj[i].id);
        var type = obj[i].type;
        var required = obj[i].required;
        var minlength = obj[i].minlength;
        var maxlength = obj[i].maxlength;

        if (($id.val() == undefined ? "" : $id.val().replace(/[ ]/g, "")) == "" && required == true) {
            flag = false;
            break;
        }


        if (minlength != null) {
            if ($id.val().length < minlength) {
                flag = false;
                minLengthFlag = false;
                minLengthValue = minlength;
                break;
            }
        }

        if (maxlength != null) {
            if ($id.val().length > maxlength) {
                flag = false;
                maxLengthFlag = false;
                maxLengthValue = maxlength;
                break;
            }
        }

        if ($id.val() != "" && type != null) {
            if (type == "int" && !intreg.test($id.val())) {
                typeFlag = false;
                flag = false;
                break;
            }
            else if (type == "email" && !IsMail($id.val())) {
                typeFlag = false;
                flag = false;
                break;
            }
            else if (type == "mobile" && !IsMobile($id.val())) {
                typeFlag = false;
                flag = false;
                break;
            }
            else if (type == "decimal" && !decimalreg.test($id.val())) {
                typeFlag = false;
                flag = false;
                break;
            }
            else {
                flag = true;
                typeFlag = true;
                minLengthFlag = true;
                maxLengthFlag = true;
            }
        }
    }
    if (flag == false) {
        var tip = "请填写" + obj[i].info;
        if (typeFlag == false) {
            tip = "请填写正确的" + obj[i].info;
        }
        else if (minLengthFlag == false) {
            tip = obj[i].info + "长度不能小于" + minLengthValue;
        }
        else if (maxLengthFlag == false) {
            tip = obj[i].info + "长度不能超过" + maxLengthValue;
        }
        showerrortip(tip);
        //scrollToLocation($id);
        $id.focus();
    }
    return flag;
}

function SetMenu(fid, sid) {
    $("#menu" + fid + "_" + sid).addClass("current");
}

/***************************************
功能：禁止页面拖放
添加时间：20150105
添加人：v-liuxch
***************************************/
document.ondragstart = function () {
    return false;
};

$(".editbaricon li").click(function () {
    $(".popup").css("display", "none");
});




/***************************************
功能：i9以下显示默认文本
添加时间：20150311
添加人：v-qichm
***************************************/
$(function () {
    if (!placeholderSupport()) {   // 判断浏览器是否支持 placeholder
        $('[placeholder]').focus(function () {
            var input = $(this);
            if (input.val() == input.attr('placeholder')) {
                input.val('');
                input.removeClass('placeholder');
            }
        }).blur(function () {
            var input = $(this);
            if (input.val() == '' || input.val() == input.attr('placeholder')) {
                input.addClass('placeholder');
                input.val(input.attr('placeholder'));
            }
        }).blur();
    };
})
function placeholderSupport() {
    return 'placeholder' in document.createElement('input');
}


