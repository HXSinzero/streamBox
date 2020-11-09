using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_REPORTPARA")]
    public class ReportParaEntity
    {
        [PrimaryKey]
        public long ID { get; set; }
    }
}
