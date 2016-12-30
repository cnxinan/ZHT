using System;
using System.Collections.Generic;

namespace ZHT.Data.Models
{
    public partial class Material
    {
        public string Code { get; set; }
        public Nullable<int> MaterialType { get; set; }
        public string MaterialName { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Modifier { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> ValidStatus { get; set; }
    }
}
