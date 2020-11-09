using KR.BaseApp.Entitys;
using KR.CIMS;
using KR.CIMS.Interfaces;
using Quartz;
using Quartz.Impl;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using WMProjectApp;

namespace WMProjectHost
{
    /// <summary>
    /// AppHost辅助类
    /// </summary>
    public class HelperApp
    {
        private ILog logger = (ILog)null;
        WebAPIAppHost appHost = new WebAPIAppHost();
        WebQuartz webQuartz = new WebQuartz();

        public HelperApp()
        {
            LogManager.LogFactory = (ILogFactory)new NLogFactory();
            this.logger = LogManager.GetLogger(typeof(HelperApp));
        }

        public void Start()
        {
            try
            {
                logger.Info("...");
                logger.Info("......");
                logger.Info(".........");

                this.InitDataBase();

                string urlBase = "http://*:18080/";
                string appSetting = ConfigurationManager.AppSettings["WEBAPIPORT"];
                if (!string.IsNullOrEmpty(appSetting))
                    urlBase = string.Format("http://*:{0}/", (object)appSetting);

                //启动API
                appHost.Init().Start(urlBase);
                logger.Info(urlBase + "已启动！");

                //启动定时器
                webQuartz.Start();
                logger.Info("Quartz已启动！");
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
            InterfaceInstall installWMApp = new KR.WMApp.Installer();
            InterfaceInstall installWMProject = new WMProject.Installer();

            installBaseApp.Install();//安装基础表
            installWMApp.Install();//安装WM管理的变
            installWMProject.Install();//安装项目自定义的表
            #endregion
        }
    }
}
