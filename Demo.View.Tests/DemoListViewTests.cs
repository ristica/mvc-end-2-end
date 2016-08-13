using System.Collections.Generic;
using Demo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorGenerator.Testing;

namespace Demo.View.Tests
{
    [TestClass]
    public class DemoListViewTests
    {
        [TestMethod]
        public void ShouldRenderNoProductsYetOnNoProductsListViewTest()
        {
            var view = new ASP._Views_Product_List_cshtml();

            var html = view.RenderAsHtml(null);

            var noProductParagraph = html.GetElementbyId("noProductParagraph");

            Assert.IsNotNull(noProductParagraph);
            Assert.IsTrue(noProductParagraph.InnerText == "There are no products in the database yet...");
        }

        [TestMethod]
        public void ShouldRenderProductsListViewTest()
        {
            var view = new ASP._Views_Product_List_cshtml();

            var list = new List<ProductViewModel>
            {
                new ProductViewModel(),
                new ProductViewModel()
            };
            var html = view.RenderAsHtml(list);

            var noProductParagraph = html.GetElementbyId("noProductParagraph");

            Assert.IsNull(noProductParagraph);
        }
    }
}
