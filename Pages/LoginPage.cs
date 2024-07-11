using Microsoft.Playwright;

namespace DemoBDD.Pages
{
    public class LoginPage : BasePage
    {
        public readonly ILocator txtUserName;
        public ILocator txtPassword;
        public ILocator btnLogin;
        public LoginPage(IPage page) : base(page)
        {
            txtUserName = this.page.Locator("//input[@name='username']");
            txtPassword = this.page.Locator("//input[@name='password']");
            btnLogin = this.page.Locator("//input[@value='Log In']");
        }

        public async void Login(string username, string password)
        {
            await txtUserName.FillAsync("john");
            await txtPassword.FillAsync("demo");
            await btnLogin.ClickAsync();
        }
    }
}
