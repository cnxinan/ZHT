using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class BusinessScopeMap:EntityTypeConfiguration<BusinessScope>
    {
         public BusinessScopeMap()
        {
            this.HasKey(t => t.code);

            this.Property(t => t.code)
                .IsRequired()
                .HasMaxLength(36);
            this.ToTable("Business.BusinessScope");
            this.Property(t => t.businessScopeName).HasColumnName("businessScopeName");
            this.Property(t => t.creator).HasColumnName("creator");
            this.Property(t => t.createtime).HasColumnName("createtime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifyTime).HasColumnName("modifyTime");
            this.Property(t => t.validStatus).HasColumnName("validStatus");

        }
    }
}
