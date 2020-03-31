using VK.Application.Constants.Locators;
using VK.Application.PageObject.Forms;
using VK.Framework.Base;
using VK.Framework.Elements;

namespace VK.Application.PageObject.Pages
{
    public class FeedPage: BasePage
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly Banner UserIdBanner = new Banner(FeedPageLocatorConstants.UserId, "User Id"); 
        private static readonly Banner FeedPageBanner = new Banner(FeedPageLocatorConstants.FeedPageBannerLocator, "Banner");
        public FeedPage() : base(FeedPageBanner)
        {
        }

        public MainMenuForm GetMainMenuForm()
        {
            return new MainMenuForm();
        }

        public string GetUserId(string attribute="data-from-oid")
        {
            Log.Info("Gets User Id");
            return UserIdBanner.GetElementAttributeValue(attribute);
        }
    }
}