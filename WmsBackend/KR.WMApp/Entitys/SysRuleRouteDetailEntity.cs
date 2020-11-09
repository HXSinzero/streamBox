using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_SYS_RULEROUTEDETAIL")]
    [CompositeIndex("RULEROUTEID", "ITEMNAME")]
    public class SysRuleRouteDetailEntity
    {
        [PrimaryKey]
        public int ID { get; set; }

        [Required]
        public int RULEROUTEID { get; set; }

        [StringLength(100)]
        public string ITEMNAME { get; set; }

        [StringLength(1000)]
        public string ITEMVALUE { get; set; }

        [StringLength(200)]
        public string ITEMDESC { get; set; }

        [Description("状态")]
        public int ITEMSTATE { get; set; }

        [Description("执行时间")]
        [StringLength(100)]
        public string EXECUTEDATE { get; set; }

        [Description("受影响的行数据")]
        public long AFFECTEDCOUNT { get; set; }
    }
}
