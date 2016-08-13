using System.Net;
using Demo.Controllers.Mvc;
using Demo.Repository;
using Demo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace Demo.Controller.Tests.DeleteStory
{
    public partial  class DeleteProductTests
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

        #endregion

        #region Shared

        private void AdminClicksAProductOnListView()
        {
            this._repository = new Mock<IProductRepository>();
            this._controller = new ProductController(this._repository.Object);
        }

        #endregion

        #region ShouldRenderDefaultViewWithExistingProduct

        private void AdminLandsOnDeletePageWithExistingProduct()
        {
            this._repository.Setup(obj => obj.GetProduct(this._id)).Returns(this._product);
            this._controllerResult = this._controller.WithCallTo(c => c.Delete(this._id));
        }

        private void ItShouldCreateDefaultView()
        {
            this._controllerResult.ShouldRenderDefaultView();
        }

        private void TheProductShouldHaveCorrespondingId()
        {
            Assert.IsTrue(
                ((ProductViewModel)this._controllerResult.Controller.ViewData.Model).ProductId == this._id);
        }

        #endregion

        #region ShouldReturnHttpNotFoundOnDeleteIfNoProductFoundTest

        private void AdminLandsOnDeletePageWithNonExistingProduct()
        {
            this._controllerResult = this._controller.WithCallTo(c => c.Delete(11));
        }

        private void AdminShouldSeeHttpNotFoundMessage()
        {
            this._controllerResult.ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        #endregion
    }
}
