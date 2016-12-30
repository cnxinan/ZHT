using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class OrderDetail
    {
        public string code { get; set; }
        public string openID { get; set; }
        public string orderCode { get; set; }
        public string goodsCode { get; set; }
        public string goodsName { get; set; }
        public string sharedBusinessUserCode { get; set; }
        public Nullable<int> goodsCount { get; set; }
        public Nullable<int> charge { get; set; }
        public string userName { get; set; }
        public string remark { get; set; }
        public DateTime? createTime { get; set; }
        public string modifier { get; set; }
        public DateTime? modifyTime { get; set; }
        public bool validStatus { get; set; }

        public virtual Order order { get; set; }

        public virtual Goods goods { get; set; }
    }
}
