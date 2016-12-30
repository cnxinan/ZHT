using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class NotifyMap:EntityTypeConfiguration<Notify>
    {
        public NotifyMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.creater)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.creattime)
               .IsRequired();

            this.ToTable("Business.Notify");
            this.Property(t => t.notifytime).HasColumnName("notifytime");
            this.Property(t => t.notifytype).HasColumnName("notifytype");
            this.Property(t => t.notifycontent).HasColumnName("notifycontent");
            this.Property(t => t.usercode).HasColumnName("usercode");
            this.Property(t => t.remark).HasColumnName("remark");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
        }
    }
}
