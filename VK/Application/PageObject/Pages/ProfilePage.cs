using OpenQA.Selenium;
using VK.Application.PageObject.Forms;
using VK.Framework.Base;
using VK.Framework.Elements;

namespace VK.Application.PageObject.Pages
{
    public class ProfilePage: BasePage
    {
        private static readonly Banner AvatarLabel = new Banner(By.ClassName("page_avatar_img"), "Avatar Page");
        public ProfilePage() : base(AvatarLabel)
        {
        }

        public WallPostForm GetWallPostForm()
        {
            return new WallPostForm();
        }
    }
}