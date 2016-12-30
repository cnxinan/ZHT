using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.TicketContract
{
    public class RefundTicketFormat : TicketFormatBase
    {
        public override EnumTicketType TicketType
        {
            get { return EnumTicketType.RefundBill; }
        }
        /// <summary>
        /// 台号
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 开单时间
        /// </summary>
        public DateTime OpenOrderDate { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public int PeopleCount { get; set; }
        /// <summary>
        /// 点单员
        /// </summary>
        public string CreatePerson { get; set; }
        /// <summary>
        /// 产品明细
        /// </summary>
        public List<KichenPlaySubItem> SubItems { get; set; }
    }
}
