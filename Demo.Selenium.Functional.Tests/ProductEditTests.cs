using Demo.Selenium.Functional.Tests.Helpers;
using Demo.Selenium.Functional.Tests.PageObjectModels;
using Demo.Selenium.Functional.Tests.SeleniumFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;

namespace Demo.Selenium.Functional.Tests
{
    //[TestClass]
    public class ProductEditTests : SeleniumBase
    {
        #region Fields

        private ProductEditViewPageObject _pob;

        #endregion

        #region Initialization

        [ClassInitialize]
        public static void Initialize(TestContext ctx)
        {
            if (WebDriverBase.Driver == null)
            {
                WebDriverBase.Driver = new ChromeDriver();
            }

            WebDriverBase.Driver.Navigate().GoToUrl(BaseUrlHelper.baseURL);
            ThreadSleepHelper.Wait();
        }

        #endregion

        #region Test methods

        [TestMethod]
        [TestCategory("Selenium")]
        [Priority(2)]
        [Owner("Chrome")]
        public void ProductCreationTests()
        {
            this.CreateTestProduct();
            this.TestInitialize();
            this.ShouldEditProductTest();
        }

        #endregion

        #region Tests

        private void ShouldEditProductTest()
        {
            Console.WriteLine("ShouldEditProductTest");
            var result = this._pob.EditProduct("1", "Product UPDATE", "Description UPDATE", "123,45");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.LblMessage.Text.ToLowerInvariant().Equals("operation successfully executed..."));
            ThreadSleepHelper.Wait();
        }

        #endregion

        #region Helpers

        private void CreateTestProduct()
        {
            WebDriverBase.Driver.Navigate().GoToUrl(BaseUrlHelper.baseURL + "product/create");
            var ctx = new ProductCreateViewPageObject();
            ThreadSleepHelper.Wait();

            ctx.CreateNewProduct("Product", "Description", "111,00");
            ThreadSleepHelper.Wait();
        }

        #endregion

        #region Abstract methods

        protected override void TestInitialize()
        {
            WebDriverBase.Driver.Navigate().GoToUrl(BaseUrlHelper.baseURL + "product/edit/1");
            this._pob = new ProductEditViewPageObject();
            ThreadSleepHelper.Wait();
        }

        #endregion

        #region Clean up

        [ClassCleanup]
        public static void CleanUp()
        {
            WebDriverBase.Driver.Dispose();
            ThreadSleepHelper.Wait();
        }

        #endregion       
    }
}
