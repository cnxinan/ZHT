using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class BankCardMap : EntityTypeConfiguration<BankCard>
    {
        public BankCardMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Code, t.CreateTime });

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.BankCardNum)
                .HasMaxLength(20);

            this.Property(t => t.BankCode)
                .HasMaxLength(36);

            this.Property(t => t.BankBranch)
                .HasMaxLength(50);

            this.Property(t => t.LocationCode)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.LocationName)
                .HasMaxLength(36);

            this.Property(t => t.Creator)
                .HasMaxLength(36);

            this.Property(t => t.Com_Code)
                .HasMaxLength(36);

            // Table & Column Mappings
            this.ToTable("Business.BankCard");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.BankCardNum).HasColumnName("BankCardNum");
            this.Property(t => t.BankCode).HasColumnName("BankCode");
            this.Property(t => t.BankBranch).HasColumnName("BankBranch");
            this.Property(t => t.LocationCode).HasColumnName("LocationCode");
            this.Property(t => t.LocationName).HasColumnName("LocationName");
            this.Property(t => t.ValidStatus).HasColumnName("ValidStatus");
            this.Property(t => t.Creator).HasColumnName("Creator");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Com_Code).HasColumnName("Com_Code");
            this.Property(t => t.Com_VersionEndTime).HasColumnName("Com_VersionEndTime");
        }
    }
}
