﻿
using SeleniumExtras.PageObjects;

namespace Tfl.CoreUI
{
    public class BasePage
    {
        private IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public TPage GetPage<TPage>(IWebDriver driver) where TPage : new()
        {
            if (_driver == null)
            {
                _driver = driver;
            }
            var pageInstance = new TPage();
            PageFactory.InitElements(driver, pageInstance);
            return pageInstance;
        }

        public static void NavigateToUrl(string url)
        {
            WebDriverSupport.SupportDriver().Navigate().GoToUrl(url);
        }

    }
}
