using KR.BaseApp;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_TASKSTAT")]
    public class TaskStatEntity : BaseExtend10
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }

        [Required]
        [StringLength(100)]
        public string TASKNO { get; set; }

        [StringLength(100)]
        [Description("统计项")]
        public string STATITEMNAME { get; set; }

        [StringLength(1000)]
        [Description("统计项值")]
        public string STATITEMVALUE { get; set; }

        [StringLength(200)]
        [Description("统计项描述")]
        public string STATITEMDESC { get; set; }

        [StringLength(100)]
        [Description("记录时间")]
        public string CREATETIME { get; set; }

        [StringLength(2147483647)]
        [Description("备注")]
        public string REMARK { get; set; }
    }
}
