using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.TicketContract
{
    public class TempCheckoutTicketFormat : TicketFormatBase
    {
        public override EnumTicketType TicketType
        {
            get { return EnumTicketType.TemplateBill; }
        }
        /// <summary>
        /// 会员名称
        /// </summary>
        public string MembershipName { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string MembershipCardNumber { get; set; }
        /// <summary>
        /// 台号
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 消费清单
        /// </summary>
        public List<CheckoutTicketFormatItem> ListItems { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 服务费
        /// </summary>
        public decimal ServiceFee { get; set; }
    }
}
