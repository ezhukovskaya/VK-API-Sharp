using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using VK.Application.PageObject.Forms;
using VK.Application.PageObject.Pages;
using VK.Application.Utils;
using VK.Framework.Base;

namespace VK.Tests
{
    public class Tc1 : BaseTest
    {
        private static readonly string RandomMessage = Guid.NewGuid().ToString();
        private static readonly string NewMessage = "MEOWMEOWMEOW!!!!!!!";

        [Test]
        public void MyFirstTest()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LogInTheAccount();
            FeedPage feedPage = new FeedPage();
            string userId = feedPage.GetUserId();
            feedPage.GetMainMenuForm().MainMenuButtonClick(NavButtons.MyProfile);
            ProfilePage profilePage = new ProfilePage();
            JObject wallPostResponse = AppUtils.CreateWallPost(userId, RandomMessage);
            string postId = wallPostResponse["response"]["post_id"].ToString();
            Assert.True(profilePage.GetWallPostForm().GetWallPostBanner(userId, postId).IsDisplayed(),
                "The Post is not from the right user");
            Assert.AreEqual(RandomMessage, profilePage.GetWallPostForm().GetWallPostBanner(userId, postId).GetText(),
                $"Message do not matches {RandomMessage}");
            JObject wallPostCommentResponse = AppUtils.CreateComment(postId, RandomMessage);
            string commentId = wallPostCommentResponse["response"]["comment_id"].ToString();
            profilePage.GetWallPostForm().GetLikeButton(userId, postId).Click();
        }
    }
}