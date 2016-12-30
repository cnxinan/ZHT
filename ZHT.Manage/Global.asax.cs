using System;

namespace ZHT.Manage
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            DIConfig.Register();
        }       
    }
}