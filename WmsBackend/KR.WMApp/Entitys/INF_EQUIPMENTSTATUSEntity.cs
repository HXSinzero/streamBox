using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("INF_EQUIPMENTSTATUS")]
    public class INF_EQUIPMENTSTATUSEntity
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
        [StringLength(100)]
        public string WMSLOCNUM { get; set; }

        [Required]
        [StringLength(100)]
        public string EQUIPMENTSTATUS { get; set; }

        [StringLength(100)]
        public string EQUIPMENTPOSITION { get; set; }

        [StringLength(100)]
        public string JOBID { get; set; }

        [StringLength(100)]
        public string BARCODE { get; set; }

        [StringLength(100)]
        public string TUTYPE { get; set; }

        [StringLength(100)]
        public string TARGET { get; set; }

        [StringLength(1000)]
        public string EXTENDINFO { get; set; }

        [StringLength(100)]
        public string EXTATTR1 { get; set; }

        [StringLength(100)]
        public string EXTATTR2 { get; set; }

        [StringLength(100)]
        public string EXTATTR3 { get; set; }

        [StringLength(100)]
        public string UPDATEDATE { get; set; }

        [Required]
        public int STATUS { get; set; }

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

        [Default(0)]
        public int SORTINDEX { get; set; }

        [PrimaryKey]
        [AutoIncrement]
        public long AUTOID { get; set; }


    }
}
