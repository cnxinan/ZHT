using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
   public partial class Goods
    {
        public string code { get; set; }
        public string goodsNumber { get; set; }
        public string sellerCode { get; set; }
        public string goodsName { get; set; }
        public bool isReserve { get; set; }
        public string goodsTypeCode { get; set; }
        public string goodsUnitCode { get; set; }
        public Nullable<int> oldPrice { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> commission { get; set; }
        public string intruduction { get; set; }
        public Nullable<bool> isShelves { get; set; }
        public Nullable<int> expressCharge { get; set; }
        public string creator { get; set; }
        public DateTime? createTime { get; set; }
        public string modifier { get; set; }
        public DateTime? modifyTime { get; set; }
        public Nullable<bool> validStatus { get; set; }
        public Nullable<int> linkNumber { get; set; }
        public Nullable<int> monthSalesNum { get; set; }
        public Nullable<bool> isTakeOut { get; set; }
        public Nullable<bool> isSoldOut { get; set; }
        public Nullable<bool> isRecommend { get; set; }
        public string provinceCode { get; set; }
        public string cityCode { get; set; }
        public string countyCode { get; set; }
        public Nullable<int> goodsWeight { get; set; }
        public Nullable<int> minimumQuantity { get; set; }
        public Nullable<bool> isFreightFee { get; set; }
        public string freightFeeTemplateCode { get; set; }
        public Nullable<bool> isPreSale { get; set; }
        public Nullable<bool> isCrowdfunding { get; set; }
        public string centralizedProcurementCode { get; set; }
        public Nullable<int> stockCount { get; set; }
        public Nullable<int> storageCost { get; set; }
        public Nullable<int> limitedQuantity { get; set; }
        public Nullable<bool> isLimitedNewUser { get; set; }

        public virtual BusinessScopeType businessScopeType { get; set; }

        public virtual GoodsUnit goodsUnit { get; set; }

        public virtual ICollection<OrderDetail> orderDetails { get; set; } 

    }
}
