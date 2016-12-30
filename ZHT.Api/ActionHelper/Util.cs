using Newtonsoft.Json;
using System;
using System.Data;
using System.Diagnostics;

namespace ZHT.Api.ActionHelper
{
    public static class Util
    {

        
        //Json对象转换，将string转换为JSON对象
        public static T jsonParse<T>(string jsonString)
        {
            T result = default(T); 
            
            try
            {
                result = JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                int depth = 1;

                LogHelper log = LogFactory.GetLogger(st.GetFrame(depth).GetMethod().DeclaringType);
                log.Error("Json pasrse failed! -- ", ex);
                return result;
            }
            return result;
        }

        //Json对象转换，将Json对象转换为string类型
        public static string stringify(object jsonObject)
        {
            string result = null;

            try { 
                result = JsonConvert.SerializeObject(jsonObject);
            }catch (Exception ex){
                StackTrace st = new StackTrace();
                int depth = 1;

                LogHelper log = LogFactory.GetLogger(st.GetFrame(depth).GetMethod().DeclaringType);
                log.Error("Json pasrse failed! -- ", ex);
                return result;
            }

            return result;
           
        }

        //计算两个日期之间间隔的天数
        public static int calculateDays(DateTime startTime, DateTime endTime) {

            DateTime dtEnd = new DateTime(Convert.ToInt32(endTime.Year), Convert.ToInt32(endTime.Month), Convert.ToInt32(endTime.Day));
            DateTime dtStart = new DateTime(Convert.ToInt32(startTime.Year), Convert.ToInt32(startTime.Month), Convert.ToInt32(startTime.Day));

            int interval = new TimeSpan(dtEnd.Ticks - dtStart.Ticks).Days;

            return interval;
        }

        //对DataTable进行排序
        public static DataTable sortDataTable(DataTable dt, string column, string sort)
        {
            DataView dv = dt.DefaultView;
            dv.Sort = column +" "+ sort;
            return dv.ToTable();
        
        }

        //检查string是否是时间格式
        public static bool IsDate(string strDate)
        {
            try
            {
                DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}