using System;
using Demo.Selenium.Functional.Tests.Helpers;
using Demo.Selenium.Functional.Tests.PageObjectModels;
using Demo.Selenium.Functional.Tests.SeleniumFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Configuration;

namespace Demo.Selenium.Functional.Tests.FF
{
    [TestClass]
    public class ProductCrudTests : SeleniumBase
    {
        #region Fields

        private string _productId;
        private static IWebDriver _driver;
        private static string _ffPathToTheExe => ConfigurationManager.AppSettings["ffPath"];

        #endregion

        #region Test methods

        [TestMethod]
        [TestCategory("Selenium")]
        [Priority(3)]
        [Owner("Chrome")]
        public void ProductCreationTests()
        {
            // home page
            this.Navigate("home");

            // create new product
            this.CreateProduct();
            
            // show product details
            this.Navigate("details");

            // edit product
            this.EditProduct();

            // show details
            this.Navigate("details");

            // delete product
            this.DeleteProduct();
        }

        #endregion

        #region Tests

        private void CreateProduct()
        {
            _driver.Navigate().GoToUrl(BaseUrlHelper.baseURL + "product/create");
            var pcvpo = new ProductCreateViewPageObject(_driver);
            var confirmation = pcvpo.CreateNewProduct("Product", "Description", "111,00");

            ThreadSleepHelper.Wait();

            this._productId = confirmation.LblProductId.Text;

            Assert.IsNotNull(confirmation);
            Assert.IsTrue(confirmation.LblMessage.Text.ToLowerInvariant().Equals("operation successfully executed..."));
        }

        private void EditProduct()
        {
            _driver.Navigate().GoToUrl(BaseUrlHelper.baseURL + "product/edit/" + this._productId);
            var pevpo = new ProductEditViewPageObject(_driver);
            var confirmation = pevpo.EditProduct(this._productId, "Product UPDATE", "Description UPDATE", "123,45");

            ThreadSleepHelper.Wait();

            Assert.IsNotNull(confirmation);
            Assert.IsTrue(confirmation.LblMessage.Text.ToLowerInvariant().Equals("operation successfully executed..."));
        }

        private void DeleteProduct()
        {
            _driver.Navigate().GoToUrl(BaseUrlHelper.baseURL + "product/delete/" + this._productId);
            var pcvpo = new ProductDeleteViewPageObject(_driver);
            var confirmation = pcvpo.DeleteProduct();

            ThreadSleepHelper.Wait();

            Assert.IsNotNull(confirmation);
            Assert.IsTrue(confirmation.LblMessage.Text.ToLowerInvariant().Equals("operation successfully executed..."));
        }

        #endregion

        #region Helpers

        private void Navigate(string page)
        {
            switch (page)
            {
                case "home":
                    _driver.Navigate().GoToUrl(BaseUrlHelper.baseURL);
                    ThreadSleepHelper.Wait();
                    break;
                case "details":
                    _driver.Navigate().GoToUrl(BaseUrlHelper.baseURL + "product/details/" + this._productId);
                    ThreadSleepHelper.Wait();
                    break;
                default:
                    throw new NotImplementedException(string.Format("Page {0} does not exist!", page));
            }
        }

        #endregion

        #region Initialization

        [ClassInitialize]
        public static void Initialize(TestContext ctx)
        {
            System.Environment.SetEnvironmentVariable(
                @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe", "webdriver.firefox.exe");

            var wdb = new WebDriverBase(new FirefoxDriver());
            _driver = wdb.GetDriver();            
        }

        #endregion

        #region Abstract methods

        protected override void TestInitialize()
        {
            
        }

        #endregion

        #region Clean up

        [ClassCleanup]
        public static void CleanUp()
        {
            _driver.Dispose();
            ThreadSleepHelper.Wait();
        }

        #endregion       
    }
}
