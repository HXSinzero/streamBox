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
using ServiceStack.OrmLite.Dapper;
using System.Reflection;

namespace KR.WMApp.Services
{
    /// <summary>
    /// 托盘管理服务
    /// </summary>
    public class PalletService : LogService
    {
        public DTOResponse GetList(PalletRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<PalletEntity> expression = dbConn.From<PalletEntity>();

                    if (!string.IsNullOrEmpty(request.STOCKNO))
                        expression.And(x => x.STOCKNO == request.STOCKNO);
                    if (!string.IsNullOrEmpty(request.GROUPNO))
                        expression.And(x => x.GROUPNO == request.GROUPNO);
                    if (!string.IsNullOrEmpty(request.LOCATIONNO))
                        expression.And(x => x.LOCATIONNO == request.LOCATIONNO);
                    if (!string.IsNullOrEmpty(request.PALLETNO))
                        expression.And(x => x.PALLETNO == request.PALLETNO);

                    if (!string.IsNullOrEmpty(request.STATE))
                        expression.And(x => x.STATE == int.Parse(request.STATE));

                    if (!string.IsNullOrEmpty(request.PLANNO))
                        expression.And(x => x.PLANNO == request.PLANNO);

                    long count = dbConn.Count<PalletEntity>(expression);
                    List<PalletEntity> entityList = dbConn.Select<PalletEntity>(expression)
                        .OrderBy(x => x.ID)
                        .Skip((request.page - 1) * request.limit)
                        .Take(request.limit)
                        .ToList();
                    dtoResponse.TotalCount = count;
                    dtoResponse.ResultObject = (object)entityList;
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

        public DTOResponse GetDetailList(PalletRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<PalletDetailEntity> expression = dbConn.From<PalletDetailEntity>();

                    if (request.PALLETID > -1)
                        expression.And(x => x.PALLETID == request.PALLETID);

                    long count = dbConn.Count<PalletDetailEntity>(expression);
                    List<PalletDetailEntity> entityList = dbConn.Select<PalletDetailEntity>(expression)
                        .OrderBy(x => x.ID)
                        .Skip((request.page - 1) * request.limit)
                        .Take(request.limit)
                        .ToList();

                    dtoResponse.TotalCount = count;
                    dtoResponse.ResultObject = (object)entityList;
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

        public DTOResponse GetPalletList(PalletRequest request)
        {
            //主从表，获取
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    var expression = dbConn.From<PalletEntity>()
                    .Join<PalletEntity, PalletDetailEntity>((x, y) => x.ID == y.PALLETID);

                    if (!string.IsNullOrEmpty(request.STOCKNO))
                        expression.And(x => x.STOCKNO == request.STOCKNO);
                    if (!string.IsNullOrEmpty(request.GROUPNO))
                        expression.And(x => x.GROUPNO == request.GROUPNO);
                    if (!string.IsNullOrEmpty(request.LOCATIONNO))
                        expression.And(x => x.LOCATIONNO == request.LOCATIONNO);
                    if (!string.IsNullOrEmpty(request.PALLETNO))
                        expression.And(x => x.PALLETNO == request.PALLETNO);

                    if (!string.IsNullOrEmpty(request.STATE))
                        expression.And(x => x.STATE == int.Parse(request.STATE));

                    if (!string.IsNullOrEmpty(request.PLANNO))
                        expression.And(x => x.PLANNO == request.PLANNO);

                    expression.Select("WM_PALLET.*,WM_PALLET_DETAIL.*");

                    long count = dbConn.Count<PalletEntity>(expression);
                    List<dynamic> dynamics = dbConn.Select<dynamic>(expression)
                        .OrderByDescending(x => x.ID)
                        .Skip((request.page - 1) * request.limit)
                        .Take(request.limit)
                        .ToList();

                    foreach(var item in dynamics)
                    {
                        item.CREATEDATETIME = item.CREATEDATE.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    dtoResponse.ResultObject = dynamics;
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
    }
}
