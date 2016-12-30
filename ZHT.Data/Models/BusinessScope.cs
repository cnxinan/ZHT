using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class BusinessScope
    {
        public BusinessScope()
        {
            this.businessScopTypes = new List<BusinessScopeType>();
        }
        public string code { get; set; }
        public string businessScopeName { get; set; }
        public string creator { get; set; }
        public DateTime? createtime { get; set; }
        public string modifier { get; set; }
        public DateTime? modifyTime { get; set; }
        public bool validStatus { get; set; }

        public virtual ICollection<BusinessScopeType> businessScopTypes { get; set; }
    }
}
