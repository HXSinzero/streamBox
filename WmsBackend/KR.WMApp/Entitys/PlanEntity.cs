using KR.BaseApp;
using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_PLAN")]
    public class PlanEntity : BaseExtend10
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }

        [Index]
        [StringLength(100)]
        [Description("计划编号")]
        public string PLANNO { get; set; }

        [StringLength(100)]
        [Description("计划状态")]
        public string PLANSTATE { get; set; }

        [Description("场景编号")]
        [StringLength(100)]
        public string SCENENO { get; set; }

        [Description("场景描述")]
        [StringLength(200)]
        public string SCENEDESC { get; set; }

        [StringLength(200)]
        [Description("计划变更消息")]
        public string PLANMESSAGE { get; set; }

        [StringLength(100)]
        [Description("备注")]
        public string REMARK { get; set; }

        [StringLength(100)]
        [Description("创建人")]
        public string CREATEBY { get; set; }

        [Description("创建时间")]
        public DateTime? CREATEDATE { get; set; }

        [StringLength(100)]
        [Description("修改人")]
        public string MODIFYBY { get; set; }

        [StringLength(100)]
        [Description("修改时间")]
        public string MODIFYDATE { get; set; }
    }
}
