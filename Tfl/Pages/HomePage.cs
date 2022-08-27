


namespace Tfl.Pages
{
    public class HomePage
    {
        protected WebDriverSupport _driverSupport = new WebDriverSupport();

        #region Cookie Elements
        [FindsBy(How = How.Id, Using = "CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")]
        private IWebElement AcceptCookieButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//button[contains(@onclick, 'endCookieProcess()')]")]
        private IWebElement CookieDoneButton { get; set; }
        #endregion


        #region Home Page Elements
        [FindsBy(How = How.Id, Using = "InputFrom")]
        private IWebElement FromText { get; set; }
        [FindsBy(How = How.ClassName, Using = "stop-name")]
        private IWebElement SelectOption { get; set; }
        [FindsBy(How = How.Id, Using = "InputTo")]
        private IWebElement ToText { get; set; }

        [FindsBy(How = How.ClassName, Using = "plan-journey-button")]
        private IWebElement PlanJourneyButton { get; set; }
        [FindsBy(How = How.Id, Using = "InputFrom-error")]
        private IWebElement FromFieldMandatoryError { get; set; }
        [FindsBy(How = How.Id, Using = "InputTo-error")]
        private IWebElement ToFieldMandatoryError { get; set; }


        [FindsBy(How = How.ClassName, Using = "change-departure-time")]
        private IWebElement ChangeTimeLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Arriving')]")]
        private IWebElement ArrivingButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Date of departure')]")]
        private IWebElement DateOption { get; set; }
        [FindsBy(How = How.Id, Using = "Date")]
        private IWebElement SelectDay { get; set; }
        [FindsBy(How = How.Id, Using = "Time")]
        private IWebElement SelectTime { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Recents')]")]
        private IWebElement RecentsLink { get; set; }


        [FindsBy(How = How.ClassName, Using = "journey-item")]
        private IWebElement JourneyItem { get; set; }
        #endregion



        #region Cookie Actions
        public void AcceptCookie()
        {
            AcceptCookieButton.ClickElement();
            CookieDoneButton.WaitUntilDisplayed(2);
            CookieDoneButton.ClickElement();
        }
        #endregion

        #region Home Page Actions
        public void EnterJourney(string from, string to)
        {
            AcceptCookie();
            
            WebElementExtension.EnterTextIntoField(FromText, from);
            SelectOption.ClickElement();
            WebElementExtension.EnterTextIntoField(ToText, to);
            SelectOption.ClickElement();
        }
        public void EnterInvalidJourney(string from, string to)
        {
            AcceptCookie();
            WebElementExtension.EnterTextIntoField(FromText, from);
            WebElementExtension.EnterTextIntoField(ToText, to);
        }


        public void PlanMyJourney()
        {
            PlanJourneyButton.ClickElement();
        }
        public void MandatoryFieldValidationError(string fromError,string toError)
        {
            AcceptCookie();
            FromFieldMandatoryError.WaitUntilDisplayed();
            Assert.That(FromFieldMandatoryError.Text.Contains(fromError));
            Assert.That(ToFieldMandatoryError.Text.Contains(toError));
        }
        public void ChangeTime()
        {
            ChangeTimeLink.ClickElement();
            ArrivingButton.WaitUntilDisplayed(2);
            ArrivingButton.ClickElement();
        }

        public void ChangeArrivalTime(string day, string time)
        {
            DateOption.ClickElement();
            WebElementExtension.SelectElementByText(SelectDay, day);
            WebElementExtension.SelectElementByText(SelectTime, time);
            PlanJourneyButton.ClickElement();
        }

        public void PlanJourneyOnArrivalTime()
        {
            ArrivingButton.ClickElement();
            PlanJourneyButton.ClickElement();
        }

        public void ClickRecentTab()
        {
            RecentsLink.ClickElement();
        }

        public void VerifyRecentJourney()
        {
            JourneyItem.WaitUntilDisplayed();
        }
        #endregion


    }
}
