using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_PRODUCT")]
    public class ProductEntity
    {
        [PrimaryKey]
        [StringLength(100)]
        [Required]
        public long ID { get; set; }

        [StringLength(100)]
        [Required]
        [Index(Unique = true)]
        public string PRODUCTNO { get; set; }

        [StringLength(200)]
        [Required]
        public string PRODUCTNAME { get; set; }

        [StringLength(1000)]
        public string PRODUCTDESC { get; set; }

        [StringLength(100)]
        public string PRODUCTSUBDESC { get; set; }

        [StringLength(100)]
        public string PRODUCTSPEC { get; set; }

        [StringLength(100)]
        [Required]
        public string PRODUCTBARCODE { get; set; }

        [StringLength(100)]
        public string PRODUCTNODECODE { get; set; }

        [StringLength(100)]
        public string TURNOVERRATE { get; set; }

        [StringLength(100)]
        [Required]
        public string ABC { get; set; }

        [StringLength(100)]
        public string PRODUCTCLASS { get; set; }

        [StringLength(100)]
        public string PRODUCTTYPE { get; set; }

        [StringLength(100)]
        [Required]
        public string PRODUCTTSTATE { get; set; }

        [Required]
        public Decimal? QUANTITY_PACK { get; set; }

        [StringLength(100)]
        [Required]
        public string MAINUNIT { get; set; }

        [StringLength(100)]
        [Required]
        public string BASICUNIT { get; set; }

        [Required]
        public decimal MAINTOBASICRATE { get; set; }

        [StringLength(100)]
        public string MAINTOBASICDESC { get; set; }

        [StringLength(100)]
        [Required]
        public string CREATEBY { get; set; }

        [StringLength(100)]
        [Required]
        public string CREATEDATE { get; set; }

        [StringLength(100)]
        public string MODIFYBY { get; set; }

        [StringLength(100)]
        public string MODIFYDATE { get; set; }

        [StringLength(200)]
        public string REMARK { get; set; }

        [StringLength(100)]
        public string BRANDID { get; set; }

        [StringLength(200)]
        public string BRANDNAME { get; set; }

        [StringLength(100)]
        public string VENDORID { get; set; }

        [StringLength(200)]
        public string VENDORNAME { get; set; }

        [StringLength(100)]
        public string PRODUCTERID { get; set; }

        [StringLength(200)]
        public string PRODUCTERNAME { get; set; }

        public Decimal? MARKETPRICE { get; set; }

        public Decimal? LOWESTSALEPRICE { get; set; }

        public Decimal? SELLPRICE { get; set; }

        [StringLength(100)]
        public string ISDELICATE { get; set; }

        [StringLength(100)]
        public string IMPORTPRODUCT { get; set; }

        [StringLength(200)]
        public string IMAGEURL { get; set; }

        [StringLength(100)]
        public string DEFAULTCOLOR { get; set; }

        [StringLength(100)]
        public string PALLETEMPLTY { get; set; }

        [StringLength(100)]
        public string PALLETENTITY { get; set; }

        public Decimal? SIZE_LENGTH { get; set; }

        public Decimal? SIZE_WIDTH { get; set; }

        public Decimal? SIZE_HEIGHT { get; set; }

        public Decimal? VOLUME { get; set; }

        public Decimal? WEIGHT { get; set; }

        public Decimal? NETWEIGHT { get; set; }

        [StringLength(100)]
        public string WARNSTATE { get; set; }

        public Decimal? INV_HIGH { get; set; }

        public Decimal? INV_SAFE { get; set; }

        public Decimal? INV_ORDER { get; set; }

        public Decimal? INV_HIVEDAYS { get; set; }

        public Decimal? INV_LIMIT { get; set; }

        [StringLength(100)]
        public string INV_HIGH_COLOR { get; set; }

        [StringLength(100)]
        public string INV_SAFE_COLOR { get; set; }

        [StringLength(100)]
        public string INV_ORDER_COLOR { get; set; }

        [StringLength(100)]
        public string INV_HIVEDAYS_COLOR { get; set; }

        [StringLength(100)]
        public string INV_LIMIT_COLOR { get; set; }

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
