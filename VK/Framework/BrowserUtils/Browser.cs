using System;
using OpenQA.Selenium;

namespace VK.Framework.BrowserUtils
{
    public class Browser
    {
        private static IWebDriver driver;
        private const int Timeout = 10;

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

        public static void Close()
        {
            GetBrowser().Close();
        }

        public static void Quit()
        {
            GetBrowser().Quit();
        }

        public static void SetImplicitlyWait()
        {
            GetBrowser().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Timeout);
        }

        public static string GetCurrentUrl()
        {
            return GetBrowser().Url;
        }
    }
}