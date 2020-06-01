using NUnit.Framework;
using Emag_Tests_Site.Pages;
using Emag_Tests_Site.Utils.Selenium;
using static Emag_Tests_Site.Utils.Selenium.Driver;
using static Emag_Tests_Site.Utils.Selenium.Settings;

namespace Emag_Tests_Site.Tests
{
    [TestFixture]
    public class BaseTests : Page
    {
        [SetUp]
        public static void StartWebDriver()
        {
            DriverController.Instance.StartChrome();
        }

        [TearDown]
        public static void CloseWebDriver()
        {
            DriverController.Instance.StopWebDriver();
        }
    }
}
