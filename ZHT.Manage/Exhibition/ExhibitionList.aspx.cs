using Autofac;
using System;
using ZHT.Service;
using Webdiyer.WebControls.Mvc;

namespace ZHT.Manage.Exhibition
{
    public partial class ExhibitionList : System.Web.UI.Page
    {
        
        protected string current1;
        protected string current2;

        protected int exhibitionType = 0;     //0 正在进行 1 已结束

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["type"] == null || Request["type"].ToString() == "0")
            {
                exhibitionType = 0;
                current1 = "current";
            }
            else
            {
                exhibitionType = 1;
                current2 = "current";
            }
        }
    }
}