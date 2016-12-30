using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class Goods_BusinessScopeTypeMap:EntityTypeConfiguration<Goods_BusinessScopeType>
    {
        public Goods_BusinessScopeTypeMap()
        {
            this.HasKey(t => t.code);
            this.Property(t => t.code)
                .IsRequired()
                .HasMaxLength(36);
            this.ToTable("Business.Goods_BusinessScopeType");
            this.Property(t => t.goodsCode).HasColumnName("goodsCode");
            this.Property(t => t.businessScopeTypeCode).HasColumnName("businessScopeTypeCode");
            this.Property(t => t.creator).HasColumnName("creator");
            this.Property(t => t.createTime).HasColumnName("createTime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifyTime).HasColumnName("modifyTime");
            this.Property(t => t.validStatus).HasColumnName("validStatus");   
        }
    }
}
