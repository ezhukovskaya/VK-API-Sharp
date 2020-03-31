using NUnit.Framework;
using VK.Application.Constants;
using VK.Application.Constants.Paths;
using VK.Framework.BrowserUtils;

namespace VK.Framework.Base
{
    public abstract class BaseTest
    {
        [SetUp]
        public void Init()
        {
            Browser.SetImplicitlyWait();
            Browser.GoToUrl(UrlConstants.Url);
            Browser.Maximize();
        }

        [TearDown]
        public void Close()
        {
            Browser.Quit();
        }
    }
}