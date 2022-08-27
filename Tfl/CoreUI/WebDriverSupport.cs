

using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using Tfl.Enums;

namespace Tfl.CoreUI
{
    public class WebDriverSupport
    {
        [ThreadStatic] private static IWebDriver _supportDriver;
        private Stopwatch Watch { get; set; }
        public static IWebDriver SupportDriver()
        {
            return _supportDriver;
        }
        public static void DisposeDriver()
        {
            _supportDriver.Dispose();
            _supportDriver.Quit();
            _supportDriver.Close();
        }
        public static IWebDriver LaunchDriver(string browserType)
        {
            _supportDriver = BrowserFactory.InitBrowser((BrowserType)Enum.Parse(typeof(BrowserType), browserType));
            return _supportDriver;
        }


    }
}
