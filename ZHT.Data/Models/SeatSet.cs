using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
   public partial class SeatSet
    {
        public SeatSet()
        {
            this.seatno = new List<SeatNo>();
        }
        public string id { get; set;}
        public string exhibitioncode { get; set; }
        public string basetypescode { get; set; }
        public decimal seatprice { get; set; }
        public string seatscale { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public int isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        public virtual Exhibition exhibition { get; set; }
        public virtual ICollection<SeatNo> seatno { get; set; }

    }
}
