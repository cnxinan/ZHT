using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.TicketContract
{
    public class BusinessDailyTicketFormat : TicketFormatBase
    {
        public override EnumTicketType TicketType
        {
            get { return EnumTicketType.BusinessDaily; }
        }
        public BusinessDailyTicketFormat()
        {
            MemberRecharge = new PayItem();
            BusinessCredit = new PayItem();
            DiscountStatistical = new PayItem();
        }
        /// <summary>
        /// 门店Image
        /// </summary>
        public string StoreImage{ get; set; }
        /// <summary>
        /// 门店信息
        /// </summary>
        public string StoreInfo { get; set; }
        /// <summary>
        /// 日期信息
        /// </summary>
        public string DateInfo { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// 应收金额
        /// </summary>
        public decimal PayableAmount { get; set; }
        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal DiscountAmount { get; set; }
        /// <summary>
        /// 净收金额
        /// </summary>
        public decimal CleanAmount { get; set; }
        /// <summary>
        /// 实收金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 现金金额
        /// </summary>
        public decimal CashAmount { get; set; }
        /// <summary>
        /// 赠送金额
        /// </summary>
        public decimal GivingAmount { get; set; }

        /// <summary>
        /// 会员卡充值
        /// </summary>
        public PayItem MemberRecharge { get; set; }
        /// <summary>
        /// 营业收款
        /// </summary>
        public PayItem BusinessCredit { get; set; }
        /// <summary>
        /// 优惠统计
        /// </summary>
        public PayItem DiscountStatistical { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string CreatePerson { get; set; }
        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime PrintDate { get; set; }
        /// <summary>
        /// 人次
        /// </summary>
        public int PersonCount { get; set; }
        /// <summary>
        /// 订单数
        /// </summary>
        public int OrdersCount { get; set; }
        /// <summary>
        /// 人均消费
        /// </summary>
        public decimal Average { get; set; }
    }
    public class PayItem
    {
        public PayItem()
        {
            ItmInfoList = new List<ItmInfo>();
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        public List<ItmInfo> ItmInfoList { get; set; }
      
    }
    public class ItmInfo
    {
        public string Name { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
        
    }
}
