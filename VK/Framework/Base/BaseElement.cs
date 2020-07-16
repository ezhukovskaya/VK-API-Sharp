using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using VK.Framework.BrowserUtils;

namespace VK.Framework.Base
{
    public abstract class BaseElement
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly By _buttonLocator;
        private string ElementName { get; }

        public By GetButtonLocator()
        {
            return _buttonLocator;
        }

        protected BaseElement(By buttonLocator, string elementName)
        {
            this._buttonLocator = buttonLocator;
            this.ElementName = elementName;
        }

        protected internal string GetElementAttributeValue(string attributeName)
        {
            return this.GetElementByLocator().GetAttribute(attributeName);
        }

        protected IWebElement GetElementByLocator()
        {
            return Browser.GetBrowser().FindElement(this._buttonLocator);
        }

        private ReadOnlyCollection<IWebElement> GetElementsByLocator()
        {
            return Browser.GetBrowser().FindElements(this._buttonLocator);
        }

        public void Click()
        {
            Log.Info($"{ElementName} click");
            GetElementByLocator().Click();
        }

        public string GetText()
        {
            return GetElementByLocator().Text;
        }

        public bool IsDisplayed()
        {
            return GetElementsByLocator().ToArray().Length > 0;
        }
    }
}