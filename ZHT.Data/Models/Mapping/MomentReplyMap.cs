using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public  class MomentReplyMap:EntityTypeConfiguration<MomentReply>
    {
        public MomentReplyMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
               .IsRequired()
               .HasMaxLength(50);
            this.Property(t => t.momentcode)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.creater)
                .IsRequired()
                .HasMaxLength(50);

            this.ToTable("Business.MomentReply");
            this.Property(t => t.replytime).HasColumnName("replytime");
            this.Property(t => t.replycontent).HasColumnName("replycontent");
            this.Property(t => t.momentcode).HasColumnName("momentcode");
            this.Property(t => t.parentid).HasColumnName("parentid");
            this.Property(t => t.creattime).HasColumnName("creattime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
            //父表导航，子表导航，父表外键
            this.HasRequired(t => t.moment)
                .WithMany(t => t.momentreply)
                .HasForeignKey(d => d.momentcode);
        }
    }
}
