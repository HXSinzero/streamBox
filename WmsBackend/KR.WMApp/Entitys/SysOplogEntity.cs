using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_SYSOPLOG")]
    public class SysOplogEntity
    {
        [PrimaryKey]
        [AutoIncrement] public long ID { get; set; }
        [Default(3)] public int LEVEL { get; set; }
        public DateTime CREATEDATE { get; set; }
        [StringLength(100)] public string ENTERDATE { get; set; }
        [StringLength(200)] public string KEYVALUE { get; set; }
        [StringLength(StringLengthAttribute.MaxText)] public string OPMESSAGE { get; set; }
    }
}
