using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.Logging
{
    public class LoginLog : Log
    {
        public int UserId { get; set; }
        public string LoginStatus { get; set; }
    }
}
