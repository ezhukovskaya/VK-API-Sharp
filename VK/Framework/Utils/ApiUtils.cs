using System.IO;
using System.Net;
using unirest;

namespace VK.Framework.Utils
{
    public class ApiUtils
    {
        public static string PostRequest(string url)
        {
            var jsonResponse = Unirest.post(url).asString();
            return jsonResponse.Body;
        }
    }
}