using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class SellerOrder
    {
        public SellerOrder()
        {
            this.sellerOrderDetails = new List<SellerOrderDetails>();
        }

        public string id { get; set; }
        public DateTime enrolltime { get; set; }
        public string seatsetcode { get; set; }
        public string sname { get; set; }
        public string sphone { get; set; }
        public decimal totalprice { get; set; }
        public string paytype { get; set; }
        public string payaccount { get; set; }
        public string sellerid { get; set; }
        public string remark { get; set; }
        public string orderno { get; set; }
        public string exhibitionid { get; set; }
        public string sellerintro { get; set; }
        public int orderstatus { get; set; }
        public DateTime creattime { get; set; }
        public string creater { get; set; }
        public DateTime modifiytime { get; set; }
        public string modifier { get; set; }
        public int isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        public virtual Exhibition exhibition { get; set; }
       
        public virtual ICollection<SellerOrderDetails> sellerOrderDetails { get; set; }
    }
}
