using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZHT.Data.Models.Mapping
{
    public class MaterialMap : EntityTypeConfiguration<Material>
    {
        public MaterialMap()
        {
            // Primary Key
            this.HasKey(t => t.Code);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.MaterialName)
                .HasMaxLength(256);

            this.Property(t => t.FilePath)
                .HasMaxLength(256);

            this.Property(t => t.Creator)
                .HasMaxLength(36);

            this.Property(t => t.Modifier)
                .HasMaxLength(36);

            // Table & Column Mappings
            this.ToTable("Material", "Business");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.MaterialType).HasColumnName("MaterialType");
            this.Property(t => t.MaterialName).HasColumnName("MaterialName");
            this.Property(t => t.Content).HasColumnName("Content");
            this.Property(t => t.FilePath).HasColumnName("FilePath");
            this.Property(t => t.Creator).HasColumnName("Creator");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Modifier).HasColumnName("Modifier");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ValidStatus).HasColumnName("ValidStatus");
        }
    }
}
