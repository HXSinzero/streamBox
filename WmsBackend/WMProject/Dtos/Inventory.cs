using ServiceStack;

namespace WMProject.Dtos
{
    [Route("/api/v1/inventory", "GET")]
    public class Inventory
    {
        public string PH_ID { get; set; }
        public string PRODUCT_DATE { get; set; }
    }
}
