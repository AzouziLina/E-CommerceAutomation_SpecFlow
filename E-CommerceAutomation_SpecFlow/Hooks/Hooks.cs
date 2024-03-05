using CoreAutomation.Driver;
using CoreAutomation.Logging;
using CoreAutomation.Reporting;
using CoreAutomation.Utilities;
using System.Reflection;
using TechTalk.SpecFlow;

namespace ECommerceAutomation.Hooks
{
    [Binding]
    public sealed class hooks: ECommerceBddBase
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            reportHelper = ExtentReportHelper.GetInstance();
            loggerHelper = SerilogLoggerHelper.GetInstance();
            browserHelper = new SeleniumBrowserHelper(reportHelper, loggerHelper);
            JsonHelper= new JsonHelper();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            reportHelper.CreateGherkinFeature(featureContext.FeatureInfo.Title);
        }
        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            try
            {
                reportHelper.CreateGherkinScenario(scenarioContext.ScenarioInfo.Title);
                loggerHelper.Info("Start :" + scenarioContext.ScenarioInfo.Title);
                browserHelper.Init();
            }

            catch (Exception ex)
            {
                reportHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                loggerHelper.Error($"{MethodBase.GetCurrentMethod().Name} crashed : Exception message is : {ex.StackTrace}");
                throw ex;
            }
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;
            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    reportHelper.SetGivenStepPassed(stepName);
                }
                else if (stepType == "When")
                {
                    reportHelper.SetWhenStepPassed(stepName);
                }
                else if (stepType == "Then")
                {
                    reportHelper.SetThenStepPassed(stepName);
                }
                else if (stepType == "And")
                {
                    reportHelper.SetAndStepPassed(stepName);
                }
            }
            //When scenario fails
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    reportHelper.SetGivenStepFailed(stepName, scenarioContext.TestError.Message);
                }
                else if (stepType == "When")
                {
                    reportHelper.SetWhenStepFailed(stepName, scenarioContext.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    reportHelper.SetThenStepFailed(stepName, scenarioContext.TestError.Message);
                }
                else if (stepType == "And")
                {
                    reportHelper.SetAndStepFailed(stepName, scenarioContext.TestError.Message);
                }
            }
        }
        [AfterScenario]
        public static void AfterScenario(ScenarioContext scenarioContext)
        {
            browserHelper.Close();
            loggerHelper.Info("End :" + scenarioContext.ScenarioInfo.Title);
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            reportHelper.EndReporting();
            loggerHelper.EndLogging();
        }

    }
}