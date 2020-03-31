using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using VK.Application.Constants;
using VK.Application.Constants.Paths;
using VK.Framework.Enums;
using VK.Framework.Utils;
using WebDriverManager.DriverConfigs.Impl;

namespace VK.Framework.BrowserUtils
{
    static class BrowserFactory
    {
        public static IWebDriver GetBrowser()
        {
            string browserName = XMLUtils.GetNodeValue("browserName", FilePathConstants.TestConfigurationPath);
            BrowserList browserList = (BrowserList) Enum.Parse(typeof(BrowserList), browserName);
            switch (browserList)
            {
                case BrowserList.Chrome:
                    return GetChromeDriver();
                case BrowserList.Firefox:
                    return GetFirefoxDriver();
                default:
                    throw new InvalidElementStateException("Incorrect browser name in configuration file");
            }
        }

        private static ChromeDriver GetChromeDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }

        private static FirefoxDriver GetFirefoxDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }
    }
}