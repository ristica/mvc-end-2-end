using System.Collections.Generic;
using System.Linq;
using Demo.Controllers.Mvc;
using Demo.Repository;
using Demo.ViewModels;
using Moq;
using TestStack.FluentMVCTesting;

namespace Demo.Controller.Tests.ListStory
{
    public partial class ListProductsTests
    {
        #region Fields

        private Mock<IProductRepository> _repository;
        private ProductController _controller;
        private List<ProductViewModel> _products;
        private ControllerResultTest<ProductController> _controllerResult;

        #endregion

        #region ShouldRenderDefaultView

        private void CustomerClicksProductsMenuLink()
        {
            this._repository = new Mock<IProductRepository>();
            this._controller = new ProductController(this._repository.Object);
        }

        private void CustomerLandsOnPage()
        {
            this._controllerResult = this._controller.WithCallTo(x => x.List());
        }

        private void ItShouldBeListDefaultView()
        {
            this._controllerResult.ShouldRenderDefaultView();
        }

        #endregion

        #region Shared

        private void CustomerComesOnListView()
        {
            this._controllerResult = this._controller.WithCallTo(c => c.List());
        }

        #endregion

        #region ShouldRenderListViewWithProductsIfAnyAreAvailable

        private void IfThereAreProductsAvailable()
        {
            this._products = new List<ProductViewModel>
            {
                new ProductViewModel
                {
                    ProductId = 1,
                    ProductName = "Product 1",
                    ProductDescription = "Description 1",
                    ProductPrice = new decimal(101)
                },
                new ProductViewModel
                {
                    ProductId = 2,
                    ProductName = "Product 2",
                    ProductDescription = "Description 2",
                    ProductPrice = new decimal(102)
                },
                new ProductViewModel
                {
                    ProductId = 3,
                    ProductName = "Product 2",
                    ProductDescription = "Description 2",
                    ProductPrice = new decimal(103)
                }
            };
            this._repository = new Mock<IProductRepository>();
            this._repository.Setup(obj => obj.GetProducts()).Returns(this._products);
            this._controller = new ProductController(this._repository.Object);
        }

        private void CustomerSeesProductsInTheListView()
        {
            this._controllerResult
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<ProductViewModel>>(
                    x => x.Count() == 3 && x.FirstOrDefault().ProductName == "Product 1");
        }

        #endregion

        #region ShouldRenderListViewWithoutProductsIfThereAreNoProductsAvailable

        private void IfThereAreNpProductsAvailable()
        {
            this._products = new List<ProductViewModel>();
            this._repository = new Mock<IProductRepository>();
            this._repository.Setup(obj => obj.GetProducts()).Returns(this._products);
            this._controller = new ProductController(this._repository.Object);
        }

        private void CustomerSeesNoProductsInTheListView()
        {
            this._controllerResult
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<ProductViewModel>>(x => !x.Any());
        }

        #endregion
    }
}
