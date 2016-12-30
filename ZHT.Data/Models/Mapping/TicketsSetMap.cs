using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public  class TicketsSetMap:EntityTypeConfiguration<TicketsSet>
    {
        public TicketsSetMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.exhibitioncode)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.creater)
              .IsRequired()
              .HasMaxLength(50);
            this.Property(t => t.creattime)
              .IsRequired();

            this.ToTable("Business.TicketsSet");
            this.Property(t => t.namerequire).HasColumnName("namerequire");
            this.Property(t => t.phonerequire).HasColumnName("phonerequire");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
            //父表导航，子表导航，父表外键
            this.HasRequired(t => t.exhibition)
                .WithMany(t => t.ticketsset)
                .HasForeignKey(d => d.exhibitioncode);
        }
    }
}
