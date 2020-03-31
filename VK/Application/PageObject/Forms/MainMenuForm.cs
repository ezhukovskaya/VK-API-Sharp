using System;
using OpenQA.Selenium;
using VK.Framework.Elements;

namespace VK.Application.PageObject.Forms
{
    public static class NavButtons
    {
        public static readonly Button MyProfile = MainMenuForm.GetMainMenuFormButton("pr", "My Profile");
    }

    public class MainMenuForm
    {
        internal static Button GetMainMenuFormButton(string buttonId, string buttonName)
        {
            return new Button(By.Id($"l_{buttonId}"), buttonName);
        }

        public void MainMenuButtonClick(Button button)
        {
            button.Click();
        }
    }
}