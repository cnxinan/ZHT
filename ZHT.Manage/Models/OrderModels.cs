using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHT.Manage.Models
{

    public class OrderListModel
    {
        public string OrderId { get; set; }

        public string SellerName { get; set; }

        public string OrderNo { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string TotalAmount { get; set; }

        public string Status { get; set; }
        
    }

    public class OrderModel
    {
        public string SellerName { get; set; }

        public string OrderNo { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string TotalAmount { get; set; }

        public string CreateDate { get; set; }

        public List<OrderDetailsModel> orderDetails { get; set; }
    }

    public class OrderDetailsModel
    {
        public string ProductName { get; set; }

        public string Count { get; set; }

        public string Charge { get; set; }
    }
}