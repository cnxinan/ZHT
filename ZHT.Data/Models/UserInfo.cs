using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class UserInfo
    {
        public string Code { get; set; }
        public string Nickname { get; set; }
        public string HeadImage { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Signature { get; set; }
        public string RealName { get; set; }
        public string IDNumber { get; set; }
        public string UserType { get; set; }
        public string AuditStatus { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<bool> IsValid { get; set; }
        public Nullable<int> FollowerNo { get; set; }
        public Nullable<int> FocusNo { get; set; }
        public Nullable<int> CollectNo { get; set; }
        public Nullable<int> LaunchNo { get; set; }
        public Nullable<int> SupportNo { get; set; }
        public Nullable<int> PointTotal { get; set; }
        public Nullable<int> NewMessage { get; set; }
        public Nullable<int> FriendNo { get; set; }
        public Nullable<int> PraiseNo { get; set; }
        public Nullable<int> FriendApply { get; set; }
        public Nullable<bool> IsApplay { get; set; }
        public Nullable<int> ApplayNo { get; set; }
        public Nullable<int> BankCardNo { get; set; }
        public Nullable<System.DateTime> DynamicTime { get; set; }
        public Nullable<System.DateTime> TaskTime { get; set; }
        public Nullable<bool> IsLifer { get; set; }
    }
}
