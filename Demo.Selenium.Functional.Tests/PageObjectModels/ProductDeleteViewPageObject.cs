using Demo.Selenium.Functional.Tests.Helpers;
using Demo.Selenium.Functional.Tests.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Demo.Selenium.Functional.Tests.PageObjectModels
{
    public class ProductDeleteViewPageObject
    {
        #region Fields

        private readonly IWebDriver _driver;

        #endregion

        #region Page Object Model

        [FindsBy(How = How.Id, Using = "btnDelete")]
        public IWebElement BtnDelete { get; set; }

        #endregion

        #region C-Tor

        public ProductDeleteViewPageObject(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this._driver, this);
        }

        #endregion

        #region Operations

        public ConfirmationViewPageObject DeleteProduct()
        {
            ThreadSleepHelper.Wait();
            this.BtnDelete.PerformButtonClick();

            return new ConfirmationViewPageObject(this._driver);
        }

        #endregion
    }
}
