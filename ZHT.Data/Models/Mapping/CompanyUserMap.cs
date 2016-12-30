using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public  class CompanyUserMap : EntityTypeConfiguration<CompanyUser>
    {
        public CompanyUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Code);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.CompanyCode)
                .HasMaxLength(36);

            this.Property(t => t.UserID)
                .HasMaxLength(36);


            // Table & Column Mappings
            this.ToTable("Business.CompanyUser");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.CompanyCode).HasColumnName("CompanyCode");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ValidStatus).HasColumnName("ValidStatus");
            this.Property(t => t.IsManager).HasColumnName("IsManager");
        }
    }
}
