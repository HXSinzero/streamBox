using KR.BaseApp;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_PRODUCT_BATCHNO")]
    [CompositeIndex("BATCHNO", "SEQNO")]
    public class ProductBatchnoEntity
    {
        [AutoIncrement]
        public long ID { get; set; }

        [Required]
        [StringLength(100)]
        public string BATCHNO { get; set; }

        [Required]
        public int SEQNO { get; set; }

        [StringLength(100)]
        public string OBJECTNAME { get; set; }

        [Required]
        [StringLength(100)]
        public string ITEMNAME { get; set; }

        [StringLength(100)]
        public string REMARK { get; set; }
    }
}
