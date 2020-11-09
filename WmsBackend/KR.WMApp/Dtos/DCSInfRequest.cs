using KR.BaseApp.Dtos;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
    [Route("/WMService/DCSInfRequest", "GET")]
    public class DCSInfRequest : PageRequest
    {
        [Required]
        public int ACTION { get; set; }

        public string JOBID { get; set; }

        public string STATUS { get; set; }

        public string EQUIPMENTID { get; set; }

        public string CREATEDATE { get; set; }
    }
}
