using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    /// <summary>
    /// 描 述：BOM检查清单
    /// </summary>
    [Alias("WM_PRODUCTBOMCHECK")]
    public class ProductBOMCheckEntity
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

        [StringLength(100)]
        public string CHECKITEM { get; set; }

        [StringLength(100)]
        public string CHECKNAME { get; set; }

        [StringLength(100)]
        public string CHECKSTATE { get; set; }

        [StringLength(100)]
        public string CHECKREMARK { get; set; }

        [Default(0)]
        public int LINESTATE { get; set; }

        [StringLength(100)]
        public string REMARK { get; set; }

        [StringLength(100)]
        public string MODIFYBY { get; set; }

        public DateTime MODIFYDATE { get; set; }
    }
}