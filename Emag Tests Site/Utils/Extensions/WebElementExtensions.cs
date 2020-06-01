using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Emag_Tests_Site.Utils.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Emag_Tests_Site.Utils.Extensions
{
    // The first rule of an extension method is that it must be located in a static class.
    // With public, we make sure that the class is accessible from the page classes.

    // The next rule is that an extension method must be a static method.

    // Another rule is that an extension method uses the “this” keyword as the first parameter with a type in .NET
    // and this method will be called by a given type instance on the client side.

    public static class WebElementExtensions
    {
        public static object SeleniumExtras { get; private set; }


        // Get Text/Value
        public static string GetElementValue(this IWebElement element)
        {
            Console.WriteLine(element.GetAttribute("value"));
            return element.GetAttribute("value");
        }

        public static string GetElementText(this IWebElement element)
        {
            return element.GetAttribute("text");
        }

        // Highlight the element 
        public static void HighlightElement(this IWebElement element)
        {
            var js = (IJavaScriptExecutor)Driver.Browser();
            js.ExecuteScript(Settings.WdHighlightedColor, element);
        }

        // Wait until the element is clickable
        public static void WaitElementToBeClickable(this IWebElement element, int sec = 10)
        {
            var wait = new WebDriverWait(Driver.Browser(), TimeSpan.FromSeconds(sec));
        }

        // Element is displayed
        public static bool ElementDisplayed(this IWebElement element, int sec = 10)
        {
            var wait = new WebDriverWait(Driver.Browser(), TimeSpan.FromSeconds(sec));
            return wait.Until(d =>
            {
                try
                {
                    element.ElementEnabled(sec);
                    return element.Displayed;
                }
                catch (ElementNotVisibleException)
                {
                    return false;
                }
            }
            );
        }

        public static bool ElementEnabled(this IWebElement element, int sec = 10)
        {
            var wait = new WebDriverWait(Driver.Browser(), TimeSpan.FromSeconds(sec));
            return wait.Until(d =>
            {
                try
                {
                    element.HighlightElement();
                    return element.Enabled; // Enabled = selenium property
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            }
            );
        }

        // Click into a button, checkbox
        public static void ClickElement(this IWebElement element, int sec = 10)
        {
            element.WaitElementToBeClickable(sec);
            element.ElementDisplayed();
            element.Click();
        }

        // Enter text
        public static void EnterText(this IWebElement element, string value, int sec = 10, bool clearFirst = false)
        {
            element.ElementDisplayed(sec);
            if (clearFirst == true) element.Click();
            element.SendKeys(value);
        }
    }
}
