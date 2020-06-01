using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emag_Tests_Site.Utils.Selenium
{
    //calls the curent driver instance

    internal class Driver
    {

        internal static IWebDriver Browser()
        {
            return DriverController.Instance.WebDriver;
        }
    }
}
