using System;

namespace ZHT.Data.Models
{
    public partial class ContentInfo
    {
        public ContentInfo()
        {
        }

        public string Code { get; set; }
        public string Con_Code { get; set; }
        public string CompanyCode { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }
        public System.DateTime CreateTime { get; set; }
        public bool ValidStatus { get; set; }
        public Nullable<int> Hit { get; set; }

        public virtual ContentType ContentType { get; set; }
    }
}
