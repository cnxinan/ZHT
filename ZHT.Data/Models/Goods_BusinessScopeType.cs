using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class Goods_BusinessScopeType
    {
        public Goods_BusinessScopeType()
        {
        }
        public string code { get; set; }
        public string goodsCode { get; set; }
        public string businessScopeTypeCode { get; set; }
        public string creator { get; set; }
        public DateTime? createTime { get; set; }
        public string modifier { get; set; }
        public DateTime? modifyTime { get; set; }
        public bool validStatus { get; set; }


        public virtual BusinessScopeType businessScopeType { get; set; }
    }
}
