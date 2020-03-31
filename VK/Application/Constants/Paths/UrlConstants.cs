using VK.Framework.Utils;

namespace VK.Application.Constants.Paths
{
    public static class UrlConstants
    {
        public static readonly string Url = XMLUtils.GetNodeValue("url", FilePathConstants.TestConfigurationPath);
        public static readonly string ApiUrl = XMLUtils.GetNodeValue("apiUrl", FilePathConstants.TestConfigurationPath);
    }
}