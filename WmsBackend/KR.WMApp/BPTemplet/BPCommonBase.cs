using KR.BaseApp;
using KR.CIMS;
using KR.WMApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Linq;

namespace KR.WMApp.BPTemplet
{
    public class BPCommonBase
    {
        public static ILog logger = LogManager.GetLogger(typeof(BPCommonBase));

        #region 下达任务信息到接口表
        /// <summary>
        /// 下达任务信息到接口表
        /// </summary>
        /// <param name="dbCon"></param>
        /// <param name="dbTrans"></param>
        /// <param name="taskEntity">任务对象</param>
        /// <param name="jobType"></param>
        /// <returns></returns>
        public static DTOResponse OrderTask(
              IDbConnection dbCon,
              IDbTransaction dbTrans,
              TaskEntity taskEntity,
              int jobType = 1)
        {
            DTOResponse dtoResponse = new DTOResponse();
            if (CheckSysScenceOrderDcsState() == false)
            {
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "场景设置不下达！";
                return dtoResponse;
            }
            INF_JOBDOWNLOADEntity jobdownloadEntity = new INF_JOBDOWNLOADEntity();
            jobdownloadEntity.ID = Utils.GetDateTimeGuid();
            jobdownloadEntity.GROUPID = "0";
            jobdownloadEntity.JOBID = taskEntity.TASKNO;
            jobdownloadEntity.EQUIPMENTID = "";
            jobdownloadEntity.WAREHOUSEID = "none";
            jobdownloadEntity.JOBTYPE = jobType;
            jobdownloadEntity.ORDERTYPE = 0;
            jobdownloadEntity.SOURCE = taskEntity.SOURCE02;
            jobdownloadEntity.TARGET = taskEntity.DESTINATION02;
            jobdownloadEntity.BRANDID = "0";
            jobdownloadEntity.PLANQTY = new Decimal?(new Decimal());
            jobdownloadEntity.PILETYPE = "0";
            jobdownloadEntity.PRIORITY = taskEntity.PRIORITY;
            jobdownloadEntity.BARCODE = taskEntity.PALLETNO;
            jobdownloadEntity.TUTYPE = taskEntity.PALLETTYPE;
            jobdownloadEntity.ENTERDATE = Utils.GetTodayNow();
            jobdownloadEntity.RESPONDDATE = (string)null;
            jobdownloadEntity.RESPONDCOUNT = 1;
            jobdownloadEntity.RESPONDMSG = "";
            jobdownloadEntity.STATUS = 0;
            jobdownloadEntity.WEIGHT = new Decimal?(new Decimal());
            jobdownloadEntity.FULLCOUNT = 0;
            jobdownloadEntity.EXTENDINFO = "";
            jobdownloadEntity.EXTATTR1 = taskEntity.TASKDESC;
            jobdownloadEntity.EXTATTR2 = taskEntity.CUSTOMCOL01;
            jobdownloadEntity.EXTATTR3 = taskEntity.TASKNO.ToString();
            jobdownloadEntity.CREATEDATE = Utils.GetTodayNow();
            jobdownloadEntity.CREATEUSERID = SysInfo.CurrentUserID;
            jobdownloadEntity.CREATEUSERNAME = SysInfo.CurrentUserName;

            TaskStatEntity taskstatEntity = new TaskStatEntity();
            taskstatEntity.TASKNO = taskEntity.TASKNO;
            taskstatEntity.STATITEMNAME = "taskcreat";
            taskstatEntity.STATITEMDESC = "任务创建";
            taskstatEntity.STATITEMVALUE = "0";
            taskstatEntity.CREATETIME = Utils.GetDatetime();
            taskstatEntity.P01 = taskEntity.CREATEDATE;
            taskstatEntity.P02 = Utils.GetDatetime();

            long c1 = dbCon.Insert<INF_JOBDOWNLOADEntity>(jobdownloadEntity, false);
            long c2 = dbCon.Insert<TaskStatEntity>(taskstatEntity, false);
            dtoResponse.IsSuccess = c1 == 1 && c2 == 1 ? true : false;
            dtoResponse.MessageText = "下达接口表操作完成:" + dtoResponse.IsSuccess.ToString();
            return dtoResponse;
        }
        #endregion

        #region 下达站台信息
        public static DTOResponse OrderStationInfo(
            IDbConnection dbCon,
            IDbTransaction dbTrans,
            OrderStnInfoRequest orderStnInfo)
        {
            int jobType = 4;
            DTOResponse dtoResponse = new DTOResponse();
            if (CheckSysScenceOrderDcsState() == false)
            {
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "场景设置不下达！";
                return dtoResponse;
            }
            INF_JOBDOWNLOADEntity jobdownloadEntity = new INF_JOBDOWNLOADEntity();
            jobdownloadEntity.ID = Utils.GetDateTimeGuid();
            jobdownloadEntity.GROUPID = "0";
            jobdownloadEntity.JOBID = orderStnInfo.JOBID.ToString();
            jobdownloadEntity.EQUIPMENTID = orderStnInfo.STATIONNO;
            jobdownloadEntity.WAREHOUSEID = "none";
            jobdownloadEntity.JOBTYPE = jobType;
            jobdownloadEntity.ORDERTYPE = 0;
            jobdownloadEntity.SOURCE = orderStnInfo.STATIONNO;
            jobdownloadEntity.TARGET = orderStnInfo.DESTINATION;
            jobdownloadEntity.BRANDID = "0";
            jobdownloadEntity.PLANQTY = 0;
            jobdownloadEntity.PILETYPE = "0";
            jobdownloadEntity.PRIORITY = orderStnInfo.PRIORITY;
            jobdownloadEntity.BARCODE = orderStnInfo.PALLETNO;
            jobdownloadEntity.TUTYPE = orderStnInfo.PALLETTYPE;
            jobdownloadEntity.ENTERDATE = Utils.GetTodayNow();
            jobdownloadEntity.RESPONDDATE = (string)null;
            jobdownloadEntity.RESPONDCOUNT = 1;
            jobdownloadEntity.RESPONDMSG = "";
            jobdownloadEntity.STATUS = 0;
            jobdownloadEntity.WEIGHT = 0;
            jobdownloadEntity.FULLCOUNT = 0;
            jobdownloadEntity.EXTENDINFO = "";
            jobdownloadEntity.EXTATTR1 = "";
            jobdownloadEntity.EXTATTR2 = "";
            jobdownloadEntity.EXTATTR3 = "";
            jobdownloadEntity.CREATEDATE = Utils.GetTodayNow();
            jobdownloadEntity.CREATEUSERID = SysInfo.CurrentUserID;
            jobdownloadEntity.CREATEUSERNAME = SysInfo.CurrentUserName;

            long c1 = dbCon.Insert<INF_JOBDOWNLOADEntity>(jobdownloadEntity, false);
            dtoResponse.IsSuccess = c1 == 1 ? true : false;
            dtoResponse.MessageText = "下达接口表操作完成:" + dtoResponse.IsSuccess.ToString();
            return dtoResponse;
        }
        #endregion

        #region 检查当前场景
        public static bool CheckSysScenceOrderDcsState()
        {
            bool ifOrder = false;
            try
            {
                SysSceneEntity sysScene = null;
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    sysScene = dbConn.Select<SysSceneEntity>(x => x.SCENESTATE == "1").FirstOrDefault();
                }
                if (sysScene != null)
                {
                    if (sysScene.ORDERDCSSTATE == 1)
                    {
                        ifOrder = true;
                    }
                }
                return ifOrder;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 根据TASKCLASS转换JOBTYPE
        public static int ConvertJobtype(string taskClass)
        {
            int jobType = 1;
            switch (taskClass)
            {
                case "1":
                case "11":
                    jobType = 6;
                    break;
                case "2":
                case "22":
                    jobType = 7;
                    break;
                case "3":
                case "33":
                    jobType = 8;
                    break;
            }
            return jobType;
        }
        #endregion
    }
}
