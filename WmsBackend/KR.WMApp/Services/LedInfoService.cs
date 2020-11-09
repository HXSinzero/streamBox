using KR.BaseApp;
using KR.BaseApp.Entitys;
using KR.BaseApp.Services;
using KR.CIMS;
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
    public class LedInfoService : LogService
    {
        public DTOResponse GetList(LedInfoRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    List<INF_LEDINFOEntity> list = dbConn.Select<INF_LEDINFOEntity>().OrderBy<INF_LEDINFOEntity, int>((Func<INF_LEDINFOEntity, int>)(x => x.ID)).ToList<INF_LEDINFOEntity>();
                    dtoResponse.ResultObject = (object)list;
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "查询操作成功！";
                }
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                LedInfoService.logger.Error((object)ex);
            }
            return dtoResponse;
        }

        public DTOResponse GetkanbanInfo(LedInfoRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            string reportno = request.REPORTNO;
            Report report = HelperDbOperation.Select<Report>((Expression<Func<Report, bool>>)(x => x.REPORTNO == reportno)).First<Report>();
            if (report != null)
            {
                string datasource = report.DATASOURCE;
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    List<object> objectList = dbConn.Select<object>(datasource);
                    dtoResponse.ResultObject = (object)objectList;
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "查询操作成功！";
                    return dtoResponse;
                }
            }
            else
            {
                dtoResponse.IsSuccess = false;
                return dtoResponse;
            }
        }
    }
}
