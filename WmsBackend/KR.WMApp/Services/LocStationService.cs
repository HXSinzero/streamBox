using KR.BaseApp;
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
    public class LocStationService : LogService
    {
        public DTOResponse GetList(LocationStnRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {

                    SqlExpression<LocStationInfoEntity> expression = dbConn.From<LocStationInfoEntity>();
                    if (!string.IsNullOrEmpty(request.STATIONTYPE) && request.STATIONTYPE != "0")
                    {
                        expression.And(x => x.STATIONTYPE == request.STATIONTYPE);
                    }

                    if (!string.IsNullOrEmpty(request.TECHNO) && request.TECHNO != "000")
                    {
                        expression.And(x => x.TECHNO == request.TECHNO);
                    }

                    List<LocStationInfoEntity> list = dbConn.Select<LocStationInfoEntity>(expression).OrderBy<LocStationInfoEntity, string>((Func<LocStationInfoEntity, string>)(x => x.ID)).ToList<LocStationInfoEntity>();

                    dtoResponse.ResultObject = (object)list;
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "查询操作成功！";
                }
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                logger.Error((object)ex);
            }
            return dtoResponse;
        }

        public DTOResponse SetP01(LocationStnRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConnection = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    using (IDbTransaction trans = dbConnection.OpenTransaction())
                    {
                        request.CONTROLMODE = 1;
                        dtoResponse = this.SetP01(request, dbConnection, trans);
                        if (dtoResponse.IsSuccess)
                            trans.Commit();
                        else
                            trans.Rollback();
                        return dtoResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                logger.Error((object)ex);
                return dtoResponse;
            }
        }

        public DTOResponse SetP01(
          LocationStnRequest request,
          IDbConnection db,
          IDbTransaction trans)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                LocStationInfoEntity stationinfoEntity = db.Single<LocStationInfoEntity>(x => x.STATIONNO == request.STATIONNO);
                if (stationinfoEntity != null)
                {
                    //如果是紧急出口EMEXIT==1,0==正常出口，不允许分配
                    if (stationinfoEntity.EMEXIT == 1)
                    {
                        throw new Exception("紧急出口,不允许分配！");
                    }

                    stationinfoEntity.LOCATIONX = request.LOCATIONX;
                    stationinfoEntity.PRIORITY = request.PRIORITY;
                    stationinfoEntity.TASKCOUNT = request.TASKCOUNT;
                    stationinfoEntity.P03 = request.P03;
                    stationinfoEntity.P04 = request.P04;
                    stationinfoEntity.OPBY = SysInfo.CurrentUserName;
                    stationinfoEntity.OPDATE = Utils.GetTodayNow();
                    stationinfoEntity.OPMESSAGE = "设置站台参数！";
                    stationinfoEntity.CONTROLMODE = new Decimal?((Decimal)request.CONTROLMODE);

                    SqlExpression<LocStationInfoEntity> sqlExpression = db.From<LocStationInfoEntity>();
                    sqlExpression.Where(x => x.ID == stationinfoEntity.ID);
                    sqlExpression.UpdateFields.Add("LOCATIONX");
                    sqlExpression.UpdateFields.Add("PRIORITY");
                    sqlExpression.UpdateFields.Add("TASKCOUNT");
                    sqlExpression.UpdateFields.Add("P03");
                    sqlExpression.UpdateFields.Add("P04");

                    sqlExpression.UpdateFields.Add("OPBY");
                    sqlExpression.UpdateFields.Add("OPDATE");
                    sqlExpression.UpdateFields.Add("OPMESSAGE");
                    sqlExpression.UpdateFields.Add("CONTROLMODE");

                    db.UpdateOnly<LocStationInfoEntity>(stationinfoEntity, sqlExpression);

                }
                SysAlterInfoService.InsertAlterInfo("1", request.STATIONNO + "设置站台参数：" + request.ToJson(), "1");
                dtoResponse.ResultObject = (object)new List<LocStationInfoEntity>()
                {
                  stationinfoEntity
                };
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "操作成功！";
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                logger.Error((object)ex);
                return dtoResponse;
            }
        }

        public DTOResponse SetP01Emplty(LocationStnRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConnection = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    using (IDbTransaction trans = dbConnection.OpenTransaction())
                    {
                        dtoResponse = this.SetP01Emplty(request, dbConnection, trans);
                        if (dtoResponse.IsSuccess)
                            trans.Commit();
                        else
                            trans.Rollback();
                        return dtoResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                logger.Error((object)ex);
                return dtoResponse;
            }
        }

        public DTOResponse SetP01Emplty(
          LocationStnRequest request,
          IDbConnection db,
          IDbTransaction trans)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                LocStationInfoEntity stationinfoEntity = db.Single<LocStationInfoEntity>(x => x.STATIONNO == request.STATIONNO);
                if (stationinfoEntity != null)
                {
                    stationinfoEntity.WORNO = (string)null;
                    stationinfoEntity.WORLINE = (string)null;
                    stationinfoEntity.WORSTATE = (string)null;
                    stationinfoEntity.OPBY = SysInfo.CurrentUserName;
                    stationinfoEntity.OPDATE = Utils.GetTodayNow();
                    stationinfoEntity.OPMESSAGE = "清空工单设置";
                    stationinfoEntity.CONTROLMODE = new Decimal?(new Decimal());
                    stationinfoEntity.ISCLOSE = 0;

                    SqlExpression<LocStationInfoEntity> sqlExpression = db.From<LocStationInfoEntity>();
                    sqlExpression.Where(x => x.ID == stationinfoEntity.ID);
                    sqlExpression.UpdateFields.Add("WORNO");
                    sqlExpression.UpdateFields.Add("WORLINE");
                    sqlExpression.UpdateFields.Add("WORSTATE");

                    sqlExpression.UpdateFields.Add("OPBY");
                    sqlExpression.UpdateFields.Add("OPDATE");
                    sqlExpression.UpdateFields.Add("OPMESSAGE");
                    sqlExpression.UpdateFields.Add("CONTROLMODE");
                    sqlExpression.UpdateFields.Add("ISCLOSE");

                    db.UpdateOnly<LocStationInfoEntity>(stationinfoEntity, sqlExpression);

                }
                SysAlterInfoService.InsertAlterInfo("1", request.STATIONNO + "清空工单设置", "1");
                dtoResponse.ResultObject = (object)new List<LocStationInfoEntity>()
                {
                  stationinfoEntity
                };
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "操作成功！";
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                logger.Error((object)ex);
                return dtoResponse;
            }
        }

        public DTOResponse SetSTATIONSTATE(LocationStnRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                int num = 0;
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    using (IDbTransaction dbTransaction = dbConn.OpenTransaction())
                    {
                        LocStationInfoEntity stationinfoEntity = OrmLiteReadExpressionsApi.Single<LocStationInfoEntity>(dbConn, (Expression<Func<LocStationInfoEntity, bool>>)(x => x.STATIONNO == request.STATIONNO));
                        if (stationinfoEntity == null)
                            throw new Exception("未查询到" + request.STATIONNO + "的信息");
                        stationinfoEntity.STATIONSTATE = request.STATIONSTATE;
                        stationinfoEntity.OPBY = SysInfo.CurrentUserName;
                        stationinfoEntity.OPDATE = Utils.GetTodayNow();
                        stationinfoEntity.OPMESSAGE = "设置状态！";

                        SqlExpression<LocStationInfoEntity> sqlExpression = dbConn.From<LocStationInfoEntity>();
                        sqlExpression.Where(x => x.ID == stationinfoEntity.ID);
                        sqlExpression.UpdateFields.Add("STATIONSTATE");

                        sqlExpression.UpdateFields.Add("OPBY");
                        sqlExpression.UpdateFields.Add("OPDATE");
                        sqlExpression.UpdateFields.Add("OPMESSAGE");

                        num = dbConn.UpdateOnly<LocStationInfoEntity>(stationinfoEntity, sqlExpression);

                        dbTransaction.Commit();
                    }
                }
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "设置状态成功！" + num.ToString();
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                logger.Error((object)ex);
                return dtoResponse;
            }
        }

        public DTOResponse SwitchEmexitState(LocationStnRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                int num = 0;
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    using (IDbTransaction dbTransaction = dbConn.OpenTransaction())
                    {
                        LocStationInfoEntity stationinfoEntity = OrmLiteReadExpressionsApi.Single<LocStationInfoEntity>(dbConn, (Expression<Func<LocStationInfoEntity, bool>>)(x => x.STATIONNO == request.STATIONNO));
                        if (stationinfoEntity == null)
                            throw new Exception("未查询到" + request.STATIONNO + "的信息");
                        stationinfoEntity.EMEXIT = request.EMEXIT;
                        stationinfoEntity.OPBY = SysInfo.CurrentUserName;
                        stationinfoEntity.OPDATE = Utils.GetTodayNow();
                        stationinfoEntity.OPMESSAGE = "设置紧急出口成功！";
                        num = dbConn.Update<LocStationInfoEntity>(stationinfoEntity, (Action<IDbCommand>)null);

                        dbTransaction.Commit();
                    }
                }
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "设置状态成功！" + num.ToString();
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                logger.Error((object)ex);
                return dtoResponse;
            }
        }
    }
}
