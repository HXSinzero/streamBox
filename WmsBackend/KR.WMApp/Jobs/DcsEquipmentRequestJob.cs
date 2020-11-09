using KR.BaseApp;
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
    /// Dcs设备申请请求处理定时器
    /// </summary>
    public class DcsEquipmentRequestJob : BaseJob
    {
        public override JobExecuteState ExecuteCustomImp(string strJobKey)
        {
            JobExecuteState jobExecuteState = new JobExecuteState();
            DTOResponse dtoResponse = new DCSInfService().EquipmentRequestHandle();
            jobExecuteState.ReturnValue = dtoResponse.IsSuccess.ToString();
            jobExecuteState.MessageCode = dtoResponse.MessageCode;
            jobExecuteState.MessageText = dtoResponse.MessageText;
            return jobExecuteState;
        }
    }
}
