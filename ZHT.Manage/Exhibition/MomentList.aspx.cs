using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHT.Manage.Exhibition
{
    public partial class MomentList : System.Web.UI.Page
    {
        protected string exhibitionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ExhibitionId"] != null)
            {
                exhibitionId = Request["ExhibitionId"];
            }
        }
    }
}