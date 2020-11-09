using KR.BaseApp;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Description("场景管理表")]
    [Alias("WM_SYS_SCENE")]
    public class SysSceneEntity : BaseExtend10
    {
        [PrimaryKey]
        [Description("编号")]
        public int ID { get; set; }

        [Description("场景编号")]
        [StringLength(100)]
        public string SCENENO { get; set; }

        [Description("场景名称")]
        [StringLength(100)]
        public string SCENENAME { get; set; }

        [Description("场景描述")]
        [StringLength(1000)]
        public string SCENEDESC { get; set; }

        [Description("场景状态")]
        [StringLength(100)]
        public string SCENESTATE { get; set; }

        [Description("场景参数")]
        [StringLength(1000)]
        public string SCENEPARA { get; set; }

        [Description("场景分类")]
        [Default(0)]
        public int SCENETYPE { get; set; }

        [Description("入库规则")]
        [StringLength(100)]
        public string RULEID_IN { get; set; }

        [Description("出库规则")]
        [StringLength(100)]
        public string RULEID_OUT { get; set; }

        [Description("场景异常情况")]
        [StringLength(1000)]
        public string EXCEPTIONHANDLE { get; set; }

        [Description("紧急出口")]
        [StringLength(1000)]
        public string EMERGENCYEXIT { get; set; }

        [Description("使用状态")]
        [Default(0)]
        public int USESTATE { get; set; }

        [Description("是否下达到DCS")]
        [Default(0)]
        public int ORDERDCSSTATE { get; set; }

        [Description("操作信息")]
        [StringLength(200)]
        public string OPMESSAGE { get; set; }

        [Description("操作日期")]
        [StringLength(100)]
        public string OPDATE { get; set; }

        [Description("操作人")]
        [StringLength(100)]
        public string OPBY { get; set; }
    }
}
