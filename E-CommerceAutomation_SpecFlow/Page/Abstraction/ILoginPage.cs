namespace ECommerceAutomation.Page.Abstraction
{
    public interface ILoginPage
    {
        void SetEmail(string emailAdress);
        void SetPassword(string Passsword);
        void ClickOnContinue();
        void ClickOnToSignIn();
        void ClickOnLogIn();
        bool IsLogInDone(string ExpectedMessage);
        bool IsErrorMessageDisplayed(string ExpectedMessage);
    }
}
