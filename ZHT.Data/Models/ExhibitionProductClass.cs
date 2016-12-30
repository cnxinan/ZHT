using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class ExhibitionProductClass
    {
        public string id { get; set; }
        public string classname { get; set; }
        public string exhibitioncode { get; set; }
        public string classremark { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public int isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
      
        public virtual Exhibition exhibition { get; set; }
    }
}
