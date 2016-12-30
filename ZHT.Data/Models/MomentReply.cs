using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
   public partial class MomentReply
    {
        public string id { get; set; }
        public DateTime replytime { get; set; }
        public string replycontent { get; set; }
        public string momentcode { get; set; }
        public string parentid { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public int isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }

        public virtual Moment moment { get; set; }
    }
}
