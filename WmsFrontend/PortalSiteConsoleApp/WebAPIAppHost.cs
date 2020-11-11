using Funq;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.Web;
using System;
using System.Configuration;

namespace PortalSiteConsoleApp
{
    public class WebAPIAppHost : AppSelfHostBase
    {
        public WebAPIAppHost()
          : base("RestAPI", 
                typeof(KR.BaseApp.RestAPIService).Assembly
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
            
            //container.Register<IDbConnectionFactory>((Func<Container, IDbConnectionFactory>)(c => (IDbConnectionFactory)new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["ICMS"].ConnectionString, HelperConnection.GetProvider(ConfigurationManager.ConnectionStrings["ICMS"].ProviderName))));
            
            this.Plugins.Add((IPlugin)new SessionFeature());
            container.Register<ICacheClient>(new MemoryCacheClient());

            this.SetConfig(new HostConfig()
            {
                DefaultContentType = "charset=UTF-8;",
                WebHostPhysicalPath = MapProjectPath("~")//“~”表示Web 应用程序根目录，“/”也是表示根目录，“../”表示当前目录的上一级目录，“./”表示当前目录
                //EmbeddedResourceSources = { typeof(RestAPIService).Assembly },
                //EmbeddedResourceBaseTypes = { typeof(RestAPIService) }
            });
        }
    }
}
