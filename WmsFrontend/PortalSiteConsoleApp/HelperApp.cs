using KR.CIMS.Interfaces;
using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;
using System;

namespace PortalSiteConsoleApp
{
    /// <summary>
    /// AppHost辅助类
    /// </summary>
    public class HelperApp
    {
        private ILog logger = (ILog)null;
        //WebAPIAppHost appHost = new WebAPIAppHost();
        //WebQuartz webQuartz = new WebQuartz();

        public HelperApp()
        {
            LogManager.LogFactory = (ILogFactory)new NLogFactory();
            this.logger = LogManager.GetLogger(typeof(HelperApp));
        }

        public void Start()
        {
            try
            {
                this.InitDataBase();

                //string urlBase = "http://*:18080/";
                //string appSetting = ConfigurationManager.AppSettings["WEBAPIPORT"];
                //if (!string.IsNullOrEmpty(appSetting))
                //    urlBase = string.Format("http://*:{0}/", (object)appSetting);

                ////启动API
                //appHost.Init().Start(urlBase);
                //logger.Info(urlBase + "已启动！");
                ////启动定时器
                //webQuartz.Start();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
        }

        public void InitDataBase()
        {
            #region 创建实体对象及执行实体对象更改
            InterfaceInstall installBaseApp = new KR.BaseApp.Installer();

            installBaseApp.Install();//安装基础表

            #endregion
        }
    }
}
