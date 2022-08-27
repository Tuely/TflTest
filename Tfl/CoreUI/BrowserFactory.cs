
using Tfl.Enums;
using static Tfl.Enums.BrowserType;
namespace Tfl.CoreUI
{
    public class BrowserFactory
    {
        [ThreadStatic] public static IWebDriver Driver;

        private static readonly TimeSpan _timeSpan = AppConfigManager.ImplicitTimeout;

        public static IWebDriver InitBrowser(BrowserType? browserType)
        {
            browserType = browserType ?? Chrome;

            switch (browserType)
            {
                case Chrome:
                    Driver = ChromeDriver();
                    break;
                //case Firefox:
                //    Driver = FireFoxDriver();
                //    break;
                //case Ie:
                //    Driver = InternetExplorerDriver();
                //    break;
                default:
                    Driver = ChromeDriver();
                    break;
            }
            Driver.Manage().Timeouts().ImplicitWait = _timeSpan;
            Driver.Manage().Timeouts().PageLoad = _timeSpan;
            Driver.Manage().Window.Maximize();
            return Driver;
        }


        #region Browser configurations

        private static IWebDriver ChromeDriver()
        {
            var options = new ChromeOptions { PageLoadStrategy = PageLoadStrategy.Normal };
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            options.AddArguments(new List<string> { "no-sandbox", "-incognito" });
            Driver = new ChromeDriver(chromeDriverService, options);
            return Driver;
        }


        #endregion

    }


}
