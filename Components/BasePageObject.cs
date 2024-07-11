using Microsoft.Playwright;

namespace DemoBDD.Components
{
    public class BasePageObject
    {
        ILocator host;

        public BasePageObject(ILocator host)
        {
            this.host = host;
        }

    }
}
