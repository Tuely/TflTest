namespace Tfl.Steps
{
    [Binding]
    public class PlanAJourneyStepDefinitions
    {
        private PageObjectFactory _page;
        public PlanAJourneyStepDefinitions(PageObjectFactory page)
        {
            _page = page;
        }

        #region Given Steps
        [Given(@"I navigate into the Tfl Journey Planner page")]
        public void GivenINavigateIntoTheTflJourneyPlannerPage()
        {
            BasePage.NavigateToUrl(AppConfigManager.BaseUrl());
        }

        [Given(@"I select journey from '([^']*)' to '([^']*)'")]
        public void GivenISelectJourneyFromTo(string from, string to)
        {
            _page.HomePage().EnterJourney(from, to);
        }
        
        [Given(@"I select a new journey from '([^']*)' to '([^']*)'")]
        [Given(@"I select an invalid journey from '([^']*)' to '([^']*)'")]
        public void GivenISelectAnInvalidJourneyFromTo(string from, string to)
        {
            _page.HomePage().EnterInvalidJourney(from, to);
        }

        [Given(@"I click my journey button without entering from and to places")]
        [When(@"I click Plan my journey")]
        public void WhenIClickPlanMyJourney()
        {
            _page.HomePage().PlanMyJourney();
        }
        #endregion

        #region When Steps
        [When(@"I change time link on the journey planner")]
        public void WhenIChangeTimeLinkOnTheJourneyPlanner()
        {
            _page.HomePage().ChangeTime();
        }

        [When(@"I change Arrival Time as '([^']*)' at '([^']*)'")]
        public void WhenIChangeArrivalTimeAsAt(string day, string time)
        {
            _page.HomePage().ChangeArrivalTime(day, time);
        }

        [When(@"In the result page amended by using the “Edit Journey” button")]
        public void WhenInTheResultPageAmendedByUsingTheEditJourneyButton()
        {
            _page.JourneyResultPage().EditJourney();
        }
        [When(@"I click on recents Tab")]
        public void WhenIClickOnRecentsTab()
        {
            _page.JourneyResultPage().ReturnToPlanJourneyPage();
            _page.HomePage().ClickRecentTab();
        }
        #endregion

        #region Then Steps
        [Then(@"I should navigate into results page")]
        public void ThenIShouldNavigateIntoResultsPage()
        {
            _page.JourneyResultPage().ValidJourneyResult();
        }

        [Then(@"I should get message '([^']*)'")]
        public void ThenIShouldGetMessage(string message)
        {
            _page.JourneyResultPage().InvalidLocationMessage(message);
        }
              

        [Then(@"I should get an error message '([^']*)' and '([^']*)'")]
        public void ThenIShouldGetAnErrorMessageAnd(string fromError, string toError)
        {
            _page.HomePage().MandatoryFieldValidationError(fromError, toError);
        }

        [Then(@"I should be able to plan a joureny based on arrival time")]
        public void ThenIShouldBeAbleToPlanAJourenyBasedOnArrivalTime()
        {
            _page.HomePage().PlanJourneyOnArrivalTime();
        }

        [Then(@"I Verify that the “Recents” tab on the widget displays a list of recently planned journeys")]
        public void ThenIVerifyThatTheRecentsTabOnTheWidgetDisplaysAListOfRecentlyPlannedJourneys()
        {
            _page.HomePage().VerifyRecentJourney();
        }
        #endregion


    }
}
