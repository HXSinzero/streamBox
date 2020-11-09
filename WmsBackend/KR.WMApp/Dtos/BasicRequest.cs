using KR.BaseApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
    [Route("/WMService/BasicRequest", "GET")]
    public class BasicRequest : PageRequest
    {
        [Required]
        public int ACTION { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string BasicType { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string Subdesc { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 数据实体
        /// </summary>
        public string PostData { get; set; }
    }
}