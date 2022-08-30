using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfl.Pages
{
    public class JourneyResultPage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();

        #region JourneyResultPage Elements

        [FindsBy(How = How.ClassName, Using = "journey-busy-stations-information")]
        private IWebElement Message { get; set; }

        [FindsBy(How = How.ClassName, Using = "info-message")]
        private IWebElement InvalidLocationMessageText { get; set; }

        [FindsBy(How = How.ClassName, Using = "field-validation-error")]
        private IWebElement ErrorMessage { get; set; }
        [FindsBy(How = How.ClassName, Using = "edit-journey")]
        private IWebElement EditJourneyButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Plan a journey')]")]
        private IWebElement PlanJourneyLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@class, 'disambiguation-link')][1]")]
        private IWebElement SelectJourneyFromList { get; set; }

        #endregion

        #region JourneyResultPage actions
        public void ValidJourneyResult()
        {
            Message.WaitUntilDisplayed();
            Assert.That(Message.Text.Contains("Discover quieter times to travel"));
        }
       
       public void InvalidLocationMessage(string message)
        {
            InvalidLocationMessageText.WaitUntilDisplayed();
            Assert.That(InvalidLocationMessageText.Text.Contains(message));
       }
      public void SelectAJourneyFromList()
        {
            SelectJourneyFromList.WaitUntilDisplayed();
            SelectJourneyFromList.Click();
            ValidJourneyResult();
        }
        public void ReturnToPlanJourneyPage()
        {
            SelectAJourneyFromList();
            PlanJourneyLink.ClickElement();
        }
        public void EditJourney()
        {
            EditJourneyButton.ClickElement();
        }
        #endregion

    }
}
