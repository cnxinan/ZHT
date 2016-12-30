using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models.Mapping
{
   public class OrderMap:EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.HasKey(t => t.code);
            this.Property(t => t.code)
                .IsRequired()
                .HasMaxLength(36);
            this.ToTable("Business.Order");
            this.Property(t => t.orderNumber).HasColumnName("orderNumber");
            this.Property(t => t.wxUnifiedOrderNum).HasColumnName("wxUnifiedOrderNum");
            this.Property(t => t.businessUserCode).HasColumnName("businessUserCode");
            this.Property(t => t.sellerCode).HasColumnName("sellerCode");
            this.Property(t => t.sellerNumber).HasColumnName("sellerNumber");
            this.Property(t => t.sellerName).HasColumnName("sellerName");
            this.Property(t => t.orderType).HasColumnName("orderType");
            this.Property(t => t.customerName).HasColumnName("customerName");
            this.Property(t => t.telephone).HasColumnName("telephone");
            this.Property(t => t.sex).HasColumnName("sex");
            this.Property(t => t.businessUserAddress).HasColumnName("businessUserAddress");
            this.Property(t => t.createTime).HasColumnName("createTime");
            this.Property(t => t.customerDate).HasColumnName("customerDate");
            this.Property(t => t.customerTime).HasColumnName("customerTime");
            this.Property(t => t.orderFrom).HasColumnName("orderFrom");
            this.Property(t => t.pyteType).HasColumnName("pyteType");
            this.Property(t => t.serviceCharge).HasColumnName("serviceCharge");
            this.Property(t => t.storageCharge).HasColumnName("storageCharge");
            this.Property(t => t.charge).HasColumnName("charge");
            this.Property(t => t.totalCharge).HasColumnName("totalCharge");
            this.Property(t => t.balancePay).HasColumnName("balancePay");
            this.Property(t => t.cardVoucherPay).HasColumnName("cardVoucherPay");
            this.Property(t => t.realPay).HasColumnName("realPay");
            this.Property(t => t.sendTime).HasColumnName("sendTime");
            this.Property(t => t.completeTime).HasColumnName("completeTime");
            this.Property(t => t.expressNum).HasColumnName("expressNum");
            this.Property(t => t.customerMessage).HasColumnName("customerMessage");
            this.Property(t => t.peopleNum).HasColumnName("peopleNum");
            this.Property(t => t.deskNumCode).HasColumnName("deskNumCode");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.quantity).HasColumnName("quantity");
            this.Property(t => t.needInvoice).HasColumnName("needInvoice");
            this.Property(t => t.invoiceTitle).HasColumnName("invoiceTitle");
            this.Property(t => t.invoiceType).HasColumnName("invoiceType");
            this.Property(t => t.invoiceContent).HasColumnName("invoiceContent");
            this.Property(t => t.modifyTime).HasColumnName("modifyTime");
            this.Property(t => t.isDelete).HasColumnName("isDelete");
            this.Property(t => t.validStatus).HasColumnName("validStatus");
            this.Property(t => t.modifier).HasColumnName("modifier");
            this.Property(t => t.creator).HasColumnName("creator");
            this.Property(t => t.sellerDiscountCode).HasColumnName("sellerDiscountCode");
            this.Property(t => t.confirmTime).HasColumnName("confirmTime");
            this.Property(t => t.discountCharge).HasColumnName("discountCharge");
            this.Property(t => t.courierCode).HasColumnName("courierCode");
            this.Property(t => t.courierUserName).HasColumnName("courierUserName");
            this.Property(t => t.courierTelephone).HasColumnName("courierTelephone");
            this.Property(t => t.expressType).HasColumnName("expressType");
            this.Property(t => t.transportMethod).HasColumnName("transportMethod");
            this.Property(t => t.realRefundPay).HasColumnName("realRefundPay");
            this.Property(t => t.groupPurchaseCode).HasColumnName("groupPurchaseCode");
            this.Property(t => t.platformCardVoucherPay).HasColumnName("platformCardVoucherPay");
            this.Property(t => t.preSaleCode).HasColumnName("preSaleCode");
            this.Property(t => t.crowdfundingCode).HasColumnName("crowdfundingCode");
            this.Property(t => t.freightCode).HasColumnName("freightCode");
            this.Property(t => t.storeSharingOrderCode).HasColumnName("storeSharingOrderCode");
            this.Property(t => t.isSelfPickup).HasColumnName("isSelfPickup");
            this.Property(t => t.selfPickupAddressCode).HasColumnName("selfPickupAddressCode");
            this.Property(t => t.selfPickupAddressName).HasColumnName("selfPickupAddressName");
            this.Property(t => t.shoppingCardPay).HasColumnName("shoppingCardPay");
            this.Property(t => t.sumCommission).HasColumnName("sumCommission");
           
        }
    }
}
