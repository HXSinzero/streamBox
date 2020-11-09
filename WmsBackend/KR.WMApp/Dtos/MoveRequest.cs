using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
    /// <summary>
    /// 移动请求
    /// </summary>
    public class MoveRequest
    {
        [Required]
        public int ACTION { get; set; }

        /// <summary>
        /// INF_EQUIPMENTREQUEST的ID属性
        /// </summary>
        public string InfRequestId { get; set; }

        /// <summary>
        /// 申请的命令码（任务号）
        /// </summary>
        public string RequestCode { get; set; }

        /// <summary>
        /// 申请站台号(设备号)
        /// </summary>
        public string StationNo { get; set; }

        /// <summary>
        /// 托盘号
        /// </summary>
        public string PalletNo { get; set; }

        /// <summary>
        /// 托盘类型
        /// </summary>
        public string PalletType { get; set; }

        /// <summary>
        /// 计划号
        /// </summary>
        public string PlanNo { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 目标位置
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; }
    }
}
