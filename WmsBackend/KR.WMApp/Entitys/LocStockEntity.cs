using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_LOC_STOCK")]
    public class LocStockEntity
    {
        [PrimaryKey]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [Required]
        [StringLength(100)]
        public string STOCKNO { get; set; }

        [Required]
        [StringLength(100)]
        public string STOCKNAME { get; set; }

        [StringLength(1000)]
        public string STOCKDESC { get; set; }

        [StringLength(100)]
        public string STOCKSTATE { get; set; }

        [StringLength(100)]
        public string STOREMAN { get; set; }

        [StringLength(100)]
        public string STOCKTYPE { get; set; }

        [StringLength(100)]
        public string STOCKADDRESS { get; set; }

        [StringLength(100)]
        public string CAPACITY { get; set; }

        [StringLength(100)]
        public string SQUARE { get; set; }

        [StringLength(100)]
        public string STORAGE { get; set; }
    }
}
