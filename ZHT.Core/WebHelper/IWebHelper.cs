using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ZHT.Core.WebHelper
{
    public interface IWebHelper
    {
        HttpContextBase GetHttpContext();
        /// <summary>
        /// Get URL referrer
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetUrlReferrer();

        /// <summary>
        /// Get context IP address
        /// </summary>
        /// <returns>URL referrer</returns>
        string GetCurrentIpAddress();

        bool IsCurrentConnectionSecured();

        bool IsStaticResource(HttpRequest request);

        /// <summary>
        /// Maps a virtual path to a physical disk path.
        /// </summary>
        /// <param name="path">The path to map. E.g. "~/bin"</param>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        string MapPath(string path);
        /// <summary>
        /// 文件URL路径
        /// </summary>
        /// <returns></returns>
        string GetFileUrl();
        /// <summary>
        /// 文件磁盘路径
        /// </summary>
        /// <returns></returns>
        string GetFileDisk();
    }
}
