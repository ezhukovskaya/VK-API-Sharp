using OpenQA.Selenium;
using VK.Framework.Elements;

namespace VK.Application.PageObject.Forms
{
    public class WallPostForm
    {
        public Button GetLikeButton(string ownerId, string postId)
        {
            string currentPost = GetCurrentPostLocator(ownerId, postId);
            return new Button(By.XPath($"{currentPost}//div[contains(@class,'like_button_icon')]"), $"Post {postId}");
        }
        public Banner GetWallPostBanner(string ownerId, string postId)
        {
            return new Banner(By.XPath($"{GetCurrentPostLocator(ownerId, postId)}"), $" Wall post {postId}");
        }

        private string GetCurrentPostLocator(string ownerId, string postId)
        {
            return $"//div[@data-post-id='{ownerId}_{postId}']";
        }

        public bool CommentIsFromRightUser()
        {
            Button nextReplies = new Button(By.ClassName("replies_next"));
        }
    }
}