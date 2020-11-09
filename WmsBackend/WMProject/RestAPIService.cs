using KR.BaseApp;
using ServiceStack.Logging;
using WMProject.Dtos;
//using WMProject.Services;

namespace WMProject
{
    /// <summary>
    /// 本项目WEBAPI
    /// </summary>
    //[Authenticate]
    public class RestAPIService : RestAPIServiceBase
    {
        public RestAPIService()
        {
            RestAPIServiceBase.logger = LogManager.GetLogger(typeof(RestAPIService));
        }

        #region Hello测试
        public DTOResponseLayUI Any(Hello reqObj)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            DTOResponse response = new DTOResponse();
            response.IsSuccess = true;
            response.MessageText = reqObj.Name + "调用成功";
            return this.ConvertTo(response);
        }
        #endregion

        #region Inventory测试
        public object any(Inventory reqObj)
        {
            DTOResponseLayUI dtoResponseLayUi = new DTOResponseLayUI();
            DTOResponse response = new DTOResponse();
            response.IsSuccess = true;
            response.MessageText = reqObj.PH_ID + "调用成功";
            return this.ConvertTo(response);
        }
        #endregion



    }
}
