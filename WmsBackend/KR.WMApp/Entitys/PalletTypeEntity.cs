using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    /// <summary>
    /// 托盘类型
    /// </summary>
    [Alias("WM_PALLETTYPE")]
    public class PalletTypeEntity
    {
        [PrimaryKey]
        public int ID { get; set; }

        [Index(Unique =true)]
        [StringLength(100)]
        [Description("类型编号")]
        public string ITEMCODE { get; set; }

        [StringLength(200)]
        [Description("类型描述")]
        public string ITEMDESC { get; set; }

        [StringLength(100)]
        [Description("备注")]
        public string REMARK { get; set; }
    }
}
