using KR.BaseApp.Dtos;
using ServiceStack;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace KR.WMApp.Dtos
{
    [Route("/WMService/LocationRequest", "GET")]
    public class LocationRequest : PageRequest
    {
        [Required]
        public int ACTION { get; set; }

        public string LOCATIONNO { get; set; }

        public string LOCATIONTYPE { get; set; }

        public string STOCKNO { get; set; }

        public string AREANO { get; set; }

        public string GROUPNO { get; set; }

        public string CHANNELNO { get; set; }

        public string FLIGHTDESC { get; set; }

        public string EMEXIT { get; set; }

        public string USESTATE { get; set; }

        public string LOCATIONSTATE { get; set; }

        public string STORESTATE { get; set; }

        public string[] ListLocatioNo { get; set; }

        public string GROUPSTATE { get; set; }

        public string[] ListGroupNo { get; set; }

        public string GroupLeftOrRight { get; set; }
        public string GroupModel { get; set; }

        public int ROWNO_MIN { get; set; }
        public int ROWNO_MAX { get; set; }
        public int COLUMNNO_MIN { get; set; }
        public int COLUMNNO_MAX { get; set; }
        public int LAYERNO_MIN { get; set; }
        public int LAYERNO_MAX { get; set; }
    }
}
