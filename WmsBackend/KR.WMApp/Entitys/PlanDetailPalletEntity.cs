using KR.BaseApp;
using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_PLAN_DETAILPALLET")]
    [CompositeIndex(new string[] { "PLANNO", "PALLETNO" }, Unique = true)]
    public class PlanDetailPalletEntity
    {
        [AutoIncrement]
        [PrimaryKey]
        public long ID { get; set; }

        [StringLength(100)]
        public string PLANNO { get; set; }//计划编号

        [StringLength(100)]
        public string PALLETNO { get; set; }//托盘编号

        [StringLength(1000)]
        public string ITEMNAME { get; set; }

        [DecimalLength(18, 4)]
        public Decimal? ITEMVALUE { get; set; }

        [StringLength(100)]
        public string BATCHNO { get; set; }

        [StringLength(100)]
        public string PALLETCREATEDATE { get; set; }

        [StringLength(200)]
        public string OPMESSAGE { get; set; }

        [StringLength(100)]
        public string OPDATE { get; set; }

        [StringLength(100)]
        public string OPBY { get; set; }
    }
}
