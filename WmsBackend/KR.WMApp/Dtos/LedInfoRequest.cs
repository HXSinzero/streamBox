using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
    [Route("/WMService/LedInfoRequest", "GET")]
    public class LedInfoRequest
    {
        [Required]
        public int ACTION { get; set; }

        public int KANBANNO { get; set; }

        public string REPORTNO { get; set; }
    }
}
