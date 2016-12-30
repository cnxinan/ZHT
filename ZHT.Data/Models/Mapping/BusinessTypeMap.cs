﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class BusinessTypeMap : EntityTypeConfiguration<BusinessType>
    {
        public BusinessTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Code);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.ParentCode)
                .HasMaxLength(36);

            this.Property(t => t.SimpleCode)
                .HasMaxLength(10);

            this.Property(t => t.CnName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EnName)
                .HasMaxLength(50);

            this.Property(t => t.Creator)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.Modifier)
                .HasMaxLength(36);

            // Table & Column Mappings
            this.ToTable("BusinessType");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.ParentCode).HasColumnName("ParentCode");
            this.Property(t => t.SimpleCode).HasColumnName("SimpleCode");
            this.Property(t => t.CnName).HasColumnName("CnName");
            this.Property(t => t.EnName).HasColumnName("EnName");
            this.Property(t => t.Creator).HasColumnName("Creator");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.Modifier).HasColumnName("Modifier");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.ValidStatus).HasColumnName("ValidStatus");
            this.Property(t => t.SortNo).HasColumnName("SortNo");
        }
    }
}