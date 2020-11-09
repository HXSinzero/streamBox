using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.WMApp.Entitys
{
    /// <summary>
    /// 设备实例对象
    /// </summary>
    [Description("设备实例对象")]
    [Alias("EQ_INSTANCE")]
    public class EQInstanceEntity
    {
        [PrimaryKey]
        [StringLength(100)]
        public string ID { get; set; }

        [Description("设备类型")]
        [StringLength(100)]
        [Required]
        public string EQTPYE { get; set; }

        [Description("设备编号")]
        [Index(Unique = true)]
        [StringLength(100)]
        [Required]
        public string EQCODE { get; set; }

        [Description("设备名称")]
        [StringLength(100)]
        [Required]
        public string EQNAME { get; set; }

        [Description("设备状态")]
        [Required]
        public string EQSTATE { get; set; }

        [Description("使用状态")]
        [Required]
        public int USESTATE { get; set; }

        [Description("备注")]
        [StringLength(100)]
        public string REMARK { get; set; }

        [Description("关联设备")]
        [StringLength(100)]
        public string RELATEEQ { get; set; }

        [Description("安装位置")]
        [StringLength(100)]
        public string LOCATION { get; set; }

        [Description("控制号")]
        [StringLength(100)]
        public string CONTROLNO { get; set; }

        [Description("工艺段")]
        [StringLength(100)]
        public string TECHNO { get; set; }

        [Description("IP地址")]
        [StringLength(100)]
        public string IPADR { get; set; }

        [Description("IP端口")]
        [StringLength(100)]
        public string IPPORT { get; set; }
    }
}
