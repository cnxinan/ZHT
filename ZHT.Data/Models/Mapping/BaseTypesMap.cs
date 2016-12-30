using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class BaseTypesMap: EntityTypeConfiguration<BaseTypes>
    {
        public BaseTypesMap()
        {
            this.HasKey(t => t.id);

            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);

            this.ToTable("Business.BaseTypes");
            this.Property(t => t.typename).HasColumnName("typename");
            this.Property(t => t.typeid).HasColumnName("typeid");
            this.Property(t => t.typevalue).HasColumnName("typevalue");
            this.Property(t => t.creater).HasColumnName("creater");
            this.Property(t => t.creattime).HasColumnName("creattime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");


        }
    }
}

