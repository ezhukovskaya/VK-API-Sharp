using VK.Application.Constants;
using VK.Application.Constants.Account;
using VK.Application.Constants.Locators;
using VK.Framework.Base;
using VK.Framework.Elements;

namespace VK.Application.PageObject.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly Banner LoginPageBanner = new Banner(LoginPageLocatorsConstants.LogoLocator, "Logo");
        private readonly TextBox _logInBox = new TextBox(LoginPageLocatorsConstants.LoginFieldLocator, "Log In");
        private readonly TextBox _passwordBox = new TextBox(LoginPageLocatorsConstants.PasswordFieldLocator, "Password");
        private readonly Button _logOnButton = new Button(LoginPageLocatorsConstants.SubmitLocator, "Log On");

        public LoginPage() : base(LoginPageBanner)
        {
        }

        public void LogInTheAccount()
        {
            Log.Info($"Logging in as {CredsConstants.Login}");
            _logInBox.SendKeys(CredsConstants.Login);
            _passwordBox.SendKeys(CredsConstants.Password);
            _logOnButton.Click();
        }
    }
}