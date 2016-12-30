using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHT.Manage
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected string isExhibition;
        protected string isFinance;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RawUrl.Contains("Exhibition"))
            {
                isExhibition = "current";
            }
            else
            {
                isFinance = "current";
            }
        }
    }
}