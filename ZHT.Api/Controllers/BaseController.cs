using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using YuanXin.Framework.OAuth.Identity;
using ZHT.Api.Models;

namespace ZHT.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        private static readonly string CreateYXOrderUrl = ConfigurationManager.AppSettings["YxAdress"] + "OrderManage/AddExpoOrder?Total={0}&OrderNo={1}&Creator={2}&CreateTime={3}&Code={4}";
        private static readonly string GetOrderNoUrl = ConfigurationManager.AppSettings["YxAdress"] + "OrderManage/GetOrderNo";
        protected readonly string MaterialServiceUrl = ConfigurationManager.AppSettings["MaterialService"];

        /// <summary>
        /// 获取登陆用户ID
        /// </summary>
        public string CurrentUserId
        {
            get
            {
                return this.User.Identity.GetCurrentUserId();
            }
        }

        /// <summary>
        /// 获取登陆用户用户名
        /// </summary>
        public string CurrentUserName
        {
            get
            {
                return this.User.Identity.GetCurrentUserName();
            }
        }

        public string CurrentLoginName
        {
            get
            {
                return this.User.Identity.GetCurrentLoginName();
            }
        }

        /// <summary>
        /// 获取订单号
        /// </summary>
        public string GetOrderNo
        {
            get
            {
                string orderNo = string.Empty;
                try
                {
                    orderNo = HttpClientDoGet(GetOrderNoUrl);
                }
                catch
                { }

                return orderNo.Replace('\\', ' ').Replace('\"', ' ').Trim();
            }
        }

        #region 方法

        public static bool CreateYxOrder(YXOrderRequest requestModel)
        {
            string fullUrl = string.Format(CreateYXOrderUrl, requestModel.Total, requestModel.OrderNo, requestModel.Creator, DateTime.Now.ToString(), requestModel.Code);

            string responseStr = string.Empty;
            try
            {
                responseStr = HttpClientDoGet(fullUrl);
            }
            catch
            {
                return false;
            }

            return !responseStr.ToLower().Contains("true") ? false : true;
        }

        public static string HttpClientDoGet(string url, string dataType = "application/json")
        {
            string result = string.Empty;
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };

            using (var httpclient = new HttpClient(handler))
            {
                httpclient.BaseAddress = new Uri(url);
                httpclient.DefaultRequestHeaders.Accept.Clear();
                httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(dataType));

                HttpResponseMessage response = httpclient.GetAsync("").Result;

                if (response.IsSuccessStatusCode)
                {
                    Stream myResponseStream = response.Content.ReadAsStreamAsync().Result;
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                    result = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                }
            }

            return result;
        }

        #endregion

    }
}