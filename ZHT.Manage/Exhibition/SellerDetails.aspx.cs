using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZHT.Manage.Exhibition
{
    public partial class SellerDetails : System.Web.UI.Page
    {
        protected string exhibitionId = "-1";
        protected string sellerOrderId = "-1";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ExhibitionId"] != null)
            {
                exhibitionId = Request["ExhibitionId"].ToString();
            }

            if (Request["SellerOrderId"] != null)
            {
                sellerOrderId = Request["SellerOrderId"].ToString();
            }
        }
    }
}