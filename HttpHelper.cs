using RestSharp;
using Microsoft.AspNetCore.Http;

namespace RobotApocalypse
{
    public static class HttpHelper
    {


        public static async Task<HttpResponseDto> GetRequestAsync(string url)
        {

            
            HttpResponseMessage response = null;    

            try
            {
               
                var client = new HttpClient();  
                  response = await client.GetAsync(url); 

                return new HttpResponseDto
                {
                    StatusCode = response.StatusCode,
                    Content = await response.Content.ReadAsStringAsync()
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseDto
                {
                    StatusCode = response.StatusCode,
                    Content = ex.Message
                };
            }
        }
    }
}
