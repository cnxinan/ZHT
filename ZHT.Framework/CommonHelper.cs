using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Framework
{
   public class CommonHelper
    {
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <returns></returns>
        public static string GetOrderNo()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss") + RandomHelper.RandCode();
        }

        public static string GetTicketPwd()
        {
            StringBuilder sb = new StringBuilder();

            string firstSection = DateTime.Now.Year.ToString();

            string dayOfYear = DateTime.Now.DayOfYear.ToString();
            string secondSection = dayOfYear + RandomHelper.RandCode(4 - dayOfYear.Length);

            string thirdSection = RandomHelper.RandCode(4);
            return firstSection + "-" + secondSection + "-" + thirdSection;
        }

        /// <summary>
        /// 默认头像地址
        /// </summary>
        /// <returns></returns>
        public static string TempHeadImg()
        {
            return "";
        }

        //获取枚举的值
        public static string GetEnumValue<T>(T enumType)
        {
            return ((int)Enum.Parse(typeof(T), enumType.ToString())).ToString();
        }        
    }
}
