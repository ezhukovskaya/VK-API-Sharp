using VK.Application.Constants.Paths;
using VK.Framework.Utils;

namespace VK.Application.Constants.Account
{
    public static class CredsConstants
    {
        public static readonly string Login = XMLUtils.GetNodeValue("login", FilePathConstants.AppConfigurationPath);

        public static readonly string Password =
            XMLUtils.GetNodeValue("password", FilePathConstants.AppConfigurationPath);

        public static readonly string Token = XMLUtils.GetNodeValue("token", FilePathConstants.AppConfigurationPath);
    }
}