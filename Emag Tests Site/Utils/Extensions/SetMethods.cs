using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Emag_Tests_Site
{
    class SetMethods
    {

        //Enter Text
        public static void EnterText(IWebDriver driver, string element, string value, string elementtype)
        {
            if (elementtype == "id")
                driver.FindElement(By.Id(element)).SendKeys(value + OpenQA.Selenium.Keys.Enter);
            if (elementtype == "name")
                driver.FindElement(By.Name(element)).SendKeys(value + OpenQA.Selenium.Keys.Enter);
        }

        //Click into a button, checkbox, option
        public static void Click(IWebDriver driver, string element, string value, string elementtype)
        {
            if (elementtype == "id")
                driver.FindElement(By.Id(element)).Click();
            if (elementtype == "name")
                driver.FindElement(By.Name(element)).Click();
            if (elementtype == "class")
                driver.FindElement(By.ClassName(element)).Click();
        }
    }
}
