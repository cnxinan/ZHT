using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class MomentMap : EntityTypeConfiguration<Moment>
    {
        public MomentMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.publishercode)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.exhibitioncode)
               .IsRequired()
               .HasMaxLength(50);
            this.Property(t => t.creater)
              .IsRequired()
              .HasMaxLength(50);
            this.ToTable("Business.Moment");
            this.Property(t => t.pubtime).HasColumnName("pubtime");
            this.Property(t => t.pubcontent).HasColumnName("pubcontent");
            this.Property(t => t.types).HasColumnName("types");
            this.Property(t => t.publishercode).HasColumnName("publishercode");
            this.Property(t => t.exhibitioncode).HasColumnName("exhibitioncode");
            this.Property(t => t.creattime).HasColumnName("creattime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
            this.Property(t => t.viewUserIds).HasColumnName("viewUserIds");

            this.HasRequired(t => t.exhibition)
                .WithMany(t => t.moment)
                .HasForeignKey(d => d.exhibitioncode);
        }
    }
}
