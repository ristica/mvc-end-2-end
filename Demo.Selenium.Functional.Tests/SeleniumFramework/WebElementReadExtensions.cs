using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Demo.Selenium.Functional.Tests.SeleniumFramework
{
    public static class WebElementReadExtensions
    {
        #region TextBox

        /// <summary>
        /// Reads text from the text box
        /// </summary>
        /// <param name="element">text box</param>
        /// <returns></returns>
        public static string PerformTextBoxRead(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        #endregion

        #region Dropdown

        /// <summary>
        /// Gets single selected option from the dropdown
        /// </summary>
        /// <param name="element">dropdown control</param>
        /// <returns></returns>
        public static string PerformDropdownSingleSelection(this IWebElement element)
        {
            var singleOrDefault = new SelectElement(element).AllSelectedOptions.SingleOrDefault();
            return singleOrDefault != null ? singleOrDefault.Text : string.Empty;
        }

        /// <summary>
        /// Gets multiple selected options from the dropdown
        /// </summary>
        /// <param name="element">dropdown control</param>
        /// <returns></returns>
        public static IList<string> PerformDropdowmMultipleSelection(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.Select(option => option.Text).ToList();
        }

        #endregion
    }
}
