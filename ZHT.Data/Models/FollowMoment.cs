using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
   public partial class FollowMoment
    {
        public string id { get; set; }
        public DateTime followtime { get; set; }
        public string followusercode { get; set; }
        public string exhibitioncode { get; set; }
        public string momentcode { get; set; }
        public int isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        public virtual Exhibition exhibition { get; set; }
        public virtual Moment moment { get; set; }
    }
}
