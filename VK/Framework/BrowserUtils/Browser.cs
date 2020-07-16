using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using VK.Application.Constants.Paths;
using VK.Framework.Base;
using VK.Framework.Utils;

namespace VK.Framework.BrowserUtils
{
    public class Browser
    {
        private static IWebDriver driver;
        private static readonly string ImplicitTimeout = XMLUtils.GetNodeValue("implicitWait", FilePathConstants.TestConfigurationPath);
        private static readonly string ExplicitTimeout = XMLUtils.GetNodeValue("explicitWait", FilePathConstants.TestConfigurationPath);
        public static IWebDriver GetBrowser()
        { 
            return driver ??= BrowserFactory.GetBrowser();
        }

        public static void GoToUrl(string url)
        {
            GetBrowser().Url = url;
        }

        public static void Maximize()
        {
            GetBrowser().Manage().Window.Maximize();
        }

        public static void Quit()
        {
            GetBrowser().Quit();
        }

        public static void SetImplicitlyWait()
        {
            GetBrowser().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(int.Parse(ImplicitTimeout));
        }

        public static void SetExplicitWaitUntilContentChanged(BaseElement element, string newText)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(int.Parse(ExplicitTimeout)));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(
                element.GetButtonLocator(), newText));
        }

        public static string GetCurrentUrl()
        {
            return GetBrowser().Url;
        }
    }
}