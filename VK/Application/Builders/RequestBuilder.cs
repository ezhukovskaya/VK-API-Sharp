using System.Linq;
using VK.Application.Constants;
using VK.Application.Constants.Account;
using VK.Application.Constants.Methods;
using VK.Application.Constants.Paths;
using VK.Framework.Utils;

namespace VK.Application.Builders
{
    public class RequestBuilder
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
            return CreateRequest(ApiMethods.Wall, Attributtes.Post, paramsBuilder.ToString());
        }

        public static string EditWallPostPostMessage(string ownerId, string newMessage)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder();
            paramsBuilder.AddParams(Parameters.OwnerId, ownerId);
            paramsBuilder.AddParams(Parameters.Message, newMessage);
            return CreateRequest(ApiMethods.Wall, Attributtes.Edit, paramsBuilder.ToString());
        }

        public static string AddCommentToWallPost(string postId, string message)
        {
            ParamsBuilder paramsBuilder = new ParamsBuilder();
            paramsBuilder.AddParams(Parameters.PostId, postId);
            paramsBuilder.AddParams(Parameters.Message, message);
            return CreateRequest(ApiMethods.Wall, Attributtes.CreateComment, paramsBuilder.ToString());
        }
    }
}