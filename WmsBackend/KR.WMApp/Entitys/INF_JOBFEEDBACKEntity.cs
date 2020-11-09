using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("INF_JOBFEEDBACK")]
    public class INF_JOBFEEDBACKEntity
    {
        [Index(Unique =true)]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [Required]
        [StringLength(100)]
        public string JOBID { get; set; }

        [Required]
        [StringLength(100)]
        public string WAREHOUSEID { get; set; }

        [Required]
        [StringLength(100)]
        public string FEEDBACKSTATUS { get; set; }

        [Required]
        [StringLength(100)]
        public string ERRORCODE { get; set; }

        [DecimalLength(10, 4)]
        public Decimal? PLANQTY { get; set; }

        [DecimalLength(10, 4)]
        public Decimal? ACTQTY { get; set; }

        [StringLength(100)]
        public string ENTERDATE { get; set; }

        [StringLength(100)]
        public string RESPONDDATE { get; set; }

        public int RESPONDCOUNT { get; set; }

        [StringLength(1000)]
        public string RESPONDMSG { get; set; }

        [Default(0)]
        public int STATUS { get; set; }

        [DecimalLength(10, 4)]
        public Decimal? WEIGHT { get; set; }

        public int FULLCOUNT { get; set; }

        [StringLength(1000)]
        public string EXTENDINFO { get; set; }

        [StringLength(100)]
        public string EXTATTR1 { get; set; }

        [StringLength(100)]
        public string EXTATTR2 { get; set; }

        [StringLength(100)]
        public string EXTATTR3 { get; set; }

        [Required]
        [StringLength(100)]
        public string CREATEDATE { get; set; }

        [StringLength(100)]
        public string CREATEUSERID { get; set; }

        [StringLength(100)]
        public string CREATEUSERNAME { get; set; }

        public DateTime? MODIFYDATE { get; set; }

        [StringLength(100)]
        public string MODIFYUSERID { get; set; }

        [StringLength(100)]
        public string MODIFYUSERNAME { get; set; }

        public int ROWVERSION { get; set; }

        [PrimaryKey]
        [AutoIncrement]
        public long AUTOID { get; set; }
    }
}
