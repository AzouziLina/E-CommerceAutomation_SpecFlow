using CoreAutomation.Interfce;
using ECommerceAutomation.Action.Abstraction;
using ECommerceAutomation.Action;
using ECommerceAutomation.Data.Abstraction;
using ECommerceAutomation.Data;
using ECommerceAutomation.Verification.Abstraction;
using ECommerceAutomation.Verification;
using NUnit.Framework;

namespace ECommerceAutomation.Hooks
{
    public abstract class ECommerceBddBase
    {
        protected static IBrowserHelper? browserHelper;
        protected static IReportHelper? reportHelper;
        protected static ILoggerHelper? loggerHelper;
        protected static IJsonHelper? JsonHelper;
        //Data:
        public ILoginData? loginData;
        //Actions:
        public ILoginAction? loginAction;
        //Verifications:
        public ILoginVerification? loginVerification;

        public void SetUpLogin()
        {
            loginData = new LoginData(TestContext.CurrentContext.Test.Name, "Login");
            loginAction = new LoginAction(browserHelper, reportHelper, loginData, loggerHelper);
            loginVerification = new LoginVerification(browserHelper, reportHelper, loginData, loggerHelper);
        }
    }
}
