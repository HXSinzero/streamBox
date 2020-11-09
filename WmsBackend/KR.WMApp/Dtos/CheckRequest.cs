using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
  [Route("/WMService/CheckRequest", "GET")]
  public class CheckRequest
  {
    [Required]
    public int ACTION { get; set; }
  }
}
