using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class ExhibitionMap : EntityTypeConfiguration<Exhibition>
    {
        public ExhibitionMap()
        {
            this.HasKey(t => t.id);

            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.businessid)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.creater)
                .IsRequired()
                .HasMaxLength(50);

            this.ToTable("Business.Exhibition");
            this.Property(t => t.exhibitionname).HasColumnName("exhibitionname");
            this.Property(t => t.basetypescode).HasColumnName("basetypescode");
            this.Property(t => t.nocolumn).HasColumnName("nocolumn");
            this.Property(t => t.starttime).HasColumnName("starttime");
            this.Property(t => t.endtime).HasColumnName("endtime");
            this.Property(t => t.address1).HasColumnName("address1");
            this.Property(t => t.address2).HasColumnName("address2");
            this.Property(t => t.longitude).HasColumnName("longitude");
            this.Property(t => t.latitude).HasColumnName("latitude");
            this.Property(t => t.detailes).HasColumnName("detailes");
            this.Property(t => t.recruitstatus).HasColumnName("recruitstatus");
            this.Property(t => t.enrollstatus).HasColumnName("enrollstatus");
            this.Property(t => t.businessname).HasColumnName("businessname");
            this.Property(t => t.publishedtime).HasColumnName("publishedtime");
            this.Property(t => t.recruitendtime).HasColumnName("recruitendtime");
            this.Property(t => t.enrollstarttime).HasColumnName("enrollstarttime");
            this.Property(t => t.enrollendtime).HasColumnName("enrollendtime");
            this.Property(t => t.lowdiscount).HasColumnName("lowdiscount");
            this.Property(t => t.saleproportion).HasColumnName("saleproportion");
            this.Property(t => t.creattime).HasColumnName("creattime");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.modifiytime).HasColumnName("modifiytime");
            this.Property(t => t.isdel).HasColumnName("isdel");
            this.Property(t => t.temp1).HasColumnName("temp1");
            this.Property(t => t.temp2).HasColumnName("temp2");
            this.Property(t => t.province).HasColumnName("province");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.area).HasColumnName("area");
            //父表导航属性，子表导航属性，父表外键

            this.HasRequired(t => t.basetypes)
                .WithMany(t => t.exhibiton)
                .HasForeignKey(d => d.basetypescode);

           

        }
    }
}
