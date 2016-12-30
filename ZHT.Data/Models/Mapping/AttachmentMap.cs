using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class AttachmentMap : EntityTypeConfiguration<Attachment>
    {
        public AttachmentMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Code, t.VersionEndTime });

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.ResourceID)
                .HasMaxLength(36);

            this.Property(t => t.CnName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AttachmentTypeCode)
                .HasMaxLength(50);

            this.Property(t => t.URL)
                .HasMaxLength(256);

            this.Property(t => t.Creator)
                .IsRequired()
                .HasMaxLength(36);       

            this.Property(t => t.Suffix)
                .HasMaxLength(50);

            

            // Table & Column Mappings
            this.ToTable("Business.Attachment");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.ResourceID).HasColumnName("ResourceID");
            this.Property(t => t.AttachmentTypeCode).HasColumnName("AttachmentTypeCode");
            this.Property(t => t.CnName).HasColumnName("CnName");
            this.Property(t => t.URL).HasColumnName("URL");
            this.Property(t => t.FileSize).HasColumnName("FileSize");
            this.Property(t => t.Creator).HasColumnName("Creator");
            this.Property(t => t.ValidStatus).HasColumnName("ValidStatus");
            this.Property(t => t.SortNo).HasColumnName("SortNo");
            this.Property(t => t.Suffix).HasColumnName("Suffix");
            this.Property(t => t.VersionEndTime).HasColumnName("VersionEndTime");
            this.Property(t => t.VersionStartTime).HasColumnName("VersionStartTime");

            this.HasRequired(t => t.AttachmentType)
                .WithMany(t => t.Attachment)
                .HasForeignKey(t => t.AttachmentTypeCode);

        }
    }
}
