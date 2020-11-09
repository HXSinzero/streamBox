using ServiceStack.DataAnnotations;

namespace KR.WMApp.Entitys
{
    public abstract class BASEEntity
    {
        [Ignore]
        public string Action { get; set; }
    }
}
