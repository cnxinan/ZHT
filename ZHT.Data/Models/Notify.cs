using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class Notify
    {
        public string id { get; set; }
        public DateTime notifytime { get; set; }
        public int notifytype { get; set;}
        public string notifycontent { get; set; }
        public int usercode { get; set; }
        public string remark { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public int isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }


    }
}
