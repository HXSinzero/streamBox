using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    /// <summary>
    /// 业务类型
    /// </summary>
    [Alias("WM_BA_BUNIESSTYPE")]
    public class BasicBuniessTypeEntity
    {
        [PrimaryKey]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [Required]
        [StringLength(100)]
        [Index(Unique = true)]
        public string BUNIESSTYPENO { get; set; }

        [Required]
        [StringLength(100)]
        public string BUNIESSTYPENAME { get; set; }

        [StringLength(100)]
        public string BUNIESSCLASS { get; set; }

        [Required]
        [StringLength(100)]
        public string BUNIESSTYPESTATE { get; set; }

        [Required]
        [StringLength(100)]
        public string DIRECTION { get; set; }

        [Required]
        [StringLength(100)]
        public string IFSTAT { get; set; }

        [Required]
        [StringLength(100)]
        public string STOCKNO { get; set; }

        [Required]
        [StringLength(100)]
        public string STATIONNO { get; set; }

        [StringLength(100)]
        public string UNDOBUNIESSTYPENO { get; set; }

        [StringLength(100)]
        public string UNDOBUNIESSTYPENAME { get; set; }

        [StringLength(100)]
        public string MNG_SERIALNO { get; set; }

        [StringLength(100)]
        public string MNG_BATCHNO { get; set; }

        [StringLength(200)]
        public string REMARK { get; set; }

        public int RELATEID { get; set; }

    }
}
