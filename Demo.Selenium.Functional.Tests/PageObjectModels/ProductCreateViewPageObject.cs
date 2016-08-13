using Demo.Selenium.Functional.Tests.Helpers;
using Demo.Selenium.Functional.Tests.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Demo.Selenium.Functional.Tests.PageObjectModels
{
    public class ProductCreateViewPageObject
    {
        #region Fields

        private readonly IWebDriver _driver;

        #endregion

        #region Page Object Model

        [FindsBy(How = How.Id, Using = "ProductName")]
        private IWebElement TxtProductName { get; set; }

        [FindsBy(How = How.Id, Using = "ProductDescription")]
        private IWebElement TxtProductDescription { get; set; }

        [FindsBy(How = How.Id, Using = "ProductPrice")]
        private IWebElement TxtProductPrice { get; set; }

        [FindsBy(How = How.Id, Using = "btnCreate")]
        public IWebElement BtnCreate { get; set; }

        #endregion

        #region C-Tor

        public ProductCreateViewPageObject(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this._driver, this);
        }

        #endregion

        #region Operations

        public ConfirmationViewPageObject CreateNewProduct(string productName, string productDescription, string productPrice)
        {
            this.TxtProductName.PerformTextBoxWrite(productName);
            ThreadSleepHelper.Wait();
            this.TxtProductDescription.PerformTextBoxWrite(productDescription);
            ThreadSleepHelper.Wait();
            this.TxtProductPrice.PerformTextBoxWrite(productPrice);
            ThreadSleepHelper.Wait();
            this.BtnCreate.PerformButtonClick();

            return new ConfirmationViewPageObject(this._driver);
        }

        #endregion
    }
}
