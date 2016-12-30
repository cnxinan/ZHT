using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.Code);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.Nickname)
                .HasMaxLength(50);

            this.Property(t => t.HeadImage)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(11);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Gender)
                .HasMaxLength(10);

            this.Property(t => t.Province)
                .HasMaxLength(36);

            this.Property(t => t.City)
                .HasMaxLength(36);

            this.Property(t => t.Signature)
                .HasMaxLength(50);

            this.Property(t => t.RealName)
                .HasMaxLength(10);

            this.Property(t => t.IDNumber)
                .HasMaxLength(18);

            this.Property(t => t.UserType)
                .HasMaxLength(10);

            this.Property(t => t.AuditStatus)
                .HasMaxLength(10);

            this.Property(t => t.Creator)
                .HasMaxLength(36);

            // Table & Column Mappings
            this.ToTable("zc.UserInfo");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Nickname).HasColumnName("Nickname");
            this.Property(t => t.HeadImage).HasColumnName("HeadImage");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Province).HasColumnName("Province");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Signature).HasColumnName("Signature");
            this.Property(t => t.RealName).HasColumnName("RealName");
            this.Property(t => t.IDNumber).HasColumnName("IDNumber");
            this.Property(t => t.UserType).HasColumnName("UserType");
            this.Property(t => t.AuditStatus).HasColumnName("AuditStatus");
            this.Property(t => t.Creator).HasColumnName("Creator");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.IsValid).HasColumnName("IsValid");
            this.Property(t => t.FollowerNo).HasColumnName("FollowerNo");
            this.Property(t => t.FocusNo).HasColumnName("FocusNo");
            this.Property(t => t.CollectNo).HasColumnName("CollectNo");
            this.Property(t => t.LaunchNo).HasColumnName("LaunchNo");
            this.Property(t => t.SupportNo).HasColumnName("SupportNo");
            this.Property(t => t.PointTotal).HasColumnName("PointTotal");
            this.Property(t => t.NewMessage).HasColumnName("NewMessage");
            this.Property(t => t.FriendNo).HasColumnName("FriendNo");
            this.Property(t => t.PraiseNo).HasColumnName("PraiseNo");
            this.Property(t => t.FriendApply).HasColumnName("FriendApply");
            this.Property(t => t.IsApplay).HasColumnName("IsApplay");
            this.Property(t => t.ApplayNo).HasColumnName("ApplayNo");
            this.Property(t => t.BankCardNo).HasColumnName("BankCardNo");
            this.Property(t => t.DynamicTime).HasColumnName("DynamicTime");
            this.Property(t => t.TaskTime).HasColumnName("TaskTime");
            this.Property(t => t.IsLifer).HasColumnName("IsLifer");
        }
    }
}
