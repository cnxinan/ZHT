using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class EnrollUser
    {

        public string id { get; set; }
        public DateTime enrolltime { get; set; }
        public string exhibitioncode { get; set; }
        public string nickname { get; set; }
        public string sname { get; set; }
        public string sphone { get; set; }
        public int ticketstatus { get; set; }
        public string pwdticket { get; set; }
        public string remark { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public Nullable<int> isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        public string ticketTypeCode { get; set; }
        public string orderNo { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual Exhibition exhibition { get; set; }

        public virtual TicketsType ticketsType { get; set; }
        //public virtual MyFavorites myfavorites { get; set; }
       
    }
}
