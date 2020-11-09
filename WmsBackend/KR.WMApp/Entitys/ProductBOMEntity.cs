using KR.BaseApp;
using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    /// <summary>
    /// 描 述：PROJ_PRODUCTBOM
    /// </summary>
    [Alias("WM_PRODUCTBOM")]
    public class ProductBOMEntity : BaseExtend10
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }

        [Index(Unique = true)]
        [StringLength(100)]
        public string BOMNO { get; set; }

        [StringLength(200)]
        public string BOMNAME { get; set; }

        [StringLength(200)]
        public string BOMDESC { get; set; }

        [Required]
        public int BOMSTATE { get; set; }

        [StringLength(100)]
        public string INFCODE { get; set; }

        [StringLength(100)]
        public string CREATEBY { get; set; }

        public DateTime CREATEDATE { get; set; }

        [StringLength(100)]
        public string MODIFYBY { get; set; }

        public DateTime MODIFYDATE { get; set; }

        [StringLength(100)]
        public string REMARK { get; set; }
    }
}