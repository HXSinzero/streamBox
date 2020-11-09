using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_SYS_RULEROUTE")]
    public class SysRuleRouteEntity
    {
        [PrimaryKey]
        public int ID { get; set; }

        [Index(Unique = true)]
        [StringLength(100)]
        public string RULEROUTENAME { get; set; }

        [StringLength(200)]
        public string RULEROUTEDESC { get; set; }

        [StringLength(200)]
        public string FULLCLASSNAME { get; set; }

        [StringLength(200)]
        public string DEFAULTEVALUE { get; set; }
    }
}
