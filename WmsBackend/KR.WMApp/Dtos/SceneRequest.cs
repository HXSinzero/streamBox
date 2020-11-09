using KR.WMApp.Entitys;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace KR.WMApp.Dtos
{
  [Route("/WMService/SceneRequest", "GET")]
  [Route("/WMService/SceneRequest", "POST")]
  public class SceneRequest
  {
    [Required]
    public int ACTION { get; set; }

    public int ID { get; set; }

    public string SCENENO { get; set; }

    public SysSceneEntity ULDScene { get; set; }

    public string PostData { get; set; }
  }
}
