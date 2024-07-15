using Microsoft.Playwright;

namespace DemoBDD.Pages
{
    public class AccountServicesPage : BasePage
    {
        public ILocator lnkOpenNewAccount { get; private set; }
        public ILocator lnkRequestLoan { get; private set; }
        public ILocator lnkLogout { get; private set; }
        public AccountServicesPage(IPage page) : base(page)
        {
            lnkOpenNewAccount = this.page.GetByRole(AriaRole.Link, new() { NameString = "Open New Account" });
            lnkRequestLoan = this.page.GetByRole(AriaRole.Link, new() { NameString = "Request Loan" });
            lnkLogout = this.page.GetByRole(AriaRole.Link, new() { NameString = "Log Out" });
        }

        public async Task RequestLoan()
        {
            await lnkRequestLoan.ClickAsync();
        }

        public async Task Logout()
        {
            await lnkLogout.ClickAsync();
        }
    }
}
