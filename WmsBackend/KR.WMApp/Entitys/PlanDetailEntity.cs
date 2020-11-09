using KR.BaseApp;
using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_PLAN_DETAIL")]
    [CompositeIndex(new string[] { "PLANNO", "LINENUM" })]
    public class PlanDetailEntity : BaseExtend20
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }

        [Description("计划ID")]
        public long PLANID { get; set; }

        [StringLength(100)]
        [Description("计划编号")]
        public string PLANNO { get; set; }

        [StringLength(100)]
        [Description("计划类型")]
        public string PLANTYPE { get; set; }

        [Description("计划行号")]
        [Required]
        public int LINENUM { get; set; }

        [Description("状态")]
        [Default(0)]
        public int LINESTATE { get; set; }

        [Description("业务编号")]
        [StringLength(100)]
        public string BPNO { get; set; }

        [Description("业务名称")]
        [StringLength(100)]
        public string BPNAME { get; set; }

        [Description("站台编号")]
        [StringLength(100)]
        public string STATIONNO { get; set; }

        [StringLength(100)]
        [Description("修改人")]
        public string MODIFYBY { get; set; }

        [Description("修改时间")]
        public DateTime MODIFYDATE { get; set; }

        public long BOMID { get; set; }
        [StringLength(100)]
        public string BOMNO { get; set; }
        [StringLength(200)]
        public string BOMNAME { get; set; }
        [StringLength(100)]
        public string BOMBATCHNO { get; set; }

        public long PRODUCTID { get; set; }
        [StringLength(100)]
        public string PRODUCTNO { get; set; }
        [StringLength(200)]
        public string PRODUCTNAME { get; set; }
        [StringLength(100)]
        public string PRODUCTSPEC { get; set; }
        [StringLength(100)]
        public string PRODUCTCLASS { get; set; }
        [StringLength(100)]
        public string PRODUCTTYPE { get; set; }
        [StringLength(100)]
        public string BATCHNO { get; set; }

        [DecimalLength(18,4)]
        [Default(0)]
        public Decimal? Q01 { get; set; }

        [DecimalLength(18, 4)]
        [Default(0)]
        public Decimal? Q02 { get; set; }

        [DecimalLength(18, 4)]
        [Default(0)]
        public Decimal? Q03 { get; set; }

        [DecimalLength(18, 4)]
        [Default(0)]
        public Decimal? Q04 { get; set; }

        [DecimalLength(18, 4)]
        [Default(0)]
        public Decimal? Q05 { get; set; }

        [DecimalLength(18, 4)]
        [Default(0)]
        public Decimal? Q06 { get; set; }

        [StringLength(100)]
        [Required]
        public string MAINUNIT { get; set; }

        [StringLength(100)]
        [Required]
        public string BASICUNIT { get; set; }

        [StringLength(100)]
        [Description("备注1")]
        public string REMARK1 { get; set; }

        [StringLength(100)]
        [Description("备注2")]
        public string REMARK2 { get; set; }
    }
}
