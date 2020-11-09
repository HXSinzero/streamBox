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
    /// 物料管理
    /// </summary>
    public class ProductService : LogService
    {
        #region 获取物料列表
        public DTOResponse GetList(ProductRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<ProductEntity> expression = dbConn.From<ProductEntity>();

                    if (!string.IsNullOrEmpty(request.PRODUCTTYPE) && request.PRODUCTTYPE != "0")
                        expression.And(x => x.PRODUCTTYPE == request.PRODUCTTYPE);
                    if (!string.IsNullOrEmpty(request.PRODUCTNO) && request.PRODUCTNO != "0")
                        expression.And(x => x.PRODUCTNO == request.PRODUCTNO);
                    if (!string.IsNullOrEmpty(request.PRODUCTNAME))
                        expression.And(x => x.PRODUCTNAME.Contains(request.PRODUCTNAME));
                    if (!string.IsNullOrEmpty(request.PRODUCTTSTATE))
                        expression.And(x => x.PRODUCTTSTATE == request.PRODUCTTSTATE);

                    long count = dbConn.Count<ProductEntity>(expression);
                    List<ProductEntity> entityList = dbConn.Select<ProductEntity>(expression)
                        .OrderBy(x => x.ID)
                        .Skip<ProductEntity>((request.page - 1) * request.limit)
                        .Take<ProductEntity>(request.limit)
                        .ToList<ProductEntity>();
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
        public DTOResponse Save(ProductRequest request)
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
                    request.Entity = HelperSerializer.GetObjectFromJsonString<ProductEntity>(request.PostData);

                    if (request.ACTION == OPAction.CREATE)
                    {
                        ProductEntity entity = new ProductEntity();
                        entity.PRODUCTNO = request.Entity.PRODUCTNO;
                        entity.PRODUCTNAME = request.Entity.PRODUCTNAME;
                        //entity.PRODUCTDESC = "";
                        //entity.PRODUCTSUBDESC = "";
                        //entity.PRODUCTSPEC = "";
                        entity.PRODUCTBARCODE = "0";
                        //entity.PRODUCTNODECODE = "";
                        entity.TURNOVERRATE = "";
                        entity.ABC = request.Entity.ABC;
                        entity.PRODUCTCLASS = "";
                        entity.PRODUCTTYPE = request.Entity.PRODUCTTYPE;
                        entity.PRODUCTTSTATE = "1";
                        entity.QUANTITY_PACK = request.Entity.QUANTITY_PACK;
                        entity.MAINUNIT = request.Entity.MAINUNIT;
                        entity.BASICUNIT = request.Entity.MAINUNIT;
                        entity.MAINTOBASICRATE = 1;
                        //entity.MAINTOBASICDESC = "";
                        entity.CREATEBY = SysInfo.GetCurrentUserInfo();
                        entity.CREATEDATE = Utils.GetDatetime();
                        entity.MODIFYBY = "";
                        entity.MODIFYDATE = "";
                        entity.REMARK = request.Entity.REMARK;
                        /*entity.BRANDID = "";
                        entity.BRANDNAME = "";
                        entity.VENDORID = "";
                        entity.VENDORNAME = "";
                        entity.PRODUCTERID = "";
                        entity.PRODUCTERNAME = "";
                        entity.MARKETPRICE = "";
                        entity.LOWESTSALEPRICE = "";
                        entity.SELLPRICE = "";
                        entity.ISDELICATE = "";
                        entity.IMPORTPRODUCT = "";
                        entity.IMAGEURL = "";
                        entity.DEFAULTCOLOR = "";
                        entity.PALLETEMPLTY = "";
                        entity.PALLETENTITY = "";
                        entity.SIZE_LENGTH = "";
                        entity.SIZE_WIDTH = "";
                        entity.SIZE_HEIGHT = "";
                        entity.VOLUME = "";
                        entity.WEIGHT = "";
                        entity.NETWEIGHT = "";
                        entity.WARNSTATE = "";
                        entity.INV_HIGH = "";
                        entity.INV_SAFE = "";
                        entity.INV_ORDER = "";
                        entity.INV_HIVEDAYS = "";
                        entity.INV_LIMIT = "";
                        entity.INV_HIGH_COLOR = "";
                        entity.INV_SAFE_COLOR = "";
                        entity.INV_ORDER_COLOR = "";
                        entity.INV_HIVEDAYS_COLOR = "";
                        entity.INV_LIMIT_COLOR = "";
                        entity.CUSTOMCOL01 = "";
                        entity.CUSTOMCOL02 = "";
                        entity.CUSTOMCOL03 = "";
                        entity.CUSTOMCOL04 = "";
                        entity.CUSTOMCOL05 = "";
                        entity.CUSTOMCOL06 = "";
                        entity.CUSTOMCOL07 = "";
                        entity.CUSTOMCOL08 = "";
                        entity.CUSTOMCOL09 = "";
                        entity.CUSTOMCOL10 = "";*/

                        //插入记录
                        count = dbConn.Insert<ProductEntity>(entity);
                    }
                    else if (request.ACTION == OPAction.UPDATE)
                    {
                        //更新记录
                        count = dbConn.SaveAll<ProductEntity>(new List<ProductEntity>() { request.Entity });
                    }
                    else if(request.ACTION==OPAction.OP_01)
                    {
                        SqlExpression<ProductEntity> sqlExpression = dbConn.From<ProductEntity>();
                        sqlExpression.Where(x => x.ID == request.Entity.ID);
                        sqlExpression.UpdateFields.Add("DEFAULTCOLOR");
                        sqlExpression.UpdateFields.Add("PRODUCTTSTATE");

                        //更新记录
                        count = dbConn.UpdateOnly<ProductEntity>(request.Entity, sqlExpression);                        
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
