
# Tfl Journey Planner Automation
For automating Tfl UI using c#, .Net, Specflow and Nunit


## Configure variables
Setting all the variables in appsettings.json

## BDD

### Hooks 
Hooks (event bindings) can be used to perform additional automation logic at specific times, such as any setup required prior to executing a scenario. In order to use hooks, you need to add the Binding attribute to your class:
> [Binding]<br>
public class Hooks
{
    <br>
    [BeforeFeature] </br>
    <br>
    [BeforeScenario] </br>

}

Depending on the type of the hook the parameters are resolved from a container with the corresponding lifecycle.

>[BeforeFeature],[AfterFeature],[BeforeScenario],[AfterScenario],[BeforeStep],[AfterStep]    

## Tag Scoping
We use tag scoping to filter the scenarios. We tagged as 
> Smoke Test<br>
> Regression Test <br>

## Execution Report
 We use Extended Report to generate Html Dashboard. After completing execution we will get an Html report with all the test results.
 > 
![Screenshot 2022-08-27 034715](https://user-images.githubusercontent.com/29451624/187011339-6e6e884e-bd57-4d6f-b4b3-1f4b5259145f.png)

