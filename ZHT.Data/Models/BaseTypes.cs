using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class BaseTypes
    {
        public BaseTypes()
        {
            this.exhibiton = new List<Exhibition>();
        }
        public string id { get; set; }
        public string typename { get; set; }
        public Nullable<int> typeid { get; set; }
        public string typevalue { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public Nullable<int> isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual ICollection<Exhibition> exhibiton { get; set; }

    }
}
