using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_REPORT")]
    public class ReportEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }

        [Description("报表类型")]
        [Required]
        public int REPORTTYPE { get; set; }

        [Description("报表状态")]
        [Required]
        public int REPORTSTATE { get; set; }

        [Description("打印状态")]
        [Required]
        public int PRINTSTATE { get; set; }

        [Description("报表日期")]
        [Required]
        public DateTime REPORTDATE { get; set; }

        public DateTime DT01 { get; set; }

        public DateTime DT02 { get; set; }

        public DateTime DT03 { get; set; }

        public DateTime DT04 { get; set; }

        public DateTime DT05 { get; set; }

        public DateTime DT06 { get; set; }

        public DateTime DT07 { get; set; }

        public DateTime DT08 { get; set; }

        public DateTime DT09 { get; set; }

        public DateTime DT10 { get; set; }

        [StringLength(100)]
        [Description("属性1")]
        public string A01 { get; set; }

        [StringLength(100)]
        [Description("属性2")]
        public string A02 { get; set; }

        [StringLength(100)]
        [Description("属性3")]
        public string A03 { get; set; }

        [StringLength(100)]
        [Description("属性4")]
        public string A04 { get; set; }

        [StringLength(100)]
        [Description("属性5")]
        public string A05 { get; set; }

        [StringLength(100)]
        [Description("属性6")]
        public string A06 { get; set; }

        [StringLength(100)]
        [Description("属性7")]
        public string A07 { get; set; }

        [StringLength(100)]
        [Description("属性8")]
        public string A08 { get; set; }

        [StringLength(100)]
        [Description("属性9")]
        public string A09 { get; set; }

        [StringLength(100)]
        [Description("属性10")]
        public string A10 { get; set; }

        [StringLength(100)]
        [Required]
        public string CREATEBY { get; set; }

        [StringLength(100)]
        [Required]
        public string CREATEDATE { get; set; }

        [StringLength(100)]
        public string MODIFYBY { get; set; }
    }
}
