using KR.BaseApp;
using KR.BaseApp.Services;
using KR.CIMS;
using KR.WMApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace KR.WMApp.Services
{
    public class MsgService : LogService
    {
        public DTOResponse GetList(MsgRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                string str1 = (string)null;
                string str2 = (string)null;
                DateTime dt1;
                DateTime dt2;
                if (!string.IsNullOrEmpty(request.datetimerange) && request.datetimerange.Length > 10)
                {
                    string s1 = request.datetimerange.Substring(0, 10);
                    string s2 = request.datetimerange.Substring(13, 10);
                    DateTime.TryParse(s1, out dt1);
                    DateTime.TryParse(s2, out dt2);
                    str1 = dt1.ToString("yyyy-MM-dd HH:mm:ss");
                    str2 = dt2.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    DateTime today = DateTime.Today;
                    dt1 = today.AddDays(-7.0);
                    today = DateTime.Today;
                    dt2 = today.AddDays(1.0);
                    str1 = dt1.ToString("yyyy-MM-dd HH:mm:ss");
                    str2 = dt2.ToString("yyyy-MM-dd HH:mm:ss");
                }
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<SysAlterInfoEntity> expression = dbConn.From<SysAlterInfoEntity>();
                    expression.And((Expression<Func<SysAlterInfoEntity, bool>>)(x => x.CREATEDATETIME >= dt1 && x.CREATEDATETIME <= dt2));
                    if (!string.IsNullOrEmpty(request.MSGTEXT))
                        expression.And((Expression<Func<SysAlterInfoEntity, bool>>)(x => x.MSGTEXT.Contains(request.MSGTEXT)));
                    if (!string.IsNullOrEmpty(request.MSGTYPE) && request.MSGTYPE != "0")
                        expression.And((Expression<Func<SysAlterInfoEntity, bool>>)(x => x.MSGTYPE == request.MSGTYPE));
                    if (!string.IsNullOrEmpty(request.MSGSTATE))
                        expression.And((Expression<Func<SysAlterInfoEntity, bool>>)(x => x.MSGSTATE == request.MSGSTATE));
                    long num = dbConn.Count<SysAlterInfoEntity>(expression);
                    List<SysAlterInfoEntity> list = dbConn.Select<SysAlterInfoEntity>(expression).OrderByDescending<SysAlterInfoEntity, long>((Func<SysAlterInfoEntity, long>)(x => x.ID)).ToList<SysAlterInfoEntity>().Skip<SysAlterInfoEntity>((request.page - 1) * request.limit).Take<SysAlterInfoEntity>(request.limit).ToList<SysAlterInfoEntity>();
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
                MsgService.logger.Error((object)ex);
            }
            return dtoResponse;
        }

        public DTOResponse GetOplogList(MsgRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                string str1 = (string)null;
                string str2 = (string)null;
                DateTime dt1;
                DateTime dt2;
                if (!string.IsNullOrEmpty(request.datetimerange) && request.datetimerange.Length > 10)
                {
                    string s1 = request.datetimerange.Substring(0, 10);
                    string s2 = request.datetimerange.Substring(13, 10);
                    DateTime.TryParse(s1, out dt1);
                    DateTime.TryParse(s2, out dt2);
                    str1 = dt1.ToString("yyyy-MM-dd HH:mm:ss");
                    str2 = dt2.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    DateTime today = DateTime.Today;
                    dt1 = today.AddDays(-7.0);
                    today = DateTime.Today;
                    dt2 = today.AddDays(1.0);
                    str1 = dt1.ToString("yyyy-MM-dd HH:mm:ss");
                    str2 = dt2.ToString("yyyy-MM-dd HH:mm:ss");
                }
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    SqlExpression<SysOplogEntity> expression = dbConn.From<SysOplogEntity>();

                    expression.And(x => x.CREATEDATE >= dt1 && x.CREATEDATE <= dt2);

                    if (!string.IsNullOrEmpty(request.MSGTEXT))
                    {
                        expression.And(x => x.KEYVALUE.Contains(request.MSGTEXT));
                        expression.Or(x => x.OPMESSAGE.Contains(request.MSGTEXT));
                    }

                    long num = dbConn.Count<SysOplogEntity>(expression);
                    List<SysOplogEntity> list = dbConn.Select<SysOplogEntity>(expression)
                        .OrderByDescending(x => x.ID)
                        .ToList<SysOplogEntity>()
                        .Skip<SysOplogEntity>((request.page - 1) * request.limit)
                        .Take<SysOplogEntity>(request.limit)
                        .ToList<SysOplogEntity>();
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
                MsgService.logger.Error((object)ex);
            }
            return dtoResponse;
        }
    }
}
