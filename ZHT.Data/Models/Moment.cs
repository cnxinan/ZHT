using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class Moment
    {
        public Moment()
        {
            this.followmoment = new List<FollowMoment>();
            this.momentreply = new List<MomentReply>();
        }
        public string id { get; set; }
        public DateTime pubtime { get; set; }
        public string pubcontent { get; set; }
        public int types { get; set; }
        public string publishercode { get; set; }
        public string exhibitioncode { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public int isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        public string viewUserIds { get; set; }
        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual ICollection<FollowMoment> followmoment { get; set; }
        public virtual ICollection<MomentReply>momentreply { get; set; }
        public virtual Exhibition exhibition { get; set; }
    }
}
