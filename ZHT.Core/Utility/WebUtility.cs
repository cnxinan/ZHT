using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.Utility
{
    public class WebUtility
    {
        public string HttpPost(string url, object paramObj)
        {
            using (HttpClient client = new HttpClient())
            {
                var rst = client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(paramObj), Encoding.UTF8, "application/json")).Result;
                if (rst.IsSuccessStatusCode)
                {
                    try
                    {
                        return rst.Content.ReadAsStringAsync().Result;
                    }
                    catch { }
                }
            }
            return "";
        }
        public void HttpPost(string url, object paramObj, Action<string> setValueMethod)
        {
            if (setValueMethod == null)
            {
                throw new ArgumentException("setValueMethod参数不能为空!");
            }
            using (HttpClient client = new HttpClient())
            {
                client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(paramObj), Encoding.UTF8, "application/json"))
                    .ContinueWith(response =>
                    {
                        if (response.Result.IsSuccessStatusCode)
                        {
                            try
                            {
                                string rst = response.Result.Content.ReadAsStringAsync().Result;
                                setValueMethod(rst);
                            }
                            catch { }
                        }
                    });
            }
            //return default(TResult);
        }
        //private string getParameterString(object obj)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    var properties = obj.GetPropertyInfos();
        //    return string.Join("&", properties.Select(p => string.Format("{0}={1}", p.Name, p.GetValue(obj))));
        //}
        /// <summary>
        /// 微信订单随机号
        /// </summary>
        /// <returns></returns>
        public static string GetWeixinRandom()
        {
            Random r = new Random();
            const string _chars = "0123456789";
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string data = DateTime.Now.Day.ToString();
            if (month.Length == 1) { month = 0 + month; }
            char[] buffer = new char[10];
            for (int i = 0; i < 10; i++)
            {
                buffer[i] = _chars[r.Next(_chars.Length)];
            }
            return year + month + data + new string(buffer);
        }
    }
}
