using Newtonsoft.Json;
using System.Net;

namespace RobotApocalypse
{
    //public class ResponseDto
    //{

    //}
    public class ResponseDto<T> where T : class
    {

        public HttpStatusCode StatusCode { get; set; }
        public string Data { get; set; }
        public string Error { get; set; }

    }

    public class RobotDto
    {
        public string model { get; set; }
        public string serialNumber { get; set; }
        public DateTime manufacturedDate { get; set; }
        public string category { get; set; }


    }

}
