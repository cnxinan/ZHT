using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ZHT.Api.ActionHelper;

namespace ZHT.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        LogHelper log = LogFactory.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        protected void Application_Start()
        {
            DIConfig.Register();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            log.Info("系统启动");
        }

        //全局异常处理
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception objExp = HttpContext.Current.Server.GetLastError();
            
            log.Error("客户机IP:" + Request.UserHostAddress + "，错误地址:" + Request.Url 
                + "\r\n未处理异常：:" + Server.GetLastError().Message, objExp);
        }
    }
}
