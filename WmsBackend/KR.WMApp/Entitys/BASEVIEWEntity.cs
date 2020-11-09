using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("PROJ_BASEVIEW")]
    public class BASEVIEWEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string TABLENAME { get; set; }

        [Required]
        public int LINENUM { get; set; }

        [Required]
        [StringLength(100)]
        public string COLUMNNAME { get; set; }

        [Required]
        [StringLength(100)]
        public string CAPATION { get; set; }

        [Required]
        [StringLength(100)]
        public string SORTABLE { get; set; }

        [Required]
        [StringLength(100)]
        public string HIDDEN { get; set; }
    }
}
