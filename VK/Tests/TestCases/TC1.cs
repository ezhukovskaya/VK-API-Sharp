using System;
using Newtonsoft.Json.Linq;
using NUnit.Core;
using NUnit.Framework;
using VK.Application.Constants.Methods;
using VK.Application.PageObject.Forms;
using VK.Application.PageObject.Pages;
using VK.Application.Utils;
using VK.Framework.Base;
using VK.Tests.Steps;

namespace VK.Tests
{
    public class Tc1 : BaseTest
    {
        private static readonly string RandomMessage = Guid.NewGuid().ToString();
        private static readonly string NewMessage = "MEOWMEOWMEOW!!!!!!!";
        private static readonly string StatusLiked = "1";

        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Test]
        public void MyFirstTest()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LogInTheAccount();
            FeedPage feedPage = new FeedPage();
            string userId = feedPage.GetUserId();
            feedPage.GetMainMenuForm().MainMenuButtonClick(NavButtons.MyProfile);
            ProfilePage profilePage = new ProfilePage();
            string postId = Api.GetPostIdFromResponse(userId, RandomMessage);
            Log.Info($"Checks if post is {userId}'s");
            Assert.True(profilePage.GetWallPostForm().GetWallPostBanner(userId, postId).IsDisplayed(),
                "The Post is not from the right user");
            Log.Info($"Checks if message matches {RandomMessage}");
            Assert.AreEqual(RandomMessage, profilePage.GetWallPostForm().GetWallPostText(userId, postId), $"Message do not matches {RandomMessage}");
            Api.EditPostMessage(userId, NewMessage, postId);
            Log.Info($"Checks if message matches {NewMessage}");
            Assert.AreEqual(NewMessage, profilePage.GetWallPostForm().GetWallPostText(userId, postId), $"Message do not matches {NewMessage}" );
            string commentId = Api.GetCommentIdFromResponse(postId, RandomMessage);
            profilePage.GetWallPostForm().GetLikeButton(userId, postId).Click();
            Log.Info($"Checks if Comment is from {userId}");
            Assert.True(profilePage.GetWallPostForm().CommentIsFromRightUser(userId, commentId), $"Comment is not from id{userId}");
            string likeStatus = Api.GetLikeStatusFromResponse(postId, userId, userId, ResponseFields.Post);
            Log.Info("Checks if like status is 'LIKED'");
            Assert.AreEqual(likeStatus,StatusLiked, $"User id{userId} did not like item id{postId}");
        }
    }
}