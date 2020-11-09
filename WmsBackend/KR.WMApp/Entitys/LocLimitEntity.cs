using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    [Alias("WM_LOC_LIMIT")]
    public class LocLimitEntity
    {
        [PrimaryKey]
        public string ID { get; set; }

        public string AREANO { get; set; }

        public string LOCATIONNO { get; set; }

        public string LIMITCONDITION { get; set; }

        public string USESTATE { get; set; }

        public string OPMESSAGE { get; set; }

        public string OPDATE { get; set; }

        public string OPBY { get; set; }

        public string OBJECTNAME { get; set; }

        public string ATTRNAME { get; set; }

        public string ATTRVALUE { get; set; }
    }
}
