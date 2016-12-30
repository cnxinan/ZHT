using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class SellerOrderMap:EntityTypeConfiguration<SellerOrder>
    {
        public SellerOrderMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);
            
            this.Property(t => t.exhibitionid)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.sellerid)
               .IsRequired()
               .HasMaxLength(50);
            this.Property(t => t.creater)
               .IsRequired()
               .HasMaxLength(50);
            this.Property(t => t.creattime)
               .IsRequired();

            this.ToTable("Business.SellerOrder");
            this.Property(t => t.enrolltime).HasColumnName("enrolltime");
            this.Property(t => t.seatsetcode).HasColumnName("seatsetcode");
            this.Property(t => t.sname).HasColumnName("sname");
            this.Property(t => t.sphone).HasColumnName("sphone");
            this.Property(t => t.totalprice).HasColumnName("totalprice");
            this.Property(t => t.paytype).HasColumnName("paytype");
            this.Property(t => t.payaccount).HasColumnName("payaccount");
            this.Property(t => t.remark).HasColumnName("remark");
            this.Property(t => t.orderno).HasColumnName("orderno");
            this.Property(t => t.sellerintro).HasColumnName("sellerintro");
            this.Property(t => t.orderstatus).HasColumnName("orderstatus");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");

            //this.HasRequired(t => t.sellerorderdetails)
            //    .WithMany(t => t.sellerorder)
            //    .HasForeignKey(d => d.id);//外键关联的是？
        }
    }
}