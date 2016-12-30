using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
  public partial  class MyFavorites
    {
       
        public string id { get; set; }
        public DateTime favoritestime { get; set; }
        public string usercode { get; set; }
        public string favoritescode { get; set; }
        public int types { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public int isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        /// <summary>
        /// 导航
        /// </summary>
        public Exhibition exhibitions { get; set; }        
    }
}
