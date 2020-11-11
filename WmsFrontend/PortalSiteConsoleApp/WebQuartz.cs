using KR.BaseApp.Entitys;
using KR.CIMS;
using Quartz;
using Quartz.Impl;
using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace PortalSiteConsoleApp
{
    public class WebQuartz
    {
        private ILog logger = (ILog)null;
        public ISchedulerFactory schedulerFactory = (ISchedulerFactory)new StdSchedulerFactory();
        public IScheduler scheduler = (IScheduler)null;

        public WebQuartz()
        {
            LogManager.LogFactory = (ILogFactory)new NLogFactory();
            this.logger = LogManager.GetLogger(typeof(WebQuartz));
        }

        public void Start()
        {
            this.Init();
        }

        public void Stop()
        {
            if (this.scheduler == null)
                this.logger.Info((object)"scheduler对象为空！");
            else
                this.scheduler.Shutdown();
        }

        public void Init()
        {
            try
            {
                string devHotName = ConfigurationManager.AppSettings["DEVHOSTNAME"];//开发计算机
                string hostName = HelperEnvironmentSetting.GetHostName();
                string appName = ConfigurationManager.AppSettings["APPNAME"];
                if (string.IsNullOrEmpty(appName))
                    appName = AppDomain.CurrentDomain.FriendlyName.Replace(".vshost", "");
                string responservername = null;
                string responservernameBydev = null;
                responservername = hostName + "&" + appName;
                responservernameBydev = devHotName + "&" + appName;
                System.Console.WriteLine("responservername：" + responservername);
                System.Console.WriteLine("devHotName：" + responservername);
                List<JobEntity> jobEntityList = new List<JobEntity>();
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<JobEntity> expression = dbConn.From<JobEntity>();
                    expression.And(x => x.STATE == "1");//加载启用状态的定时器
                    if (devHotName == hostName)
                    {
                        expression.And(x => x.RESPONSESVRNAMEBYDEV == responservernameBydev);
                    }
                    else
                    {
                        expression.And(x => x.RESPONSESVRNAME == responservername);
                    }

                    jobEntityList = dbConn.Select<JobEntity>(expression).OrderBy<JobEntity, int>((Func<JobEntity, int>)(x => x.JOBID)).ToList<JobEntity>();
                    if (jobEntityList == null || jobEntityList.Count == 0)
                    {
                        this.logger.Info((object)"启动定时服务失败，未查询到相关数据！");
                    }
                    else
                    {
                        this.logger.Info((object)(responservername + ",加载" + jobEntityList.Count.ToString() + "个JOB"));
                        this.scheduler = this.schedulerFactory.GetScheduler();
                        this.scheduler.Clear();
                        foreach (JobEntity jobEntity in jobEntityList)
                        {
                            Type type = Type.GetType(jobEntity.CLASSFULLNAME);
                            if (type == (Type)null)
                            {
                                this.logger.Info((object)("无法获取：" + jobEntity.CLASSFULLNAME));
                            }
                            else
                            {
                                int jobid = jobEntity.JOBID;
                                IJobDetail jobDetail = (IJobDetail)new JobDetailImpl(jobid.ToString() + "-" + jobEntity.JOBDESC, "CIMS.Server", type, true, true);
                                TriggerBuilder triggerBuilder = TriggerBuilder.Create();
                                jobid = jobEntity.JOBID;
                                string key = jobid.ToString() + "-" + jobEntity.JOBTRIGGER;
                                ITrigger trigger = triggerBuilder.WithIdentity(key).WithCronSchedule(jobEntity.JOBTRIGGERPARA).Build();
                                jobDetail.JobDataMap.Put("BASE_JOB", (object)jobEntity);
                                jobDetail.JobDataMap.Put("JobKey", jobEntity.JOBID);
                                JobDataMap jobDataMap = jobDetail.JobDataMap;
                                jobid = jobEntity.JOBID;
                                string str2 = jobid.ToString() + "-" + jobEntity.JOBTRIGGER;
                                jobDataMap.Put("TriggerKey", str2);
                                this.scheduler.ScheduleJob(jobDetail, trigger);

                                logger.Info(jobEntity.JOBID + "创建成功！");
                            }
                        }
                        this.logger.Info((object)(responservername + ",启动了" + jobEntityList.Count.ToString() + "个JOB"));
                        this.scheduler.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                this.logger.Info((object)ex.ToString());
                this.logger.Error((object)ex.ToString());
            }
        }
    }
}