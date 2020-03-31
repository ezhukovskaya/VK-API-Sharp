using OpenQA.Selenium;

namespace VK.Application.Constants.Locators
{
    public class FeedPageLocatorConstants
    {
        public static readonly By FeedPageBannerLocator = By.ClassName("stories_feed_cont");
        public static readonly By UserId = By.XPath("//div[@id='submit_post_box']");
    }
}