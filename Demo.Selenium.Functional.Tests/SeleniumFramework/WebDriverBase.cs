using OpenQA.Selenium;

namespace Demo.Selenium.Functional.Tests.SeleniumFramework
{
    public sealed class WebDriverBase
    {
        private readonly IWebDriver _driver;

        public WebDriverBase(IWebDriver driver)
        {
            this._driver = driver;
        }

        public IWebDriver GetDriver()
        {
            this._driver.Manage().Window.Size = new System.Drawing.Size(1024, 768);
            return this._driver;
        }
    }
}
