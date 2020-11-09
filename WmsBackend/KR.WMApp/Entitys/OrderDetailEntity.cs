using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_ORDER_DETAIL")]
    [CompositeIndex(new string[] { "ORDERNO", "LINENUM" })]
    public class OrderDetailEntity
    {
        [PrimaryKey]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(100)]
        public string ORDERNO { get; set; }

        [Required]
        public int LINENUM { get; set; }

        [Required]
        [StringLength(100)]
        public string PRODUCTID { get; set; }

        [Required]
        [StringLength(100)]
        public string PRODUCTNO { get; set; }

        [StringLength(200)]
        public string PRODUCTNAME { get; set; }

        [StringLength(100)]
        public string PRODUCTSPEC { get; set; }

        [StringLength(100)]
        public string PRODUCTBARCODE { get; set; }

        [StringLength(100)]
        public string PRODUCTTSTATE { get; set; }

        [DecimalLength(18,4)]
        public Decimal? QUANTITY_PACK { get; set; }

        [StringLength(100)]
        public string MAINUNIT { get; set; }

        [StringLength(100)]
        public string BASICUNIT { get; set; }

        [StringLength(100)]
        public string MAINTOBASICRATE { get; set; }

        [StringLength(200)]
        public string MAINTOBASICDESC { get; set; }

        [StringLength(100)]
        public string OPSTOCK { get; set; }

        [StringLength(100)]
        public string OPLOC { get; set; }

        [StringLength(100)]
        public string BATCHNO { get; set; }

        [StringLength(100)]
        public string PRODUCTDATE { get; set; }

        [DecimalLength(18, 4)]
        public Decimal? WEIGHT_NET { get; set; }

        [DecimalLength(18, 4)]
        public Decimal? WEIGHT_LOAD { get; set; }

        [DecimalLength(18, 4)]
        public Decimal? TEMPERATURE { get; set; }

        [DecimalLength(18, 4)]
        public Decimal? HUMIDITY { get; set; }

        [Default(0)]
        [DecimalLength(18, 4)]
        public Decimal? QUANTITY_PLAN { get; set; }

        [Default(0)]
        [DecimalLength(18, 4)]
        public Decimal? QUANTITY_LOCK { get; set; }

        [Default(0)]
        [DecimalLength(18, 4)]
        public Decimal? QUANTITY_SORT { get; set; }

        [Default(0)]
        [DecimalLength(18, 4)]
        public Decimal? QUANTITY_ACT { get; set; }

        [Default(0)]
        [DecimalLength(18, 4)]
        public Decimal? QUANTITY_INV { get; set; }

        [Default(0)]
        [DecimalLength(18, 4)]
        public Decimal? QUANTITY_COUNT { get; set; }

        [Default(0)]
        [DecimalLength(18, 4)]
        public Decimal? QUANTITY_ZERO { get; set; }

        [Default(0)]
        [DecimalLength(18, 4)]
        public Decimal? QUANTITY_OTHER { get; set; }

        [Default(0)]
        [DecimalLength(18, 2)]
        public Decimal? UNITPRICE1 { get; set; }

        [Default(0)]
        [DecimalLength(18, 2)]
        public Decimal? UNITPRICE2 { get; set; }

        [Default(0)]
        [DecimalLength(18, 2)]
        public Decimal? UNITPRICE3 { get; set; }

        [StringLength(100)]
        public string MONEYUNIT { get; set; }

        [Default(0)]
        [DecimalLength(18, 2)]
        public Decimal? AMOUNT { get; set; }

        [StringLength(100)]
        public string LINESTATE { get; set; }

        [StringLength(1000)]
        public string LINEMESSAGETEXT { get; set; }

        [StringLength(200)]
        public string REMARK { get; set; }
    }
}
