using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class OrderDetailMap:EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailMap()
        {
            this.HasKey(t => t.code);
            this.Property(t => t.code)
                .IsRequired()
                .HasMaxLength(36);
            this.ToTable("Business.OrderDetail");
            this.Property(t => t.openID).HasColumnName("openID");
            this.Property(t => t.orderCode).HasColumnName("orderCode");
            this.Property(t => t.goodsCode).HasColumnName("goodsCode");
            this.Property(t => t.goodsName).HasColumnName("goodsName");
            this.Property(t => t.sharedBusinessUserCode).HasColumnName("sharedBusinessUserCode");
            this.Property(t => t.goodsCount).HasColumnName("goodsCount");
            this.Property(t => t.charge).HasColumnName("charge");
            this.Property(t => t.userName).HasColumnName("userName");
            this.Property(t => t.remark).HasColumnName("remark");
            this.Property(t => t.createTime).HasColumnName("createTime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifyTime).HasColumnName("modifyTime");
            this.Property(t => t.validStatus).HasColumnName("validStatus");

            this.HasRequired(t => t.order)
                .WithMany(t => t.orderDetails)
                .HasForeignKey(d => d.orderCode);

            this.HasRequired(t => t.goods)
                .WithMany(t => t.orderDetails)
                .HasForeignKey(d => d.goodsCode);
        }
    }
}
