using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.WMApp.Entitys
{
    /// <summary>
    /// 位置组合对象
    /// </summary>
    [Alias("WM_LOC_GROUP")]
    public class LocGroupEntity
    {
        [PrimaryKey]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [Description("仓库编号")]
        [StringLength(100)]
        public string STOCKNO { get; set; }

        [Description("区域编号")]
        [StringLength(100)]
        public string AREANO { get; set; }
        
        [Description("组编号")]
        [Index(Unique =true)]
        [StringLength(100)]
        public string GROUPNO { get; set; }

        [Description("组分类")]
        [StringLength(100)]
        public string GROUPCLASS { get; set; }

        [Description("组类型")]
        [StringLength(100)]
        public string GROUPTYPE { get; set; }

        [Description("组状态")]
        [Required]
        public int GROUPSTATE { get; set; }

        [Description("组限制码")]
        [StringLength(100)]
        public string GROUPLIMIT { get; set; }

        [Description("组限属性组")]
        [StringLength(100)]
        public string GROUPATTRIBUTE { get; set; }

        [Description("组控制号")]
        [StringLength(100)]
        public string GROUPCONTROLID { get; set; }

        [Description("口方向")]
        [StringLength(100)]
        public string DIRECTIONENTRY { get; set; }

        [Description("进出模式")]
        [StringLength(100)]
        public string GROUPMODEL { get; set; }

        [Description("使用状态")]
        [Required]
        public int USESTATE { get; set; }

        [Description("排序值")]
        [Default(0)]
        public int SORTSEQ { get; set; }

        [Description("总容量")]
        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? CAPACITY { get; set; }

        [Description("已用容量")]
        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? USECAPACITY { get; set; }

        [Description("调整容量")]
        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? ADJUSTCAPACITY { get; set; }

        [Description("排")]
        [Required]
        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? ROWNO { get; set; }

        [Description("列")]
        [Required]
        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? COLUMNNO { get; set; }

        [Description("层")]
        [Required]
        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? LAYERNO { get; set; }

        [Description("操作消息")]
        [StringLength(200)]
        public string OPMESSAGE { get; set; }

        [Description("操作时间")]
        [StringLength(100)]
        public string OPDATE { get; set; }

        [Description("操作人")]
        [StringLength(100)]
        public string OPBY { get; set; }
    }
}
