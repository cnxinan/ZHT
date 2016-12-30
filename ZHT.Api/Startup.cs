using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Web.Http;
using YuanXin.Framework.OAuth.Identity;

[assembly: OwinStartup(typeof(ZHT.Api.Startup))]

namespace ZHT.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
            {
                AccessTokenFormat = new YuanXinAccessTokenFormat()
            });
        }
    }
}