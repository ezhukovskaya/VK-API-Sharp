using VK.Framework.Elements;

namespace VK.Framework.Base
{
    public abstract class BasePage
    {
        private Banner PageBanner;

        protected BasePage(Banner pageBanner)
        {
            this.PageBanner = pageBanner;
        }

        public bool IsDisplayed()
        {
            return this.PageBanner.IsDisplayed();
        }
    }
}