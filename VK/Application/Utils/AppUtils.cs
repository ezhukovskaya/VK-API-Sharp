using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VK.Application.Builders;
using VK.Framework.Utils;

namespace VK.Application.Utils
{
    public class AppUtils
    {
        private static JObject GetResponse(string url)
        {
            string response = ApiUtils.PostRequest(url);
            return JObject.Parse(response);
        }

        public static JObject CreateWallPost(string ownerId, string message)
        {
            return GetResponse(RequestBuilder.CreateWallPostWithMessage(ownerId, message));
        }

        public static JObject EditWallPost(string ownerId, string newMessage)
        {
            return GetResponse(RequestBuilder.EditWallPostPostMessage(ownerId, newMessage));
        }

        public static JObject CreateComment(string postId, string message)
        {
            return GetResponse(RequestBuilder.AddCommentToWallPost(postId, message));
        }
    }
}