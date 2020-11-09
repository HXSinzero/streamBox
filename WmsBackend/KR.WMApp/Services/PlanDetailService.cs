using KR.BaseApp;
using KR.BaseApp.Services;
using KR.CIMS;
using KR.WMApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace KR.WMApp.Services
{
    /// <summary>
    /// 计划管理服务
    /// </summary>
    public class PlanDetailService : LogService
    {
        #region 获取计划列表
        public DTOResponse GetList(PlanDetailRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<PlanDetailEntity> expression = dbConn.From<PlanDetailEntity>();

                    if (request.LINESTATE != null)
                        expression.And(x => x.LINESTATE == request.LINESTATE);
                    if (request.PLANTYPE != null)
                        expression.And(x => x.PLANTYPE == request.PLANTYPE);

                    if (!string.IsNullOrEmpty(request.PRODUCTTYPE) && request.PRODUCTTYPE != "0")
                        expression.And(x => x.PRODUCTTYPE == request.PRODUCTTYPE);
                    if (!string.IsNullOrEmpty(request.PRODUCTNO) && request.PRODUCTNO != "0")
                        expression.And(x => x.PRODUCTNO == request.PRODUCTNO);
                    if (!string.IsNullOrEmpty(request.PRODUCTNAME))
                        expression.And(x => x.PRODUCTNAME.Contains(request.PRODUCTNAME));

                    long count = dbConn.Count<PlanDetailEntity>(expression);
                    List<PlanDetailEntity> entityList = dbConn.Select<PlanDetailEntity>(expression)
                        .OrderByDescending(x => x.ID)
                        .Skip<PlanDetailEntity>((request.page - 1) * request.limit)
                        .Take<PlanDetailEntity>(request.limit)
                        .ToList<PlanDetailEntity>();
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
        #endregion

        #region 获取计划托盘明细列表
        public DTOResponse GetDetailPalletList(PlanDetailRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                if (string.IsNullOrEmpty(request.PLANNO))
                {
                    dtoResponse.IsSuccess = false;
                    dtoResponse.MessageText = "计划单号为空！";
                    return dtoResponse;
                }

                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<PlanDetailPalletEntity> expression = dbConn.From<PlanDetailPalletEntity>();

                    if (!string.IsNullOrEmpty(request.PLANNO))
                        expression.And(x => x.PLANNO == request.PLANNO);

                    long count = dbConn.Count<PlanDetailPalletEntity>(expression);
                    List<PlanDetailPalletEntity> entityList = dbConn.Select<PlanDetailPalletEntity>(expression)
                        .OrderByDescending(x => x.ID)
                        .Skip<PlanDetailPalletEntity>((request.page - 1) * request.limit)
                        .Take<PlanDetailPalletEntity>(request.limit)
                        .ToList<PlanDetailPalletEntity>();
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
        #endregion

        #region 保存或更新实体类
        public DTOResponse Save(PlanDetailRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                if (string.IsNullOrEmpty(request.PostData))
                {
                    throw new Exception("传入的参数为空！");
                }
                long count = 0;
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    //获取对象值
                    request.Entity = HelperSerializer.GetObjectFromJsonString<PlanDetailEntity>(request.PostData);

                    if (request.ACTION == OPAction.CREATE)
                    {

                        ProductEntity productEntity = dbConn.Single<ProductEntity>(x => x.PRODUCTNO == request.Entity.PRODUCTNO);
                        if (productEntity == null)
                        {
                            throw new Exception("物料" + request.Entity.PRODUCTNO + "不存在！");
                        }

                        //获取计划序号
                        SysSequenceResult sequenceResult =
                            SysSequenceInstance.Instance().GetSysSequence("PLANID");

                        PlanDetailEntity entity = new PlanDetailEntity();
                        entity.PLANID = long.Parse(sequenceResult.SEQVALUE);
                        entity.PLANNO = sequenceResult.SEQVALUE + "#" + request.Entity.PLANNO;
                        entity.PLANTYPE = request.Entity.PLANTYPE;
                        entity.LINENUM = 1;
                        entity.LINESTATE = 0;
                        entity.BPNO = request.Entity.BPNO;
                        entity.BPNAME = request.Entity.BPNAME;
                        entity.STATIONNO = request.Entity.STATIONNO;
                        entity.MODIFYBY = SysInfo.GetCurrentUserInfo();
                        entity.MODIFYDATE = Utils.GetTodayDateTimeNow();
                        /*entity.BOMID = "";
                        entity.BOMNO = "";
                        entity.BOMNAME = "";
                        entity.BOMBATCHNO = "";*/
                        entity.PRODUCTID = productEntity.ID;
                        entity.PRODUCTNO = productEntity.PRODUCTNO;
                        entity.PRODUCTNAME = productEntity.PRODUCTNAME;
                        entity.PRODUCTSPEC = productEntity.PRODUCTSPEC;
                        entity.PRODUCTCLASS = productEntity.PRODUCTCLASS;
                        entity.PRODUCTTYPE = productEntity.PRODUCTTYPE;
                        entity.BATCHNO = request.Entity.BATCHNO;
                        entity.Q01 = request.Entity.Q01;
                        entity.Q02 = 0;
                        entity.Q03 = 0;
                        entity.Q04 = 0;
                        entity.Q05 = request.Entity.Q05;
                        entity.Q06 = request.Entity.Q06;
                        entity.MAINUNIT = productEntity.MAINUNIT;
                        entity.BASICUNIT = productEntity.MAINUNIT;
                        entity.REMARK1 = request.Entity.REMARK1;
                        entity.P01 = request.Entity.P01;
                        entity.P02 = request.Entity.P02;
                        /*entity.REMARK2 = "";
                      
                        entity.P03 = "";
                        entity.P04 = "";
                        entity.P05 = "";
                        entity.P06 = "";
                        entity.P07 = "";
                        entity.P08 = "";
                        entity.P09 = "";
                        entity.P10 = "";
                        entity.P11 = "";
                        entity.P12 = "";
                        entity.P13 = "";
                        entity.P14 = "";
                        entity.P15 = "";
                        entity.P16 = "";
                        entity.P17 = "";
                        entity.P18 = "";
                        entity.P19 = "";
                        entity.P20 = "";*/

                        //插入记录
                        count = dbConn.Insert<PlanDetailEntity>(entity);
                    }
                    else if (request.ACTION == OPAction.UPDATE)
                    {
                        //更新记录
                        count = dbConn.SaveAll<PlanDetailEntity>(new List<PlanDetailEntity>() { request.Entity });
                    }

                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "操作成功！" + count;
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
        #endregion
    }
}
