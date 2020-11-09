using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_TASK")]
    public class TaskEntity
    {
        [PrimaryKey]
        [Required]
        [AutoIncrement]
        public long ID { get; set; }

        [Required]
        [Index]
        [StringLength(100)]
        public string TASKNO { get; set; }

        [Required]
        [Index]
        [StringLength(100)]
        public string TASKDATE { get; set; }

        [Required]
        [StringLength(100)]
        public string TASKTCLASS { get; set; }

        [Required]
        [StringLength(100)]
        public string TASKTYPE { get; set; }

        [Default(0)]
        public int PRIORITY { get; set; }

        [StringLength(100)]
        public string TASKGROUPNO { get; set; }

        [StringLength(100)]
        public string PRETASKNO { get; set; }

        [StringLength(100)]
        public string STRATEGYID01 { get; set; }

        [StringLength(100)]
        public string STRATEGYNAME01 { get; set; }

        [StringLength(100)]
        public string SOURCEAREA { get; set; }

        [Required]
        [StringLength(100)]
        public string SOURCE01 { get; set; }

        [Required]
        [StringLength(100)]
        public string SOURCE02 { get; set; }

        [StringLength(100)]
        public string STRATEGYID02 { get; set; }

        [StringLength(100)]
        public string STRATEGYNAME02 { get; set; }

        [StringLength(100)]
        public string DESTINATIONAREA { get; set; }

        [Required]
        [StringLength(100)]
        public string DESTINATION01 { get; set; }

        [Required]
        [StringLength(100)]
        public string DESTINATION02 { get; set; }

        [StringLength(1000)]
        public string TASKORDERDATA { get; set; }

        [Required]
        [StringLength(100)]
        public string CREATEDATE { get; set; }

        [Default(0)]
        public DateTime CREATEDATETIME { get; set; }

        [StringLength(100)]
        public string CREATEBY { get; set; }

        [StringLength(100)]
        public string STARTDATE { get; set; }

        [StringLength(100)]
        public string ENDDATE { get; set; }

        [StringLength(100)]
        public string CANCELDATE { get; set; }

        [StringLength(100)]
        public string CANCELREASON { get; set; }

        [Required]
        [StringLength(100)]
        public string TASKSTATE { get; set; }

        [StringLength(200)]
        public string TASKDESC { get; set; }

        [StringLength(1000)]
        public string TASKMESSAGE { get; set; }

        [StringLength(100)]
        public string EVENTID { get; set; }

        [StringLength(100)]
        public string BILLID { get; set; }

        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? BILLID_LINENUM { get; set; }

        [StringLength(100)]
        public string PALLETID { get; set; }

        [Default(0)]
        [DecimalLength(10, 0)]
        public Decimal? PALLETID_LINENUM { get; set; }

        [StringLength(100)]
        public string PALLETNO { get; set; }

        [StringLength(100)]
        public string PALLETTYPE { get; set; }

        [StringLength(100)]
        public string RELATENO { get; set; }

        [StringLength(100)]
        public string TRUCKNO_PLAN { get; set; }

        [StringLength(100)]
        public string TRUCKNO_OPUSER { get; set; }

        [StringLength(100)]
        public string TRUCKNO { get; set; }

        [StringLength(100)]
        public string OPUSER { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL01 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL02 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL03 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL04 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL05 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL06 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL07 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL08 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL09 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL10 { get; set; }
    }
}
