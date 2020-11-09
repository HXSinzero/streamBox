using KR.BaseApp;
using KR.BaseApp.Entitys;
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
    public class BasicService : LogService
    {
        #region 获取列表
        public DTOResponse GetList(BasicRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    if (request.BasicType == "BUNIESSTYPE")
                    {
                        SqlExpression<BasicBuniessTypeEntity> expression = dbConn.From<BasicBuniessTypeEntity>();
                        expression.And(x => x.BUNIESSTYPESTATE == "1");
                        List<BasicBuniessTypeEntity> entityList = dbConn.Select<BasicBuniessTypeEntity>(expression)
                            .OrderBy(x => x.BUNIESSTYPENO)
                            .ToList<BasicBuniessTypeEntity>();

                        dtoResponse.ResultObject = (object)entityList;
                        dtoResponse.IsSuccess = true;
                        dtoResponse.MessageText = "查询操作成功！";
                        return dtoResponse;
                    }
                    else if (request.BasicType == "PRODUCER")
                    {
                        SqlExpression<BasicProducerEntity> expression = dbConn.From<BasicProducerEntity>();
                        expression.And(x => x.PRODUCERSTATE == "1");
                        
                        if(!string.IsNullOrEmpty(request.Code))
                        {
                            expression.And(x => x.PRODUCERNO == request.Code);
                        }

                        if (!string.IsNullOrEmpty(request.Name))
                        {
                            expression.And(x => x.PRODUCERNAME.Contains(request.Name));
                        }

                        if (!string.IsNullOrEmpty(request.Subdesc))
                        {
                            expression.And(x => x.PRODUCERSUBDESC.Contains(request.Subdesc));
                        }

                        List<BasicProducerEntity> entityList = dbConn.Select<BasicProducerEntity>(expression)
                            .OrderBy(x => x.ID)
                            .ToList<BasicProducerEntity>();

                        dtoResponse.ResultObject = (object)entityList;
                        dtoResponse.IsSuccess = true;
                        dtoResponse.MessageText = "查询操作成功！";
                        return dtoResponse;
                    }
                    else if (request.BasicType == "VENDOR")
                    {
                        SqlExpression<BasicVendorEntity> expression = dbConn.From<BasicVendorEntity>();
                        expression.And(x => x.VENDORSTATE == "1");

                        if (!string.IsNullOrEmpty(request.Code))
                        {
                            expression.And(x => x.VENDORNO == request.Code);
                        }

                        if (!string.IsNullOrEmpty(request.Name))
                        {
                            expression.And(x => x.VENDORNAME.Contains(request.Name));
                        }

                        if (!string.IsNullOrEmpty(request.Subdesc))
                        {
                            expression.And(x => x.VENDORSUBDESC.Contains(request.Subdesc));

                        }
                        List<BasicVendorEntity> entityList = dbConn.Select<BasicVendorEntity>(expression)
                            .OrderBy(x => x.ID)
                            .ToList<BasicVendorEntity>();

                        dtoResponse.ResultObject = (object)entityList;
                        dtoResponse.IsSuccess = true;
                        dtoResponse.MessageText = "查询操作成功！";
                        return dtoResponse;
                    }
                    else if (request.BasicType == "STOCK")
                    {
                        SqlExpression<LocStockEntity> expression = dbConn.From<LocStockEntity>();
                        expression.And(x => x.STOCKSTATE == "1" && x.STOCKTYPE == "1");
                        List<LocStockEntity> entityList = dbConn.Select<LocStockEntity>(expression)
                            .OrderBy(x => x.ID)
                            .ToList<LocStockEntity>();

                        dtoResponse.ResultObject = (object)entityList;
                        dtoResponse.IsSuccess = true;
                        dtoResponse.MessageText = "查询操作成功！";
                        return dtoResponse;
                    }
                    else
                    {
                        dtoResponse.ResultObject = null;
                        dtoResponse.IsSuccess = false;
                        dtoResponse.MessageText = "查询" + request.BasicType + "失败！";
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
        #endregion

        #region 保存对象
        public DTOResponse SaveBasicObject(BasicRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    if (request.BasicType == "PRODUCER")
                    {
                        int maxid = 0;
                        if (dbConn.Count<BasicProducerEntity>() == 0)
                        {
                            maxid = 1;
                        }
                        else
                        {
                            maxid = dbConn.Select<BasicProducerEntity>().Max(x => x.ID) + 1;
                        }

                        BasicProducerEntity entity = new BasicProducerEntity();
                        entity.ID = maxid;
                        entity.PRODUCERNO = request.Code;
                        entity.PRODUCERNAME = request.Name;
                        entity.PRODUCERSUBDESC = request.Subdesc;
                        entity.PRODUCERSTATE = string.IsNullOrEmpty(request.State) ? "1" : request.State;
                        entity.CREATEDATE = Utils.GetDatetime();
                        entity.CREATEBY = SysInfo.GetCurrentUserInfo();
                        bool b = dbConn.Save<BasicProducerEntity>(entity);

                        dtoResponse.IsSuccess = b;
                        dtoResponse.MessageText = "操作成功！";
                        return dtoResponse;
                    }
                    else if (request.BasicType == "VENDOR")
                    {
                        int maxid = 0;
                        if (dbConn.Count<BasicVendorEntity>()==0)
                        {
                            maxid = 1;
                        }
                        else
                        {
                            maxid = dbConn.Select<BasicVendorEntity>().Max(x => x.ID) + 1;
                        }

                        BasicVendorEntity entity = new BasicVendorEntity();
                        entity.ID = maxid;
                        entity.VENDORNO = request.Code;
                        entity.VENDORNAME = request.Name;
                        entity.VENDORSUBDESC = request.Subdesc;
                        entity.VENDORSTATE = string.IsNullOrEmpty(request.State) ? "1" : request.State;
                        entity.CREATEDATE = Utils.GetDatetime();
                        entity.CREATEBY = SysInfo.GetCurrentUserInfo();
                        bool b = dbConn.Save<BasicVendorEntity>(entity);

                        dtoResponse.IsSuccess = b;
                        dtoResponse.MessageText = "操作成功！";
                        return dtoResponse;
                    }
                    else
                    {
                        dtoResponse.ResultObject = null;
                        dtoResponse.IsSuccess = false;
                        dtoResponse.MessageText = "查询" + request.BasicType + "失败！";
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
        #endregion

        #region 系统参数
        public DTOResponse GetSysparamsList(BasicRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    List<SysParams> list = dbConn.Select<SysParams>().OrderBy(x => x.ID).ToList();
                    dtoResponse.ResultObject = list;
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "操作完成：" + dtoResponse.IsSuccess;
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

        public DTOResponse SaveSysparams(BasicRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                SysParams entity = HelperSerializer.GetObjectFromJsonString<SysParams>(request.PostData);
                if (entity == null)
                {
                    throw new Exception("传入的参数无法解析！");
                }

                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<SysParams> expression1 = dbConn.From<SysParams>();
                    expression1.Where(x => x.ID == entity.ID);
                    expression1.UpdateFields.Add("PARAVALUE");

                    int count1 = dbConn.UpdateOnly<SysParams>(entity, expression1);
                    dtoResponse.TotalCount = count1;
                    dtoResponse.IsSuccess = count1 == 1 ? true : false;

                    //dtoResponse.IsSuccess = dbConn.Update<SysParams>(entity);
                    dtoResponse.MessageText = "操作完成：" + dtoResponse.IsSuccess;
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
