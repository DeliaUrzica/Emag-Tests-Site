using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using static Emag_Tests_Site.Utils.Selenium.Driver;
using static Emag_Tests_Site.Utils.Selenium.Settings;

// We use such a class file to share methods that are inherited in the page class files.
// A good page object model framework depends on how you implement its BasePage.

namespace Emag_Tests_Site.Pages
{
    public class BasePage : Page
    {
        // Create an auto-implemented property of type IWebDriver
        public IWebDriver Driver { get; internal set; }
        public string GetTitle => Driver.Title;
        public string GetURL => Driver.Url;
        public string GetPageSource => Driver.PageSource;


        public void GoToEmag()
        {
            var url = BaseUrl;
            Browser().Navigate().GoToUrl(url);
            Browser().Manage().Window.Maximize();
            Console.WriteLine(WelcomeMessage);
        }
    }
}
