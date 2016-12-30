using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.API
{
    public class Client
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }     
        
        public string ClientType { get; set; }   

        public int RefreshTokenLifeTime { get; set; }
    }
}
