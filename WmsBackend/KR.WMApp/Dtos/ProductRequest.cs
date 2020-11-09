using KR.BaseApp.Dtos;
using KR.WMApp.Entitys;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
    [Route("/WMService/ProductRequest", "GET")]
    public class ProductRequest : PageRequest
    {
        [Required]
        public int ACTION { get; set; }

        public ProductEntity Entity { get; set; }

        public string PostData { get; set; }

        public string PRODUCTNO { get; set; }
        public string PRODUCTNAME { get; set; }
        public string PRODUCTTYPE { get; set; }
        public string PRODUCTTSTATE { get; set; }
    }
}