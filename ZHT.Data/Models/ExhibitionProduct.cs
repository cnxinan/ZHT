using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class ExhibitionProduct
    {
        public string id { get; set; }
        public string sellercode { get; set; }
        public string exhibitioncode { get; set; }
        public string yxproductcode { get; set; }
        public string unit { get; set; }
        public string exhibitionproductclasscode { get; set; }
        public decimal nprice { get; set; }
        public decimal oprice { get; set; }
        public int quantity { get; set; }
        public string pdetails { get; set; }
        public int pstatus { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public int isdel { get; set; }
        public string remark { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        public string productName { get; set; }
    }
}
