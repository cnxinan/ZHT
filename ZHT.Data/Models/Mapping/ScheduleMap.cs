using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class ScheduleMap : EntityTypeConfiguration<Schedule>
    {
        public ScheduleMap()
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

            this.ToTable("Business.Schedule");
            this.Property(t => t.stime).HasColumnName("stime");

            this.Property(t => t.starttime).HasColumnName("starttime");
            this.Property(t => t.endtime).HasColumnName("endtime");
            this.Property(t => t.schedulename).HasColumnName("schedulename");
            this.Property(t => t.scheduledesc).HasColumnName("scheduledesc");
            this.Property(t => t.creattime).HasColumnName("creattime"); this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
            //父表导航，子表导航，父表外键
            this.HasRequired(t => t.exhibition)
                .WithMany(t => t.schedule)
                .HasForeignKey(d => d.exhibitioncode);
        }
    }
}
