using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_TASKSTEP")]
    public class TaskStepEntity
    {
        [PrimaryKey]
        [Required]
        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(100)]
        public string TASKID { get; set; }

        [StringLength(100)]
        public string TASKNO { get; set; }

        [StringLength(100)]
        public string CREATEDATE { get; set; }

        [StringLength(100)]
        public string CREATEBY { get; set; }

        [StringLength(100)]
        public string STEPNAME { get; set; }

        [StringLength(100)]
        public string STEPSTATE { get; set; }

        [StringLength(100)]
        public string STEPMESSAGE { get; set; }

        [StringLength(100)]
        [Description("起始站台")]
        public string STN_FROM { get; set; }

        [StringLength(100)]
        [Description("目标站台")]
        public string STN_TO { get; set; }
    }
}
