using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
   public partial class Order
    {
        public Order()
        {
            this.orderDetails = new List<OrderDetail>();
        }
        public string code { get; set; }
        public string orderNumber { get; set; }
        public string wxUnifiedOrderNum { get; set; }
        public string businessUserCode { get; set; }
        public string sharedBusinessUserCode { get; set; }
        public string sellerCode { get; set; }
        public string sellerNumber { get; set; }
        public string sellerName { get; set; }
        public Nullable<int> orderType { get; set; }
        public string customerName { get; set; }
        public string telephone { get; set; }
        public Nullable<int> sex { get; set; }
        public string businessUserAddress { get; set; }
        public DateTime? createTime { get; set; }
        public DateTime? customerDate { get; set; }
        public string customerTime { get; set; }
        public Nullable<int> orderFrom { get; set; }
        public Nullable<int> pyteType { get; set; }
        public Nullable<int> serviceCharge { get; set; }
        public Nullable<int> storageCharge { get; set; }
        public Nullable<int> charge { get; set; }
        public Nullable<int> totalCharge { get; set; }
        public Nullable<int> balancePay { get; set; }
        public Nullable<int> cardVoucherPay { get; set; }
        public Nullable<int> realPay { get; set; }
        public DateTime? sendTime { get; set; }
        public DateTime? completeTime { get; set; }
        public string expressNum { get; set; }
        public string customerMessage { get; set; }
        public Nullable<int> peopleNum { get; set; }
        public string deskNumCode { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> quantity { get; set; }
        public bool needInvoice { get; set; }
        public string invoiceTitle { get; set; }
        public Nullable<int> invoiceType { get; set; }
        public Nullable<int> invoiceContent { get; set; }
        public DateTime? modifyTime { get; set; }
        public bool isDelete { get; set; }
        public bool validStatus { get; set; }
        public string modifier { get; set; }
        public string creator { get; set; }
        public string sellerDiscountCode { get; set; }
        public DateTime? confirmTime { get; set; }
        public Nullable<int> discountCharge { get; set; }
        public string courierCode { get; set; }
        public string courierUserName { get; set; }
        public string courierTelephone { get; set; }
        public Nullable<int> expressType { get; set; }
        public Nullable<int> transportMethod { get; set; }
        public Nullable<int> realRefundPay { get; set; }
        public string groupPurchaseCode { get; set; }
        public Nullable<int> platformCardVoucherPay { get; set; }
        public string preSaleCode { get; set; }
        public string crowdfundingCode { get; set; }
        public string freightCode { get; set; }
        public string storeSharingOrderCode { get; set; }
        public bool isSelfPickup { get; set; }
        public string selfPickupAddressCode { get; set; }
        public string selfPickupAddressName { get; set; }
        public Nullable<int> shoppingCardPay { get; set; }
        public Nullable<int> sumCommission { get; set; }

        public virtual ICollection<OrderDetail> orderDetails { get; set; }
    }
}
