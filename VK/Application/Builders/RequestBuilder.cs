using System.Linq;
using VK.Application.Constants;
using VK.Application.Constants.Account;
using VK.Application.Constants.Methods;
using VK.Application.Constants.Paths;
using VK.Framework.Utils;

namespace VK.Application.Builders
{
    public static class RequestBuilder
    {
        private static readonly string ApiVersion =
            XMLUtils.GetNodeValue("apiVersion", FilePathConstants.AppConfigurationPath);

        private static string CreateRequest(string apiMethodName, string apiMethod, string parameters)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder();
            paramsBuilder.AddParams(UrlConstants.ApiUrl + apiMethodName + apiMethod, GetRequiredParams() + parameters);
            return paramsBuilder.ToString();
        }

        private static string GetRequiredParams()
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder();
            paramsBuilder.AddParams(Parameters.AccessToken, CredsConstants.Token);
            paramsBuilder.AddParams(Parameters.VersionApi, ApiVersion);
            return paramsBuilder.ToString();
        }

        public static string CreateWallPostWithMessage(string ownerId, string message)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder();
            paramsBuilder.AddParams(Parameters.OwnerId, ownerId);
            paramsBuilder.AddParams(Parameters.Message, message);
            return CreateRequest(ApiMethods.Wall, Attributes.Post, paramsBuilder.ToString());
        }

        public static string EditWallPostPostMessage(string ownerId, string newMessage, string postId)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder();
            paramsBuilder.AddParams(Parameters.OwnerId, ownerId);
            paramsBuilder.AddParams(Parameters.PostId, postId);
            paramsBuilder.AddParams(Parameters.Message, newMessage);
            return CreateRequest(ApiMethods.Wall, Attributes.Edit, paramsBuilder.ToString());
        }

        public static string AddCommentToWallPost(string postId, string message)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder();
            paramsBuilder.AddParams(Parameters.PostId, postId);
            paramsBuilder.AddParams(Parameters.Message, message);
            return CreateRequest(ApiMethods.Wall, Attributes.CreateComment, paramsBuilder.ToString());
        }

        public static string GetLikeStatus(string itemId, string ownerId, string userId, string itemType)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder();
            paramsBuilder.AddParams(Parameters.ItemId, itemId);
            paramsBuilder.AddParams(Parameters.OwnerId, ownerId);
            paramsBuilder.AddParams(Parameters.UserId, userId);
            paramsBuilder.AddParams(Parameters.Type,itemType);
            return CreateRequest(ApiMethods.Likes, Attributes.IsLiked, paramsBuilder.ToString());
        }
    }
}