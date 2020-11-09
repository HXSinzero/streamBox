using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_LOC_DETAIL")]
    public class LocDetailEntity
    {
        [PrimaryKey]
        [Required]
        public int ID { get; set; }

        [Required]
        [Index(Unique =true)]
        public string LOCATIONNO { get; set; }

        [Required]
        [StringLength(100)]
        public string LOCATIONTYPE { get; set; }

        [Required]
        [StringLength(200)]
        public string LOCATIONDESC { get; set; }

        [StringLength(100)]
        public string LOCATIONBARCODE { get; set; }

        [Description("仓库编号")]
        [StringLength(100)]
        public string STOCKNO { get; set; }

        [Required]
        [StringLength(100)]
        public string AREANO { get; set; }

        [StringLength(100)]
        public string LOGICAREANO { get; set; }

        [StringLength(100)]
        public string PHISICALNO { get; set; }

        [StringLength(100)]
        public string CONTROLID { get; set; }

        [Required]
        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? ROWNO { get; set; }

        [Required]
        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? COLUMNNO { get; set; }

        [Required]
        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? LAYERNO { get; set; }

        [StringLength(100)]
        public string GROUPNO { get; set; }

        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? GROUPNOSEQ { get; set; }

        [StringLength(100)]
        public string PARENTNODE { get; set; }

        [StringLength(100)]
        public string LANENO { get; set; }

        [StringLength(100)]
        public string LOCATIONX { get; set; }

        [StringLength(100)]
        public string LOCATIONY { get; set; }

        [StringLength(100)]
        public string LOCATIONZ { get; set; }

        [StringLength(100)]
        public string LEFTORRIGHT { get; set; }

        [StringLength(100)]
        public string INSORTVALUE { get; set; }

        [StringLength(100)]
        public string REPORTSORTVALUE { get; set; }

        [Required]
        [StringLength(100)]
        public string LOCATIONSTATE { get; set; }

        [Required]
        [StringLength(100)]
        public string STORESTATE { get; set; }

        [Required]
        [StringLength(100)]
        public string USESTATE { get; set; }

        [StringLength(200)]
        public string OPMESSAGE { get; set; }

        [StringLength(100)]
        public string OPDATE { get; set; }

        [StringLength(100)]
        public string OPBY { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL01 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL02 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL03 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL04 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL05 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL06 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL07 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL08 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL09 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL10 { get; set; }

        [StringLength(100)]
        public string MASTERNO { get; set; }

        [StringLength(100)]
        public string MASTERNAME { get; set; }

        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? CAPACITY { get; set; }

        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? USECAPACITY { get; set; }

        [Description("紧急出口")]
        [StringLength(100)]
        public string EMEXIT { get; set; }

        [Description("控制模式")]
        [StringLength(100)]
        public string CONTROLMODE { get; set; }

        [Description("是否依赖关闭")]
        [Default(0)]
        public int ISCLOSE { get; set; }

        [StringLength(1000)]
        public string REMARK { get; set; }
    }
}
