using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.Logging
{
    public class Log
    {
        public string BusinessCode { get; set; }
        public string IpAddress { get; set; }

        public int OperateId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }


    }
}
