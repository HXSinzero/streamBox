using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_SKU")]
    public class ProductSKUEntity
    {
        [PrimaryKey]
        [Required]
        public long ID { get; set; }

        [Required]
        public long PRODUCTID { get; set; }

        [StringLength(100)]
        [Required]
        public string PRODUCTNO { get; set; }

        [StringLength(200)]
        [Required]
        public string PRODUCTNAME { get; set; }

        [StringLength(100)]
        public string PRODUCTSPEC { get; set; }

        [Required]
        [DecimalLength(18, 3)]
        public Decimal? QUANTITY { get; set; }

        [StringLength(100)]
        [Required]
        public string BASICUNIT { get; set; }

        [StringLength(100)]
        public string PRODUCTDATE { get; set; }

        [StringLength(100)]
        public string OVERDUEDATE { get; set; }

        [StringLength(100)]
        public string BATCHNO { get; set; }

        [StringLength(100)]
        public string VENDORNO { get; set; }

        [StringLength(100)]
        public string VENDORNAME { get; set; }

        [StringLength(100)]
        public string LASTINDATE { get; set; }

        [StringLength(100)]
        public string LASTOUTDATE { get; set; }

        [StringLength(100)]
        public string SKUSTATE { get; set; }

        [StringLength(100)]
        public string QUALITYSTATE { get; set; }

        [StringLength(200)]
        public string SKUCHANGEMESSAGE { get; set; }

        [StringLength(200)]
        public string REMARK { get; set; }

        [StringLength(100)]
        public string STOCKNO { get; set; }

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
    }
}
