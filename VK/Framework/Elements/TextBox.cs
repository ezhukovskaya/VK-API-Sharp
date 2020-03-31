using OpenQA.Selenium;
using VK.Framework.Base;

namespace VK.Framework.Elements
{
    public class TextBox : BaseElement
    {
        public TextBox(By buttonLocator, string elementName) : base(buttonLocator, elementName)
        {
        }

        public void SendKeys(string message)
        {
            this.GetElementByLocator().SendKeys(message);
        }
    }
}