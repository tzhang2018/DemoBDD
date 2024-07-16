using Microsoft.Playwright;
using System.ComponentModel.DataAnnotations;

namespace DemoBDD.Pages
{
    public class LoanPage : BasePage
    {
        public ILocator txtLoanAmount {  get; set; }
        public ILocator txtDownPayments { get; set; }
        public ILocator lbxFromAccountNo { get; set; }
        public ILocator btnApplyNow { get; set; }
        public ILocator tdLoanStatus { get; set; }
        public ILocator lblLoanTitle { get; set; }

        public LoanPage(IPage page) : base(page)
        {
            txtLoanAmount = this.page.Locator("id=amount");
            txtDownPayments = this.page.Locator("id=downPayment");
            lbxFromAccountNo = this.page.Locator("id=fromAccountId");
            btnApplyNow = this.page.GetByText("Apply Now");
            tdLoanStatus = this.page.Locator("id=loanStatus");
            lblLoanTitle = this.page.GetByText("Loan Request Processed");
        }

        public async Task ApplyLoan(string loanAmount, string downPayment, string fromAccount)
        {
            await txtLoanAmount.FillAsync(loanAmount);
            await txtDownPayments.FillAsync(downPayment);
            await lbxFromAccountNo.SelectOptionAsync(fromAccount);
            await btnApplyNow.ClickAsync();
            await lblLoanTitle.WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible,
            });
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                FullPage = true,
                Path = "ApplyLoan.png",
                Type = ScreenshotType.Png
            });
        }

        public async Task<string> GetLoanStatus()
        {
            var result = await tdLoanStatus.TextContentAsync();
            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "test.png",
                Type = ScreenshotType.Png,
                FullPage = true
            });
            return result;
        }

    }
}
