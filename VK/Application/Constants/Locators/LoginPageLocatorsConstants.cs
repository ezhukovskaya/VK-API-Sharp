using OpenQA.Selenium;

namespace VK.Application.Constants
{
    public class LoginPageLocatorsConstants
    {
        public static readonly By LoginFieldLocator = By.Id("index_email");
        public static readonly By PasswordFieldLocator = By.Id("index_pass");
        public static readonly By LogoLocator = By.ClassName("top_home_logo");
        public static readonly By SubmitLocator = By.Id("index_login_button");
    }
}