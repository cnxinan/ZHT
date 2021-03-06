﻿using System;
using System.Collections.Generic;

namespace ZHT.Data.Models
{
    public partial class AttachmentType
    {
        public AttachmentType()
        {
        }

        public string Code { get; set; }
        public string CnName { get; set; }
        public string EnName { get; set; }
        public string Creator { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string Modifier { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public bool ValidStatus { get; set; }
        public Nullable<int> SortNo { get; set; }

        public virtual ICollection<Attachment> Attachment { get; set; }
    }
}
