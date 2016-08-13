using System.Web;
using Demo.ViewModels;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorGenerator.Testing;

namespace Demo.View.Tests
{
    [TestClass]
    public class DemoDeleteViewTests
    {
        [TestMethod]
        public void ShouldRenderViewBagOnDeleteViewTest()
        {
            var view = new ASP._Views_Product_Delete_cshtml();

            view.ViewBag.Question = "some text";
            
            HttpContext.Current = this.GetCurrentContext();

            var html = view.RenderAsHtml(new ProductViewModel());
            
            var question = html.GetElementbyId("question").InnerText;

            Assert.IsTrue(question == "some text");
        }

        /// <summary>
        /// BUG in RazorGenerator if there is AntiForgeryToken
        /// </summary>
        /// <returns></returns>
        private HttpContext GetCurrentContext()
        {
            return new HttpContext(
                new HttpRequest(null, "http://localhost", null),
                new HttpResponse(null));
        }
    }
}
