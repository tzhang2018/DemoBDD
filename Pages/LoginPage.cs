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

        public async Task LoginAs(string username, string password)
        {
            await txtUserName.FillAsync(username);
            await txtPassword.FillAsync(password);
            await btnLogin.ClickAsync();
        }
    }
}
