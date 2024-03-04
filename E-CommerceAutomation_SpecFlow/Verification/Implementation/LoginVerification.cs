using NUnit.Framework;
using CoreAutomation.Interfce;
using ECommerceAutomation.Page.Abstraction;
using ECommerceAutomation.Page;
using ECommerceAutomation.Data.Abstraction;
using ECommerceAutomation.Verification.Abstraction;
using System.Reflection;
using CoreAutomation.Test;
using ECommerceAutomation.Hooks;

namespace ECommerceAutomation.Verification
{
    public class LoginVerification : BddBase, ILoginVerification
    {
        public IDictionary<string, string> Data = null;
        private readonly ILoginData LoginData;
        private readonly ILoginPage? loginPage;

        public LoginVerification(IBrowserHelper browserHelper, IReportHelper reportHelper, ILoginData LoginData, ILoggerHelper loggerHelper)
        {
            if (loginPage == null)
                loginPage = new LoginPage(browserHelper, reportHelper, loggerHelper);

            this.LoginData = LoginData;
            Data = this.LoginData.helper.Data;
        }
        public void VerifyLogIn()
        {
            try
            {
                Assert.IsTrue(loginPage.IsLogInDone(Data[LoginData.ExpectedMessage]));
                reportHelper.SetStepStatusPassed("Log in was done succesfully : " + Data[LoginData.ExpectedMessage]);
            }
            catch (AssertionException assertionex)
            {
                reportHelper.SetStepStatusFailed("Log in was not done succesfully : "+ assertionex);
                throw assertionex;
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public void VerifyLoginNotSuccess()
        {
            try
            {
                Assert.IsTrue(loginPage.IsErrorMessageDisplayed(Data[LoginData.ExpectedMessage]));
                reportHelper.SetStepStatusPassed("Expected Error message was displayed succesfully : " + Data[LoginData.ExpectedMessage]);
            }
            catch (AssertionException assertionex)
            {
                reportHelper.SetStepStatusFailed("Expected message not appears : " + assertionex);
                throw assertionex;
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
    }
}
