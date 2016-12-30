using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.TicketContract
{
    public class CheckoutTicketFormat : TicketFormatBase
    {
        public override EnumTicketType TicketType
        {
            get { return EnumTicketType.Bill; }
        }
        
        /// <summary>
        /// 收银员
        /// </summary>
        public string CashierPerson { get; set; }

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
        /// 会员余额
        /// </summary>
        public decimal MembershipCardBanlance { get; set; }

        /// <summary>
        /// 会员积分
        /// </summary>
        public decimal MembershipPoint { get; set; }
        
        /// <summary>
        /// 消费清单
        /// </summary>
        public List<CheckoutTicketFormatItem> ListItems { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 整单优惠
        /// </summary>
        public decimal OrderDiscountAmount { get; set; }
        /// <summary>
        /// 抹零
        /// </summary>
        public decimal EraseAmount { get; set; }
        /// <summary>
        /// 应付金额
        /// </summary>
        public decimal PayableAmount { get; set; }
        /// <summary>
        /// 微信支付金额
        /// </summary>
        public decimal WeixinAmount { get; set; }
        /// <summary>
        /// 现金支付金额
        /// </summary>
        public decimal CashAmount { get; set; }
        /// <summary>
        /// 储蓄卡金额
        /// </summary>
        public decimal DebitAmount { get; set; }
        /// <summary>
        /// 信用卡金额
        /// </summary>
        public decimal CreditAmount { get; set; }
        /// <summary>
        /// 会员卡支付金额
        /// </summary>
        public decimal MembershipAmount { get; set; }
        /// <summary>
        /// 团购支付金额
        /// </summary>
        public decimal GroupBuyingAmount { get; set; }
        /// <summary>
        /// 其他支付
        /// </summary>
        public decimal ElseAmount { get; set; }

        /// <summary>
        /// 找零
        /// </summary>
        public decimal Change { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        public decimal ServiceFee { get; set; }
        /// <summary>
        /// 其它金额
        /// </summary>
        public decimal OtherAmount { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public int PeopleCount { get; set; }
        /// <summary>
        /// 开单时间
        /// </summary>
        public DateTime OpenOrderDate { get; set; }

        /// <summary>
        /// 赠送金额
        /// </summary>
        public decimal GivingAmount { get; set; }
    }
    public class CheckoutTicketFormatItem
    {
        /// <summary>
        /// 品名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 折后价
        /// </summary>
        public decimal DPrice { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
    }
}
