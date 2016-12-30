using System;
using System.Collections.Generic;

namespace ZHT.Data.Models
{
    public partial class Goods_Material
    {
        public Goods_Material()
        {
        }

        public string Code { get; set; }
        public string GoodsCode { get; set; }
        public string MaterialCode { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Modifier { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> ValidStatus { get; set; }
    }
}
