using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class GoodsUnit
    {
        public GoodsUnit()
        {
            this.goods = new List<Goods>();
        }
        public string code { get; set; }
        public string goodsUnitName { get; set; }
        public string remark { get; set; }
        public string SellerCode { get; set; }
        public string creator { get; set; }
        public DateTime? createTime { get; set; }
        public string modifier { get; set; }
        public DateTime? modifyTime { get; set; }
        public bool validStatus { get; set; }
        public Nullable<int> goodsUnitType { get; set; }

        public virtual ICollection<Goods> goods { get; set; }
    }
}
