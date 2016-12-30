using System;
using System.Collections.Generic;

namespace ZHT.Data.Models
{
    public partial class CompanyUser
    {
        public CompanyUser()
        {
            Company = new List<Company>();
        }

        public string Code { get; set; }
        public string CompanyCode { get; set; }
        public string UserID { get; set; }
        public bool ValidStatus { get; set; }
        public Nullable<bool> IsManager { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<Company> Company { get; set; }
    }
}
