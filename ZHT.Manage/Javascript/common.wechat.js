/***************************************
功能：手机页面绑定事件名
添加时间：20141229
添加人：v-liuxch
调用方法：$(selector).bind(CLICK_TYPE,function(){ })
***************************************/
//window.CLICK_TYPE = (("ontouchstart" in window) ? "tap" : "click");

/***************************************
功能：手机页面滚动开关
添加时间：20140822
添加人：v-liuxch
***************************************/
var $document = $(document);
var preventDefault = function (e) {
    e.preventDefault();
};
var touchstart = function (e) {
    $document.on('touchmove', preventDefault);
};
var touchend = function (e) {
    $document.off('touchmove', preventDefault);
};

//var wait = 60;
//发送验证码按钮倒计时
var wait = 60;
function time(o) {
    if (wait == 0) {
        o.css("background-color", "#f4951d");
        o.html("获取验证码");
        wait = 60;
    }
    else {
        o.html("重新发送(" + wait + ")");
        o.css("background-color", "#999");
        wait--;
        setTimeout(function () {
            time(o);
        }, 1000);
    }
}


var MobileBusiness = {

    /***************************************
    功能：页面提示层
    添加时间：20140822
    添加人：v-liuxch
    调用方法：MobileBusiness.ShowTip("xxx");
    ***************************************/
    ShowTip: function (message) {
        if ($("#ui_showdialog").length == 0) {
            strDiv = '<div id="ui_showdialog"><div id="ui_showdialogContent"></div></div>';
            $("body").append(strDiv);
        }
        //禁止滚动
        touchstart();
        $("#ui_showdialogContent").text(message);
        var showDiv = $("#ui_showdialog");
        showDiv.css({
            top: document.documentElement.clientHeight / 2 - showDiv.height() / 2
        });
        showDiv.fadeIn(1000);
        showDiv.fadeOut(3000, function () {
            //启用滚动
            touchend();
        });
        showDiv.innerText = "";
    },
    WinTip: function (message) {
        this.ShowTip(message);
    },
    ErrorTip: function (message) {
        this.ShowTip(message);
    },
    delayReload: function () {
        setTimeout(function () {
            window.location.href = window.location.href;
            window.location.reload;
        }, 3000);
    },
    //校验空数据
    ValidateEmptyData: function (ctrEntities) {
        if (ctrEntities && ctrEntities.length > 0) {
            for (var i = 0; i < ctrEntities.length; i++) {
                var ctr = ctrEntities[i];
                if (($("#" + ctr.ID).val() == null) || ($("#" + ctr.ID).val().trim() == "")) {
                    this.ShowTip("请填写" + ctr.Name);
                    //$("#" + ctr.ID).focus();
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}

var PosCall;
function SetCurrentPosition(callback) {
    if (navigator.geolocation) {
        PosCall = callback;
        navigator.geolocation.getCurrentPosition(showPosition, showErrorPosition);
    }
    else {
        callback(0, 0, 0, 0);
    }
}

function showPosition(position) {
    var lng = position.coords.longitude;
    var lat = position.coords.latitude;

    var geoc = new BMap.Geocoder();
    var point = new BMap.Point(lng, lat);
    geoc.getLocation(point, function (rs) {
        var addComp = rs.addressComponents;
        var province = addComp.province;
        var city = addComp.city;
        var district = addComp.district;
        var street = addComp.street;
        var streetNumber = addComp.streetNumber;

        PosCall(lng, lat, district, street);
    });
}

function showErrorPosition(error) {
    PosCall(0, 0, 0, 0);
}

//obj:lng,lat,province,city,district,street,streetNumber
function GetPos(obj) {
    var rst = getCookie("pos_" + obj);
    if (rst != "") {
        return rst;
    }
    else {
        return "";
    }
}

function GetDistance(lng1, lat1, lng2, lat2) {
    var p1 = new BMap.Point(lng1, lat1);
    var p2 = new BMap.Point(lng2, lat2);
    if (!p1 || !p2) { return 0; }
    var R = 6371;
    var dLat = (p2.lat - p1.lat) * Math.PI / 180;
    var dLon = (p2.lng - p1.lng) * Math.PI / 180;
    var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) + Math.cos(p1.lat * Math.PI / 180) * Math.cos(p2.lat * Math.PI / 180) * Math.sin(dLon / 2) * Math.sin(dLon / 2);
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    //var d = R * c;
    var d = R * c * 1000;
    return d;
}


function GetMyDistance(mylng, mylat, lng, lat) {
    var dis = GetDistance(mylng, mylat, lng, lat);
    var d = "";
    if (mylat != 0 && mylng != 0) {
        if (!isNaN(dis)) {
            if (dis >= 1000) {
                d = parseFloat(dis * 0.001).toFixed(2) + "公里";
            } else {
                d = parseFloat(dis).toFixed(0) + "米";
            }
        }
    }
    return d;
}

function BindPageData(BindData) {
    BindData();
    $("#btnPage").click(function () {
        if (!isLoad && !isEnd) {
            pageindex++;
            $(".pagebutton").hide();
            BindData();
        }
    });
}

function ShowPageButton(pageindex, pagecount) {
    isLoad = false;   //必须
    $(".pagebutton").show();
    if (pagecount == 0 || pagecount == 1) {
        $(".pagebutton").hide();
    }
    if (pageindex >= pagecount) {
        isEnd = true;
        $("#btnPage").html("没有数据啦");
    }
    else {
        $("#btnPage").html("点击加载更多");
    }
}