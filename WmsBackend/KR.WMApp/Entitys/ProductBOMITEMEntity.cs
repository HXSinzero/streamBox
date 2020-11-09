using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    /// <summary>
    /// 描 述：BOM清单项
    /// </summary>
    [Alias("WM_PRODUCTBOMITEM")]
    [CompositeIndex(new string[] { "BOMNO", "SEQNUM" })]
    public class ProductBOMITEMEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        [Required]
        public long ID { get; set; }

        [StringLength(100)]
        public string BOMNO { get; set; }

        [StringLength(200)]
        public string BOMNAME { get; set; }

        public int SEQNUM { get; set; }

        public long PRODUCTID { get; set; }

        [StringLength(100)]
        public string PRODUCTNO { get; set; }

        [StringLength(200)]
        public string PRODUCTNAME { get; set; }

        public decimal QUANTITY_DEF { get; set; }

        public decimal QUANTITY_COUNT { get; set; }

        public decimal LINESTATE { get; set; }
        [StringLength(100)]
        public string REMARK { get; set; }

        [StringLength(100)]
        public string GROUPPARENT { get; set; }

        [StringLength(100)]
        public string GROUPNO { get; set; }

        [StringLength(100)]
        public string GROUPNAME { get; set; }

        [StringLength(100)]
        public string MODIFYBY { get; set; }

        public DateTime MODIFYDATE { get; set; }

    }
}