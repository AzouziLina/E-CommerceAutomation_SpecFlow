using TechTalk.SpecFlow;
using ECommerceAutomation.Hooks;

namespace ECommerceAutomation.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions: ECommerceBddBase
    {
        [Given(@"Enter your credentials")]
        public void GivenEnterYourCredentials()
        {
            SetUpLogin();
            loginAction.SetYourCredentials();
        }

        [When(@"Click on Login to your account")]
        public void WhenClickOnLoginToYourAccount()
        {
            loginAction.ClickOnLogIn();
        }

        [Then(@"Verify Login is done successfully")]
        public void ThenVerifyLoginIsDoneSuccessfully()
        {
            loginVerification.VerifyLogIn();
        }
        [Then(@"Verify Login was not done successfully")]
        public void ThenVerifyLoginWasNotDoneSuccessfully()
        {
            loginVerification.VerifyLoginNotSuccess();
        }

    }
}
