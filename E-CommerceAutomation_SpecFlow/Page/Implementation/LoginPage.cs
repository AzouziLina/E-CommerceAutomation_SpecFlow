using ECommerceAutomation.Page.Abstraction;
using CoreAutomation.Page;
using OpenQA.Selenium;
using System.Reflection;
using CoreAutomation.Interfce;

namespace ECommerceAutomation.Page
{
    public class LoginPage : BasePage, ILoginPage
    {
        public LoginPage(IBrowserHelper browserHelper, IReportHelper reportHelper, ILoggerHelper loggerHelper)
        {
            this.browserHelper = browserHelper;
            this.reportHelper = reportHelper;
            this.loggerHelper = loggerHelper;
        }
        //web locators
        private readonly By email = By.Id("Email");
        private readonly By pswd = By.Id("Password");
        private readonly By loginButton = By.LinkText("S'identifier");
        private readonly By loginAccount = By.ClassName("account-link");
        private readonly By error = By.ClassName("validation-summary-errors");
        private readonly By acceptButton = By.XPath("//span[normalize-space()='Accepter & Fermer']");
        private readonly By continueButton = By.XPath("//a[normalize-space()='Continuer sur la boutique en ligne']");

        public void SetEmail(string emailAdress)
        {
            try
            {
                browserHelper.SetTextUsingSendKeys(email, emailAdress);
                reportHelper.Info("Set email address was done: " + emailAdress);
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public void SetPassword(string Passsword)
        {
            try
            {
                browserHelper.SetTextUsingSendKeys(pswd, Passsword);
                reportHelper.Info("Set Password : " + Passsword);
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public void ClickOnContinue()
        {
            try
            {
                browserHelper.ClickOnElement(acceptButton);
                browserHelper.ClickOnElement(continueButton);
                reportHelper.Info("Click on Continue");

            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public void ClickOnToSignIn()
        {
            try
            {
                browserHelper.ClickOnElement(loginAccount);
                reportHelper.Info("Click on to Sign In");

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
                browserHelper.ClickOnElement(loginButton);
                reportHelper.Info("Log in to your account");

            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public bool IsLogInDone(string ExpectedMessage)
        {
            try
            {
                return browserHelper.IsTextPresentInElementLocated(loginAccount, ExpectedMessage);
            }
            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        public bool IsErrorMessageDisplayed(string ExpectedMessage)
        {
            try
            {
                return browserHelper.IsTextPresentInElementLocated(error, ExpectedMessage);
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
