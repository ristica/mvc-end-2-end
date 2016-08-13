using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy.Configuration;
using TestStack.BDDfy.Reporters.Html;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace Demo.Controller.Tests
{
    [TestClass]
    public class Initializer
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext ctx)
        {
            Configurator.BatchProcessors.HtmlReport.Enable();
            Configurator.BatchProcessors.DiagnosticsReport.Enable();
            Configurator.BatchProcessors.MarkDownReport.Enable();

            Configurator.BatchProcessors.Add(
                new HtmlReporter(new CustomHtmlReporting()));
        }
    }
}
