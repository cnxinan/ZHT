using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class ExhibitionProductMap : EntityTypeConfiguration<ExhibitionProduct>
    {
        public ExhibitionProductMap()
        {
            this.HasKey(t => t.id);

            this.Property(t => t.sellercode)
                .IsRequired()
               .HasMaxLength(50);
            this.Property(t => t.exhibitioncode)
                .IsRequired()
               .HasMaxLength(50);
            this.Property(t => t.creater)
               .IsRequired()
              .HasMaxLength(50);
            this.ToTable("Business.ExhibitionProduct");
            this.Property(t => t.yxproductcode).HasColumnName("yxproductcode");
            this.Property(t => t.unit).HasColumnName("unit");
            this.Property(t => t.exhibitionproductclasscode).HasColumnName("exhibitionproductclasscode");
            this.Property(t => t.nprice).HasColumnName("nprice");
            this.Property(t => t.oprice).HasColumnName("oprice");
            this.Property(t => t.quantity).HasColumnName("quantity");
            this.Property(t => t.pdetails).HasColumnName("pdetails");
            this.Property(t => t.pstatus).HasColumnName("pstatus");
            this.Property(t => t.creattime).HasColumnName("creattime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.remark).HasColumnName("remark");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
            this.Property(t => t.productName).HasColumnName("productName");
        }
    }
}
