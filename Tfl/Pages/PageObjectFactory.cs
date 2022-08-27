
namespace Tfl.Pages
{
    public class PageObjectFactory
    {
        public IWebDriver _driver;
        public BasePage _basePage;
        public PageObjectFactory(IWebDriver driver, BasePage basePage)
        {
            _driver = driver;
            _basePage = basePage;
        }

        public HomePage HomePage()
        {
            return _basePage.GetPage<HomePage>(_driver);
        }

        public JourneyResultPage JourneyResultPage()
        {
            return _basePage.GetPage<JourneyResultPage>(_driver);
        }

    }
}
