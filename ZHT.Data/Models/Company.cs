using System;
using System.Collections.Generic;

namespace ZHT.Data.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyUser = new List<CompanyUser>();
        }

        public string Code { get; set; }
        public string BusinessTypeCode { get; set; }
        public string AuditStatusCode { get; set; }
        public string CnName { get; set; }
        public string Address { get; set; }
        public string BusinessLicenseNumber { get; set; }
        public string LegalPersonName { get; set; }
        public string LegalPersonMobilePhone { get; set; }
        public string LegalPersonIdentityCardNumber { get; set; }
        public string CountyCode { get; set; }
        public string Location { get; set; }
        public Nullable<int> SortNo { get; set; }
        public System.DateTime VersionEndTime { get; set; }
        public Nullable<System.DateTime> VersionStartTime { get; set; }
        public Nullable<int> Category { get; set; }
        public string ContactPerson { get; set; }
        public string Creator { get; set; }
        public string Number { get; set; }
        public bool ValidStatus { get; set; }
        public Nullable<int> EvaluationCount { get; set; }
        public Nullable<int> TotalScore { get; set; }

        public virtual ICollection<CompanyUser> CompanyUser { get; set; }

    }
}
