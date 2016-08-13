using Demo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Demo.Controller.Tests.CreateStory
{
    [TestClass]
    [Story(
        AsA = "As an admin",
        IWant = "I want to be able to add new products",
        SoThat = "So that customers can buy them")]
    public partial class CreateProductTests
    {
        [TestMethod]
        public void ShouldRenderDefaultView()
        {
            this.Given(x => AdminClicksCreateNewProduct())
                .When(x => AdminLandsOnCreatePage())
                .Then(x => ItShouldBeCreateDefaultView())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldRenderCreateViewWithEmptyModel()
        {
            this.Given(x => AdminWantsToCreateNewProduct())
                .When(x => AdminComesToCreateView())
                .Then(x => EmptyModelIsCreated())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldCreateNewProductIfModelIsValid()
        {
            this.Given(x => NewModelIsValid())
                .And(x => AdminPressesCreateButtonWithValidModelState())
                .Then(x => AdminShouldBeRedirectedToConfirmationPage())
                .BDDfy<ProductViewModel>();
        }

        #region ProductViewModelValidator tests

        [TestMethod]
        public void ShouldNotCreateIfProductNameIsTooShort()
        {
            this.Given(x => ProductNameIsTooShort())
                .When(x => AdminPressesCreateButtonWithInvalidProduct())
                .Then(x => ValidationShouldFailed())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldNotCreateIfProductNameIsTooLong()
        {
            this.Given(x => ProductNameIsTooLong())
                .When(x => AdminPressesCreateButtonWithInvalidProduct())
                .Then(x => ValidationShouldFailed())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldNotCreateIfProductPriceIsNegative()
        {
            this.Given(x => ProductPriceIsNegative())
                .When(x => AdminPressesCreateButtonWithInvalidProduct())
                .Then(x => ValidationShouldFailed())
                .BDDfy<ProductViewModel>();
        }

        #endregion

        #region ModelState tests

        [TestMethod]
        public void ShouldRenderCreateViewAgainIfModelStateIsInvalidBecauseProductNameIsTooShort()
        {
            this.Given(x => ProductNameIsTooShort())
                .When(x => AdminPressesCreateButtonWithInvalidModelState())
                .Then(x => CreatePageShouldBeRenderedAgainWithTooShortNameError())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldRenderCreateViewAgainIfModelStateIsInvalidBecauseProductNameIsTooLong()
        {
            this.Given(x => ProductNameIsTooLong())
                .When(x => AdminPressesCreateButtonWithInvalidModelState())
                .Then(x => CreatePageShouldBeRenderedAgainWithTooLongNameError())
                .BDDfy<ProductViewModel>();
        }

        [TestMethod]
        public void ShouldRenderCreateViewAgainIfModelStateIsInvalidBecauseProductPriceIsNegative()
        {
            this.Given(x => ProductPriceIsNegative())
                .When(x => AdminPressesCreateButtonWithInvalidModelState())
                .Then(x => CreatePageShouldBeRenderedAgainWithNegativePriceError())
                .BDDfy<ProductViewModel>();
        }

        #endregion
    }
}
