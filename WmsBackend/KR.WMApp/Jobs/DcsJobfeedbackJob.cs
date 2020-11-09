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
    /// Dcs任务执行反馈处理定时器
    /// </summary>
    public class DcsJobfeedbackJob : BaseJob
    {
        public override JobExecuteState ExecuteCustomImp(string strJobKey)
        {
            JobExecuteState jobExecuteState = new JobExecuteState();
            DTOResponse dtoResponse = new DCSInfService().TaskHandle();
            jobExecuteState.ReturnValue = dtoResponse.IsSuccess.ToString();
            jobExecuteState.MessageCode = dtoResponse.MessageCode;
            jobExecuteState.MessageText = dtoResponse.MessageText;
            return jobExecuteState;
        }
    }
}
