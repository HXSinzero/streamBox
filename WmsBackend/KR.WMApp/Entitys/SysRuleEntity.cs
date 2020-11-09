using KR.BaseApp;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Description("规则基础信息表")]
    [Alias("WM_SYS_RULE")]
    public class SysRuleEntity : BaseExtend20
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }

        [Description("规则编号")]
        [Required]
        [StringLength(100)]
        public string RULENO { get; set; }

        [Description("规则名称")]
        [Required]
        [StringLength(100)]
        public string RULENAME { get; set; }

        [Description("规则描述")]
        [StringLength(200)]
        public string RULEDESC { get; set; }

        [Description("规则状态")]
        [Required]
        public int RULESTATE { get; set; }

        [Description("类全名")]
        [StringLength(200)]
        public string CLASSFULLNAME { get; set; }

        [Description("初始参数")]
        [StringLength(200)]
        public string INITPARA { get; set; }
    }
}
