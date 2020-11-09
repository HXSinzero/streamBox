using KR.BaseApp;
using KR.BaseApp.Services;
using KR.CIMS;
using KR.WMApp.BPTemplet;
using KR.WMApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace KR.WMApp.Services
{
    /// <summary>
    /// 搬运任务管理
    /// </summary>
    public class TaskService : LogService
    {
        public DTOResponse GetTaskList(TaskRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                if (request.IsHistory == "1")
                    return this.GetHistoryList(request);
                return this.GetList(request);
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                TaskService.logger.Error((object)ex);
            }
            return dtoResponse;
        }

        private DTOResponse GetList(TaskRequest request)
        {
         
            using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
            {
                DTOResponse dtoResponse = new DTOResponse();
                SqlExpression<TaskEntity> expression = dbConn.From<TaskEntity>();

                DateTime dt1;
                DateTime dt2;
                bool s = ProjToolHelper.TryParseDatetimerange(request.datetimerange, out dt1, out dt2);
                if (s)
                {
                    //按时间段查询
                    expression.And(x => x.CREATEDATETIME >= dt1 && x.CREATEDATETIME <= dt2);
                }

                if (!string.IsNullOrEmpty(request.TASKTCLASS) && request.TASKTCLASS != "0")
                    expression.And((Expression<Func<TaskEntity, bool>>)(x => x.TASKTCLASS == request.TASKTCLASS));

                if (!string.IsNullOrEmpty(request.ID) && request.ID != "0")
                    expression.And((Expression<Func<TaskEntity, bool>>)(x => x.ID == long.Parse(request.ID)));

                if (!string.IsNullOrEmpty(request.TASKNO))
                    expression.And((Expression<Func<TaskEntity, bool>>)(x => x.TASKNO == request.TASKNO));
                if (!string.IsNullOrEmpty(request.PALLETID))
                    expression.And((Expression<Func<TaskEntity, bool>>)(x => x.PALLETID == request.PALLETID));
                if (!string.IsNullOrEmpty(request.PALLETNO))
                    expression.And((Expression<Func<TaskEntity, bool>>)(x => x.PALLETNO == request.PALLETNO));
                if (!string.IsNullOrEmpty(request.RelateNo))
                    expression.And((Expression<Func<TaskEntity, bool>>)(x => x.RELATENO == request.RelateNo));

                if (!string.IsNullOrEmpty(request.SourceNo))
                    expression.And((Expression<Func<TaskEntity, bool>>)(x => x.SOURCE02 == request.SourceNo));
                if (!string.IsNullOrEmpty(request.DescNo))
                    expression.And((Expression<Func<TaskEntity, bool>>)(x => x.DESTINATION02 == request.DescNo));

                if (!string.IsNullOrEmpty(request.TASKSTATE))
                {
                    if (request.TASKSTATE == "notover")
                    {
                        List<string> status = new List<string>() { "99", "4" };
                        expression.And(x => !status.Contains(x.TASKSTATE));
                    }
                    else
                    {
                        expression.And((Expression<Func<TaskEntity, bool>>)(x => x.TASKSTATE == request.TASKSTATE));
                    }
                }

                long num = dbConn.Count<TaskEntity>(expression);
                List<TaskEntity> list = dbConn.Select<TaskEntity>(expression).OrderByDescending<TaskEntity, long>((Func<TaskEntity, long>)(x => x.ID)).Skip<TaskEntity>((request.page - 1) * request.limit).Take<TaskEntity>(request.limit).ToList<TaskEntity>();
                dtoResponse.TotalCount = num;
                dtoResponse.ResultObject = (object)list;
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "查询操作成功！";
                return dtoResponse;
            }
        }

        private DTOResponse GetHistoryList(TaskRequest request)
        {
            using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
            {
                DTOResponse dtoResponse = new DTOResponse();
                SqlExpression<ZHISTaskEntity> expression = dbConn.From<ZHISTaskEntity>();
                if (!string.IsNullOrEmpty(request.TASKTCLASS) && request.TASKTCLASS != "0")
                    expression.And((Expression<Func<ZHISTaskEntity, bool>>)(x => x.TASKTCLASS == request.TASKTCLASS));
                if (!string.IsNullOrEmpty(request.PALLETNO))
                    expression.And((Expression<Func<ZHISTaskEntity, bool>>)(x => x.PALLETNO == request.PALLETNO));
                if (!string.IsNullOrEmpty(request.RelateNo))
                    expression.And((Expression<Func<ZHISTaskEntity, bool>>)(x => x.RELATENO == request.RelateNo));

                if (!string.IsNullOrEmpty(request.SourceNo))
                    expression.And((Expression<Func<ZHISTaskEntity, bool>>)(x => x.SOURCE02 == request.SourceNo));
                if (!string.IsNullOrEmpty(request.DescNo))
                    expression.And((Expression<Func<ZHISTaskEntity, bool>>)(x => x.DESTINATION02 == request.DescNo));

                long num = dbConn.Count<ZHISTaskEntity>(expression);
                List<ZHISTaskEntity> list = dbConn.Select<ZHISTaskEntity>(expression).OrderByDescending<ZHISTaskEntity, long>((Func<ZHISTaskEntity, long>)(x => x.ID)).Skip<ZHISTaskEntity>((request.page - 1) * request.limit).Take<ZHISTaskEntity>(request.limit).ToList<ZHISTaskEntity>();
                dtoResponse.TotalCount = num;
                dtoResponse.ResultObject = (object)list;
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "查询操作成功！";
                return dtoResponse;
            }
        }

        public DTOResponse GetTaskStepList(TaskRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    long num = dbConn.Count<TaskStepEntity>((Expression<Func<TaskStepEntity, bool>>)(x => x.TASKNO == request.TASKNO));
                    List<TaskStepEntity> list = dbConn.Select<TaskStepEntity>((Expression<Func<TaskStepEntity, bool>>)(x => x.TASKNO == request.TASKNO)).OrderBy<TaskStepEntity, string>((Func<TaskStepEntity, string>)(x => x.ID)).ToList<TaskStepEntity>();
                    dtoResponse.TotalCount = num;
                    dtoResponse.ResultObject = (object)list;
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "查询操作成功！";
                }
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                TaskService.logger.Error((object)ex);
            }
            return dtoResponse;
        }

        public DTOResponse TaskOprationByMen(TaskRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                if (request.TASKOPACTION == "Cancel")
                {
                    using (IDbConnection dbConnection = HelperConnection.GetConnectionFactory().OpenDbConnection())
                    {
                        using (IDbTransaction dbTrans = dbConnection.OpenTransaction())
                        {
                            TaskEntity taskEntity = OrmLiteReadExpressionsApi.Single<TaskEntity>(dbConnection, (Expression<Func<TaskEntity, bool>>)(x => x.TASKNO == request.TASKNO));
                            if (taskEntity == null)
                                throw new Exception("未查询到任务：" + request.TASKNO);
                            //dtoResponse = BPCommon.TaskCancel(dbConnection, dbTrans, taskEntity);
                            //if (!dtoResponse.IsSuccess)
                            //{
                            //    dtoResponse.MessageText = "取消任务操作1失败：" + dtoResponse.MessageText;
                            //    dbTrans.Rollback();
                            //    return dtoResponse;
                            //}
                            //int jobType = 2;
                            //dtoResponse = BPCommon.OrderTask(dbConnection, dbTrans, taskEntity, jobType);
                            //if (dtoResponse.IsSuccess)
                            //{
                            //    dtoResponse.MessageText = "取消任务操作2成功！" + dtoResponse.MessageText;
                            //    dbTrans.Commit();
                            //    return dtoResponse;
                            //}
                            dtoResponse.MessageText = "取消任务操作2失败：" + dtoResponse.MessageText;
                            dbTrans.Rollback();
                            return dtoResponse;
                        }
                    }
                }

                if (request.TASKOPACTION == "OrderDCS")
                {
                    using (IDbConnection dbConnection = HelperConnection.GetConnectionFactory().OpenDbConnection())
                    {
                        using (IDbTransaction dbTrans = dbConnection.OpenTransaction())
                        {
                            TaskEntity taskEntity = OrmLiteReadExpressionsApi.Single<TaskEntity>(dbConnection, (Expression<Func<TaskEntity, bool>>)(x => x.TASKNO == request.TASKNO));
                            if (taskEntity == null)
                                throw new Exception("未查询到任务：" + request.TASKNO);

                            SysSequenceResult sequenceResult = SysSequenceInstance.Instance().GetSysSequence("TASKID");
                            taskEntity.TASKNO = int.Parse(sequenceResult.SEQVALUE).ToString();

                            SqlExpression<TaskEntity> sqlExpression = dbConnection.From<TaskEntity>();
                            sqlExpression.Where(x => x.ID == taskEntity.ID);
                            sqlExpression.UpdateFields.Add("TASKNO");
                            int count = dbConnection.UpdateOnly<TaskEntity>(taskEntity, sqlExpression);

                            int jobType = BPCommonBase.ConvertJobtype(taskEntity.TASKTCLASS);

                            dtoResponse = BPCommonBase.OrderTask(dbConnection, dbTrans, taskEntity, jobType);
                            if (dtoResponse.IsSuccess)
                            {
                                dtoResponse.MessageText = "重新下达任务操作成功！" + dtoResponse.MessageText;
                                dbTrans.Commit();
                                return dtoResponse;
                            }
                            else
                            {
                                dtoResponse.MessageText = "重新下达任务操作失败：" + dtoResponse.MessageText;
                                dbTrans.Rollback();
                                return dtoResponse;
                            }
                        }
                    }
                }

                if (request.TASKOPACTION == "Over")
                {
                    List<INF_JOBFEEDBACKEntity> jobfeedbackEntityList = new List<INF_JOBFEEDBACKEntity>();

                    INF_JOBFEEDBACKEntity jobfeedbackEntity1 = new INF_JOBFEEDBACKEntity();
                    jobfeedbackEntity1.ID = Utils.GetDateTimeGuid();
                    jobfeedbackEntity1.JOBID = request.TASKNO;
                    jobfeedbackEntity1.WAREHOUSEID = "none";
                    jobfeedbackEntity1.FEEDBACKSTATUS = "1";
                    jobfeedbackEntity1.ERRORCODE = "0";
                    jobfeedbackEntity1.ENTERDATE = Utils.GetTodayNow();
                    jobfeedbackEntity1.CREATEDATE = Utils.GetTodayNow();
                    jobfeedbackEntity1.RESPONDCOUNT = 0;
                    jobfeedbackEntity1.STATUS = 0;
                    jobfeedbackEntity1.FULLCOUNT = 0;
                    jobfeedbackEntity1.ROWVERSION = 0;
                    jobfeedbackEntityList.Add(jobfeedbackEntity1);

                    INF_JOBFEEDBACKEntity jobfeedbackEntity2 = new INF_JOBFEEDBACKEntity();
                    jobfeedbackEntity2.ID = Utils.GetDateTimeGuid();
                    jobfeedbackEntity2.JOBID = request.TASKNO;
                    jobfeedbackEntity2.WAREHOUSEID = "none";
                    jobfeedbackEntity2.FEEDBACKSTATUS = "99";
                    jobfeedbackEntity2.ERRORCODE = "0";
                    jobfeedbackEntity2.ENTERDATE = Utils.GetTodayNow();
                    jobfeedbackEntity2.CREATEDATE = Utils.GetTodayNow();
                    jobfeedbackEntity2.RESPONDCOUNT = 0;
                    jobfeedbackEntity2.STATUS = 0;
                    jobfeedbackEntity2.FULLCOUNT = 0;
                    jobfeedbackEntity2.ROWVERSION = 0;
                    jobfeedbackEntityList.Add(jobfeedbackEntity2);

                    long num1 = 0;
                    using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                    {
                        foreach (INF_JOBFEEDBACKEntity jobfeedbackEntity in jobfeedbackEntityList)
                        {
                            long num2 = dbConn.Insert<INF_JOBFEEDBACKEntity>(jobfeedbackEntity, false);
                            num1 += num2;
                        }
                    }
                    dtoResponse.IsSuccess = num1 > 1L;
                    dtoResponse.MessageText = "任务操作成功";
                    return dtoResponse;
                }
                else
                {
                    List<INF_JOBFEEDBACKEntity> jobfeedbackEntityList = new List<INF_JOBFEEDBACKEntity>();

                    jobfeedbackEntityList.Add(new INF_JOBFEEDBACKEntity()
                    {
                        ID = Utils.GetDateTimeGuid(),
                        JOBID = request.TASKNO,
                        WAREHOUSEID = "none",
                        FEEDBACKSTATUS = request.TASKOPACTION,
                        ERRORCODE = "0",
                        ENTERDATE = Utils.GetTodayNow(),
                        CREATEDATE = Utils.GetTodayNow(),
                        RESPONDCOUNT = 0,
                        STATUS = 0,
                        FULLCOUNT = 0,
                        ROWVERSION = 0
                    });

                    long num1 = 0;
                    using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                    {
                        foreach (INF_JOBFEEDBACKEntity jobfeedbackEntity in jobfeedbackEntityList)
                        {
                            long num2 = dbConn.Insert<INF_JOBFEEDBACKEntity>(jobfeedbackEntity, false);
                            num1 += num2;
                        }
                    }
                    dtoResponse.IsSuccess = num1 > 1L;
                    dtoResponse.MessageText = "任务操作成功";
                    return dtoResponse;
                }
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                TaskService.logger.Error((object)ex);
            }
            return dtoResponse;
        }
    }
}
