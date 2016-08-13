using Demo.Controllers.Mvc;
using Demo.Repository;
using Demo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace Demo.Controller.Tests.CreateStory
{
    public partial  class CreateProductTests
    {
        #region Fields

        private Mock<IProductRepository> _repository;
        private ProductController _controller;
        private ProductViewModelValidator _validator;
        private ControllerResultTest<ProductController> _controllerResult;
        private ProductViewModel _newProduct = new ProductViewModel
        {
            ProductId = 0,
            ProductName = "Test",
            ProductDescription = "Description",
            ProductPrice = 1M
        };
        private ProductViewModel _product = new ProductViewModel
        {
            ProductId = 1,
            ProductName = "Test",
            ProductDescription = "Description",
            ProductPrice = 1M
        };

        #endregion

        #region ShouldRenderDefaultView

        private void AdminClicksCreateNewProduct()
        {
            this._repository = new Mock<IProductRepository>();
            this._controller = new ProductController(this._repository.Object);
        }

        private void AdminLandsOnCreatePage()
        {
            this._controllerResult = this._controller.WithCallTo(x => x.Create());
        }

        private void ItShouldBeCreateDefaultView()
        {
            this._controllerResult.ShouldRenderDefaultView();
        }

        #endregion

        #region Shared

        private void AdminPressesCreateButtonWithValidModelState()
        {
            this._validator = new ProductViewModelValidator();

            this._repository = new Mock<IProductRepository>();
            this._repository.Setup(obj => obj.UpdateProduct(this._newProduct)).Returns(this._product);

            this._controller = new ProductController(this._repository.Object);

            this._controllerResult = this._controller.WithCallTo(c => c.Create(this._newProduct));
        }

        private void AdminPressesCreateButtonWithInvalidProduct()
        {
            this._validator = new ProductViewModelValidator();

            this._repository = new Mock<IProductRepository>();
            this._repository.Setup(obj => obj.UpdateProduct(this._product)).Returns(_product);

            this._controller = new ProductController(this._repository.Object);

            this._controllerResult = this._controller.WithCallTo(c => c.Create(this._product));
        }

        private void AdminPressesCreateButtonWithInvalidModelState()
        {
            this._repository = new Mock<IProductRepository>();
            this._repository.Setup(obj => obj.UpdateProduct(this._product)).Verifiable();

            this._controller = new ProductController(this._repository.Object);            
        }

        private void ValidationShouldFailed()
        {
            var result = this._validator.Validate(this._product);

            Assert.IsTrue(result.Errors.Count == 1);
            Assert.IsFalse(result.IsValid);
        }

        private void ProductNameIsTooShort()
        {
            this._product.ProductName = "p";
        }

        private void ProductNameIsTooLong()
        {
            this._product.ProductName = "This Product has name that is toooooo long";
        }

        private void ProductPriceIsNegative()
        {
            this._product.ProductPrice = -1;
        }

        #endregion

        #region ShouldRenderCreateViewWithEmptyModel

        private void AdminWantsToCreateNewProduct()
        {
            this._repository = new Mock<IProductRepository>();
            this._controller = new ProductController(this._repository.Object);
        }

        private void AdminComesToCreateView()
        {
            this._controllerResult = this._controller.WithCallTo(c => c.Create());
        }

        private void EmptyModelIsCreated()
        {
            this._controllerResult
                .ShouldRenderDefaultView()
                .WithModel<ProductViewModel>(x => x.ProductId == 0);
        }

        #endregion

        #region ShouldCreateNewProductIfModelIsValid

        private void NewModelIsValid()
        {
            
        }

        private void AdminShouldBeRedirectedToConfirmationPage()
        {
            this._controllerResult.ShouldRedirectTo(r => r.Confirmation);
        }

        #endregion

        #region ShouldRenderCreateViewAgainIfModelStateIsInvalidBecauseProductNameIsTooShort

        private void CreatePageShouldBeRenderedAgainWithTooShortNameError()
        {
            this._controller.ModelState.AddModelError("ProductName", "Product name musst be between 2 and 20 characters.");

            this._controller
                    .WithCallTo(c => c.Create(this._product))
                    .ShouldRenderView("Create")
                    .WithModel<ProductViewModel>()
                    .AndModelErrorFor(m => m.ProductName).ThatEquals("Product name musst be between 2 and 20 characters.");
        }

        #endregion

        #region ShouldRenderCreateViewAgainIfModelStateIsInvalidBecauseProductNameIsTooLong

        private void CreatePageShouldBeRenderedAgainWithTooLongNameError()
        {
            this._controller.ModelState.AddModelError("ProductName", "Product name musst be between 2 and 20 characters.");

            this._controller
                    .WithCallTo(c => c.Create(this._product))
                    .ShouldRenderView("Create")
                    .WithModel<ProductViewModel>()
                    .AndModelErrorFor(m => m.ProductName).ThatEquals("Product name musst be between 2 and 20 characters.");
        }

        #endregion

        #region ShouldRenderCreateViewAgainIfModelStateIsInvalidBecauseProductPriceIsNegative

        private void CreatePageShouldBeRenderedAgainWithNegativePriceError()
        {
            this._controller.ModelState.AddModelError("ProductPrice", "Product price musst be in positive range.");

            this._controller
                    .WithCallTo(c => c.Create(this._product))
                    .ShouldRenderView("Create")
                    .WithModel<ProductViewModel>()
                    .AndModelErrorFor(m => m.ProductPrice).ThatEquals("Product price musst be in positive range.");
        }

        #endregion
    }
}
