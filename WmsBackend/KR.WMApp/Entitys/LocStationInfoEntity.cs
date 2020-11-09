using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_STATIONINFO")]
    public class LocStationInfoEntity
    {
        [PrimaryKey]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [Index(Unique = true)]
        [Required]
        [StringLength(100)]
        public string STATIONNO { get; set; }

        [Required]
        [StringLength(200)]
        public string STATIONDESC { get; set; }

        [Required]
        [StringLength(100)]
        public string STATIONTYPE { get; set; }

        [StringLength(100)]
        public string CONTROLNO { get; set; }

        [StringLength(100)]
        public string VSTATIONNO { get; set; }

        [StringLength(100)]
        public string RELATENO { get; set; }

        [StringLength(100)]
        public string GROUPNO { get; set; }

        [StringLength(100)]
        public string AREANO { get; set; }

        [StringLength(100)]
        public string TECHNO { get; set; }

        [StringLength(100)]
        public string BUFFERNO { get; set; }

        [StringLength(100)]
        public string STATIONNGNO { get; set; }

        [StringLength(100)]
        public string STATIONCHECKNO { get; set; }

        [StringLength(100)]
        public string LOCATIONX { get; set; }

        [StringLength(100)]
        public string LOCATIONY { get; set; }

        [StringLength(100)]
        public string LOCATIONZ { get; set; }

        [StringLength(100)]
        public string TARGETX { get; set; }

        [StringLength(100)]
        public string TARGETY { get; set; }

        [StringLength(100)]
        public string TARGETZ { get; set; }

        [StringLength(100)]
        public string STATIONSTATE { get; set; }

        [StringLength(100)]
        public string WORNO { get; set; }

        [StringLength(100)]
        public string WORLINE { get; set; }

        [StringLength(100)]
        public string WORSTATE { get; set; }

        [StringLength(100)]
        public string OPBY { get; set; }

        [StringLength(100)]
        public string OPMESSAGE { get; set; }

        [StringLength(100)]
        public string OPDATE { get; set; }

        [StringLength(100)]
        public string P01 { get; set; }

        [StringLength(100)]
        public string P02 { get; set; }

        [StringLength(100)]
        public string P03 { get; set; }

        [StringLength(100)]
        public string P04 { get; set; }

        [StringLength(100)]
        public string P05 { get; set; }

        [StringLength(100)]
        public string P06 { get; set; }

        [StringLength(100)]
        public string P07 { get; set; }

        [StringLength(100)]
        public string P08 { get; set; }

        [StringLength(100)]
        public string P09 { get; set; }

        [StringLength(100)]
        public string P10 { get; set; }

        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? CAPACITY { get; set; }

        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? USECAPACITY { get; set; }

        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? CONTROLMODE { get; set; }

        [Default(0)]
        public int EMEXIT { get; set; }

        [Default(0)]
        public int ISCLOSE { get; set; }

        [Default(3)]
        public int PRIORITY { get; set; }

        [Default(1)]
        public int TASKCOUNT { get; set; }
    }
}
