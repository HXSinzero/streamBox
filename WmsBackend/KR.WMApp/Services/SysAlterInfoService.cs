using KR.BaseApp.Services;
using KR.CIMS;
using KR.WMApp.Entitys;
using ServiceStack.OrmLite;
using System.Data;

namespace KR.WMApp.Services
{
    /// <summary>
    /// 预警管理服务
    /// </summary>
    public class SysAlterInfoService : LogService
    {
        public static void InsertAlterInfo(string msgType, string msg, string msgState = "1")
        {
            SysAlterInfoEntity projAlertinfo = new SysAlterInfoEntity();
            projAlertinfo.MSGSTATE = msgState;
            projAlertinfo.MSGTYPE = msgType;
            projAlertinfo.MSGTEXT = msg;
            projAlertinfo.CREATEDATE = Utils.GetDatetime();
            projAlertinfo.CREATEDATETIME = Utils.GetTodayDateTimeNow();
            using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
            {
                dbConn.Save<SysAlterInfoEntity>(projAlertinfo, false);
            }
        }
    }
}
