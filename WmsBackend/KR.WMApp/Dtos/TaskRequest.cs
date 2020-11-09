using KR.BaseApp.Dtos;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
    [Route("/WMService/TaskRequest", "GET")]
    public class TaskRequest : PageRequest
    {
        [Required]
        public int ACTION { get; set; }
        public string datetimerange { get; set; }

        public string ID { get; set; }

        public string TASKNO { get; set; }

        public string PALLETID { get; set; }

        public string PALLETNO { get; set; }

        public string TASKTCLASS { get; set; }

        public string RelateNo { get; set; }

        public string SourceNo { get; set; }

        public string DescNo { get; set; }

        public string TASKOPACTION { get; set; }

        public string IsHistory { get; set; }

        public string TASKSTATE { get; set; }
    }
}
