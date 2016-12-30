//��Ҫ���ñ��js��ʱ�򣬾ͼ�����Env.require("cookie.js")����Env.require("/common/cookie.js")���������·�����Ǿ���·���Ϳ�ϲ���ˡ�
//Env.require������ҳ��ģ���У�Ҳ������js�ļ��У���һ��Ҫ��ִ֤��ʱenv.js����ʽ���롣
//���Env.requireͬһ��js����������Ի��Ǿ��ԣ���ֻ�е�һ�λ���أ����Բ����ظ���

//��������еİ汾��������Ϊ�������ǰ׺�����ٸ��»���
var envLastVer = '2014_11_17_17_03';

//���ڴ��ͨ�����Ƽ�ͨ�Ŷ�����࣬��������ͨ����ͬͨ�����������ֲ�ͬ��ͨ�Ŷ���  
function HttpRequestObject() {
    this.chunnel = null;
    this.instance = null;
}

//���ڻ�ȡ�Ľű���css�ļ��������
function HttpGetObject() {
    this.url = null;        //Ҫ���ص��ļ�·��
    this.cache_key = null;  //�����
    this.chunnel = null;    //ͨ����
    this.type = null;       //���ͣ�js��css
    this.is_fill = false;   //�����Ƿ����
    this.is_exec = false;   //�����Ƿ��ѱ�ִ�У���ֹ�ּ����������ظ�ִ��
}

//ͨ�Ŵ����࣬���Ծ�̬�������еķ���  
var Request = new function () {

    //ͨ����Ļ���  
    this.httpRequestCache = new Array();

    //�����µ�ͨ�Ŷ��� 
    this.createInstance = function () {
        var instance = null;
        if (window.XMLHttpRequest) {
            //mozilla  
            instance = new XMLHttpRequest();
            //��Щ�汾��Mozilla�����������������ص�δ����XML mime-typeͷ����Ϣ������ʱ�����
            //��ˣ�Ҫȷ�����ص����ݰ���text/xml��Ϣ  
            if (instance.overrideMimeType) {
                instance.overrideMimeType = "text/xml";
            }
        }
        else if (window.ActiveXObject) {
            //IE  
            var MSXML = ['MSXML2.XMLHTTP.5.0', 'Microsoft.XMLHTTP', 'MSXML2.XMLHTTP.4.0', 'MSXML2.XMLHTTP.3.0', 'MSXML2.XMLHTTP'];
            for (var i = 0; i < MSXML.length; i++) {
                try {
                    instance = new ActiveXObject(MSXML[i]);
                    break;
                }
                catch (e) {
                }
            }
        }
        return instance;
    }

    /**  
    * ��ȡһ��ͨ�Ŷ���  
    * ��ûָ��ͨ�����ƣ���Ĭ��ͨ����Ϊ"default"  
    * �������в�������Ҫ��ͨ���࣬�򴴽�һ����ͬʱ����ͨ���໺����  
    * @param _chunnel��ͨ�����ƣ��������ڴ˲�������Ĭ��Ϊ"default"  
    * @return һ��ͨ�Ŷ���������ͨ���໺����  
    */
    this.getInstance = function (_chunnel) {
        var instance = null;
        var object = null;
        if (_chunnel == undefined)//ûָ��ͨ������  
        {
            _chunnel = "default";
        }
        var getOne = false;
        for (var i = 0; i < this.httpRequestCache; i++) {
            object = HttpRequestObject(this.httpRequestCache[i]);
            if (object.chunnel == _chunnel) {
                if (object.instance.readyState == 0 || object.instance.readyState == 4) {
                    instance = object.instance;
                }
                getOne = true;
                break;
            }
        }
        if (!getOne) //�����ڻ����У��򴴽�  
        {
            object = new HttpRequestObject();
            object.chunnel = _chunnel;
            object.instance = this.createInstance();
            this.httpRequestCache.push(object);
            instance = object.instance;
        }
        return instance;
    }

    /**  
    * �ͻ��������˷�������  
    * @param _url:����Ŀ��  
    * @param _data:Ҫ���͵�����  
    * @param _processRequest:���ڴ����ؽ���ĺ������䶨������ڱ�ĵط�����Ҫ��һ����������Ҫ�����ͨ�Ŷ���  
    * @param _chunnel:ͨ�����ƣ�Ĭ��Ϊ"default"  
    * @param _asynchronous:�Ƿ��첽����Ĭ��Ϊtrue,���첽����
    * @param _paraObj:��صĲ������� 
    */
    this.send = function (_url, _data, _processRequest, _chunnel, _asynchronous, _paraObj) {
        if (_url.length == 0 || _url.indexOf("?") == 0) {
            alert("����Ŀ��Ϊ�գ�����ʧ�ܣ����飡");
            return;
        }
        if (_chunnel == undefined || _chunnel == "") {
            _chunnel = "default";
        }
        if (_asynchronous == undefined) {
            _asynchronous = true;
        }
        var instance = this.getInstance(_chunnel);
        if (instance == null) {
            alert("�������֧��ajax�����飡")
            return;
        }
        if (_asynchronous == true && typeof (_processRequest) == "function") {
            instance.onreadystatechange = function () {
                if (instance.readyState == 4) // �ж϶���״̬  
                {
                    if (instance.status == 200) // ��Ϣ�Ѿ��ɹ����أ���ʼ������Ϣ  
                    {
                        _processRequest(instance, _paraObj);
                    }
                    else {
                        alert("���������ҳ�����쳣�����飡");
                    }
                }
            }
        }
        //_url��һ��ʱ�̸ı�Ĳ�������ֹ���ڱ�����������ͬ�����������������������  
        if (_url.indexOf("?") != -1) {
            _url += "&requestTime=" + (new Date()).getTime();
        }
        else {
            _url += "?requestTime=" + (new Date()).getTime();
        }
        if (_data.length == 0) {
            instance.open("GET", _url, _asynchronous);
            instance.send(null);
        }
        else {
            instance.open("POST", _url, _asynchronous);
            instance.setRequestHeader("Content-Length", _data.length);
            instance.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            instance.send(_data);
        }
        if (_asynchronous == false && typeof (_processRequest) == "function") {
            _processRequest(instance, _paraObj);
        }
    }
}

var Env = new function () {
    this.needLoadObject = new Array();

    //��ȡenv.js�ļ�����·��
    this.envPath = null;
    this.getPath = function () {
        this.envPath = document.location.pathname;
        this.envPath = this.envPath.substring(0, this.envPath.lastIndexOf("/") + 1);
        var _scripts = document.getElementsByTagName("script");
        var _envPath = null;
        var _scriptSrc = null;
        for (var i = 0; i < _scripts.length; i++) {
            _scriptSrc = _scripts[i].getAttribute("src");
            if (_scriptSrc && _scriptSrc.indexOf("env.js") != -1) {
                break;
            }
        }
        if (_scriptSrc != null) {
            if (_scriptSrc.charAt(0) == '/') {
                this.envPath = _scriptSrc.substr(0, _scriptSrc.length - 6);
            }
            else {
                this.envPath = this.envPath + _scriptSrc.substr(0, _scriptSrc.length - 6);
            }
        }
    }
    this.getPath();

    //��ȡ�ļ���׺��
    this.getFileExt = function (fileUrl) {
        var d = /\.[^\.]+$/.exec(fileUrl);
        return d.toString().toLowerCase();
    }

    //���η���Ҫ������ļ�
    this.pushNeedLoad = function (url) {
        var _absUrl = null;
        if (url.charAt(0) == '/')
            _absUrl = url;
        else
            _absUrl = this.envPath + url;

        var object = new HttpGetObject();
        object.url = _absUrl;
        object.cache_key = envLastVer + _absUrl;    //���ð汾��+����·�����ɻ����
        object.chunnel = 'ch' + (this.needLoadObject.length + 1);
        object.type = this.getFileExt(_absUrl);

        //���Դӻ����ȡ
        var cacheContent = localStorage.getItem(object.cache_key);
        if (cacheContent) { object.is_fill = true; }

        this.needLoadObject.push(object);
        return this;
    }

    //����װ��Ҫ������ļ�
    this.batchLoad = function () {
        for (var i = 0; i < this.needLoadObject.length; i++) {
            var item = this.needLoadObject[i];
            var processGet = function (_instance, _paraObj) {
                localStorage.setItem(_paraObj.cache_key, _instance.responseText);    //�����ļ�
                _paraObj.is_fill = true;
            }
            if (item.is_fill == false) {
                Request.send(item.url, "", processGet, item.chunnel, false, item);  //����ͬ����ʽ����
            }
        }
        return this;
    }

    //����ִ��Ҫ������ļ�
    this.batchExec = function () {
        var runCss = function (_css) { document.write('<style type="text/css">' + _css + '</style>'); }
        var runJs = function (_js) {
            if (window.execScript)
                window.execScript(_js);
            else
                window.eval(_js);
        }
        //����ִ�У�����jsΪ���߳�ִ�У�ÿִ��һ��js�����������������Կ��Ա�֤˳��ִ��
        for (var i = 0; i < this.needLoadObject.length; i++) {
            var item = this.needLoadObject[i];
            if (item.is_exec == false) {
                if (item.type == '.js') {
                    runJs(localStorage.getItem(item.cache_key));
                    item.is_exec = true;  //�����ִ�У��´β�����ִ��
                }
                else if (item.type == '.css') {
                    runCss(localStorage.getItem(item.cache_key));
                    item.is_exec = true;  //�����ִ�У��´β�����ִ��
                }
            }
        }
    }
}