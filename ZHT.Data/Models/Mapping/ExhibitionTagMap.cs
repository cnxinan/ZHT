using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class ExhibitionTagMap:EntityTypeConfiguration<ExhibitionTag>
    {
        public ExhibitionTagMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);
            this.ToTable("Business.ExhibitionTag");
            this.Property(t => t.tagname).HasColumnName("tagname");
            this.Property(t => t.tagremark).HasColumnName("tagremark");
            this.Property(t => t.creater).HasColumnName("creater");
            this.Property(t => t.creattime).HasColumnName("creattime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
            //父表导航，子表导航，父表外键
            this.HasRequired(t => t.exhibition)
                .WithMany(t => t.exhibitiontag)
                .HasForeignKey(d => d.exhibitioncode);
        }
    }
}
