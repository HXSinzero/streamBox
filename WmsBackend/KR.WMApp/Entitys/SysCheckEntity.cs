using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_SYS_CHECK")]
    public class SysCheckEntity
    {
        [PrimaryKey]
        public int ID { get; set; }

        [Index(Unique = true)]
        [StringLength(100)]
        [Description("检查项")]
        public string ITEMNAME { get; set; }

        [StringLength(1000)]
        [Description("检查项值")]
        public string ITEMVALUE { get; set; }

        [StringLength(200)]
        [Description("检查项描述")]
        public string ITEMDESC { get; set; }

        [Description("状态")]
        public int ITEMSTATE { get; set; }

        [Description("执行时间")]
        [StringLength(100)]
        public string EXECUTEDATE { get; set; }

        [Description("受影响的行数据")]
        public long AFFECTEDCOUNT { get; set; }

        [StringLength(4000)]
        [Description("归档项值")]
        public string ARCITEMVALUE { get; set; }
    }
}
