using KR.BaseApp;
using KR.BaseApp.Entitys;
using KR.BaseApp.Services;
using KR.CIMS;
using KR.WMApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace KR.WMApp.Services
{
    public class DCSInfService : LogService
    {
        public DTOResponse GetList<T>(DCSInfRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    string str1 = typeof(T).Name.Replace("Entity", "");
                    string str2 = "SELECT * FROM " + str1;
                    string str3 = " WHERE 1=1";
                    if (!string.IsNullOrEmpty(request.EQUIPMENTID) && str1 != "INF_JOBFEEDBACK")
                        str3 += string.Format(" AND EQUIPMENTID='{0}'", (object)request.EQUIPMENTID);
                    if (!string.IsNullOrEmpty(request.STATUS))
                        str3 += string.Format(" AND STATUS={0}", (object)request.STATUS);
                    if (!string.IsNullOrEmpty(request.JOBID))
                        str3 += string.Format(" AND JOBID='{0}'", (object)request.JOBID);
                    if (!string.IsNullOrEmpty(request.CREATEDATE))
                    {
                        DateTime dt1;
                        if (DateTime.TryParse(request.CREATEDATE, out dt1))
                        {
                            str3 += string.Format(" AND CREATEDATE LIKE '{0}%'", dt1.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            dt1 = System.DateTime.Today;
                            str3 += string.Format(" AND CREATEDATE LIKE '{0}%'", dt1.ToString("yyyy-MM-dd"));
                        }
                    }

                    string str4 = " ORDER BY AUTOID DESC,CREATEDATE DESC";
                    long num = dbConn.Count<T>();
                    string sql = str2 + str3 + str4;
                    DCSInfService.logger.Debug((object)sql);
                    List<T> list = Enumerable.ToList<T>(Enumerable.Take<T>(Enumerable.Skip<T>(dbConn.Select<T>(sql), (request.page - 1) * request.limit), request.limit));
                    dtoResponse.TotalCount = num;
                    dtoResponse.ResultObject = (object)list;
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "查询操作成功！";
                    return dtoResponse;
                }
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                DCSInfService.logger.Error((object)ex);
                return dtoResponse;
            }
        }

        public DTOResponse TaskHandle()
        {
            DTOResponse dtoResponse = new DTOResponse();
            IDbConnection dbCon = (IDbConnection)null;
            IDbTransaction dbTrans = (IDbTransaction)null;
            string id = (string)null;
            string msg = (string)null;
            try
            {
                HelperDbOperation.BeginTransaction(ref dbCon, ref dbTrans);
                INF_JOBFEEDBACKEntity jobFeedBack = dbCon.Select<INF_JOBFEEDBACKEntity>((Expression<Func<INF_JOBFEEDBACKEntity, bool>>)(x => x.STATUS == 0 && x.RESPONDCOUNT < 1)).OrderBy<INF_JOBFEEDBACKEntity, string>((Func<INF_JOBFEEDBACKEntity, string>)(x => x.ENTERDATE)).OrderBy<INF_JOBFEEDBACKEntity, string>((Func<INF_JOBFEEDBACKEntity, string>)(x => x.JOBID)).OrderBy<INF_JOBFEEDBACKEntity, string>((Func<INF_JOBFEEDBACKEntity, string>)(x => x.FEEDBACKSTATUS)).FirstNonDefault<INF_JOBFEEDBACKEntity>();
                if (jobFeedBack == null)
                {
                    dtoResponse.IsSuccess = false;
                    dtoResponse.MessageText = "当前没有请求需要处理！";
                    return dtoResponse;
                }
                id = jobFeedBack.ID;
                TaskEntity projTaskEntity = OrmLiteReadExpressionsApi.Single<TaskEntity>(dbCon, (Expression<Func<TaskEntity, bool>>)(x => x.TASKNO == jobFeedBack.JOBID));
                if (projTaskEntity == null)
                {
                    TaskStepEntity stepEntity = OrmLiteReadExpressionsApi.Single<TaskStepEntity>(dbCon, (Expression<Func<TaskStepEntity, bool>>)(x => x.ID == jobFeedBack.JOBID));
                    if (stepEntity != null)
                    {
                        stepEntity.STEPSTATE = "3";
                        dbCon.Update<TaskStepEntity>(stepEntity, (Expression<Func<TaskStepEntity, bool>>)(x => x.ID == stepEntity.ID), (Action<IDbCommand>)null);
                        TaskEntity taskEntity = OrmLiteReadExpressionsApi.Single<TaskEntity>(dbCon, (Expression<Func<TaskEntity, bool>>)(x => x.TASKNO == stepEntity.TASKNO));
                        //dtoResponse = BPCommon.NextTaskStep(dbCon, dbTrans, taskEntity);
                        if (!dtoResponse.IsSuccess)
                            return dtoResponse;
                        jobFeedBack.STATUS = 1;
                        ++jobFeedBack.RESPONDCOUNT;
                        jobFeedBack.RESPONDDATE = Utils.GetTodayNow();
                        jobFeedBack.RESPONDMSG = "反馈成功";
                        dbCon.Update<INF_JOBFEEDBACKEntity>(jobFeedBack, (Action<IDbCommand>)null);
                        dtoResponse.IsSuccess = true;
                        dtoResponse.MessageText = "子任务" + jobFeedBack.JOBID + "处理成功！";
                        return dtoResponse;
                    }
                    dtoResponse.IsSuccess = false;
                    dtoResponse.MessageText = "查找任务" + jobFeedBack.JOBID + "失败！";
                    dtoResponse.MessageCode = "9999";
                    return dtoResponse;
                }
                this.InsertTaskStat(jobFeedBack);
                if (projTaskEntity.TASKTCLASS == "3")
                {
                    if (jobFeedBack.FEEDBACKSTATUS == "1")
                    {
                        projTaskEntity.TASKSTATE = jobFeedBack.FEEDBACKSTATUS;
                        projTaskEntity.STARTDATE = Utils.GetTodayNow();
                        projTaskEntity.TASKMESSAGE = "任务开始";
                    }
                    if (jobFeedBack.FEEDBACKSTATUS == "99")
                    {
                        projTaskEntity.TASKSTATE = jobFeedBack.FEEDBACKSTATUS;
                        projTaskEntity.ENDDATE = Utils.GetTodayNow();
                        projTaskEntity.TASKMESSAGE = "任务结束";
                    }
                }
                else
                {
                    if (jobFeedBack.FEEDBACKSTATUS == "1")
                    {
                        projTaskEntity.TASKSTATE = jobFeedBack.FEEDBACKSTATUS;
                        projTaskEntity.STARTDATE = Utils.GetTodayNow();
                        projTaskEntity.TASKMESSAGE = "任务开始";
                    }
                    if (jobFeedBack.FEEDBACKSTATUS == "3")
                    {
                        projTaskEntity.TRUCKNO = jobFeedBack.EXTATTR1;
                        projTaskEntity.TRUCKNO_PLAN = Utils.GetTodayNow();
                        projTaskEntity.TASKMESSAGE = "设备开始执行";
                    }
                    if (jobFeedBack.FEEDBACKSTATUS == "99")
                    {
                        projTaskEntity.TASKSTATE = jobFeedBack.FEEDBACKSTATUS;
                        projTaskEntity.ENDDATE = Utils.GetTodayNow();
                        projTaskEntity.TASKMESSAGE = "任务结束";
                        string sql1 = string.Format("UPDATE PROJ_LOCATION_DETAIL SET STORESTATE='0' WHERE LOCATIONNO='{0}'", (object)projTaskEntity.SOURCE01);
                        dbCon.ExecuteSql(sql1);
                        string sql2 = string.Format("UPDATE PROJ_LOCATION_DETAIL SET STORESTATE='1' WHERE LOCATIONNO='{0}'", (object)projTaskEntity.DESTINATION01);
                        dbCon.ExecuteSql(sql2);
                        string sql3 = string.Format("UPDATE PROJ_ULDINFO SET CURRLOC='{2}',MODIFYBY='{3}',MODIFYDATE='{4}',CURRSTATE=CURRSTATE+1 WHERE ULDNO='{0}' AND P01='{1}'", (object)projTaskEntity.PALLETNO, (object)projTaskEntity.BILLID, (object)projTaskEntity.DESTINATION01, (object)projTaskEntity.TASKNO, (object)Utils.GetDatetime());
                        dbCon.ExecuteSql(sql3);
                        string sql4 = string.Format("UPDATE PROJ_ULDCARRYPLAN SET P10='{2}',MODIFYBY='{3}',MODIFYDATE='{4}' WHERE PLANNO='{0}' AND ULDNO='{1}'", (object)projTaskEntity.BILLID, (object)projTaskEntity.PALLETNO, (object)projTaskEntity.DESTINATION02, (object)projTaskEntity.TASKNO, (object)Utils.GetDatetime());
                        dbCon.ExecuteSql(sql4);
                        if (SysParamsService.CheckPrarams("SimulatorTaskOver").ToLower() == "true")
                            this.UpdateInfEquipmentStatus(dbCon, dbTrans, projTaskEntity);
                        //dtoResponse = BPCommon.NextTaskStep(dbCon, dbTrans, projTaskEntity);
                        if (!dtoResponse.IsSuccess)
                            return dtoResponse;
                        this.GetDataFromDCS(new List<long>()
            {
              long.Parse(projTaskEntity.TASKNO)
            });
                    }
                }
                jobFeedBack.STATUS = 1;
                ++jobFeedBack.RESPONDCOUNT;
                jobFeedBack.RESPONDDATE = Utils.GetTodayNow();
                jobFeedBack.RESPONDMSG = "反馈成功";
                int num1 = dbCon.Update<INF_JOBFEEDBACKEntity>(jobFeedBack, (Action<IDbCommand>)null);
                int num2 = dbCon.Update<TaskEntity>(projTaskEntity, (Action<IDbCommand>)null);
                if (num1 == 1 && num2 == 1)
                {
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "执行操作成功！";
                }
                return dtoResponse;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                DCSInfService.logger.Error((object)ex);
                return dtoResponse;
            }
            finally
            {
                HelperDbOperation.EndTransaction(dtoResponse.IsSuccess, ref dbCon, ref dbTrans);
                if (dtoResponse.MessageCode == "9999")
                    this.UpdataJobFeedBack(id, msg);
            }
        }

        private void UpdataJobFeedBack(string id, string msg)
        {
            if (id == null)
                return;
            try
            {
                HelperDbOperation.ExecuteSql(string.Format("UPDATE INF_JOBFEEDBACK SET RESPONDCOUNT=RESPONDCOUNT+1,RESPONDDATE='{1}',RESPONDMSG='{2}' WHERE ID='{0}'", (object)id, (object)Utils.GetTodayNow(), (object)msg.GetMaxString(100)));
            }
            catch (Exception ex)
            {
                DCSInfService.logger.Error((object)ex);
            }
        }

        public DTOResponse UpdateEquipmentStatus()
        {
            DTOResponse dtoResponse = new DTOResponse();
            IDbConnection dbCon = (IDbConnection)null;
            IDbTransaction dbTrans = (IDbTransaction)null;
            try
            {
                object obj = HelperDbOperation.ExecuteScalar("SELECT ID FROM PROJ_ULDSCENE WHERE SCENESTATE=1");
                HelperDbOperation.BeginTransaction(ref dbCon, ref dbTrans);
                List<INF_EQUIPMENTSTATUSEntity> equipmentstatusEntityList = dbCon.Select<INF_EQUIPMENTSTATUSEntity>((Expression<Func<INF_EQUIPMENTSTATUSEntity, bool>>)(x => x.WMSLOCNUM == "none" && x.STATUS == 0));
                foreach (INF_EQUIPMENTSTATUSEntity equipmentstatusEntity in equipmentstatusEntityList)
                {
                    if (equipmentstatusEntity.EQUIPMENTSTATUS == "1")
                    {
                        string str1 = "0";
                        string str2 = "故障代码：" + equipmentstatusEntity.EQUIPMENTSTATUS;
                        string todayNow = Utils.GetTodayNow();
                        string sql1 = string.Format("UPDATE PROJ_LOCATION_DETAIL SET LOCATIONSTATE='{1}',OPMESSAGE='{2}',OPDATE='{3}',OPBY='dcs' WHERE CONTROLID='{0}'", (object)equipmentstatusEntity.EQUIPMENTID, (object)str1, (object)str2, (object)todayNow);
                        int num1 = dbCon.ExecuteSql(sql1);
                        string sql2 = (string)null;
                        int num2 = 0;
                        string sql3 = (string)null;
                        int num3 = 0;
                        int num4 = 0;
                        if (Convert.ToInt32(obj) < 100)
                        {
                            sql2 = string.Format("UPDATE PROJ_STATIONINFO SET STATIONSTATE='{1}',OPMESSAGE='{2}',OPDATE='{3}',OPBY='dcs' WHERE CONTROLNO IN (SELECT GROUPNO FROM PROJ_LOCATION_DETAIL WHERE CONTROLID='{0}')", (object)equipmentstatusEntity.EQUIPMENTID, (object)"1", (object)str2, (object)todayNow);
                            num2 = dbCon.ExecuteSql(sql2);
                            sql3 = string.Format("UPDATE PROJ_STATIONINFO SET STATIONSTATE='{1}',OPMESSAGE='{2}',OPDATE='{3}',OPBY='dcs' WHERE CONTROLNO IN (SELECT AREANO FROM PROJ_LOCATION_DETAIL WHERE CONTROLID='{0}')", (object)equipmentstatusEntity.EQUIPMENTID, (object)"1", (object)str2, (object)todayNow);
                            num3 = dbCon.ExecuteSql(sql3);
                            if (SysParamsService.CheckPrarams("StationErrorUpdateRelate").ToLower() == "true")
                            {
                                string sql4 = string.Format("UPDATE PROJ_STATIONINFO SET ISCLOSE={1} WHERE STATIONNO IN ( SELECT RELATENO FROM PROJ_STATIONRELATE WHERE STATIONNO IN ( SELECT AREANO FROM PROJ_LOCATION_DETAIL WHERE CONTROLID='{0}'))", (object)equipmentstatusEntity.EQUIPMENTID, (object)0);
                                num4 = dbCon.ExecuteSql(sql4);
                            }
                        }
                        DCSInfService.logger.Info((object)sql2);
                        DCSInfService.logger.Info((object)sql3);
                        DCSInfService.logger.Info((object)(equipmentstatusEntity.EQUIPMENTID + ":" + num1.ToString() + "/" + num2.ToString() + "/" + num3.ToString() + " " + str2));
                        SysAlterInfoService.InsertAlterInfo("2", equipmentstatusEntity.EQUIPMENTID + "故障恢复！" + str2, "1");
                    }
                    else
                    {
                        string str1 = "error";
                        string str2 = "故障代码：" + equipmentstatusEntity.EQUIPMENTSTATUS;
                        string todayNow = Utils.GetTodayNow();
                        string sql1 = string.Format("UPDATE PROJ_LOCATION_DETAIL SET LOCATIONSTATE='{1}',OPMESSAGE='{2}',OPDATE='{3}',OPBY='dcs' WHERE CONTROLID='{0}'", (object)equipmentstatusEntity.EQUIPMENTID, (object)str1, (object)str2, (object)todayNow);
                        int num1 = dbCon.ExecuteSql(sql1);
                        string sql2 = (string)null;
                        int num2 = 0;
                        string sql3 = (string)null;
                        int num3 = 0;
                        int num4 = 0;
                        if (Convert.ToInt32(obj) < 100)
                        {
                            sql2 = string.Format("UPDATE PROJ_STATIONINFO SET STATIONSTATE='{1}',OPMESSAGE='{2}',OPDATE='{3}',OPBY='dcs' WHERE CONTROLNO IN (SELECT GROUPNO FROM PROJ_LOCATION_DETAIL WHERE CONTROLID='{0}')", (object)equipmentstatusEntity.EQUIPMENTID, (object)"0", (object)str2, (object)todayNow);
                            num2 = dbCon.ExecuteSql(sql2);
                            sql3 = string.Format("UPDATE PROJ_STATIONINFO SET STATIONSTATE='{1}',OPMESSAGE='{2}',OPDATE='{3}',OPBY='dcs' WHERE CONTROLNO IN (SELECT AREANO FROM PROJ_LOCATION_DETAIL WHERE CONTROLID='{0}')", (object)equipmentstatusEntity.EQUIPMENTID, (object)"0", (object)str2, (object)todayNow);
                            num3 = dbCon.ExecuteSql(sql3);
                            if (SysParamsService.CheckPrarams("StationErrorUpdateRelate").ToLower() == "true")
                            {
                                string sql4 = string.Format("UPDATE PROJ_STATIONINFO SET ISCLOSE={1} WHERE STATIONNO IN ( SELECT RELATENO FROM PROJ_STATIONRELATE WHERE STATIONNO IN ( SELECT AREANO FROM PROJ_LOCATION_DETAIL WHERE CONTROLID='{0}'))", (object)equipmentstatusEntity.EQUIPMENTID, (object)9);
                                num4 = dbCon.ExecuteSql(sql4);
                            }
                        }
                        DCSInfService.logger.Info((object)sql2);
                        DCSInfService.logger.Info((object)sql3);
                        DCSInfService.logger.Info((object)(equipmentstatusEntity.EQUIPMENTID + ":" + num1.ToString() + "/" + num2.ToString() + "/" + num3.ToString() + " " + str2));
                        SysAlterInfoService.InsertAlterInfo("2", equipmentstatusEntity.EQUIPMENTID + "发生故障！" + str2, "1");
                    }
                    string sql = string.Format("UPDATE INF_EQUIPMENTSTATUS SET STATUS=1,MODIFYDATE='{1}' WHERE ID='{0}'", (object)equipmentstatusEntity.ID, (object)Utils.GetDatetime());
                    dbCon.ExecuteSql(sql);
                }
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "执行设备状态更新:" + equipmentstatusEntityList.Count.ToString();
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                DCSInfService.logger.Error((object)ex);
                return dtoResponse;
            }
            finally
            {
                HelperDbOperation.EndTransaction(dtoResponse.IsSuccess, ref dbCon, ref dbTrans);
            }
        }

        public DTOResponse UpdateKanbanFormEquipmentStatus()
        {
            DTOResponse dTOResponse = new DTOResponse();
            try
            {
                List<INF_EQUIPMENTSTATUSEntity> list = HelperDbOperation.Select<INF_EQUIPMENTSTATUSEntity>(x => x.WMSLOCNUM == "none");
                // from x in HelperDbOperation
                //select x.WMSLOCNUM == "none";
                foreach (INF_EQUIPMENTSTATUSEntity item in list)
                {
                    DateTime dateTime = DateTime.Parse(item.UPDATEDATE);
                    DateTime now = DateTime.Now;
                    TimeSpan timeSpan = Utils.DateDiff(dateTime, now);
                    if (timeSpan.TotalSeconds < 60.0)
                    {
                        string eQUIPMENTID = item.EQUIPMENTID;
                        string jOBID = item.JOBID;
                        if (eQUIPMENTID.StartsWith("3"))
                        {
                            //dTOResponse = BPCommon.SetOutKanban_zhongxiang(eQUIPMENTID, item.JOBID);
                            //dTOResponse = BPCommon.SetOutKanban_hengxiang(eQUIPMENTID, item.JOBID);
                        }
                        logger.Info(timeSpan.TotalSeconds.ToString() + "秒" + item.EQUIPMENTID + "更新信息：" + item.JOBID + "/" + item.BARCODE + "/" + item.TARGET + "/" + item.TUTYPE);
                        if (eQUIPMENTID.StartsWith("2") && (item.TARGET == eQUIPMENTID || item.TARGET == "1") && int.Parse(item.JOBID) > 0)
                        {
                            //HelperRule.UpdateRkStation(eQUIPMENTID, item.JOBID);
                        }
                    }
                }
                dTOResponse.IsSuccess = true;
                dTOResponse.MessageText = "执行操作成功！";
                return dTOResponse;
            }
            catch (Exception ex)
            {
                dTOResponse.IsSuccess = false;
                dTOResponse.MessageText = ex.Message;
                logger.Error(ex);
                return dTOResponse;
            }
        }

        public DTOResponse InsertTaskStat(INF_JOBFEEDBACKEntity jobFeedBack)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                TaskStatEntity projTaskstatEntity = new TaskStatEntity();
                projTaskstatEntity.TASKNO = jobFeedBack.JOBID;
                projTaskstatEntity.STATITEMNAME = jobFeedBack.FEEDBACKSTATUS;
                projTaskstatEntity.STATITEMDESC = jobFeedBack.FEEDBACKSTATUS;
                projTaskstatEntity.STATITEMVALUE = "0";
                projTaskstatEntity.CREATETIME = Utils.GetDatetime();
                projTaskstatEntity.P01 = jobFeedBack.ENTERDATE;
                projTaskstatEntity.P02 = Utils.GetDatetime();
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                    dbConn.Save<TaskStatEntity>(projTaskstatEntity, false);
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "保存 PROJ_TASKSTAT成功！";
                DCSInfService.logger.Info((object)dtoResponse);
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                DCSInfService.logger.Error((object)ex);
                return dtoResponse;
            }
        }

        public DTOResponse GetDataFromDCS(List<long> jobidList)
        {
            DTOResponse dTOResponse = new DTOResponse();
            try
            {
                string arg = jobidList.ToInString();
                List<object> list = null;
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory("DCS").OpenDbConnection())
                {
                    string sql = $"select wjid,rid,sc,tg,paid,st,ts,et,sct from sm_wcs_jb_ts_od where wjid in ({arg}) order by wjid,et";
                    list = dbConn.Select<object>(sql);
                }
                List<TaskStatEntity> list2 = new List<TaskStatEntity>();
                foreach (dynamic item in list)
                {
                    TaskStatEntity pROJ_TASKSTATEntity = new TaskStatEntity();
                    pROJ_TASKSTATEntity.TASKNO = item.wjid;
                    pROJ_TASKSTATEntity.STATITEMNAME = item.paid;
                    pROJ_TASKSTATEntity.STATITEMDESC = item.rid;
                    DateTime d = Convert.ToDateTime(item.et);
                    DateTime d2 = Convert.ToDateTime(item.sct);
                    pROJ_TASKSTATEntity.STATITEMVALUE = (d2 - d).Seconds.ToString();
                    pROJ_TASKSTATEntity.P01 = item.et;
                    pROJ_TASKSTATEntity.P02 = item.sct;
                    pROJ_TASKSTATEntity.CREATETIME = Utils.GetDatetime();
                    list2.Add(pROJ_TASKSTATEntity);
                }
                long num = 0L;
                using (IDbConnection dbConn2 = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    num = dbConn2.SaveAll(list2);
                }
                dTOResponse.IsSuccess = true;
                dTOResponse.MessageText = "获取tsorder成功！" + num.ToString();
                logger.Info(dTOResponse);
                return dTOResponse;
            }
            catch (Exception ex)
            {
                dTOResponse.IsSuccess = false;
                dTOResponse.MessageText = ex.Message;
                logger.Error(ex);
                return dTOResponse;
            }
        }

        private void UpdateInfEquipmentStatus(IDbConnection dbCon, IDbTransaction dbTrans, TaskEntity entity)
        {
            string sql = string.Format("UPDATE INF_EQUIPMENTSTATUS SET JOBID='{1}',BARCODE='{2}',UPDATEDATE='{3}' WHERE EQUIPMENTID='{0}'", entity.DESTINATION02, entity.TASKNO, entity.PALLETNO, Utils.GetDatetime());
            int num = dbCon.ExecuteSql(sql);
        }


        /// <summary>
        /// 设备请求处理
        /// </summary>
        /// <returns></returns>
        public DTOResponse EquipmentRequestHandle()
        {
            throw new NotImplementedException();
        }
    }
}
