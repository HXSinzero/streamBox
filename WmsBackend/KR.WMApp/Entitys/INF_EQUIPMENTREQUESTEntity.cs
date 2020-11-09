using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("INF_EQUIPMENTREQUEST")]
    public class INF_EQUIPMENTREQUESTEntity
    {
        [Index(Unique = true)]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [Required]
        [StringLength(100)]
        public string EQUIPMENTID { get; set; }

        [Required]
        [StringLength(100)]
        public string WAREHOUSEID { get; set; }

        [Required]
        public int REQUESTTYPE { get; set; }

        [StringLength(100)]
        public string BARCODE { get; set; }

        [StringLength(100)]
        public string JOBID { get; set; }

        [StringLength(100)]
        public string BRANDID { get; set; }

        [StringLength(100)]
        public string TUTYPE { get; set; }

        [Required]
        [Default(0)]
        public int REQUESTQTY { get; set; }

        [StringLength(100)]
        public string ENTERDATE { get; set; }

        [StringLength(100)]
        public string RESPONDDATE { get; set; }

        public int RESPONDCOUNT { get; set; }

        [StringLength(1000)]
        public string RESPONDMSG { get; set; }

        [Required]
        [Default(0)]
        public int STATUS { get; set; }

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

        [StringLength(100)]
        public string MODIFYDATE { get; set; }

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
