using Demo.Selenium.Functional.Tests.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Demo.Selenium.Functional.Tests.PageObjectModels
{
    public class ConfirmationViewPageObject
    {
        #region Proerties

        [FindsBy(How = How.Id, Using = "message")]
        public IWebElement LblMessage { get; set; }

        [FindsBy(How = How.Id, Using = "productId")]
        public IWebElement LblProductId { get; set; }

        #endregion

        #region C-Tor

        public ConfirmationViewPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #endregion
    }
}
