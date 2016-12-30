using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class CompanyMap : EntityTypeConfiguration<Company>
    {
        public CompanyMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Code, t.VersionEndTime });

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.CnName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(200);

            this.Property(t => t.BusinessLicenseNumber)
                .HasMaxLength(50);

            this.Property(t => t.LegalPersonName)
                .HasMaxLength(50);

            this.Property(t => t.LegalPersonMobilePhone)
                .HasMaxLength(15);

            this.Property(t => t.LegalPersonIdentityCardNumber)
                .HasMaxLength(50);

            this.Property(t => t.CountyCode)
                .HasMaxLength(36);

            this.Property(t => t.Location)
                .HasMaxLength(50);

            this.Property(t => t.ContactPerson)
                .HasMaxLength(128);

            this.Property(t => t.Creator)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.BusinessTypeCode)
                .HasMaxLength(36);

            this.Property(t => t.AuditStatusCode)
                .HasMaxLength(36);

            // Table & Column Mappings
            this.ToTable("Business.Company");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.CnName).HasColumnName("CnName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.BusinessLicenseNumber).HasColumnName("BusinessLicenseNumber");
            this.Property(t => t.LegalPersonName).HasColumnName("LegalPersonName");
            this.Property(t => t.LegalPersonMobilePhone).HasColumnName("LegalPersonMobilePhone");
            this.Property(t => t.LegalPersonIdentityCardNumber).HasColumnName("LegalPersonIdentityCardNumber");
            this.Property(t => t.CountyCode).HasColumnName("CityCode");
            this.Property(t => t.Location).HasColumnName("Location");
            this.Property(t => t.ContactPerson).HasColumnName("ContactPerson");
            this.Property(t => t.Creator).HasColumnName("Creator");
            this.Property(t => t.ValidStatus).HasColumnName("ValidStatus");
            this.Property(t => t.SortNo).HasColumnName("SortNo");
            this.Property(t => t.VersionEndTime).HasColumnName("VersionEndTime");
            this.Property(t => t.BusinessTypeCode).HasColumnName("BusinessTypeCode");
            this.Property(t => t.AuditStatusCode).HasColumnName("AuditStatusCode");
            this.Property(t => t.VersionStartTime).HasColumnName("VersionStartTime");
        }
    }
}
