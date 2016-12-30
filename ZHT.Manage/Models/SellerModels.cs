using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHT.Manage.Models
{
    public class SellerListModel
    {
        public string SellerOrderId { get; set; }       //参展订单ID

        public string SellerName { get; set; }          //展商名称

        public string SeatInfo { get; set; }            //展位信息

        public string SName { get; set; }               //姓名

        public string SPhone { get; set; }              //手机

        public string Status { get; set; }              //状态
    }

    public class SellerModel
    {
        public string HeadImg { get; set; }             //商家LOGO

        public string SellerName { get; set; }          //商家名称

        public string Address { get; set; }             //商家地址

        public string SName { get; set; }               //联系人

        public string SPhone { get; set; }              //联系电话 

        public string BusinessScope { get; set; }       //经营范围

        public string SellerInfo { get; set; }          //商家介绍

        public string SeatInfo { get; set; }            //预定展位

        public string TotalPrice { get; set; }          //支付总价
    }
}