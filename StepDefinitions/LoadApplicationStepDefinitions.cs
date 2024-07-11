using DemoBDD.Pages;
using Microsoft.Playwright.NUnit;
using TechTalk.SpecFlow;

namespace DemoBDD.StepDefinitions
{
    [Binding]
    public class LoadApplicationStepDefinitions : PageTest
    {
        [BeforeScenario]
        public void Setup()
        {

        }

        [Given(@"John is an active ParaBank customer")]
        public void GivenJohnIsAnActiveParaBankCustomer()
        {
            var sut = new LoginPage(Page);
            
        }

        [Then(@"the loan application is approved)")]
        public void ThenTheLoanApplicationIsApproved()
        {
            
        }

        [When(@"they apply for a (\d+) dollar loan")]
        public void WhenTheyApplyForADollarLoan(int loanAmount)
        {
            
        }

        [Then(@"the loan application is denied")]
        public void ThenTheLoanApplicationIsDenied()
        {
            
        }

        [When(@"their monthly income is (.*)")]
        public void WhenTheirMonthlyIncomeIs(int income)
        {
            
        }
    }
}
