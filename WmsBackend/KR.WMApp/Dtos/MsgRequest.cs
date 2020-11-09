using KR.BaseApp.Dtos;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
    [Route("/WMService/MsgRequest", "GET")]
    public class MsgRequest : PageRequest
    {
        [Required]
        public int ACTION { get; set; }

        public long ID { get; set; }

        public string MSGTEXT { get; set; }

        public string MSGSTATE { get; set; }

        public string MSGTYPE { get; set; }

        public string datetimerange { get; set; }
    }
}
