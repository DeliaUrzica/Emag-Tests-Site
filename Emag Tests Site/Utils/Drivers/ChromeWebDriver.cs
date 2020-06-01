using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emag_Tests_Site.Utils.Drivers
{
    internal static class ChromeWebDriver
    {
        internal static IWebDriver LoadChromeDriver()
        {
            var driver = new ChromeDriver();
            return driver;

        }
    }
}
