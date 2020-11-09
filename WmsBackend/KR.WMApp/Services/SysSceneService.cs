using KR.BaseApp;
using KR.BaseApp.Services;
using KR.CIMS;
using KR.WMApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace KR.WMApp.Services
{
    public class SysSceneService : LogService
    {
        public DTOResponse OrderSenceMode(
          SceneRequest request,
          IDbConnection db,
          IDbTransaction trans)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                SysSceneEntity uldScene1 = OrmLiteReadExpressionsApi.Single<SysSceneEntity>(db, (Expression<Func<SysSceneEntity, bool>>)(x => x.ID == request.ID || x.SCENENO == request.SCENENO));
                if (uldScene1 == null)
                    throw new Exception("获取场景为空！");
                if (uldScene1.SCENENO != request.SCENENO)
                    throw new Exception("传入的参数与后台不一致！");
                if (uldScene1.USESTATE != 1)
                    throw new Exception("当前模式" + uldScene1.SCENENO + "管理员未启用！请联系管理员！");
                INF_JOBDOWNLOADEntity jobdownloadEntity1 = new INF_JOBDOWNLOADEntity();
                jobdownloadEntity1.ID = Utils.GetDateTimeGuid();
                jobdownloadEntity1.GROUPID = "0";
                //jobdownloadEntity1.JOBID = uldScene1.P01;
                //jobdownloadEntity1.EQUIPMENTID = uldScene1.P02;
                jobdownloadEntity1.WAREHOUSEID = "none";
                jobdownloadEntity1.JOBTYPE = 4;
                jobdownloadEntity1.ORDERTYPE = 0;
                jobdownloadEntity1.SOURCE = "0";
                //jobdownloadEntity1.TARGET = uldScene1.P02;
                jobdownloadEntity1.BRANDID = "0";
                jobdownloadEntity1.PLANQTY = new Decimal?(new Decimal());
                jobdownloadEntity1.PILETYPE = "0";
                jobdownloadEntity1.PRIORITY = 1;
                jobdownloadEntity1.BARCODE = "0";
                int id = uldScene1.ID;
                string str1 = id.ToString();
                jobdownloadEntity1.TUTYPE = str1;
                jobdownloadEntity1.ENTERDATE = Utils.GetTodayNow();
                jobdownloadEntity1.RESPONDDATE = (string)null;
                jobdownloadEntity1.RESPONDCOUNT = 1;
                jobdownloadEntity1.RESPONDMSG = "";
                jobdownloadEntity1.STATUS = 0;
                jobdownloadEntity1.WEIGHT = new Decimal?(new Decimal());
                jobdownloadEntity1.FULLCOUNT = 0;
                jobdownloadEntity1.EXTENDINFO = "";
                jobdownloadEntity1.EXTATTR1 = "";
                jobdownloadEntity1.EXTATTR2 = "";
                jobdownloadEntity1.EXTATTR3 = "";
                jobdownloadEntity1.CREATEDATE = Utils.GetTodayNow();
                jobdownloadEntity1.CREATEUSERID = SysInfo.CurrentUserID;
                jobdownloadEntity1.CREATEUSERNAME = SysInfo.CurrentUserName;
                string emergencyexit = uldScene1.EMERGENCYEXIT;
                if (!string.IsNullOrEmpty(emergencyexit))
                {
                    string str2 = emergencyexit;
                    char[] chArray = new char[1] { ',' };
                    foreach (string str3 in str2.Split(chArray))
                    {
                        string item = str3;
                        LocDetailEntity locationDetailEntity = OrmLiteReadExpressionsApi.Single<LocDetailEntity>(db, (Expression<Func<LocDetailEntity, bool>>)(x => x.GROUPNO == item));
                        if (locationDetailEntity != null)
                        {
                            locationDetailEntity.EMEXIT = "1";
                            db.UpdateOnly<LocDetailEntity>(locationDetailEntity, (Expression<Func<LocDetailEntity, object>>)(x => new
                            {
                                EMEXIT = x.EMEXIT
                            }), (Expression<Func<LocDetailEntity, bool>>)null, (Action<IDbCommand>)null);
                        }
                    }
                }
                uldScene1.SCENESTATE = "1";
                uldScene1.OPBY = SysInfo.CurrentUserName;
                uldScene1.OPDATE = Utils.GetTodayNow();
                SysSceneEntity uldScene2 = uldScene1;
                id = uldScene1.ID;
                string str4 = "下达" + id.ToString() + "操作成功！";
                uldScene2.OPMESSAGE = str4;
               // uldScene1.P10 = jobdownloadEntity1.ID;
                string sql = string.Format("UPDATE PROJ_ULDSCENE SET SCENESTATE='0',OPBY='{1}',OPDATE='{2}',OPMESSAGE='{3}' WHERE ID<>{0}", (object)uldScene1.ID, (object)SysInfo.CurrentUserName, (object)Utils.GetTodayNow(), (object)"场景切换");
                long num1 = 0;
                //num1 = (long)db.SaveAll<INF_JOBDOWNLOADEntity>((IEnumerable<INF_JOBDOWNLOADEntity>)new List<INF_JOBDOWNLOADEntity>()
                //{
                //  jobdownloadEntity1
                //});
                int num2 = db.Update<SysSceneEntity>(uldScene1, (Action<IDbCommand>)null);
                int num3 = db.ExecuteSql(sql);
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "下达操作成功!" + num1.ToString() + "/" + num2.ToString() + "/" + num3.ToString();
                SysSceneService.logger.Info((object)dtoResponse.ToString());
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                SysSceneService.logger.Error((object)ex);
                return dtoResponse;
            }
        }

        public DTOResponse OrderSenceMode(SceneRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConnection = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    using (IDbTransaction trans = dbConnection.OpenTransaction())
                    {
                        dtoResponse = this.OrderSenceMode(request, dbConnection, trans);
                        if (dtoResponse.IsSuccess)
                            trans.Commit();
                        else
                            trans.Rollback();
                        SysSceneService.logger.Info((object)dtoResponse.ToString());
                        return dtoResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                SysSceneService.logger.Error((object)ex);
                return dtoResponse;
            }
        }

        public DTOResponse GetSceneList(SceneRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    List<SysSceneEntity> uldSceneList = dbConn.Select<SysSceneEntity>(x => x.USESTATE == 1);
                    dtoResponse.ResultObject = (object)uldSceneList;
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "查询操作成功！";
                }
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                SysSceneService.logger.Error((object)ex);
            }
            return dtoResponse;
        }

        public DTOResponse GetCurrent(SceneRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    List<SysSceneEntity> uldSceneList = dbConn.Select<SysSceneEntity>((Expression<Func<SysSceneEntity, bool>>)(x => x.SCENESTATE == "1"));
                    dtoResponse.ResultObject = (object)uldSceneList;
                    dtoResponse.IsSuccess = true;
                    dtoResponse.MessageText = "查询操作成功！";
                }
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                SysSceneService.logger.Error((object)ex);
            }
            return dtoResponse;
        }

        public DTOResponse SaveEntity(SceneRequest request)
        {
            DTOResponse dtoResponse = new DTOResponse();
            try
            {
                SysSceneEntity uldScene = JsonSerializer.DeserializeFromString<SysSceneEntity>(request.PostData);
                if (request.PostData == null)
                {
                    dtoResponse.IsSuccess = false;
                    dtoResponse.MessageText = "传入的数据为空！";
                    return dtoResponse;
                }
                int num = 0;
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                    num = dbConn.Update<SysSceneEntity>(uldScene, (Action<IDbCommand>)null);
                dtoResponse.IsSuccess = true;
                dtoResponse.MessageText = "保存数据操作成功！" + num.ToString();
                return dtoResponse;
            }
            catch (Exception ex)
            {
                dtoResponse.IsSuccess = false;
                dtoResponse.MessageText = ex.Message;
                SysSceneService.logger.Error((object)ex);
                return dtoResponse;
            }
        }
    }
}
