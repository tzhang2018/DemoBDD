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
            var browser = await playwright.Chromium.LaunchAsync(GetBrowserOptions());
            var context = await browser.NewContextAsync();
            Page = await context.NewPageAsync();
        }

        private BrowserTypeLaunchOptions GetBrowserOptions()
        {
            var result = new BrowserTypeLaunchOptions();
            if (Environment.OSVersion.Platform == PlatformID.Unix)
                result.Headless = true;
            else
                result.Headless = false;

            return result;
        }
    }
}
