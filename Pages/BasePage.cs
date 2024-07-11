using Microsoft.Playwright;


namespace DemoBDD.Pages
{
    public class BasePage
    {
        protected IPage page;
        public BasePage(IPage page)
        {
            this.page = page;
        }

        public async void Close()
        {
            await this.page.CloseAsync();
        }
    }

    
}