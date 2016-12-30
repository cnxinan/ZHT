using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
   public partial class SeatNo
    {
        public SeatNo()
        {
            this.sellerorderdetails = new List<SellerOrderDetails>();
        }
        public string id { get; set; }
        public string seatsetcode { get; set; }
        public string seatno { get; set; }
        public string remark { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public int isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual SeatSet seatset { get; set; }
        public virtual ICollection<SellerOrderDetails> sellerorderdetails { get; set; }

    }
}
