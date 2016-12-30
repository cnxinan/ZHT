using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.WebHelper
{
    /// <summary>
    /// 营业时间
    /// </summary>
    public class OfficeDataTime
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class DateTimeHelper
    {
        /// <summary>
        /// 处理营业时间
        /// </summary>
        /// <param name="benginTime">开始时间（小时:分钟）</param>
        /// <param name="endTime">结束时间（小时:分钟）</param>
        /// <param name="searchDateTime">查询日期</param>
        /// <returns>OfficeDataTime</returns>
        public static OfficeDataTime OfficeHours(TimeSpan benginTime, TimeSpan endTime, DateTime searchDateTime)
        {
            DateTime searchBeginDate = searchDateTime.Date.Add(benginTime);
            DateTime searchEndDate = searchDateTime.Date.Add(endTime);
            OfficeDataTime selectDataTime = new OfficeDataTime();
            //当天时间段
            if (searchBeginDate <= searchEndDate)
            {
                selectDataTime.BeginDate = searchBeginDate;
                selectDataTime.EndDate = searchEndDate;
            }
            //隔天时间段
            else
            {
                //判断当前时间是否跨天
                TimeSpan temp1 = new TimeSpan(23, 59, 59);
                //没有跨天
                if (searchEndDate <= searchDateTime && searchDateTime <= searchDateTime.Date.Add(temp1))
                {
                    selectDataTime.BeginDate = searchBeginDate;
                    selectDataTime.EndDate = searchEndDate.AddDays(1);

                }
                //已经跨天
                else
                {
                    selectDataTime.BeginDate = searchBeginDate.AddDays(-1);
                    selectDataTime.EndDate= searchEndDate;
                }
            }
            return selectDataTime;
        }


        /// <summary>
        /// 处理报表统计时间
        /// </summary>
        /// <param name="statisticalTime">报表统计节点（例:14:00）</param>
        /// <param name="sameDay">true:当日,false:次日</param>
        /// <returns>OfficeDataTime</returns>
        public static OfficeDataTime StatisticsTime(string statisticalTime, bool sameDay)
        {
            TimeSpan timeSpan = new TimeSpan(Convert.ToInt32(statisticalTime.Split(':')[0]), Convert.ToInt32(statisticalTime.Split(':')[1]), 0);
            OfficeDataTime officeDataTime = new OfficeDataTime();
            if (sameDay)
            {
                officeDataTime.BeginDate = DateTime.Now.Date.Add(timeSpan).AddDays(-1);
                officeDataTime.EndDate = DateTime.Now.Date.Add(timeSpan);
            }
            else
            {
                officeDataTime.BeginDate = DateTime.Now.Date.Add(timeSpan);
                officeDataTime.EndDate = DateTime.Now.Date.Add(timeSpan).AddDays(1);
            }
            return officeDataTime;
        }

        /// <summary>
        /// 处理报表统计时间
        /// </summary>
        /// <param name="statisticalTime">报表统计节点（例:14:00）</param>
        /// <param name="sameDay">true:当日,false:次日</param>
        /// <param name="searchDate">查询日期</param>
        /// <returns>OfficeDataTime</returns>
        public static OfficeDataTime StatisticsTime(string statisticalTime, bool sameDay, DateTime searchDate)
        {
            TimeSpan timeSpan = new TimeSpan(Convert.ToInt32(statisticalTime.Split(':')[0]), Convert.ToInt32(statisticalTime.Split(':')[1]), 0);

            OfficeDataTime officeDataTime = new OfficeDataTime();
            DateTime searchBeginDate = searchDate.Date.Add(timeSpan);
            DateTime searchEndDate = searchDate.Date.Add(timeSpan);

            if (sameDay)
            {
                searchBeginDate = searchBeginDate.AddDays(-1);
            }
            else
            {
                searchEndDate = searchEndDate.AddDays(+1);
            }
            officeDataTime.BeginDate = searchBeginDate;
            officeDataTime.EndDate = searchEndDate;

            return officeDataTime;
        }

        /// <summary>
        /// 处理报表统计时间
        /// </summary>
        /// <param name="statisticalTime">报表统计节点（例:14:00）</param>
        /// <param name="sameDay">true:当日,false:次日</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>OfficeDataTime</returns>
        public static OfficeDataTime StatisticsTime(string statisticalTime, bool sameDay, DateTime beginDate,DateTime endDate)
        {
            TimeSpan timeSpan = new TimeSpan(Convert.ToInt32(statisticalTime.Split(':')[0]), Convert.ToInt32(statisticalTime.Split(':')[1]), 0);

            OfficeDataTime officeDataTime = new OfficeDataTime();
            DateTime searchBeginDate = beginDate.Date.Add(timeSpan);
            DateTime searchEndDate = endDate.Date.Add(timeSpan);

            if (sameDay)
            {
                searchBeginDate = searchBeginDate.AddDays(-1);
            }
            else
            {
                searchEndDate = searchEndDate.AddDays(+1);
            }
            officeDataTime.BeginDate = searchBeginDate;
            officeDataTime.EndDate = searchEndDate;

            return officeDataTime;
        }

    }
}
