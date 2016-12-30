using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.System
{
    public class GenerateCode
    {
        public string UniqueCode { get; set; }
    }

    public class WeixinCode
    {
        public string WxCardCode { get; set; }
    }

    public class BillCode
    {
        /// <summary>
        /// 单据编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 是否生成成功，如生成失败，错误消息由ErrorMessage属性返回
        /// </summary>
        public bool Success { get; set; }
        /// <summary>                                        
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
