using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public  class GoodsMap:EntityTypeConfiguration<Goods>
    {
        public GoodsMap()
        {
            this.HasKey(t => t.code);
            this.Property(t => t.code)
                .IsRequired()
                .HasMaxLength(36);
            this.ToTable("Business.Goods");
            this.Property(t => t.goodsNumber).HasColumnName("goodsNumber");
            this.Property(t => t.sellerCode).HasColumnName("sellerCode");
            this.Property(t => t.goodsName).HasColumnName("goodsName");
            this.Property(t => t.isReserve).HasColumnName("isReserve");
            this.Property(t => t.goodsTypeCode).HasColumnName("goodsTypeCode");
            this.Property(t => t.goodsUnitCode).HasColumnName("goodsUnitCode");
            this.Property(t => t.oldPrice).HasColumnName("oldPrice");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.commission).HasColumnName("commission");
            this.Property(t => t.intruduction).HasColumnName("intruduction");
            this.Property(t => t.isShelves).HasColumnName("isShelves");
            this.Property(t => t.expressCharge).HasColumnName("expressCharge");
            this.Property(t => t.createTime).HasColumnName("createTime");
            this.Property(t => t.creator).HasColumnName("creator");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifyTime).HasColumnName("modifyTime");
            this.Property(t => t.validStatus).HasColumnName("validStatus");
            this.Property(t => t.linkNumber).HasColumnName("linkNumber");
            this.Property(t => t.monthSalesNum).HasColumnName("monthSalesNum");
            this.Property(t => t.isTakeOut).HasColumnName("isTakeOut");
            this.Property(t => t.isSoldOut).HasColumnName("isSoldOut");
            this.Property(t => t.isRecommend).HasColumnName("isRecommend");
            this.Property(t => t.provinceCode).HasColumnName("provinceCode");
            this.Property(t => t.cityCode).HasColumnName("cityCode");
            this.Property(t => t.countyCode).HasColumnName("countyCode");
            this.Property(t => t.goodsWeight).HasColumnName("goodsWeight");
            this.Property(t => t.minimumQuantity).HasColumnName("minimumQuantity");
            this.Property(t => t.isFreightFee).HasColumnName("isFreightFee");
            this.Property(t => t.freightFeeTemplateCode).HasColumnName("freightFeeTemplateCode");
            this.Property(t => t.isPreSale).HasColumnName("isPreSale");
            this.Property(t => t.isCrowdfunding).HasColumnName("isCrowdfunding");
            this.Property(t => t.centralizedProcurementCode).HasColumnName("centralizedProcurementCode");
            this.Property(t => t.stockCount).HasColumnName("stockCount");
            this.Property(t => t.storageCost).HasColumnName("storageCost");
            this.Property(t => t.limitedQuantity).HasColumnName("limitedQuantity");
            this.Property(t => t.isLimitedNewUser).HasColumnName("isLimitedNewUser");

            this.HasRequired(t => t.businessScopeType)
                .WithMany(t => t.goods)
                .HasForeignKey(d => d.goodsTypeCode);

            this.HasRequired(t => t.goodsUnit)
                .WithMany(t => t.goods)
                .HasForeignKey(d => d.goodsUnitCode);
        }

    }
}
