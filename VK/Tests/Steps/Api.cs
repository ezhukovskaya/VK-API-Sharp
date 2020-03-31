using Newtonsoft.Json.Linq;
using VK.Application.Constants.Methods;
using VK.Application.Utils;

namespace VK.Tests.Steps
{
    public static class Api
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string GetField(JObject response, string responseField)
        {
            Log.Info($"Gets {responseField} from response");
            return response[ResponseFields.Response][responseField].ToString();
        }

        public static string GetPostIdFromResponse(string userId, string message)
        {
            JObject wallPostResponse = AppUtils.CreateWallPost(userId, message);
            return GetField(wallPostResponse, ResponseFields.PostId);
        }

        public static string GetCommentIdFromResponse(string postId, string message)
        {
            JObject wallPostCommentResponse = AppUtils.CreateComment(postId, message);
            return GetField(wallPostCommentResponse, ResponseFields.CommentId);
        }

        public static string GetLikeStatusFromResponse(string itemId, string ownerId, string userId, string itemType)
        {
            JObject isItemLikedResponse = AppUtils.IsItemLiked(itemId, ownerId, userId, itemType);
            return GetField(isItemLikedResponse, ResponseFields.Liked);
        }

        public static void EditPostMessage(string ownerId, string newMessage, string postId)
        {
            AppUtils.EditWallPost(ownerId, newMessage, postId);
        }
    }
}