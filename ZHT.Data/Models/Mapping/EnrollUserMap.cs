using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class EnrollUserMap:EntityTypeConfiguration<EnrollUser>
    {
        public EnrollUserMap()
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
            
            this.ToTable("Business.EnrollUser");
            this.Property(t => t.enrolltime).HasColumnName("enrolltime");
            this.Property(t => t.nickname).HasColumnName("nickname");
            this.Property(t => t.sname).HasColumnName("sname");
            this.Property(t => t.sphone).HasColumnName("sphone");
            this.Property(t => t.ticketstatus).HasColumnName("ticketstatus");
            this.Property(t => t.pwdticket).HasColumnName("pwdticket");
            this.Property(t => t.remark).HasColumnName("remark");
            this.Property(t => t.creattime).HasColumnName("creattime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
            this.Property(t => t.ticketTypeCode).HasColumnName("ticketTypeCode");
            this.Property(t => t.orderNo).HasColumnName("orderNo");
            //子表导航 父表导航 ，父表外键
            this.HasRequired(t => t.exhibition)
                .WithMany(t => t.enrolluser)
                .HasForeignKey(t => t.exhibitioncode);

            this.HasRequired(t => t.ticketsType)
                .WithMany(t => t.enrollusers)
                .HasForeignKey(t => t.ticketTypeCode);
        }
    }
}
