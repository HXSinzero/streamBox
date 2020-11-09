using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_STATIONRELATE")]
    public class LocStationRelateEntity
    {
        [PrimaryKey]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(100)]
        public string STATIONNO { get; set; }

        [StringLength(100)]
        public string RELATENO { get; set; }
    }
}
