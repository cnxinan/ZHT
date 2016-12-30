using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class Settlement
    {
        public string id { get; set; }
        public string exhibitionCode { get; set; }
        public decimal amount { get; set; }
        public int type { get; set; }
        public string creater { get; set; }
        public DateTime creatTime { get; set; }
        public int isDel { get; set; }

        public virtual Exhibition exhibition { get; set; }
    }
}
