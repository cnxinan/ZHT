using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class BankCard
    {
        public BankCard()
        {
            
        }

        public string Code { get; set; }
        public string BankCardNum { get; set; }
        public string BankCode { get; set; }
        public string BankBranch { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public bool ValidStatus { get; set; }
        public string Creator { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string Com_Code { get; set; }
        public Nullable<System.DateTime> Com_VersionEndTime { get; set; }

        public virtual Company company { get; set; }
    }
}
