using VK.Application.Constants.Paths;
using VK.Framework.Utils;

namespace VK.Application.Constants
{
    public class UrlConstants
    {
        public static readonly string Url = XMLUtils.GetNodeValue("url", FilePathConstants.TestConfigurationPath);
        public static readonly string ApiUrl = XMLUtils.GetNodeValue("apiUrl", FilePathConstants.TestConfigurationPath);
    }
}