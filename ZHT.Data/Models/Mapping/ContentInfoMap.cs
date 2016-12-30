using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class ContentInfoMap : EntityTypeConfiguration<ContentInfo>
    {
        public ContentInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.Code);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.Con_Code)
                .HasMaxLength(36);

            this.Property(t => t.CompanyCode)
                .HasMaxLength(36);

            this.Property(t => t.Title)
                .HasMaxLength(100);

            this.Property(t => t.Creator)
                .IsRequired()
                .HasMaxLength(36);

            // Table & Column Mappings
            this.ToTable("Business.ContentInfo");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Con_Code).HasColumnName("Con_Code");
            this.Property(t => t.CompanyCode).HasColumnName("CompanyCode");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.Creator).HasColumnName("Creator");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ValidStatus).HasColumnName("ValidStatus");
            this.Property(t => t.Hit).HasColumnName("Hit");

            this.HasRequired(t => t.ContentType)
                .WithMany(t => t.ContentInfo)
                .HasForeignKey(t => t.Con_Code);
        }
    }
}
