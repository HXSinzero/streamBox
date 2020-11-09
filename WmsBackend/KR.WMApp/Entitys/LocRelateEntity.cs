using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_LOC_RELATE")]
    [CompositeIndex(new string[] { "LOCATIONNO", "RELETENO" })]
    public class LocRelateEntity
    {
        [PrimaryKey]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [Required]
        [StringLength(100)]
        public string LOCATIONNO { get; set; }

        [Required]
        [StringLength(100)]
        public string RELETENO { get; set; }
    }
}
