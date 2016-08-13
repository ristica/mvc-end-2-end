using Demo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Demo.Controller.Tests.ListStory
{
    [TestClass]
    [Story(
        AsA = "As a potential customer if I come to the product's list view",
        IWant = "I want to see all available products (if there are any in the store)",
        SoThat = "So that I can buy some")]
    public partial class ListProductsTests
    {
        [TestMethod]
        public void ShouldRenderDefaultView()
        {
            this.Given(x => CustomerClicksProductsMenuLink())
                .When(x => CustomerLandsOnPage())
                .Then(x => ItShouldBeListDefaultView())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldRenderListViewWithProductsIfAnyAreAvailable()
        {
            this.Given(x => IfThereAreProductsAvailable())
                .When(x => CustomerComesOnListView())
                .Then(x => CustomerSeesProductsInTheListView())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldRenderListViewWithoutProductsIfThereAreNoProductsAvailable()
        {
            this.Given(x => IfThereAreNpProductsAvailable())
                .When(x => CustomerComesOnListView())
                .Then(x => CustomerSeesNoProductsInTheListView())
                .BDDfy<ProductViewModel>();
        }
    }
}
