using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_REPORT_DETAIL")]
    [CompositeIndex(new string[] { "PID", "SEQNUM" })]
    public class ReportDetailEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }

        [Description("报表主键")]
        [Required]
        [ForeignKey(typeof(ReportEntity), OnDelete = "CASCADE")]
        public long PID { get; set; }

        [Description("顺序号")]
        [Required]
        public long SEQNUM { get; set; }

        [StringLength(100)]
        [Description("属性1")]
        public string P01 { get; set; }

        [StringLength(100)]
        [Description("属性2")]
        public string P02 { get; set; }

        [StringLength(100)]
        [Description("属性3")]
        public string P03 { get; set; }

        [StringLength(100)]
        [Description("属性4")]
        public string P04 { get; set; }

        [StringLength(100)]
        [Description("属性5")]
        public string P05 { get; set; }

        [StringLength(100)]
        [Description("属性6")]
        public string P06 { get; set; }

        [StringLength(100)]
        [Description("属性7")]
        public string P07 { get; set; }

        [StringLength(100)]
        [Description("属性8")]
        public string P08 { get; set; }

        [StringLength(100)]
        [Description("属性9")]
        public string P09 { get; set; }

        [StringLength(100)]
        [Description("属性10")]
        public string P10 { get; set; }

        [Default(0)]
        [CustomField("decimal(18,4)")]
        public Decimal DQ01 { get; set; }

        [Default(0)]
        [CustomField("decimal(18,4)")]
        public Decimal DQ02 { get; set; }

        [Default(0)]
        [CustomField("decimal(18,4)")]
        public Decimal DQ03 { get; set; }

        [Default(0)]
        [CustomField("decimal(18,4)")]
        public Decimal DQ04 { get; set; }

        [Default(0)]
        [CustomField("decimal(18,4)")]
        public Decimal DQ05 { get; set; }

        [Default(0)]
        [CustomField("decimal(18,4)")]
        public Decimal DQ06 { get; set; }

        [Default(0)]
        [CustomField("decimal(18,4)")]
        public Decimal DQ07 { get; set; }

        [Default(0)]
        [CustomField("decimal(18,4)")]
        public Decimal DQ08 { get; set; }

        [Default(0)]
        [CustomField("decimal(18,4)")]
        public Decimal DQ09 { get; set; }

        [Default(0)]
        [CustomField("decimal(18,4)")]
        public Decimal DQ10 { get; set; }

        [Default(0)]
        public long LQ01 { get; set; }

        [Default(0)]
        public long LQ02 { get; set; }

        [Default(0)]
        public long LQ03 { get; set; }

        [Default(0)]
        public long LQ04 { get; set; }

        [Default(0)]
        public long LQ05 { get; set; }

        [Default(0)]
        public long LQ06 { get; set; }

        [Default(0)]
        public long LQ07 { get; set; }

        [Default(0)]
        public long LQ08 { get; set; }

        [Default(0)]
        public long LQ09 { get; set; }

        [Default(0)]
        public long LQ10 { get; set; }

        [Default(0)]
        public int LINESTATE { get; set; }

        [StringLength(2147483647)]
        public string REMARK1 { get; set; }

        [StringLength(2147483647)]
        public string REMARK2 { get; set; }
    }
}
