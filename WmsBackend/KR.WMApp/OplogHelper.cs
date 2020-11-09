using KR.BaseApp;
using KR.CIMS;
using KR.WMApp.Entitys;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using System;
using System.Data;

namespace KR.WMApp
{
    public class HelperOplog
    {
        public static ILog logger = LogManager.GetLogger(typeof(HelperOplog));

        public static void InsertOplog(DTOResponse dtoResponse, string keyValue = "")
        {
            try
            {
                SysOplogEntity oplog = new SysOplogEntity();
                oplog.CREATEDATE = System.DateTime.Now;
                oplog.ENTERDATE = Utils.GetDatetime();
                oplog.KEYVALUE = keyValue;
                oplog.OPMESSAGE = dtoResponse.ToString();
                using (IDbConnection dbCon = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    dbCon.Insert<SysOplogEntity>(oplog);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }
        }

        public static void InsertOplog(string opMessage, string keyValue = "")
        {
            try
            {
                SysOplogEntity oplog = new SysOplogEntity();
                oplog.CREATEDATE = System.DateTime.Now;
                oplog.ENTERDATE = Utils.GetDatetime();
                oplog.KEYVALUE = keyValue;
                oplog.OPMESSAGE = opMessage;
                using (IDbConnection dbCon = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    dbCon.Insert<SysOplogEntity>(oplog);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }
        }
    }
}
