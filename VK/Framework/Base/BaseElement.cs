using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using VK.Framework.BrowserUtils;

namespace VK.Framework.Base
{
    public abstract class BaseElement
    {
        protected readonly By ButtonLocator;
        protected string ElementName;

        protected BaseElement(By buttonLocator, string elementName)
        {
            this.ButtonLocator = buttonLocator;
            this.ElementName = elementName;
        }

        protected internal string GetElementAttributeValue(string attributeName)
        {
            return this.GetElementByLocator().GetAttribute(attributeName);
        }

        protected IWebElement GetElementByLocator()
        {
            return Browser.GetBrowser().FindElement(this.ButtonLocator);
        }

        private ReadOnlyCollection<IWebElement> GetElementsByLocator()
        {
            return Browser.GetBrowser().FindElements(this.ButtonLocator);
        }

        public void Click()
        {
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