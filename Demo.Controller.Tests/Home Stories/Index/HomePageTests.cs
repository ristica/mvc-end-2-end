using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Demo.Controller.Tests.IndexStory
{
    [TestClass]
    [Story(
        AsA = "As a user if I put the right web address",
        IWant = "I want to see the start page",
        SoThat = "So that I can ...")]
    public partial class HomePageTests
    {
        [TestMethod]
        public void ShouldRenderIndexDefaultViewOnAppStart()
        {
            this.Given(x => IfIPutRightAddressInBrowser())
                .When(x => UserComesOnIndexView())
                .Then(x => UserSeesWelcomePage())
                .BDDfy();
        }
    }
}
