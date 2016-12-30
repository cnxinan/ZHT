using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
   public partial class TicketsType
    {
        public TicketsType()
        {
            this.enrollusers = new List<EnrollUser>();
        }
        public string id { get; set; }
        public string ticketname { get; set; }
        public decimal price { get; set; }
        public int quota { get; set; }
        public string privilege { get; set; }
        public string ticketssetcode { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public int isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        public virtual TicketsSet ticketset { get; set; }

        public virtual ICollection<EnrollUser> enrollusers { get; set; }
    }
}
