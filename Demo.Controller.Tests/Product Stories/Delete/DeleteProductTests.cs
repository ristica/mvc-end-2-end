using System;
using Demo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Demo.Controller.Tests.DeleteStory
{
    [TestClass]
    [Story(
        AsA = "As an admin",
        IWant = "I want to be able to delete choosen product",
        SoThat = "So that customer can buy it")]
    public partial class DeleteProductTests
    {
        [TestMethod]
        public void ShouldRenderDefaultViewWithExistingProduct()
        {
            this.Given(x => AdminClicksAProductOnListView())
                .When(x => AdminLandsOnDeletePageWithExistingProduct())
                .Then(x => ItShouldCreateDefaultView())
                .And(x => TheProductShouldHaveCorrespondingId())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldReturnHttpNotFoundOnDeleteIfNoProductFoundTest()
        {
            this.Given(x => AdminClicksAProductOnListView())
                .When(x => AdminLandsOnDeletePageWithNonExistingProduct())
                .Then(x => AdminShouldSeeHttpNotFoundMessage())
                .BDDfy<ProductViewModel>();
        }
    }
}
