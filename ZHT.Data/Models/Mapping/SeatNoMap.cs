using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class SeatNoMap:EntityTypeConfiguration<SeatNo>
    {
        public SeatNoMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.creater)
               .IsRequired()
               .HasMaxLength(50);

            this.ToTable("Business.SeatNo");
            this.Property(t => t.seatsetcode).HasColumnName("seatsetcode");
            this.Property(t => t.seatno).HasColumnName("seatno");
            this.Property(t => t.remark).HasColumnName("remark");
            this.Property(t => t.creattime).HasColumnName("creattime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");

            this.HasRequired(t => t.seatset)
                 .WithMany(t => t.seatno)
                 .HasForeignKey(d => d.seatsetcode);
        }
    }
}
