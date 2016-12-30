using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using sysweb = System.Web;

namespace ZHT.Core.System
{
    public class SystemPaths
    {
        /// <summary>
        /// 推广二维码任务背景图片
        /// 格式：路径/商家编码/文件名
        /// </summary>
        public static readonly string QrcodeTaskBackgroundPath = "/Uploads/qrcodeTask/{0}";

        /// <summary>
        /// 推广二维码与背景图片合成后图片保存位置
        /// 格式：路径/商家编码/yyyyMMdd/文件名
        /// </summary>
        public static readonly string QrcodeTaskUserUploadPath = "/Uploads/user_qrcode/{0}/{1}";

        /// <summary>
        /// 用户推广二维码保存位置（根据推广链接地址生成的二维码图片）
        /// </summary>
        public static readonly string ParameterQrcodePath = "/Uploads/ParamQrcode/{0}";

        /// <summary>
        /// 将相对路径转化为绝对路径
        /// </summary>
        /// <param name="relativePath">相对路径</param>
        /// <returns>绝对路径</returns>
        public static string ServerMappath(string relativePath, params object[] parameters)
        {
            if (parameters != null)
            {
                return sysweb.HttpContext.Current.Server.MapPath(string.Format(relativePath, parameters));
            }
            else
            {
                return sysweb.HttpContext.Current.Server.MapPath(relativePath);
            }
        }
        /// <summary>
        /// 返回HTTP协议的内网地址
        /// </summary>
        /// <returns></returns>
        public static string GetLocalWebServerPath()
        {
            return string.Format("http://{0}", Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork));
        }
    }
}
