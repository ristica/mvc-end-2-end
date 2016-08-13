using System;
using System.Security.Cryptography.X509Certificates;
using Demo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Demo.Controller.Tests.Stories.EditStory
{
    [TestClass]
    [Story(
        AsA = "As an admin",
        IWant = "I want to be able to update choosen product",
        SoThat = "So that customers be notified about change(s)")]
    public partial class EditProductTests
    {
        [TestMethod]
        public void ShouldRenderDefaultViewWithExistingProduct()
        {
            this.Given(x => AdminClicksAProductOnListView())
                .When(x => AdminLandsOnEditPageWithExistingProduct())
                .Then(x => ItShouldCreateDefaultView())
                .And(x => TheProductShouldHaveCorrespondingId())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldReturnHttpNotFoundOnEditIfNoProductFoundTest()
        {
            this.Given(x => AdminClicksAProductOnListView())
                .When(x => AdminLandsOnEditPageWithNonExistingProduct())
                .Then(x => AdminShouldSeeHttpNotFoundMessage())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldUpdateProductIfModelIsValid()
        {
            this.Given(x => AdminEditsExistingProduct())
                .When(x => ProductIsInValidState())
                .And(x => x.AdminClicksSaveButton())
                .Then(x => AdminShouldBeRedirectedToConfirmationPage())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldNotUpdateProductIfProductNameIsTooShort()
        {
            this.Given(x => ProductNameIsTooShort())
                .And(x => AdminClicksSaveButton())
                .Then(x => ModelStateShouldBeInvalid())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldNotUpdateProductIfProductNameIsTooLong()
        {
            this.Given(x => ProductNameIsTooLong())
                .When(x => AdminClicksSaveButton())
                .Then(x => ModelStateShouldBeInvalid())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldNotUpdateProductIfProductPriceIsNegative()
        {
            this.Given(x => ProductPriceIsNegative())
                .When(x => AdminClicksSaveButton())
                .Then(x => ModelStateShouldBeInvalid())
                .BDDfy<ProductViewModel>();
        }

    }
}
