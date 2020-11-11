using Funq;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Caching;
using ServiceStack.Web;
using System;

namespace PortalSite
{
    /// <summary>
    /// API服务主机对象
    /// </summary>
    public class WebHost : AppHostBase
    {
        public WebHost()
             : base("RestAPI",
                   typeof(KR.BaseApp.RestAPIService).Assembly,
                   typeof(PortalSite.RestAPIService).Assembly
                   )
        {
        }

        public override void Configure(Container container)
        {
            this.Plugins.Add((IPlugin)new SwaggerFeature());
            this.Plugins.Add((IPlugin)new RequestLogsFeature(new int?()));
            CorsFeature corsFeature = new CorsFeature("*", "GET, POST, PUT, DELETE, OPTIONS", "*", false, (string)null, new int?());
            this.PreRequestFilters.Add((Action<IRequest, IResponse>)((httpReq, httpRes) =>
            {
                if (!(httpReq.Verb == "OPTIONS"))
                    return;
                httpRes.StatusCode = 204;
            }));
            this.Plugins.Add((IPlugin)corsFeature);

            this.Plugins.Add((IPlugin)new SessionFeature());
            container.Register<ICacheClient>(new MemoryCacheClient());
        }
    }
}