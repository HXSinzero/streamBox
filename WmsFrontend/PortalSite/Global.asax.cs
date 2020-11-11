using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;
using System;

namespace PortalSite
{
    /// <summary>
    /// 网站启动入口
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            LogManager.LogFactory = (ILogFactory)new NLogFactory();
            ILog logger = LogManager.GetLogger(typeof(Global));
            //启动API
            new WebHost().Init();
            logger.Info("api启动……");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}