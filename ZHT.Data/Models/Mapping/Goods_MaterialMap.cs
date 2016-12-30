using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ZHT.Data.Models.Mapping
{
    public class Goods_MaterialMap : EntityTypeConfiguration<Goods_Material>
    {
        public Goods_MaterialMap()
        {
            // Primary Key
            this.HasKey(t => t.Code);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.GoodsCode)
                .HasMaxLength(36);

            this.Property(t => t.MaterialCode)
                .HasMaxLength(36);

            this.Property(t => t.Creator)
                .HasMaxLength(36);

            this.Property(t => t.Modifier)
                .HasMaxLength(36);

            // Table & Column Mappings
            this.ToTable("Goods_Material", "Business");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.GoodsCode).HasColumnName("GoodsCode");
            this.Property(t => t.MaterialCode).HasColumnName("MaterialCode");
            this.Property(t => t.Creator).HasColumnName("Creator");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Modifier).HasColumnName("Modifier");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ValidStatus).HasColumnName("ValidStatus");
        }
    }
}
