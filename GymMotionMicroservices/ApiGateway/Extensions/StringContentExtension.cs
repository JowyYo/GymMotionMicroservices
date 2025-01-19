using System.Net.Http.Headers;

namespace ApiGateway.Extensions
{
    public static class StringContentExtension
    {
        public static StringContent AddMediaTypeJsonHeader(this StringContent content) 
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
