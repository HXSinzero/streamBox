using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    /// <summary>
    /// 托盘移动记录
    /// </summary>
    [Alias("WM_PALLETMVINFO")]
    public class PalletMvInfoEntity
    {
        [PrimaryKeyAttribute]
        [RequiredAttribute]
        [AutoIncrement]
        public long ID { get; set; }

        [Required]
        public long PALLETID { get; set; }

        [Required]
        [StringLength(100)]
        public string PALLETNO { get; set; }

        [Required]
        [StringLength(100)]
        public string MVTYPE { get; set; }

        [Required]
        public DateTime CREATEDATE { get; set; }

        [Default(0)]
        public int LINESTATE { get; set; }

        [StringLength(100)]
        public string ORDERNO { get; set; }

        [StringLength(100)]
        public string ORDERNO_LINENUM { get; set; }

        [StringLength(100)]
        public string PLANNO { get; set; }

        [StringLength(100)]
        public string PLANNO_LINENUM { get; set; }

        [StringLength(100)]
        public string TASKID { get; set; }

        [StringLength(100)]
        public string TASKNO { get; set; }

        [StringLength(200)]
        public string TASKDESC { get; set; }

        [StringLength(100)]
        public string FROMLOC { get; set; }

        [StringLength(100)]
        public string TOLOC { get; set; }

        [StringLength(100)]
        public string REMARK { get; set; }
    }
}
