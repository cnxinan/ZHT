using System;

namespace ZHT.Data.Models
{
    public partial class Attachment
    {
        public Attachment()
        {
        }

        public string Code { get; set; }
        public string AttachmentTypeCode { get; set; }
        public string ResourceID { get; set; }
        public string CnName { get; set; }
        public string Suffix { get; set; }
        public string URL { get; set; }
        public Nullable<int> FileSize { get; set; }
        public string Creator { get; set; }
        public System.DateTime VersionEndTime { get; set; }
        public Nullable<System.DateTime> VersionStartTime { get; set; }
        public bool ValidStatus { get; set; }
        public Nullable<int> SortNo { get; set; }

        public virtual AttachmentType AttachmentType { get; set; }
    }
}
