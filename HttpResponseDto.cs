using System.Net;

namespace RobotApocalypse
{
   
    public class HttpResponseDto
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
    }
}