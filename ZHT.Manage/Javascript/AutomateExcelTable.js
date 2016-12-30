//导出Excel
function AutomateExcelTable(results, mask) {
    if (results.Table.length != 0) {
        if (results.Table[0].length != 0) {
            //初始化列表
            var oXL = new ActiveXObject("Excel.Application"); //创建应该对象
            var oWB = oXL.Workbooks.Add(); //新建一个Excel工作簿
            var oSheet = oWB.ActiveSheet; //指定要写入内容的工作表为活动工作表
            var table = results.Table[0]; //指定要写入的数据源的是一个datatable
            var hang = results.Table[0].length; //取数据源行数
            var lie = 0; //取数据源列数
            var key;
            for (key in table[0]) {
                if (table[0].hasOwnProperty(key))
                    lie++;
            }
            for (i = 0; i < hang; i++) {//在Excel中写行
                var num = 0;
                $.each(table[i], function (k, v) {
                    if (num < lie) {
                        if (i == 0) {
                            //    定义格式
                            oSheet.Cells(i + 1, num + 1).NumberFormatLocal = "@";
                            //  !!!!!!!上面这一句是将单元格的格式定义为文本
                            oSheet.Cells(i + 1, num + 1).Font.Bold = false; //加粗
                            oSheet.Cells(i + 1, num + 1).Font.Size = 10; //字体大小
                            oSheet.Cells(i + 1, num + 1).value = k; //向单元格写入值
                            oSheet.Cells(i + 2, num + 1).NumberFormatLocal = "@";
                            oSheet.Cells(i + 2, num + 1).Font.Bold = false; //是否加粗
                            oSheet.Cells(i + 2, num + 1).value = v;

                        }
                        //    定义格式
                        else {
                            oSheet.Cells(i + 2, num + 1).NumberFormatLocal = "@";
                            //  !!!!!!!上面这一句是将单元格的格式定义为文本
                            oSheet.Cells(i + 2, num + 1).Font.Bold = false; //加粗
                            oSheet.Cells(i + 2, num + 1).value = v; //向单元格写入值
                        }
                    }
                    num++;
                });
            }
            oXL.Visible = true;
            oXL.UserControl = true;
            $("#" + mask).hide();
        }
        else {
            $("#" + mask).hide();
            showerrortip("导出的数据不能为空");

        }
    }
    else {
        $("#" + mask).hide();
        showerrortip("导出的数据不能为空");
    }
}

//遮罩层
function showMask(mask) {
    $("#" + mask).css("height", $(document).height());
    $("#" + mask).css("width", $(document).width());
    $("#" + mask).css("display", "block");
    $("#" + mask).show();

}
//替换所有的回车换行，空格
function TransferString(content) {
    var string = content;
    try {
        string = string.replace(/\n/g, "<BR>");
        var str = string.replace(/[ ]/g, '&nbsp;');
    } catch (e) {
        alert(e.message);
    }
    return str;
}
//验证图片
function CheckExt(obj) {
    if (obj.value == "") return false;
    var filePath = obj.value;
    var path = filePath.toString();
    var pathfile = path.slice(path.indexOf(".") - path.length);
    if (pathfile != ".jpg" && pathfile != ".jpeg" && pathfile != ".png" && pathfile != ".bmp" && pathfile != ".gif") {
        showerrortip("图片格式不正确");
        $("#text" + obj.id).val("");
        $(obj).val("");
        return;
    }
//    var fileId = filePath;
//    var dom = document.getElementById(fileId);
//    var fileSize = dom.files[0].size; //文件的大小，单位为字节B

    try {

        var fileSystem = new ActiveXObject("Scripting.FileSystemObject");
        var file = fileSystem.GetFile(filePath);
        fileSize = file.Size;
        if (fileSize / 1024 / 1024 > 2) {
            showerrortip("上传图片大小不能大于2M")
            $("#text" + obj.id).val("");
            $(obj).val("");
            return;
        }

    } catch (e) {

    }

    $("#text" + obj.id).val(filePath);

}
//金额小写转大写
function changeMoneyToChinese(money) {
    var cnNums = new Array("零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖"); //汉字的数字
    var cnIntRadice = new Array("", "拾", "佰", "仟"); //基本单位
    var cnIntUnits = new Array("", "万", "亿", "兆"); //对应整数部分扩展单位
    var cnDecUnits = new Array("角", "分", "毫", "厘"); //对应小数部分单位
    var cnInteger = "整"; //整数金额时后面跟的字符
    var cnIntLast = "元"; //整型完以后的单位
    var maxNum = 999999999999999.9999; //最大处理的数字

    var IntegerNum; //金额整数部分
    var DecimalNum; //金额小数部分
    var ChineseStr = ""; //输出的中文金额字符串
    var parts; //分离金额后用的数组，预定义

    if (money == "") {
        return "";
    }

    money = parseFloat(money);
    //alert(money);
    if (money >= maxNum) {
        $.alert('超出最大处理数字');
        return "";
    }
    if (money == 0) {
        ChineseStr = cnNums[0] + cnIntLast + cnInteger;
        //document.getElementById("show").value=ChineseStr;
        return ChineseStr;
    }
    money = money.toString(); //转换为字符串
    if (money.indexOf(".") == -1) {
        IntegerNum = money;
        DecimalNum = '';
    } else {
        parts = money.split(".");
        IntegerNum = parts[0];
        DecimalNum = parts[1].substr(0, 4);
    }
    if (parseInt(IntegerNum, 10) > 0) {//获取整型部分转换
        zeroCount = 0;
        IntLen = IntegerNum.length;
        for (i = 0; i < IntLen; i++) {
            n = IntegerNum.substr(i, 1);
            p = IntLen - i - 1;
            q = p / 4;
            m = p % 4;
            if (n == "0") {
                zeroCount++;
            } else {
                if (zeroCount > 0) {
                    ChineseStr += cnNums[0];
                }
                zeroCount = 0; //归零
                ChineseStr += cnNums[parseInt(n)] + cnIntRadice[m];
            }
            if (m == 0 && zeroCount < 4) {
                ChineseStr += cnIntUnits[q];
            }
        }
        ChineseStr += cnIntLast;
        //整型部分处理完毕
    }
    if (DecimalNum != '') {//小数部分
        decLen = DecimalNum.length;
        for (i = 0; i < decLen; i++) {
            n = DecimalNum.substr(i, 1);
            if (n != '0') {
                ChineseStr += cnNums[Number(n)] + cnDecUnits[i];
            }
        }
    }
    if (ChineseStr == '') {
        ChineseStr += cnNums[0] + cnIntLast + cnInteger;
    }
    else if (DecimalNum == '') {
        ChineseStr += cnInteger;
    }
    return ChineseStr;

}
//打印
function preview() {
    bdhtml = window.document.body.innerHTML;

    sprnstr = "<!--startprint-->";

    eprnstr = "<!--endprint-->";

    prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);

    prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));

    window.document.body.innerHTML = prnhtml;

    window.print();

}