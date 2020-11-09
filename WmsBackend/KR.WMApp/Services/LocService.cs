using KR.BaseApp;
using KR.BaseApp.Services;
using KR.CIMS;
using KR.WMApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Legacy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace KR.WMApp.Services
{
    /// <summary>
    /// 位置管理服务
    /// </summary>
    public class LocService : LogService
    {
        public DTOResponse GetList(LocationRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<LocDetailEntity> expression = dbConn.From<LocDetailEntity>();
                    if (!string.IsNullOrEmpty(request.LOCATIONTYPE) && request.LOCATIONTYPE != "0")
                        expression.And((Expression<Func<LocDetailEntity, bool>>)(x => x.LOCATIONTYPE == request.LOCATIONTYPE));
                    if (!string.IsNullOrEmpty(request.GROUPNO) && request.GROUPNO != "0")
                        expression.And((Expression<Func<LocDetailEntity, bool>>)(x => x.GROUPNO.Contains(request.GROUPNO)));
                    if (!string.IsNullOrEmpty(request.AREANO) && request.AREANO != "0")
                        expression.And((Expression<Func<LocDetailEntity, bool>>)(x => x.AREANO == request.AREANO));
                    if (!string.IsNullOrEmpty(request.STOCKNO) && request.STOCKNO != "0")
                        expression.And((Expression<Func<LocDetailEntity, bool>>)(x => x.STOCKNO == request.STOCKNO));

                    if (!string.IsNullOrEmpty(request.USESTATE))
                        expression.And((Expression<Func<LocDetailEntity, bool>>)(x => x.USESTATE == request.USESTATE));
                    if (!string.IsNullOrEmpty(request.STORESTATE))
                        expression.And((Expression<Func<LocDetailEntity, bool>>)(x => x.STORESTATE == request.STORESTATE));
                    if (!string.IsNullOrEmpty(request.LOCATIONSTATE))
                        expression.And((Expression<Func<LocDetailEntity, bool>>)(x => x.LOCATIONSTATE == request.LOCATIONSTATE));

                    if (request.ROWNO_MIN > 0 && request.ROWNO_MAX > 0)
                        expression.And(x => x.ROWNO >= request.ROWNO_MIN && x.ROWNO <= request.ROWNO_MAX);
                    if (request.COLUMNNO_MIN > 0 && request.COLUMNNO_MAX > 0)
                        expression.And(x => x.COLUMNNO >= request.COLUMNNO_MIN && x.COLUMNNO <= request.COLUMNNO_MAX);
                    if (request.LAYERNO_MIN > 0 && request.LAYERNO_MAX > 0)
                        expression.And(x => x.LAYERNO >= request.LAYERNO_MIN && x.LAYERNO <= request.LAYERNO_MAX);

                    long count = dbConn.Count<LocDetailEntity>(expression);
                    List<LocDetailEntity> locationDetailEntityList = dbConn.Select<LocDetailEntity>(expression)
                        .OrderBy<LocDetailEntity, long>((Func<LocDetailEntity, long>)(x => x.ID))
                        .Skip<LocDetailEntity>((request.page - 1) * request.limit)
                        .Take<LocDetailEntity>(request.limit)
                        .ToList<LocDetailEntity>();
                    dtoResponse.TotalCount = count;
                    dtoResponse.ResultObject = (object)locationDetailEntityList;
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "查询操作成功！";
                    return dtoResponse;
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

        public DTOResponse GetListLocGroup(LocationRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<LocGroupEntity> expression = dbConn.From<LocGroupEntity>();
                    if (!string.IsNullOrEmpty(request.LOCATIONTYPE) && request.LOCATIONTYPE != "0")
                        expression.And((x => x.GROUPTYPE == request.LOCATIONTYPE));
                    if (!string.IsNullOrEmpty(request.GROUPNO) && request.GROUPNO != "0")
                        expression.And((x => x.GROUPNO.Contains(request.GROUPNO)));
                    if (!string.IsNullOrEmpty(request.AREANO) && request.AREANO != "0")
                        expression.And((x => x.AREANO == request.AREANO));

                    if (!string.IsNullOrEmpty(request.USESTATE))
                        expression.And(x => x.USESTATE == int.Parse(request.USESTATE));
                    if (!string.IsNullOrEmpty(request.GROUPSTATE))
                        expression.And(x => x.GROUPSTATE == int.Parse(request.GROUPSTATE));

                    if (!string.IsNullOrEmpty(request.AREANO) && request.STOCKNO != "0")
                        expression.And(x => x.STOCKNO == request.STOCKNO);

                    if (request.ROWNO_MIN > 0 && request.ROWNO_MAX > 0)
                        expression.And(x => x.ROWNO >= request.ROWNO_MIN && x.ROWNO <= request.ROWNO_MAX);

                    long count = dbConn.Count<LocGroupEntity>(expression);
                    List<LocGroupEntity> listResult = dbConn.Select<LocGroupEntity>(expression)
                        .OrderBy(x => x.ID)
                        .Skip<LocGroupEntity>((request.page - 1) * request.limit)
                        .Take<LocGroupEntity>(request.limit)
                        .ToList<LocGroupEntity>();
                    dtoResponse.TotalCount = count;
                    dtoResponse.ResultObject = (object)listResult;
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "查询操作成功！";
                    return dtoResponse;
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

        public DTOResponse ChangeUseState(LocationRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    LocDetailEntity locationDetailEntity = dbConn.Select<LocDetailEntity>((Expression<Func<LocDetailEntity, bool>>)(x => x.LOCATIONNO == request.LOCATIONNO)).FirstNonDefault<LocDetailEntity>();
                    if (locationDetailEntity == null)
                        throw new Exception(request.LOCATIONNO + "位置不存在！");
                    locationDetailEntity.USESTATE = request.USESTATE;
                    locationDetailEntity.OPBY = SysInfo.GetCurrentUserInfo();
                    locationDetailEntity.OPDATE = Utils.GetTodayNow();
                    locationDetailEntity.OPMESSAGE = "修改使用状态！";
                    int count = dbConn.UpdateOnly<LocDetailEntity>(
                        locationDetailEntity,
                        new string[4] { "USESTATE", "OPBY", "OPDATE", "OPMESSAGE" },
                        (Expression<Func<LocDetailEntity, bool>>)(x => x.LOCATIONNO == request.LOCATIONNO), (Action<IDbCommand>)null);
                    dtoResponse.IsSuccess = count > 0 ? true : false;
                    dtoResponse.MessageText = "操作成功！" + count.ToString();
                    return dtoResponse;
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

        public DTOResponse SetGroupnoSeq(LocationRequest request)
        {
            //根据左右方向设置GROUPNOSEQ的值
            //先进后出（FILO） 先进先出（FIFO）
            DTOResponse dtoResponse = new DTOResponse();
            IDbConnection dbCon = null;
            IDbTransaction dbTrans = null;
            try
            {
                HelperDbOperation.BeginTransaction(ref dbCon, ref dbTrans);

                List<LocGroupEntity> locGroupEntities = dbCon.Select<LocGroupEntity>(x => request.ListGroupNo.Contains(x.GROUPNO));
                
                foreach (var group in locGroupEntities)
                {
                    List<LocDetailEntity> locDetailEntities =
                        dbCon.Select<LocDetailEntity>(x => x.GROUPNO == group.GROUPNO);

                    SqlExpression<LocGroupEntity> expression = dbCon.From<LocGroupEntity>();
                    expression.UpdateFields.Add("DIRECTIONENTRY");
                    expression.UpdateFields.Add("GROUPMODEL");
                    expression.Where(x => x.ID == group.ID);

                    group.DIRECTIONENTRY = request.GroupLeftOrRight;
                    group.GROUPMODEL = request.GroupModel;
                    int c = dbCon.UpdateOnly(group, expression);
                    
                    int seqIndex = 0;
                    SqlExpression<LocDetailEntity> sqlExpression = null;

                    if (request.GroupModel == "FILO")
                    {
                        seqIndex = 0;

                        if (request.GroupLeftOrRight == "L")
                        {
                            seqIndex = locDetailEntities.Count;
                            foreach (var item in locDetailEntities)
                            {
                                item.GROUPNOSEQ = seqIndex;
                                seqIndex--;

                                sqlExpression = dbCon.From<LocDetailEntity>();
                                sqlExpression.UpdateFields.Add("GROUPNOSEQ");
                                sqlExpression.Where(x => x.ID == item.ID);
                                int count = dbCon.UpdateOnly<LocDetailEntity>(item, sqlExpression);
                            }
                        }
                        else
                        {
                            foreach (var item in locDetailEntities)
                            {
                                seqIndex++;
                                item.GROUPNOSEQ = seqIndex;

                                sqlExpression = dbCon.From<LocDetailEntity>();
                                sqlExpression.UpdateFields.Add("GROUPNOSEQ");
                                sqlExpression.Where(x => x.ID == item.ID);
                                int count = dbCon.UpdateOnly<LocDetailEntity>(item, sqlExpression);
                            }
                        }
                    }

                    if (request.GroupModel == "none")
                    {
                        seqIndex = 0;
                        foreach (var item in locDetailEntities)
                        {
                            seqIndex++;
                            item.GROUPNOSEQ = seqIndex;

                            sqlExpression = dbCon.From<LocDetailEntity>();
                            sqlExpression.UpdateFields.Add("GROUPNOSEQ");
                            sqlExpression.Where(x => x.ID == item.ID);
                            int count = dbCon.UpdateOnly<LocDetailEntity>(item, sqlExpression);
                        }
                    }

                    if (request.GroupModel == "FIFO")
                    {

                    }
                }

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
            finally
            {
                HelperDbOperation.EndTransaction(dtoResponse.IsSuccess, ref dbCon, ref dbTrans);
            }
        }

        public DTOResponse ChangeGroupUseState(LocationRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    LocGroupEntity entity = dbConn.Select<LocGroupEntity>(x => x.GROUPNO == request.GROUPNO).FirstNonDefault();
                    if (entity == null)
                        throw new Exception(request.LOCATIONNO + "位置不存在！");
                    entity.USESTATE = int.Parse(request.USESTATE);
                    entity.OPBY = SysInfo.GetCurrentUserInfo();
                    entity.OPDATE = Utils.GetTodayNow();
                    entity.OPMESSAGE = "修改使用状态！";
                    int count = dbConn.UpdateOnly<LocGroupEntity>(
                        entity,
                        new string[4] { "USESTATE", "OPBY", "OPDATE", "OPMESSAGE" },
                        (x => x.GROUPNO == request.GROUPNO));
                    dtoResponse.IsSuccess = count > 0 ? true : false;
                    dtoResponse.MessageText = "操作成功！" + count.ToString();
                    return dtoResponse;
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

        public DTOResponse BatchChangeUseState(LocationRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<LocDetailEntity> sqlExpression = dbConn.From<LocDetailEntity>();
                    sqlExpression.Where(x => request.ListLocatioNo.Contains(x.LOCATIONNO));
                    sqlExpression.UpdateFields.Add("USESTATE");
                    sqlExpression.UpdateFields.Add("OPBY");
                    sqlExpression.UpdateFields.Add("OPDATE");
                    sqlExpression.UpdateFields.Add("OPMESSAGE");

                    LocDetailEntity locDetailEntity = new LocDetailEntity();
                    locDetailEntity.USESTATE = request.USESTATE;
                    locDetailEntity.OPBY = SysInfo.GetCurrentUserInfo();
                    locDetailEntity.OPDATE = Utils.GetTodayNow();
                    locDetailEntity.OPMESSAGE = "修改使用状态！";

                    int count = dbConn.UpdateOnly<LocDetailEntity>(locDetailEntity, sqlExpression);

                    dtoResponse.IsSuccess = count > 0 ? true : false;
                    dtoResponse.MessageText = "操作完成，修改记录" + count.ToString() + "条 " + dtoResponse.IsSuccess.ToString();
                    HelperOplog.InsertOplog("位置使用状态更改：" + request.USESTATE + "/" + request.ListLocatioNo.ToJson());
                    HelperOplog.InsertOplog(dtoResponse);
                    return dtoResponse;
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
    }
}
