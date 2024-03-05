using CoreAutomation.Interfce;
using ECommerceAutomation.Action.Abstraction;
using ECommerceAutomation.Page.Abstraction;
using ECommerceAutomation.Data.Abstraction;
using ECommerceAutomation.Page;
using System.Reflection;
using ECommerceAutomation.Hooks;

namespace ECommerceAutomation.Action
{
    public class LoginAction: ECommerceBddBase, ILoginAction
    {
        public IDictionary<string, string> Data = null;
        private readonly ILoginData LoginData;
        private readonly ILoginPage? loginPage;

        public LoginAction(IBrowserHelper browserHelper, IReportHelper reportHelper, ILoginData LoginData, ILoggerHelper loggerHelper)
        {
            if (loginPage == null)
                loginPage = new LoginPage(browserHelper, reportHelper, loggerHelper);

            this.LoginData = LoginData;
            Data = this.LoginData.helper.Data;
        }
        public void ClickOnContinue()
        {
            try
            {
                loginPage.ClickOnContinue();
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public void SetYourCredentials()
        {
            try
            {
                loginPage.ClickOnContinue();
                loginPage.ClickOnToSignIn();
                loginPage.SetEmail(Data[LoginData.Email]);
                loginPage.SetPassword(Data[LoginData.Password]);
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public void ClickOnLogIn()
        {
            try
            {
                loginPage.ClickOnLogIn();
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public void LoginToYourAccount()
        {
            try 
            {
                SetYourCredentials();
                ClickOnLogIn();
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
