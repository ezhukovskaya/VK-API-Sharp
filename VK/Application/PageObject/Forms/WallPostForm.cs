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

        public string GetWallPostText(string ownerId, string postId)
        {
            return new Banner(By.XPath($"{GetCurrentPostLocator(ownerId, postId)}//div[contains(@class,'wall_post_text zoom_text')]"), "Post Text").GetText();
        }

        private string GetCurrentPostLocator(string ownerId, string postId)
        {
            return $"//div[@data-post-id='{ownerId}_{postId}']";
        }

        public bool CommentIsFromRightUser(string userId, string commentId)
        {
            Button nextReplies = new Button(By.ClassName("replies_next"), "Next Replies");
            Banner comment = new Banner(By.Id($"post{userId}_{commentId}"), $"Comment is from id{userId}");
            if (nextReplies.IsDisplayed())
            {
                nextReplies.Click();
            }

            return comment.IsDisplayed();
        }
    }
}