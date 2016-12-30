using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class SellerOrderDetailsMap:EntityTypeConfiguration<SellerOrderDetails>
    {
        public SellerOrderDetailsMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.sellerordercode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.seatnocode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.creater)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.creattime)
                .IsRequired();

            this.ToTable("Business.SellerOrderDetails");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");

            this.HasRequired(t => t.seatno)
                .WithMany(t => t.sellerorderdetails)
                .HasForeignKey(d => d.seatnocode);
            this.HasRequired(t => t.sellerorder)
                .WithMany(t => t.sellerOrderDetails)
                .HasForeignKey(d => d.sellerordercode);
        }
    }
}
