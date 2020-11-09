using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
    /// <summary>
    /// 站台参数请求
    /// </summary>
    [Route("/WMService/StnRequest", "GET")]
    [Route("/WMService/StnRequest", "POST")]
    public class LocationStnRequest
    {
        [Required]
        public int ACTION { get; set; }

        public string STATIONTYPE { get; set; }

        public string STATIONNO { get; set; }

        public string STATIONSTATE { get; set; }

        public string GROUPNO { get; set; }

        public string AREANO { get; set; }

        public string TECHNO { get; set; }

        public string RELATENO { get; set; }

        public string P01 { get; set; }
        public string P02 { get; set; }
        public string P03 { get; set; }
        public string P04 { get; set; }
        public string P05 { get; set; }
        public string P06 { get; set; }
        public string P07 { get; set; }
        public string P08 { get; set; }
        public string P09 { get; set; }
        public string P10 { get; set; }

        public string LOCATIONX { get; set; }

        public string OPBY { get; set; }

        public int CONTROLMODE { get; set; }

        public string IFSWITCHTOEMEXIT { get; set; }

        public int EMEXIT { get; set; }

        public int PRIORITY { get; set; }
        public int TASKCOUNT { get; set; }
    }
}
