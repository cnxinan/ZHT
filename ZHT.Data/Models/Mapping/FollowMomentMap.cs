using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class FollowMomentMap : EntityTypeConfiguration<FollowMoment>
    {
        public FollowMomentMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.exhibitioncode)
                .IsRequired()
                .HasMaxLength(50);
            this.Property(t => t.momentcode)
                .IsRequired()
                .HasMaxLength(50);

            this.ToTable("Business.FollowMoment");
            this.Property(t => t.followtime).HasColumnName("followtime");
            this.Property(t => t.followusercode).HasColumnName("followusercode");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
            //父表导航，子表导航，父表外键
            this.HasRequired(t => t.exhibition)
                .WithMany(t => t.followmoment)
                .HasForeignKey(d => d.exhibitioncode);

            this.HasRequired(t => t.moment)
                .WithMany(t => t.followmoment)
                .HasForeignKey(d => d.momentcode);
        }
    }
}
