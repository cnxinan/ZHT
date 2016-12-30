using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class TicketsTypeMap:EntityTypeConfiguration<TicketsType>
    {
        public TicketsTypeMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.ticketssetcode)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.creater)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.creattime)
                .IsRequired();

            this.ToTable("Business.TicketsType");
            this.Property(t => t.ticketname).HasColumnName("ticketname");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.quota).HasColumnName("quota");
            this.Property(t => t.privilege).HasColumnName("privilege");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
            //父表导航，子表导航，父表外键
            this.HasRequired(t => t.ticketset)
                .WithMany(t => t.tickettype)
                .HasForeignKey(d => d.ticketssetcode);
        }
    }
}
