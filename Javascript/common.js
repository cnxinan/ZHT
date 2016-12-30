window.CLICK_TYPE = (("ontouchstart" in window) ? "touchend" : "click");

/***************************************
功能：短信发送验证码
添加时间：20140822
添加人：v-liuxch
调用方法：PostSMS(phoneNumber, sessionID, requestUrl, successAction);
phoneNumber 手机号,sessionID 页面会话值,requestUrl 页面请求的地址,successAction 成功后的回调函数
***************************************/
function PostSMS(phoneNumber, sessionID, requestUrl, successAction) {
    $.ajax(
			    {
			        type: 'POST',
			        url: requestUrl,
			        data: {
			            mobile: phoneNumber,
			            sessionId: sessionID
			        },

			        success: function (response, stutas, xhr) {
			            var result = response.documentElement.textContent || response.text;
			            if (result.toLowerCase() == "true") {
			                successAction();
			            } else {
			                MobileBusiness.ShowTip("验证码发送失败,请稍候再试");
			            }
			        },
			        error: function (err) {
			            MobileBusiness.ShowTip(err.responseText);
			        }
			    }
		    );
}

///
/***************************************
功能：校验用户短信是否正确
添加时间：20140822
添加人：v-liuxch
调用方法：CheckSMS(phoneNumber, sessionID, markCode, requestUrl, successAction);
phoneNumber 手机号,sessionID 页面会话值,markCode 验证吗,requestUrl 页面请求的地址,successAction 成功后的回调函数
***************************************/
function CheckSMS(phoneNumber, sessionID, markCode, requestUrl, successAction) {
    $.ajax(
		    {
		        type: 'POST',
		        url: requestUrl,
		        async: false,
		        data: {
		            sessionId: sessionID,
		            markCode: markCode
		        },
		        success: function (response, stutas, xhr) {
		            var result = response.documentElement.textContent || response.text;
		            if (result.toLowerCase() == "true") {
		                successAction();
		            } else {
		                MobileBusiness.ShowTip("验证码有误,请核实.");
		            }
		        },
		        error: function (err) {
		            MobileBusiness.ShowTip(err.responseText);
		        }
		    }
	    );
}

/***************************************
功能：格式化json日期为yyyy-MM-dd hh:mm:ss 如果日期为NULL,返回空
添加时间：20140822
添加人：v-liuxch
调用方法：DateFormat(date,format);
***************************************/
function DateFormat(jsondate, format) {
    jsondate = jsondate.replace("/Date(", "").replace(")/", "");
    if (jsondate.indexOf("+") > 0) {
        jsondate = jsondate.substring(0, jsondate.indexOf("+"));
    }
    else if (jsondate.indexOf("-") > 0) {
        jsondate = jsondate.substring(0, jsondate.indexOf("-"));
    }
    var date = new Date(parseInt(jsondate, 10));
    var o = {
        "M+": date.getMonth() + 1, //month
        "d+": date.getDate(), //day
        "h+": date.getHours(), //hour
        "m+": date.getMinutes(), //minute
        "s+": date.getSeconds(), //second
        "q+": Math.floor((date.getMonth() + 3) / 3), //quarter
        "S": date.getMilliseconds() //millisecond
    }
    if (/(y+)/.test(format)) format = format.replace(RegExp.$1,
    (date.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o) if (new RegExp("(" + k + ")").test(format))
        format = format.replace(RegExp.$1,
    RegExp.$1.length == 1 ? o[k] :
    ("00" + o[k]).substr(("" + o[k]).length));
    if (date.getFullYear() == 1) {
        return "";
    }
    else {
        return format;
    }
}


/***************************************
功能：js截取字符串，中英文都能用,如果给定的字符串大于指定长度，截取指定长度返回，否者返回源字符串
添加时间：2015年1月26日11:10:28
添加人：v-lsh
调用方法：cutstr(str, len);
***************************************/
function cutstr(str, len) {
    var str_length = 0;
    var str_len = 0;
    str_cut = new String();
    str_len = str.length;
    for (var i = 0; i < str_len; i++) {
        a = str.charAt(i);
        str_length++;
        if (escape(a).length > 4) {
            //中文字符的长度经编码之后大于4
            str_length++;
        }
        str_cut = str_cut.concat(a);
        if (str_length >= len) {
            str_cut = str_cut.concat("...");
            return str_cut;
        }
    }
    //如果给定字符串小于指定长度，则返回源字符串；
    if (str_length < len) {
        return str;
    }
}

//格式化json日期格式化获取年份
/***************************************
功能：格式化json日期格式化并获取距离现在相差多少年
添加时间：2015年1月15日
添加人：v-lsh
调用方法：ChangeYearFormat(jsondate);
***************************************/
function ChangeYearFormat(jsondate) {
    jsondate = jsondate.replace("/Date(", "").replace(")/", "");
    if (jsondate.indexOf("+") > 0) {
        jsondate = jsondate.substring(0, jsondate.indexOf("+"));
    }
    else if (jsondate.indexOf("-") > 0) {
        jsondate = jsondate.substring(0, jsondate.indexOf("-"));
    }

    var date = new Date(parseInt(jsondate, 10));
    var now = new Date();


    return now.getFullYear() - date.getFullYear();


};


/***************************************
功能：格式化json日期格式化获取年月日时分秒没有定义样式
添加时间：2015年1月15日
添加人：v-lsh
调用方法：Change(jsondate);
***************************************/
function Change(jsondate) {
    jsondate = jsondate.replace("/Date(", "").replace(")/", "");
    if (jsondate.indexOf("+") > 0) {
        jsondate = jsondate.substring(0, jsondate.indexOf("+"));
    }
    else if (jsondate.indexOf("-") > 0) {
        jsondate = jsondate.substring(0, jsondate.indexOf("-"));
    }

    var date = new Date(parseInt(jsondate, 10));

    return date;

};

/***************************************
功能：求字符串时间的时间差
添加时间：2015年1月28日17:59:20
添加人：v-lsh
调用方法：difftmime(start, end);
***************************************/
function difftmime(start, end) {
    var reg = /\:/g;

    var sDate = new Date;
    var s = start.split(reg);
    sDate.setHours(s[0]);
    sDate.setMinutes(s[1]);

    var eDate = new Date;
    var e = end.split(reg);
    eDate.setHours(e[0]);
    eDate.setMinutes(e[1]);

    return sDate - eDate;
}

/***************************************
功能：验证手机格式是否正确
添加时间：20140822
添加人：v-liuxch
调用方法：IsMobile(string);
***************************************/
function IsMobile(text) {
    var _emp = /^\s*|\s*$/g;
    text = text.replace(_emp, "");
    var _d = /^1[3578][01234567789]\d{8}$/g;
    var _l = /^1[34578][0123456789]\d{8}$/g;
    var _y = /^(134[012345678]\d{7}|1[34578][0123456789]\d{8})$/g;

    if (_d.test(text)) {
        return true;
    }
    else if (_l.test(text)) {
        return true;
    }
    else if (_y.test(text)) {
        return true;
    }
    return false;
}

/***************************************
功能：验证是否是正确的邮箱格式
添加时间：20140822
添加人：v-liuxch
调用方法：IsMail(string);
***************************************/
function IsMail(text) {
    var _emp = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/g;
    if (_emp.test(text)) {
        return true;
    }
    else {
        return false;
    }
}


/***************************************
功能：页面Cookie保存方法
添加时间：20141229
添加人：v-liuxch
调用方法：
c_name：Cookie名
value：Cookie值
expiredays：时效
***************************************/
function setCookie(c_name, value, expiredays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + expiredays);
    document.cookie = c_name + "=" + escape(value) +
((expiredays == null) ? "" : ";expires=" + exdate.toGMTString()) + ";path=/;";


}
/***************************************
功能：页面Cookie获取方法
添加时间：20141229
添加人：v-liuxch
调用方法：
c_name：Cookie名
***************************************/
function getCookie(c_name) {
    if (document.cookie.length > 0) {
        c_start = document.cookie.indexOf(c_name + "=");
        if (c_start != -1) {
            c_start = c_start + c_name.length + 1;
            c_end = document.cookie.indexOf(";", c_start);
            if (c_end == -1) c_end = document.cookie.length;
            return unescape(document.cookie.substring(c_start, c_end));
        }
    }
    return "";
}
/***************************************
功能：页面Cookie检测是否存在方法
添加时间：20141229
添加人：v-liuxch
调用方法：
c_name：Cookie名
***************************************/
function checkCookie(c_name) {
    obj = getCookie(c_name);
    return obj;
}

function deleteCookie(c_name) {
    if (getCookie(c_name) != "") {
        var exdate = new Date();
        exdate.setDate(exdate.getDate() - 10000);
        var cval = getCookie(c_name);
        if (null != cval) {
            document.cookie = c_name + "=" + cval + ";expires=" + exdate.toGMTString() + ";path=/";
            //alert(getCookie(c_name));
        }
    }
}

/***************************************
功能：滚动到指定DOM节点
添加时间：20141229
添加人：v-liuxch
调用方法：scrollToLocation($("#selector"))
***************************************/
function scrollToLocation(obj) {
    var scroll_offset = obj.offset();  //得到pos这个div层的offset，包含两个值，top和left
    $("body,html").animate({
        scrollTop: scroll_offset.top + 5  //让body的scrollTop等于pos的top，就实现了滚动
    }, 1000);
}
function showTip(texts, times) {
    $.mobile.loading("hide");
    $.mobile.loading('show', { text: texts, textVisible: true, theme: "b", textonly: true });
    setTimeout(hideTip, times || 1200);

}
function hideTip() {
    $.mobile.loading('hide');
}
function Close() {
    var ua = navigator.userAgent;
    var ie = navigator.appName == "Microsoft Internet Explorer" ? true : false;
    if (ie) {
        var IEversion = parseFloat(ua.substring(ua.indexOf("MSIE") + 5, ua.indexOf(";", ua.indexOf("MSIE"))));
        if (IEversion < 5.5) {
            var str = "<object id = 'noTipClose' classid='clsid:ADB880A6-D8FF-11CF-9377-00AA003B7A11'>";
            str += "<param name='Command' value='Close'/></object>";
            document.body.insertAdjacentHTML("beforeEnd", str);
            document.all.noTipClose.Click();
        } else {
            window.opener = null;
            window.open('', '_self', '');
            window.close();
        }
    } else {
        window.close();
    }
}

// 日期比较
function CompareDate(d1, d2) {
    t1 = new Date(d1.replace(/-/g, "/"));
    t2 = new Date(d2.replace(/-/g, "/"));
    return (t1 > t2);
}

// 客户端只允许输入数字和退格Backspace)
function OnlyNumber() {
    // 8 Delete
    if (!((window.event.keyCode > 47 && window.event.keyCode < 58) || window.event.keyCode == 8)) {
        window.event.returnValue = false;
    }
}

// 客户端只允许输入数字和退格Backspace)、防止粘贴
function InPasteNumbers() {
    if (IsValidNumbers(window.clipboardData.getData('Text')) == false) {
        window.event.returnValue = false;
    }
}

// 客户端只允许输入中文、字母和数字
function OnlyCHNChar() {
    var re = /[\w\u4e00-\u9fa5]/;
    if (re.test(String.fromCharCode(window.event.keyCode)) == false) {
        window.event.returnValue = false;
    }
}

// 客户端只允许输入中文、字母和数字、防止粘贴
function InPasteCHNChar() {
    var re = /[^\w\u4e00-\u9fa5]/g;
    if (re.test(window.clipboardData.getData('Text')) == true) {
        window.event.returnValue = false;
    }
}

// 输入是否是合法的数字（多个数字）
function IsValidNumbers(value) {
    var re = /^[0-9]*$/;
    var result = false;
    if (re.test(value) == true) {
        result = true;
    }
    return result;
}

// 输入是否是合法的数字（一个数字）
function IsValidNumber(value) {
    var re = /^[0-9]*$/;
    var result = false;
    if (re.test(value) == true) {
        result = true;
    }
    return result;
}

// 判断是4位数字
function IsValidFourNumber(value) {
    var re = /^[1-9][0-9]{3}$/;
    var result = false;
    if (re.test(value) == true) {
        result = true;
    }
    return result;
}

// 输入是否为空(不包括空格)
function IsEmpty(input) {
    if (($.trim(input)).length == 0) {
        return true;
    }
    return false;
}

// 时间比较
function CompareDate(d1, d2) {
    t1 = new Date(d1.replace(/-/g, "/"));
    t2 = new Date(d2.replace(/-/g, "/"));
    return (t1 > t2);
}

// 年比较
function CompareYear(d1, d2) {
    t2 = new Date(d2.replace(/-/g, "/"));
    return (t2.getYear() > d1);
}

// 日期不能小于1900-01-01
function ValidateMinDate(date) {
    var minDate = (new Date(1900, 1, 1)).Format("yyyy-MM-dd");
    return CompareDate(minDate, date);
}

// 日期不能大于当前日期
function ValidateCurrentDate(date) {
    var currentDate = (new Date()).Format("yyyy-MM-dd");
    return CompareDate(date, currentDate);
}

// 日期不能小于1900-01-01且不能大于当前日期
function ValidateDate(d1) {
    var minDate = (new Date(1900, 0, 1)).Format("yyyy-MM-dd");
    var currentDate = (new Date()).Format("yyyy-MM-dd");
    if (CompareDate(d1, minDate) && CompareDate(currentDate, d1)) {
        return true;
    }
    return false;
}

// 只允许输入数字
function onlyNum() {
    var str = $(this).val().replace(/\D/g, '');
    $(this).val(str);
}

//不允许输入特殊字符，允许输入汉字、英文、数字、小数点
function onlyEnCnNumDot() {
    var str = $(this).val().replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5\.]/g, '');
    $(this).val(str);
}

//不允许输入特殊字符，允许输入汉字、英文、数字
function onlyEnCnNum() {
    var str = $(this).val().replace(/[^\a-\z\A-\Z0-9\u4E00-\u9FA5]/g, '');
    $(this).val(str);
}

// 验证输入的长度,超过长度自动截取
function CheckInputLength(e, maxLength) {
    if (e.value.length > maxLength) {
        e.value = e.value.substring(0, maxLength);
    }
}

//长度验证，如果超过长度自动截取
function checkValueLength(param) {
    var s = $(this).val();
    if (s.length > param.data) {
        $(this).val(s.substr(0, param.data));
    }
}

/***************************************
功能：对数据库中取到的数据中含有 &,<,>,',"等的转义
添加时间：20150114
添加人：v-zhushx
***************************************/
function html_encode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/&/g, "&gt;");
    s = s.replace(/</g, "&lt;");
    s = s.replace(/>/g, "&gt;");
    s = s.replace(/ /g, "&nbsp;");
    s = s.replace(/\'/g, "&#39;");
    s = s.replace(/\"/g, "&quot;");
    s = s.replace(/\n/g, "<br>");
    return s;
}

/***************************************
功能：由于低版本浏览器不支持JSON.stringify(obj)，借助jquery实现该方法
该方法只支持一个层级的json对象
添加时间：2015-03-06
添加人：v-zhushx
***************************************/
function jsonToS(json) {
    var s = "";
    $.each(json, function (k, v) {
        s += "," + k + ":" + v;
    });
    if (s != "") {
        s = s.substring(1);
    }
    return "{" + s + "}";
}
/***
json数组的
添加时间：2015-03-06
添加人：v-zhushx
**/
function jsonToStr(json) {
    var s = "";
    $.each(json, function (k, v) {
        if ('object' === typeof this) {
            s += ',' + jsonToS(this);
        } else {
            s += ',"' + k + '":"' + v + '"';
        }
    });
    if (s != "") {
        s = s.substring(1);
    }
    return "[" + s + "]";
}