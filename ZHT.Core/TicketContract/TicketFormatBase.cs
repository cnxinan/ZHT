using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.TicketContract
{
    public abstract class TicketFormatBase
    {
        public abstract EnumTicketType TicketType { get; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        /// <summary>
        /// 语言 zh-CN en-US ja_JP ko_KR
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// 结账日期
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 主标题
        /// </summary>
        public string Headline { get; set; }
        /// <summary>
        /// 副标题
        /// </summary>
        public string Subheading { get; set; }

        /// <summary>
        /// 页尾标记
        /// </summary>
        public string FootText { get; set; }
        /// <summary>
        /// 是否转桌指定打印
        /// </summary>
        public bool IfTurn { get; set; }
    }
}
