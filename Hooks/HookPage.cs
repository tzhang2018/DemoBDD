using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace DemoBDD.Hooks
{
    [Binding]
    public class HookPage
    {
        public IPage Page { get; private set; }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var context = await browser.NewContextAsync();
            Page = await context.NewPageAsync();
        }
    }
}
