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
    /// <summary>
    /// 数据检查服务（重置）
    /// </summary>
    public class SysCheckService : LogService
    {
        public DTOResponse GetList(CheckRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    List<SysCheckEntity> list = dbConn.Select<SysCheckEntity>().OrderBy<SysCheckEntity, int>((Func<SysCheckEntity, int>)(x => x.ID)).ToList<SysCheckEntity>();
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

        public DTOResponse RestForArc(CheckRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            IDbConnection dbCon = (IDbConnection)null;
            IDbTransaction dbTrans = (IDbTransaction)null;
            try
            {
                HelperDbOperation.BeginTransaction(ref dbCon, ref dbTrans);
                IDbConnection dbConn = dbCon;
                Expression<Func<SysCheckEntity, bool>> predicate = (Expression<Func<SysCheckEntity, bool>>)(x => x.ITEMSTATE == 1);
                foreach (SysCheckEntity uldCheck in dbConn.Select<SysCheckEntity>(predicate).OrderBy<SysCheckEntity, int>((Func<SysCheckEntity, int>)(x => x.ID)).ToList<SysCheckEntity>())
                {
                    if (!string.IsNullOrEmpty(uldCheck.ARCITEMVALUE))
                    {
                        long num = (long)dbCon.ExecuteSql(uldCheck.ARCITEMVALUE);
                    }
                }
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "执行成功！";
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.ToString();
                return dtoResponse;
            }
            finally
            {
                HelperDbOperation.EndTransaction(dtoResponse.IsSuccess, ref dbCon, ref dbTrans);
            }
        }

        public DTOResponse Rest(CheckRequest request)
        {
            this.RestForArc(request);
            DTOResponse dtoResponse = new DTOResponse();
            IDbConnection dbCon = (IDbConnection)null;
            IDbTransaction dbTrans = (IDbTransaction)null;
            try
            {
                HelperDbOperation.BeginTransaction(ref dbCon, ref dbTrans);
                IDbConnection dbConn = dbCon;
                Expression<Func<SysCheckEntity, bool>> predicate = (Expression<Func<SysCheckEntity, bool>>)(x => x.ITEMSTATE == 1);
                foreach (SysCheckEntity uldCheck in dbConn.Select<SysCheckEntity>(predicate).OrderBy<SysCheckEntity, int>((Func<SysCheckEntity, int>)(x => x.ID)).ToList<SysCheckEntity>())
                {
                    long num = (long)dbCon.ExecuteSql(uldCheck.ITEMVALUE);
                    uldCheck.AFFECTEDCOUNT = num;
                    uldCheck.EXECUTEDATE = Utils.GetTodayNow();
                    dbCon.Save<SysCheckEntity>(uldCheck, false);
                }
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "执行成功！";
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.ToString();
                return dtoResponse;
            }
            finally
            {
                HelperDbOperation.EndTransaction(dtoResponse.IsSuccess, ref dbCon, ref dbTrans);
                LogService.WriteLog(new LogerInfo()
                {
                    SOURCEOBJECTID = "盘点执行",
                    SOURCECONTENTJSON = request.ToJson<CheckRequest>()
                });
            }
        }
    }
}
