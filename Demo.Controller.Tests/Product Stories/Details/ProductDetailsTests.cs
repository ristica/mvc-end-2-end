using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;
using Demo.ViewModels;

namespace Demo.Controller.Tests.DetailsStory
{
    [TestClass]
    [Story(
        AsA = "As an admin or customer",
        IWant = "I want to be able to see details about choosen product",
        SoThat = "So that I can verify the data")]
    public partial class ProductDetailsTests
    {
        [TestMethod]
        public void ShouldRenderDefaultViewWithExistingProduct()
        {
            this.Given(x => AdminClicksAProductOnListView())
                .When(x => AdminLandsOnDetailsPageWithExistingProduct())
                .Then(x => ItShouldCreateDefaultView())
                .And(x => TheProductShouldHaveCorrespondingId())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldReturnHttpNotFoundOnDetailsIfNoProductFoundTest()
        {
            this.Given(x => AdminClicksAProductOnListView())
                .When(x => AdminLandsOnDetailsPageWithNonExistingProduct())
                .Then(x => AdminShouldSeeHttpNotFoundMessage())
                .BDDfy<ProductViewModel>();
        }
    }
}
