using KR.BaseApp;
using KR.BaseApp.Services;
using KR.CIMS;
using KR.WMApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Linq;

namespace KR.WMApp.Services
{
    /// <summary>
    /// 搬运移动服务后台（手工下达的任务）
    /// </summary>
    public class MoveService : LogService
    {
        public DTOResponse CreateTaskByMen(MoveRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            IDbConnection dbCon = (IDbConnection)null;
            IDbTransaction dbTrans = (IDbTransaction)null;
            try
            {
                HelperDbOperation.BeginTransaction(ref dbCon, ref dbTrans);
                dtoResponse = this.CreateTaskByMen(request, dbCon, dbTrans);
                LogService.logger.Info((object)dtoResponse.ToString());
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                LogService.logger.Error((object)ex);
                return dtoResponse;
            }
            finally
            {
                HelperDbOperation.EndTransaction(dtoResponse.IsSuccess, ref dbCon, ref dbTrans);
            }
        }

        protected DTOResponse CreateTaskByMen(
          MoveRequest request,
          IDbConnection dbCon,
          IDbTransaction dbTrans)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                if (string.IsNullOrEmpty(request.StationNo))
                    throw new Exception("参数不正确!@StationNo");
                if (string.IsNullOrEmpty(request.Destination))
                    throw new Exception("参数不正确!@Destination");

                LocStationInfoEntity locStation1 = dbCon.Single<LocStationInfoEntity>(x => x.CONTROLNO == request.StationNo);
                if (locStation1 == null)
                    throw new Exception(string.Format("站台：{0}不存在！", request.StationNo));

                LocStationInfoEntity locStation2 = dbCon.Single<LocStationInfoEntity>(x => x.CONTROLNO == request.Destination);
                if (locStation2 == null)
                    throw new Exception(string.Format("站台：{0}不存在！", request.Destination));

                if (string.IsNullOrEmpty(request.PalletNo))
                    request.PalletNo = "0";
                if (string.IsNullOrEmpty(request.PalletType))
                    request.PalletType = "1";
                if (request.Priority < 1)
                    request.Priority = 1;

                SysSequenceResult sysSequence = SysSequenceInstance.Instance().GetSysSequence("TASKID");
                TaskEntity taskEntity = new TaskEntity()
                {
                    TASKNO = long.Parse(sysSequence.SEQVALUE).ToString(),
                    TASKDATE = Utils.GetToday(),
                    TASKTCLASS = "3",
                    TASKTYPE = "0",
                    PRIORITY = request.Priority,
                    TASKGROUPNO = "",
                    PRETASKNO = "",
                    STRATEGYID01 = "",
                    STRATEGYNAME01 = "",
                    SOURCEAREA = locStation1.GROUPNO,
                    SOURCE01 = locStation1.STATIONNO,
                    SOURCE02 = locStation1.CONTROLNO,
                    STRATEGYID02 = "",
                    STRATEGYNAME02 = "",
                    DESTINATIONAREA = locStation2.GROUPNO,
                    DESTINATION01 = locStation2.STATIONNO,
                    DESTINATION02 = locStation2.CONTROLNO,
                    TASKORDERDATA = "",
                    CREATEDATE = Utils.GetTodayNow(),
                    CREATEBY = SysInfo.CurrentUserName,
                    STARTDATE = "",
                    ENDDATE = "",
                    CANCELDATE = "",
                    CANCELREASON = "",
                    TASKSTATE = "0",
                    BILLID = "0",
                    BILLID_LINENUM = 0,
                    PALLETNO = request.PalletNo,
                    PALLETTYPE = request.PalletType
                };
                taskEntity.TASKDESC = string.Format("人工任务:从{0}到{1}", taskEntity.SOURCE02, taskEntity.DESTINATION02);
                long num = dbCon.Insert<TaskEntity>(taskEntity, false);
                
                dtoResponse.MessageText = "任务号：" + taskEntity.TASKNO + "容器编号:" + request.PalletNo + "从" + locStation1.CONTROLNO + "到" + locStation2.CONTROLNO;
                dtoResponse.IsSuccess = num == 1 ? true : false;
                LogService.logger.Info((object)dtoResponse.ToString());
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                LogService.logger.Error((object)ex);
                return dtoResponse;
            }
        }

        public DTOResponse OrderStationInfo(MoveRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 确认重置站台设置信息
        /// </summary>
        public DTOResponse RestChanelStorestate(MoveRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            IDbConnection dbCon = (IDbConnection)null;
            IDbTransaction dbTrans = (IDbTransaction)null;
            try
            {
                HelperDbOperation.BeginTransaction(ref dbCon, ref dbTrans);

                string msg = "重置站台设置信息";
                string sqlUpdateStn = string.Format(
                    @"UPDATE PROJ_STATIONINFO SET USECAPACITY=0,OPDATE='{1}',OPMESSAGE='{2}' WHERE CONTROLNO='{0}'",
                    request.StationNo, Utils.GetDatetime(), msg);
                int count1 = dbCon.ExecuteSql(sqlUpdateStn);

                dtoResponse.IsSuccess = count1 > 0 ? true : false;
                dtoResponse.MessageText = "确认重置" + request.StationNo + "站台状态成功:" + count1 + "个工位";
                LogService.logger.Info((object)dtoResponse.ToString());
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                LogService.logger.Error((object)ex);
                return dtoResponse;
            }
            finally
            {
                HelperDbOperation.EndTransaction(dtoResponse.IsSuccess, ref dbCon, ref dbTrans);
            }
        }
    }
}
