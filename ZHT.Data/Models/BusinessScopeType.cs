using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class BusinessScopeType
    {
        public BusinessScopeType()
        {
            this.goods = new List<Goods>();
        }
        public string code { get; set; }
        public string goodsTypeName { get; set; }
        public string businessScopeCode { get; set; }
        public string creator { get; set; }
        public DateTime? createTime { get; set; }
        public string modifier { get; set; }
        public DateTime? modifyTime { get; set; }
        public bool validStatus { get; set; }
        public Nullable<int> sortNumber { get; set; }

        public virtual BusinessScope businessScope { get; set; }

        public virtual ICollection<Goods> goods { get; set; }

    }
}
