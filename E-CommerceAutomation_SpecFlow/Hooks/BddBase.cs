using CoreAutomation.Interfce;

namespace ECommerceAutomation.Hooks
{
    public abstract class BddBase
    {
        protected static IBrowserHelper? browserHelper;
        protected static IReportHelper? reportHelper;
        protected static ILoggerHelper? loggerHelper;
        protected static IJsonHelper? JsonHelper;
    }
}
