using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_LOC_STOREHOUSE")]
    public class LocStorehouseEntity
    {
        [PrimaryKey]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [Required]
        [StringLength(100)]
        public string ITEMCODE { get; set; }

        [Required]
        [StringLength(100)]
        public string ITEMNAME { get; set; }

        [StringLength(1000)]
        public string ITEMDESC { get; set; }

    }
}
