using KR.BaseApp;
using KR.BaseApp.Dtos;
using KR.BaseApp.Entitys;
using KR.BaseApp.Services;
using KR.CIMS.Jobs;
using KR.WMApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.WMApp.Jobs
{
    /// <summary>
    /// Dcs设备状态处理定时器
    /// </summary>
    public class DcsEquipmentStatusJob : BaseJob
    {
        public override JobExecuteState ExecuteCustomImp(string strJobKey)
        {
            JobExecuteState jobExecuteState1 = new JobExecuteState();
            DTOResponse dtoResponse1 = new DTOResponse();
            DCSInfService dcsInfService = new DCSInfService();
            string str1 = "AcceptWcsUpdateInfEquitmentStaus";
            DTOResponse dtoResponse2 = SysParamsService.CheckPrarams(new SysParamsReuqest()
            {
                ParamsName = str1
            });
            bool isSuccess;
            if (dtoResponse2.IsSuccess)
            {
                SysParams resultObject = dtoResponse2.ResultObject as SysParams;
                if (resultObject == null)
                {
                    jobExecuteState1.MessageText = "系统参数为空";
                    return jobExecuteState1;
                }
                if (resultObject.PARAVALUE == "TRUE")
                {
                    DTOResponse dtoResponse3 = dcsInfService.UpdateEquipmentStatus();
                    JobExecuteState jobExecuteState2 = jobExecuteState1;
                    isSuccess = dtoResponse3.IsSuccess;
                    string str2 = isSuccess.ToString();
                    jobExecuteState2.ReturnValue = str2;
                    jobExecuteState1.MessageCode = dtoResponse3.MessageCode;
                    jobExecuteState1.MessageText = dtoResponse3.MessageText;
                }
            }
            string str3 = "UpdateKanbanFormInfEquitmentStaus";
            DTOResponse dtoResponse4 = SysParamsService.CheckPrarams(new SysParamsReuqest()
            {
                ParamsName = str3
            });
            if (dtoResponse4.IsSuccess)
            {
                SysParams resultObject = dtoResponse4.ResultObject as SysParams;
                if (resultObject == null)
                {
                    jobExecuteState1.MessageText = "系统参数为空";
                    return jobExecuteState1;
                }
                if (resultObject.PARAVALUE == "TRUE")
                {
                    DTOResponse dtoResponse3 = dcsInfService.UpdateKanbanFormEquipmentStatus();
                    JobExecuteState jobExecuteState2 = jobExecuteState1;
                    isSuccess = dtoResponse3.IsSuccess;
                    string str2 = isSuccess.ToString();
                    jobExecuteState2.ReturnValue = str2;
                    jobExecuteState1.MessageCode = dtoResponse3.MessageCode;
                    jobExecuteState1.MessageText = dtoResponse3.MessageText;
                }
            }
            return jobExecuteState1;
        }
    }
}
