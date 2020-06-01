using OpenQA.Selenium;
using Emag_Tests_Site.Utils.Drivers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Emag_Tests_Site.Utils.Selenium
{
    internal class DriverController
    {
        internal static DriverController Instance = new DriverController();
        internal IWebDriver WebDriver { get; set; }

        internal void StartChrome()
        {
            if (WebDriver != null) return;
            WebDriver = ChromeWebDriver.LoadChromeDriver();
        }

        internal void StopWebDriver()
        {
            if (WebDriver == null) return;
            try
            {
                WebDriver.Quit();
                WebDriver.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e, "::WebDriver stop error");
                WebDriver = null;
                Console.WriteLine(":: WebDriver stopped");
            }
        }
    }
}
