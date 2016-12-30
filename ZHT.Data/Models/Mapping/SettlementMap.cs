using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public  class SettlementMap : EntityTypeConfiguration<Settlement>
    {
        public SettlementMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired();

            this.ToTable("Business.Settlement");
            this.Property(t => t.exhibitionCode).HasColumnName("ExhibitionCode");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.amount).HasColumnName("amount");
            this.Property(t => t.creater).HasColumnName("creater");
            this.Property(t => t.creatTime).HasColumnName("creatTime");
            this.Property(t => t.isDel).HasColumnName("isDel");

            this.HasRequired(t => t.exhibition)
                .WithMany(t => t.settlement)
                .HasForeignKey(t => t.exhibitionCode);
        }
    }
}
