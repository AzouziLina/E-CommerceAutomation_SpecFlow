using CoreAutomation.Interfce;

namespace ECommerceAutomation.Data.Abstraction
{
    public interface ILoginData
    {
        IDataHelper helper { get; set; }
        string Email { get; }
        string Password { get; }
        string ExpectedMessage { get; }
    }
}
