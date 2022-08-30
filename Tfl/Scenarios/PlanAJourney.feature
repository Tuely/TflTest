@regression
Feature: PlanAJourney
As a tester 
I want to test Plan a Journey feature
Background:
	Given I navigate into the Tfl Journey Planner page

@smoke
Scenario: Verify that a valid journey can be planned using the widget
	Given I select journey from 'Orpington, UK' to 'London Bridge'
	When I click Plan my journey
	Then I should navigate into results page

Scenario: Verify that the widget is unable to provide results when an invalid journey is planned
	Given I select an invalid journey from 'Lon' to 'Brn'
	When I click Plan my journey
	Then I should get message 'We found more than one location matching'

Scenario: Verify that the widget is unable to plan a journey if no locations are entered into the widget
	Given I click my journey button without entering from and to places
	Then I should get an error message 'The From field is required.' and 'The To field is required.'

Scenario: Verify change time link on the journey planner displays “Arriving” option and plan a journey based on arrival time
	Given I select journey from 'Orpington, UK' to 'London Bridge'
	When I change time link on the journey planner
	And I change Arrival Time as 'Tomorrow' at '10:30'
	Then I should navigate into results page

@smoke
Scenario: Verify On the Journey results page, verify that a journey can be amended by using the “Edit Journey” button.
	Given I select journey from 'Orpington, UK' to 'London Bridge'
	When I click Plan my journey
	And In the result page amended by using the “Edit Journey” button
	And I change Arrival Time as 'Tomorrow' at '10:30'
	Then I should navigate into results page

Scenario: Verify that the “Recents” tab on the widget displays a list of recently planned journeys.
	Given I select a new journey from 'Br6 6nw' to 'Bromley'
	When I click Plan my journey
	And I click on recents Tab
	Then I Verify that the “Recents” tab on the widget displays a list of recently planned journeys

Scenario: Verify entering invalid place getting error message
	Given I select an invalid journey from '123' to '123'
	When I click Plan my journey
	Then I should get an error  message 'Journey planner could not find any results to your search. Please try again'