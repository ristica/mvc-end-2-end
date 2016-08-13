using System;
using Demo.Selenium.Functional.Tests.Helpers;
using Demo.Selenium.Functional.Tests.PageObjectModels;
using Demo.Selenium.Functional.Tests.SeleniumFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Demo.Selenium.Functional.Tests
{
    //[TestClass]
    public class ProductCreateTests : SeleniumBase
    {
        #region Fields

        private ProductCreateViewPageObject _pob;

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
        [Priority(1)]
        [Owner("Chrome")]
        public void ProductCreationTests()
        {
            this.TestInitialize();
            //this.ShouldNotCreateNewProductIfFirstnameTooShortTest();
            //this.TestInitialize();
            //this.ShouldNotCreateNewProductIfFirstnameTooLongTest();
            //this.TestInitialize();
            //this.ShouldNotCreateNewProductIfPriceHasWrongFormatTest();
            //this.TestInitialize();
            //this.ShouldNotCreateNewProductIfPriceLessThenZeroTest();
            //this.TestInitialize();
            this.ShouldCreateNewProductTest();
        }

        #endregion

        #region Tests

        //private void ShouldNotCreateNewProductIfFirstnameTooShortTest()
        //{
        //    Console.WriteLine("ShouldNotCreateNewProductIfFirstnameTooShortTest");
        //    var result = this._pob.CreateNewProduct("P", "New product description", "111,00");

        //    Assert.IsNull(result, result.LblMessage.Text);
        //}

        //private void ShouldNotCreateNewProductIfFirstnameTooLongTest()
        //{
        //    //SeleniumWriteMethods.FindElementAndSendKeys(Attribute.ID, Constants.PRODUCT_NAME, "Product to test the ModelState");
        //    //SeleniumWriteMethods.FindElementAndSendKeys(Attribute.ID, Constants.PRODUCT_DESCRIPTION, "Description");
        //    //SeleniumWriteMethods.FindElementAndSendKeys(Attribute.ID, Constants.PRODUCT_PRICE, "111,00");

        //    //ThreadSleepHelper.Wait();

        //    //SeleniumWriteMethods.FindButtonAndClick(Attribute.ID, Constants.BTN_CREATE);

        //    //// show render Create view again...

        //    //var errorMessage = WebDriverBase.Driver.FindElement(By.ClassName("field-validation-error"));

        //    //Assert.IsTrue(errorMessage != null);
        //}

        //private void ShouldNotCreateNewProductIfPriceHasWrongFormatTest()
        //{
        //    //SeleniumWriteMethods.FindElementAndSendKeys(Attribute.ID, Constants.PRODUCT_NAME, "Product");
        //    //SeleniumWriteMethods.FindElementAndSendKeys(Attribute.ID, Constants.PRODUCT_DESCRIPTION, "Description");
        //    //SeleniumWriteMethods.FindElementAndSendKeys(Attribute.ID, Constants.PRODUCT_PRICE, "111.00");

        //    //ThreadSleepHelper.Wait();

        //    //SeleniumWriteMethods.FindButtonAndClick(Attribute.ID, Constants.BTN_CREATE);

        //    //// show render Create view again...

        //    //var errorMessage = WebDriverBase.Driver.FindElement(By.ClassName("field-validation-error"));

        //    //Assert.IsTrue(errorMessage != null);
        //}

        //private void ShouldNotCreateNewProductIfPriceLessThenZeroTest()
        //{
        //    //SeleniumWriteMethods.FindElementAndSendKeys(Attribute.ID, Constants.PRODUCT_NAME, "Product");
        //    //SeleniumWriteMethods.FindElementAndSendKeys(Attribute.ID, Constants.PRODUCT_DESCRIPTION, "Description");
        //    //SeleniumWriteMethods.FindElementAndSendKeys(Attribute.ID, Constants.PRODUCT_PRICE, "-1");

        //    //ThreadSleepHelper.Wait();

        //    //SeleniumWriteMethods.FindButtonAndClick(Attribute.ID, Constants.BTN_CREATE);

        //    //// show render Create view again...

        //    //var errorMessage = WebDriverBase.Driver.FindElement(By.ClassName("field-validation-error"));

        //    //Assert.IsTrue(errorMessage != null);
        //}

        private void ShouldCreateNewProductTest()
        {
            Console.WriteLine("ShouldCreateNewProductTest");
            var result = this._pob.CreateNewProduct("New Product", "New product description", "111,00");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.LblMessage.Text.ToLowerInvariant().Equals("operation successfully executed..."));

            ThreadSleepHelper.Wait();
        }

        #endregion

        #region Abstract methods

        protected override void TestInitialize()
        {
            WebDriverBase.Driver.Navigate().GoToUrl(BaseUrlHelper.baseURL + "product/create");
            this._pob = new ProductCreateViewPageObject();
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