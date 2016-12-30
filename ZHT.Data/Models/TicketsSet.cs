using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class TicketsSet
    {
        public TicketsSet()
        {
            this.tickettype = new List<TicketsType>();
        }
        public string id { get; set; }
        public bool namerequire { get; set; }
        public bool phonerequire { get; set; }
        public string exhibitioncode { get; set; }
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
        public virtual ICollection<TicketsType> tickettype { get; set; }

        public virtual Exhibition exhibition { get; set; }
    }
}
