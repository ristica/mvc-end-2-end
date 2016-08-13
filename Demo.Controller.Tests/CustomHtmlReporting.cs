using TestStack.BDDfy;
using TestStack.BDDfy.Reporters.Html;

namespace Demo.Controller.Tests
{
    public class CustomHtmlReporting : DefaultHtmlReportConfiguration
    {
        public override string ReportHeader => "Zurich - Test Reports";

        //public override string OutputFileName => "ZurichStories.html"; 
         
        //public override string OutputPath
        //{
        //    get
        //    {
        //        var path = Path.Combine(base.OutputPath, "ZurichReports");
        //        Directory.CreateDirectory(path);
        //        return path;
        //    }
        //}

        public override string ReportDescription => "Stories about product management";

        public override bool RunsOn(Story story)
        {
            return story.Metadata.Type.Namespace.StartsWith("Demo.Controller.Tests");
        }
    }
}
