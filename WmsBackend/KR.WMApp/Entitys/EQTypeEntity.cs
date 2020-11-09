using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.WMApp.Entitys
{
    /// <summary>
    /// 设备类别信息
    /// </summary>
    [Description("设备类别信息")]
    [Alias("EQ_TYPE")]
    public class EQTypeEntity
    {
        [PrimaryKey]
        [StringLength(100)]
        public string ID { get; set; }

        [Description("设备类别编号")]
        [Index(Unique = true)]
        [StringLength(100)]
        [Required]
        public string TYPECODE { get; set; }

        [Description("设备类别名称")]
        [StringLength(100)]
        [Required]
        public string TYPENAME { get; set; }

        [Description("通信参数")]
        [StringLength(1000)]
        public string PARAMS { get; set; }

        [Description("适配器处理类")]
        [StringLength(200)]
        public string EQADAPTER { get; set; }

        [Description("备注")]
        [StringLength(100)]
        public string REMARK { get; set; }
    }
}
