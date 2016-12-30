using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class ExhibitionProductClassMap:EntityTypeConfiguration<ExhibitionProductClass>
    {
        public ExhibitionProductClassMap()
        {
            this.HasKey(t => t.id);

            this.Property(t => t.id)
                .IsRequired();
            this.ToTable("Business.ExhibitionProductClass");
            this.Property(t => t.classname).HasColumnName("classname");

            this.Property(t => t.exhibitioncode).HasColumnName("exhibitioncode");

            this.Property(t => t.classremark).HasColumnName("classremark");

            this.Property(t => t.creater).HasColumnName("creater");

            this.Property(t => t.creattime).HasColumnName("creattime");

            this.Property(t => t.modifier).HasColumnName("modifier");

            this.Property(t => t.modifiytime).HasColumnName("modifiytime");

            this.Property(t => t.isdel).HasColumnName("isdel");

            this.Property(t => t.temp1).HasColumnName("temp1");

            this.Property(t => t.temp2).HasColumnName("temp2");
            //父表导航，子表导航，父表外键
            this.HasRequired(t => t.exhibition)
                .WithMany(t => t.exhibitionproductclass)
                .HasForeignKey(d => d.exhibitioncode);            
        }
    }
}
