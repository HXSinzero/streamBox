using KR.BaseApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
    [Route("/WMService/PlanDetailRequest", "GET")]
    public class PlanDetailRequest : PageRequest
    {
        [Required]
        public int ACTION { get; set; }

        /// <summary>
        /// 客户端参数
        /// </summary>
        public string PostData { get; set; }

        /// <summary>
        /// 计划明细对象
        /// </summary>
        public PlanDetailEntity Entity { get; set; }

        public long ID { get; set; }
        public string PLANTYPE { get; set; }
        public string PLANNO { get; set; }
        public int? LINESTATE { get; set; }

        public string PRODUCTNO { get; set; }
        public string PRODUCTNAME { get; set; }
        public string PRODUCTTYPE { get; set; }

        public int CONTROLMODEL { get; set; }
        public string GROUPNO { get; set; }
    }
}