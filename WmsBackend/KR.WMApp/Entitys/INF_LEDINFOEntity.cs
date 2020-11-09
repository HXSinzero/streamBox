using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("INF_LEDINFO")]
    public class INF_LEDINFOEntity
    {
        [PrimaryKey]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string LEDCODE { get; set; }

        [Required]
        [StringLength(100)]
        public string LEDNAME { get; set; }

        [Required]
        [StringLength(100)]
        public string LEDTYPE { get; set; }

        [Required]
        [StringLength(1000)]
        public string PARA { get; set; }

        public int SHOWTYPE { get; set; }

        [Required]
        [StringLength(100)]
        public string LOCATION { get; set; }

        [Required]
        [StringLength(100)]
        public string MESSAGETITLE { get; set; }

        [Required]
        [StringLength(100)]
        public string MESSAGECONTENT { get; set; }

        [StringLength(100)]
        public string UPDATEDATETIME { get; set; }

        [StringLength(200)]
        public string PICTUREPATH { get; set; }

        [Required]
        public int STATE { get; set; }

        [StringLength(100)]
        public string REMARK { get; set; }

        public int KANBANNO { get; set; }
    }
}
