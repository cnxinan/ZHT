using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
  public  class BusinessScopeTypeMap:EntityTypeConfiguration<BusinessScopeType>
    {
        public BusinessScopeTypeMap()
        {
            this.HasKey(t => t.code);
            this.Property(t => t.code)
                .IsRequired()
                .HasMaxLength(36);
            this.ToTable("Business.BusinessScopeType");
            this.Property(t => t.goodsTypeName).HasColumnName("goodsTypeName");
            this.Property(t => t.businessScopeCode).HasColumnName("businessScopeCode");
            this.Property(t => t.creator).HasColumnName("creator");
            this.Property(t => t.createTime).HasColumnName("createTime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifyTime).HasColumnName("modifyTime");
            this.Property(t => t.validStatus).HasColumnName("validStatus");
            this.Property(t => t.sortNumber).HasColumnName("sortNumber");

            this.HasRequired(t => t.businessScope)
                .WithMany(t => t.businessScopTypes)
                .HasForeignKey(d => d.businessScopeCode);
        }
    }
}
