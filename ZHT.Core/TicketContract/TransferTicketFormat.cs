using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.TicketContract
{
    public class TransferTicketFormat : TicketFormatBase
    {
        public override EnumTicketType TicketType
        {
            get { return EnumTicketType.TransferBill; }
        }

        /// <summary>
        /// 转出桌位号
        /// </summary>
        public string OutTableName { get; set; } 

        /// <summary>
        /// 转入桌位号
        /// </summary>
        public string IntoTableName { get; set; }

        /// <summary>
        /// 开单时间
        /// </summary>
        public DateTime OpenOrderDate { get; set; }
        /// <summary>
        /// 点单员
        /// </summary>
        public string CreatePerson { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public int PeopleCount { get; set; }
    }
}
