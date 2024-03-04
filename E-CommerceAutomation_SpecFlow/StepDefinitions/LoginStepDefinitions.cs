using NUnit.Framework;
using TechTalk.SpecFlow;
using ECommerceAutomation.Data.Abstraction;
using ECommerceAutomation.Action.Abstraction;
using ECommerceAutomation.Verification.Abstraction;
using ECommerceAutomation.Data;
using ECommerceAutomation.Action;
using ECommerceAutomation.Verification;
using ECommerceAutomation.Hooks;

namespace ECommerceAutomation.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions: BddBase
    {
        private ILoginAction loginAction = null;
        private ILoginVerification loginVerification = null;
        private ILoginData loginData = null;

        [Given(@"Enter your credentials")]
        public void GivenEnterYourCredentials()
        {
            loginData = new LoginData(TestContext.CurrentContext.Test.Name, "Login");
            //Actions
            loginAction = new LoginAction(browserHelper, reportHelper, loginData, loggerHelper);
            //Verifications
            loginVerification = new LoginVerification(browserHelper, reportHelper, loginData, loggerHelper);
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
