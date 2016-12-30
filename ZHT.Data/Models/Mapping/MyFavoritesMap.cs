using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class MyFavoritesMap:EntityTypeConfiguration<MyFavorites>
    {
        public MyFavoritesMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.usercode)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.favoritescode)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.creater)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.types)
              .IsRequired();
            
            this.ToTable("Business.MyFavorites");
            this.Property(t => t.favoritestime).HasColumnName("favoritestime");
            this.Property(t => t.creattime).HasColumnName("creattime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");

            this.HasRequired(t => t.exhibitions)
               .WithMany(t => t.myfavorites)
               .HasForeignKey(d => d.favoritescode);
        }
    }
}
