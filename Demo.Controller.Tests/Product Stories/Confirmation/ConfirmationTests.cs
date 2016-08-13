using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Demo.Controller.Tests.ConfirmationStory
{
    [TestClass]
    [Story(
        AsA = "As an user admin",
        IWant = "I want to land on Confirmation view if I added/updated/deleted a product",
        SoThat = "So that I know executed well")]
    public partial class ConfirmationTests
    {
    }
}
