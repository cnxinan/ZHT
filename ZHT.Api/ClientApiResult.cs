using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Api
{
    /// <summary>
    /// 客户端返回实体
    /// </summary>
    public class ClientApiResult
    {
        /// <summary>
        /// 返回标记
        /// </summary>
        public ResultFlag Flag { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

        public String Messages { get; set; }
    }

    /// <summary>
    /// 返回标记
    /// </summary>
    public enum ResultFlag
    {
        /// <summary>
        /// successful
        /// </summary>
        Successful = 1,

        /// <summary>
        ///  Data dies not exist
        /// </summary>
        DataNotExist = 2,    

        /// <summary>
        /// Error
        /// </summary>
        Error = 3,

        /// <summary>
        /// DataChanged
        /// </summary>
        DataChanged = 4,
    }
}
