

using OpenQA.Selenium.Support.UI;

namespace Tfl
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidJourney()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")).Click();
            driver.FindElement(By.XPath(".//button[contains(@onclick, 'endCookieProcess()')]")).Click();
           
        }
    }
}