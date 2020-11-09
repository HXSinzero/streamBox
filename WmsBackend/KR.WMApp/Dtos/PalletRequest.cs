using KR.BaseApp.Dtos;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
    [Route("/WMService/PalletRequest", "GET")]
    public class PalletRequest : PageRequest
    {
        [Required]
        public int ACTION { get; set; }

        public long PALLETID { get; set; }
        public string PALLETNO { get; set; }

        public string STOCKNO { get; set; }
        public string GROUPNO { get; set; }
        public string LOCATIONNO { get; set; }

        public string STATE { get; set; }
        public string PLANNO { get; set; }
    }
}
