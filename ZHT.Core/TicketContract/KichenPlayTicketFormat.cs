using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.TicketContract
{
    public class KichenPlayTicketFormat : TicketFormatBase
    {
        public override EnumTicketType TicketType
        {
            get { return EnumTicketType.KichenPlay; }
        }
        /// <summary>
        /// 桌位号
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 区域ID
        /// 如果区域ID==-1则为外卖订单
        /// 外卖订单需要提供地址
        /// </summary>
        public int AreaId { get; set; }
        /// <summary>
        /// 外卖地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public int PeopleCount { get; set; }
        /// <summary>
        /// 收银员
        /// </summary>
        public string CreatePerson { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public string BeFrom { get; set; }

        /// <summary>
        /// 要求(订单级别要求,如打包,微辣等)
        /// </summary>
        public string Request { get; set; }
        /// <summary>
        /// 厨打明细
        /// </summary>
        public List<KichenPlayItem> Items { get; set; }
    }
    public class KichenPlayItem
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        public int ProductCategoryId { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string ProductCategoryName { get; set; }
        /// <summary>
        /// 产品明细
        /// </summary>
        public List<KichenPlaySubItem> SubItems { get; set; }
    }
    public class KichenPlaySubItem
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 要求(微辣中辣少盐等单一菜品要求)  
        public string Request { get; set; }
        /// <summary>
        /// 套餐明细
        /// </summary>
        public List<KichenPlaySubItemCombo> ComboItems { get; set; }
    }
    public class KichenPlaySubItemCombo
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName { get; set; }
    }
}
