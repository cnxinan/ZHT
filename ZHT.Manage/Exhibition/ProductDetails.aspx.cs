using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHT.Manage.Exhibition
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected string exhibitionId = "-1";
        protected string exhibitionProductId = "-1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ExhibitionId"] != null)
            {
                exhibitionId = Request["ExhibitionId"];
            }

            if (Request["ExhibitionProductId"] != null)
            {
                exhibitionProductId = Request["ExhibitionProductId"];
            }
        }
    }
}