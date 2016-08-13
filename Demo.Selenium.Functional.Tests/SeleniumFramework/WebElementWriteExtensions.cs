using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Demo.Selenium.Functional.Tests.SeleniumFramework
{
    public static class WebElementWriteExtensions
    {
        #region TextBox

        /// <summary>
        /// Writes the text into the text box
        /// </summary>
        /// <param name="element">text box</param>
        /// <param name="value">value to write in the text box</param>
        public static void PerformTextBoxWrite(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        #endregion

        #region Button

        /// <summary>
        /// Performs click event on button or subnits the page
        /// </summary>
        /// <param name="element">button</param>
        public static void PerformButtonClick(this IWebElement element)
        {
            element.Click();
        }

        #endregion

        #region Dropdown

        /// <summary>
        /// Setss the selected option of a select dom element
        /// </summary>
        /// <param name="element">ddropdown control</param>
        /// <param name="value">option to be set</param>
        public static void PerformDropdownSelect(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        #endregion
    }
}
