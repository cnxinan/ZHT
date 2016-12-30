using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHT.Manage.Models
{

    public class TicketInfoModel
    {
        public string ExhibitionId { get; set; }

        public string ExhibitionName { get; set; }

        public string EndDate { get; set; }

        public string TicketCount { get; set; }

        public string TotalAmount { get; set; }

        public string SettleAmount { get; set; }

        public string Status { get; set; }
    }

    public class SaleInfoModel
    {
        public string ExhibitionId { get; set; }

        public string ExhibitionName { get; set; }

        public string EndDate { get; set; }

        public int OrderCount { get; set; }

        public string TotalAmount { get; set; }

        public string DivideAmount { get; set; }

        public string SettleAmount { get; set; }

        public string Status { get; set; }
    }

    public class SettlementModel
    {
        public string SettlementId { get; set; }

        public string ExhibitionName { get; set; }

        public string TypeName { get; set; }

        public string Amount { get; set; }

        public string SettlementTime { get; set; }

    }

}