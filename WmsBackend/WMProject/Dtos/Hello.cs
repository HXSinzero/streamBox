using ServiceStack;

namespace WMProject.Dtos
{
    [Route("/api/v1/hello", "GET")]
    public class Hello
    {
        public string Name { get; set; }
    }
}
