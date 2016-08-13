using System.Net;
using Demo.Controllers.Mvc;
using Demo.Repository;
using Demo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace Demo.Controller.Tests.Stories.EditStory
{
    public partial  class EditProductTests
    {
        #region Fields

        private int _id = 1;
        private readonly ProductViewModel _product = new ProductViewModel
        {
            ProductId = 1,
            ProductName = "Test",
            ProductDescription = "Description",
            ProductPrice = 1M
        };
        private Mock<IProductRepository> _repository;
        private ProductController _controller;
        private ControllerResultTest<ProductController> _controllerResult;
        private ProductViewModelValidator _validator;

        #endregion

        #region Shared

        private void AdminClicksAProductOnListView()
        {
            this._repository = new Mock<IProductRepository>();
            this._controller = new ProductController(this._repository.Object);
        }

        private void AdminShouldBeRedirectedToConfirmationPage()
        {
            this._controllerResult.ShouldRedirectTo(r => r.Confirmation);
        }

        private void ItShouldCreateDefaultView()
        {
            this._controllerResult.ShouldRenderDefaultView();
        }

        private void AdminClicksSaveButton()
        {
            this._controllerResult = this._controller.WithCallTo(c => c.Edit(this._product));
        }

        #endregion

        #region ShouldRenderDefaultViewWithExistingProduct

        private void AdminLandsOnEditPageWithExistingProduct()
        {
            this._repository.Setup(obj => obj.GetProduct(this._id)).Returns(this._product);
            this._controllerResult = this._controller.WithCallTo(c => c.Edit(this._id));
        }

        private void TheProductShouldHaveCorrespondingId()
        {
            Assert.IsTrue(
                ((ProductViewModel)this._controllerResult.Controller.ViewData.Model).ProductId == this._id);
        }

        #endregion

        #region ShouldReturnHttpNotFoundOnEditIfNoProductFoundTest

        private void AdminLandsOnEditPageWithNonExistingProduct()
        {
            this._controllerResult = this._controller.WithCallTo(c => c.Edit(11));
        }

        private void AdminShouldSeeHttpNotFoundMessage()
        {
            this._controllerResult.ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        #endregion

        #region ShouldUpdateProductIfModelIsValid

        private void AdminEditsExistingProduct()
        {
            this._repository = new Mock<IProductRepository>();
            this._controller = new ProductController(this._repository.Object);
        }

        private void ProductIsInValidState()
        {
            this._repository.Setup(obj => obj.UpdateProduct(this._product)).Returns(_product);
        }

        #endregion

        #region ShouldNotUpdateProductIfProductNameIsTooShort
        
        private void ProductNameIsTooShort()
        {
            this._product.ProductName = "p";

            this._repository = new Mock<IProductRepository>();
            this._repository.Setup(obj => obj.UpdateProduct(this._product)).Returns(this._product);
            this._controller = new ProductController(this._repository.Object);
            this._validator = new ProductViewModelValidator();
        }

        private void ModelStateShouldBeInvalid()
        {
            var result = this._validator.Validate(this._product);
            Assert.IsTrue(result.Errors.Count == 1);
            Assert.IsFalse(result.IsValid);
        }

        #endregion

        #region ShouldNotUpdateProductIfProductNameIsTooLong

        private void ProductNameIsTooLong()
        {
            this._product.ProductName = "This is a pretty long name for a product";
            this._validator = new ProductViewModelValidator();

            this._repository = new Mock<IProductRepository>();
            this._repository.Setup(obj => obj.UpdateProduct(this._product)).Returns(this._product);

            this._controller = new ProductController(this._repository.Object);
        }

        #endregion

        #region ShouldNotUpdateProductIfProductPriceIsNegative

        private void ProductPriceIsNegative()
        {
            this._product.ProductPrice = -1M;
            this._validator = new ProductViewModelValidator();

            this._repository = new Mock<IProductRepository>();
            this._repository.Setup(obj => obj.UpdateProduct(this._product)).Returns(this._product);

            this._controller = new ProductController(this._repository.Object);
        }

        #endregion
    }
}
