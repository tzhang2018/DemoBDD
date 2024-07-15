using DemoBDD.Hooks;
using DemoBDD.Pages;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace DemoBDD.StepDefinitions
{
    [Binding]
    public class LoadApplicationStepDefinitions
    {
        private IPage _page;
        public LoadApplicationStepDefinitions(HookPage hook)
        {
            _page = hook.Page;
        }

        [Given(@"John is an active ParaBank customer")]
        public async Task GivenJohnIsAnActiveParaBankCustomer()
        {
            await _page.GotoAsync("https://parabank.parasoft.com/parabank", new PageGotoOptions() { WaitUntil = WaitUntilState.Load});
            var loginPage = new LoginPage(_page);
            await loginPage.LoginAs("john", "demo");
           
        }

        [Then(@"the loan application is approved")]
        public async Task ThenTheLoanApplicationIsApproved()
        {
            var loan = new LoanPage(_page);
            
            Assert.That(await loan.GetLoanStatus(), Is.EqualTo("Approved"));
        }

        [When(@"they apply for a (.*) dollar loan")]
        public async Task WhenTheyApplyForADollarLoan(int p0)
        {
            var accountService = new AccountServicesPage(_page);
            await accountService.RequestLoan();

            var loan = new LoanPage(_page);
            await loan.ApplyLoan(p0.ToString(), "500", "12345");
        }

        [Then(@"the loan application is denied")]
        public async Task ThenTheLoanApplicationIsDenied()
        {
            var loan = new LoanPage(_page);
            Assert.That(await loan.GetLoanStatus(), Is.EqualTo("Denied"));
        }

        [Then(@"the loan application is (Approved|Denied)")]
        public async Task ThenTheLoanApplicationIs(string p0)
        {
            var loan = new LoanPage(_page);
            Assert.That(await loan.GetLoanStatus(), Is.EqualTo(p0));
        }

        [When(@"they apply for a (.*) dolloar loan and their monthly income is (.*)")]
        public async Task WhenTheyApplyForADolloarLoanAndTheirMonthlyIncomeIs(int p0, int p1)
        {
            var accountService = new AccountServicesPage(_page);
            await accountService.RequestLoan();

            var loan = new LoanPage(_page);
            await loan.ApplyLoan(p0.ToString(), p1.ToString(), "13344");
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            var accountService = new AccountServicesPage(_page);
            await accountService.Logout();
        }
    }
}
