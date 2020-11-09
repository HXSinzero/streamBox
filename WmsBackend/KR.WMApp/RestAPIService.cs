using KR.BaseApp;
using KR.CIMS;
using KR.WMApp.Dtos;
using KR.WMApp.Entitys;
using KR.WMApp.Services;
using ServiceStack;
using System;
using System.Collections.Generic;

namespace KR.WMApp
{
    /// <summary>
    /// 项目api发布
    /// </summary>
    //[Authenticate]
    public class RestAPIService : RestAPIServiceBase
    {
        #region 位置管理
        public object Any(LocationRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            LocService locationService = new LocService();
            DTOResponse response = new DTOResponse();
            if (request.ACTION == 100)
            {
                response = locationService.GetList(request);
            }
            else if (request.ACTION == OPAction.OP_01)//2011
            {
                response = locationService.GetListLocGroup(request);
            }
            else if (request.ACTION == OPAction.AFFIRM_01)//1011
            {
                response = locationService.ChangeUseState(request);
            }
            else if (request.ACTION == OPAction.AFFIRM_02)//1012
            {
                response = locationService.SetGroupnoSeq(request);
            }
            else if (request.ACTION == OPAction.AFFIRM_03)//1013
            {
                //设置通道使用状态
                response = locationService.ChangeGroupUseState(request);
            }
            else if (request.ACTION == OPAction.AFFIRM_04)//1014
            {
                //批量的位置使用状态
                response = locationService.BatchChangeUseState(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return dtoResponseLayUi;
            }
            return this.ConvertTo(response);
        }

        public object Any(LocationStnRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            LocStationService stnService = new LocStationService();
            DTOResponse response;
            if (request.ACTION == 100)
                response = stnService.GetList(request);
            else if (request.ACTION == OPAction.OP_01)
                response = stnService.SetP01(request);
            else if (request.ACTION == OPAction.OP_02)
                response = stnService.SetSTATIONSTATE(request);
            else if (request.ACTION == OPAction.OP_09)
            {
                response = stnService.SetP01Emplty(request);
            }
            else if (request.ACTION == OPAction.OP_08)//设置紧急出口
            {
                response = stnService.SwitchEmexitState(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return dtoResponseLayUi;
            }
            return this.ConvertTo(response);
        }
        #endregion

        #region 物料管理
        public object Any(ProductRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            ProductService service = new ProductService();
            DTOResponse response = new DTOResponse();
            if (request.ACTION == OPAction.QUERY)
            {
                response = service.GetList(request);
            }
            else if (request.ACTION == OPAction.CREATE || request.ACTION == OPAction.UPDATE
                || request.ACTION == OPAction.OP_01)
            {
                response = service.Save(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return dtoResponseLayUi;
            }
            return this.ConvertTo(response);
        }
        #endregion

        #region 基础信息
        public object Any(BasicRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            BasicService service = new BasicService();
            DTOResponse response = new DTOResponse();
            if (request.ACTION == OPAction.QUERY)
            {
                response = service.GetList(request);
            }
            else if (request.ACTION == OPAction.AFFIRM)
            {
                response = service.SaveBasicObject(request);
            }
            else if (request.ACTION == OPAction.OP_01)
            {
                response = service.GetSysparamsList(request);
            }
            else if (request.ACTION == OPAction.OP_02)
            {
                response = service.SaveSysparams(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return dtoResponseLayUi;
            }
            return this.ConvertTo(response);
        }
        #endregion

        #region 计划管理
        public object Any(PlanDetailRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            PlanDetailService service = new PlanDetailService();
            DTOResponse response = new DTOResponse();
            if (request.ACTION == OPAction.QUERY)
            {
                response = service.GetList(request);
            }
            else if (request.ACTION == OPAction.CREATE || request.ACTION == OPAction.UPDATE)
            {
                response = service.Save(request);
            }
            else if(request.ACTION == OPAction.QUERYDETAIL1)
            {
                response = service.GetDetailPalletList(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return dtoResponseLayUi;
            }
            return this.ConvertTo(response);
        }
        #endregion

        #region 托盘管理
        public object Any(PalletRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            PalletService service = new PalletService();
            DTOResponse response = new DTOResponse();
            if (request.ACTION == OPAction.QUERY)
            {
                response = service.GetList(request);
            }
            else if (request.ACTION == OPAction.QUERYDETAIL1)
            {
                response = service.GetDetailList(request);
            }
            else if (request.ACTION == OPAction.STAT1)
            {
                response = service.GetPalletList(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return dtoResponseLayUi;
            }
            return this.ConvertTo(response);
        }
        #endregion

        #region 场景管理
        public object Any(SceneRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            SysSceneService sceneService = new SysSceneService();
            DTOResponse response = (DTOResponse)null;
            if (request.ACTION == 100)
            {
                response = sceneService.GetSceneList(request);
            }
            else if (request.ACTION != 1)
            {
                if (request.ACTION == OPAction.UPDATE)
                {
                    response = sceneService.SaveEntity(request);
                }
                else if (request.ACTION != 3)
                {
                    if (request.ACTION == 101)
                    {
                        response = sceneService.OrderSenceMode(request);
                    }
                    else
                    {
                        dtoResponseLayUi.code = -1;
                        dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                        return dtoResponseLayUi;
                    }
                }
            }
            return this.ConvertTo(response);
        }
        #endregion

        #region 任务管理
        public object Any(TaskRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            TaskService taskService = new TaskService();
            DTOResponse response;
            if (request.ACTION == 100)
            {
                response = taskService.GetTaskList(request);
            }
            else if (request.ACTION == 1001)
            {
                response = taskService.GetTaskStepList(request);
            }
            else if (request.ACTION == 101)
            {
                response = taskService.TaskOprationByMen(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return dtoResponseLayUi;
            }
            return this.ConvertTo(response);
        }
        #endregion

        #region 设备接口管理
        public object Any(DCSInfRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            DCSInfService dcsInfService = new DCSInfService();
            DTOResponse list;
            if (request.ACTION == 101)
            {
                list = dcsInfService.GetList<INF_EQUIPMENTREQUESTEntity>(request);
            }
            else if (request.ACTION == 102)
            {
                list = dcsInfService.GetList<INF_JOBDOWNLOADEntity>(request);
            }
            else if (request.ACTION == 103)
            {
                list = dcsInfService.GetList<INF_JOBFEEDBACKEntity>(request);
            }
            else if (request.ACTION == 104)
            {
                list = dcsInfService.GetList<INF_EQUIPMENTSTATUSEntity>(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return dtoResponseLayUi;
            }
            return this.ConvertTo(list);
        }
        #endregion

        #region 盘点检查（数据）
        public object Any(CheckRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            SysCheckService checkService = new SysCheckService();
            DTOResponse response;
            if (request.ACTION == 100)
                response = checkService.GetList(request);
            else if (request.ACTION == 101)
            {
                response = checkService.Rest(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return (object)dtoResponseLayUi;
            }
            return (object)this.ConvertTo(response);
        }
        #endregion

        #region 预警消息
        public object Any(MsgRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            MsgService msgService = new MsgService();
            DTOResponse response;
            if (request.ACTION == 100)
            {
                response = msgService.GetList(request);
            }
            if (request.ACTION == OPAction.QUERYDETAIL1)
            {
                response = msgService.GetOplogList(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return (object)dtoResponseLayUi;
            }
            return this.ConvertTo(response);
        }
        #endregion

        #region LED消息
        public DTOResponseLayUI Any(LedInfoRequest request)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            LedInfoService ledInfoService = new LedInfoService();
            DTOResponse response;
            if (request.ACTION == 100)
            {
                response = ledInfoService.GetList(request);
            }
            else if (request.ACTION == 101)
            {
                response = ledInfoService.GetkanbanInfo(request);
            }
            else
            {
                dtoResponseLayUi.code = -1;
                dtoResponseLayUi.msg = "未定义的操作类型：" + request.ACTION.ToString();
                return dtoResponseLayUi;
            }
            return this.ConvertTo(response);
        }
        #endregion

    }
}
