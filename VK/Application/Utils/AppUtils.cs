using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VK.Application.Builders;
using VK.Framework.Utils;

namespace VK.Application.Utils
{
    public class AppUtils
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static JObject GetResponse(string url)
        {
            Log.Info($"Gets JObject for {url}");
            string response = ApiUtils.PostRequest(url);
            return JObject.Parse(response);
        }

        public static JObject CreateWallPost(string ownerId, string message)
        {
            return GetResponse(RequestBuilder.CreateWallPostWithMessage(ownerId, message));
        }

        public static void EditWallPost(string ownerId, string newMessage, string postId)
        {
            GetResponse(RequestBuilder.EditWallPostPostMessage(ownerId, newMessage, postId));
        }

        public static JObject CreateComment(string postId, string message)
        {
            return GetResponse(RequestBuilder.AddCommentToWallPost(postId, message));
        }

        public static JObject IsItemLiked(string itemId, string ownerId, string userId, string itemType)
        {
            return GetResponse(RequestBuilder.GetLikeStatus(itemId, ownerId, userId, itemType));
        }
    }
}