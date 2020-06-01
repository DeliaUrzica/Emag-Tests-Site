using Emag_Tests_Site.Utils.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emag_Tests_Site.Pages

{
    public class SearchPage : BasePage
    {
        public IWebElement SearchBox => Driver.FindElement(By.Id("searchboxTrigger"));
        public IWebElement SeachIcon => Driver.FindElement(By.CssSelector(".searchbox-submit-button i"));

        public IWebElement SearchedProduct => Driver.FindElement(By.XPath("//div[@class='card-item js-product-data' and @data-name='Card memorie SanDisk SDXC Extreme, 256GB, UHS-I']"));

        public IWebElement Promotions => Driver.FindElement(By.CssSelector("[data-option-id='promotions']"));
        public IWebElement NumberOfPromotions => Driver.FindElement(By.CssSelector("[data-option-id='promotions'] span"));

        public IWebElement DeliveredByList => Driver.FindElement(By.CssSelector("a[href*='https'][class='js-filter-item filter-item active']"));
        public IWebElement DeliveredByEMagOption => Driver.FindElement(By.CssSelector("[data-name='eMAG']"));
        public IWebElement DeliveredByBetBuyTechOption => Driver.FindElement(By.CssSelector("[data-name='Best Buy Tech']"));
        public IWebElement DeliveredByVexioOption => Driver.FindElement(By.CssSelector("[data-name='VEXIO']"));
        public IWebElement DeliveredByNumber => Driver.FindElement(By.CssSelector("div[class='ph-widget ph-select form-control js-filter-select ph-select-multiple'] [class='ph-label']"));

        public IWebElement ProductStatus => Driver.FindElement(By.CssSelector("#card_grid > div:nth-child(2) > div > div > div.card-section-btm > div:nth-child(1) > p.product-stock-status.text-availability-in_stock"));

        public IWebElement AddToBacket => Driver.FindElement(By.Id("card_grid")).FindElement(By.XPath("//div[@class='card-item js-product-data' and @data-name='Card memorie SanDisk SDXC Extreme, 256GB, UHS-I']")).FindElement(By.CssSelector("form>button"));

        public IWebElement NumberOfSearchResults => Driver.FindElement(By.CssSelector(".listing-panel-heading .title-phrasing.title-phrasing-sm"));

        public IWebElement AcceptCookiesLaterBtn => Driver.FindElement(By.CssSelector("div.gdpr-cookie-banner.js-gdpr-cookie-banner.show .cookie-banner-buttons button.btn.btn-link.js-later"));

        public void SeachProduct(string productName)
        {
            SearchBox.EnterText(productName);
        }

        public void ClickSearch()
        {
            SeachIcon.ClickElement();
            Console.WriteLine("Search Executed");
        }

        public string GetProductStatus()
        {
            string productStatus = ProductStatus.GetAttribute("innerText");
            return productStatus;
        }

        public void VerifyAddToBacketEnabled()
        {
            if (AddToBacket.Enabled)
                Console.WriteLine("Button is enabled");
            else
                Console.WriteLine("Button is disabled");
        }

        public void SelectPromotions()
        {
            Promotions.ClickElement();
            Console.WriteLine("The <Promotii> Option Checked");
        }

        public void SelectDelivereByEmagOption()
        {
            MoveToMyElement(DeliveredByList);
            DeliveredByEMagOption.ClickElement();
            Console.WriteLine("The <eMAG> Option Checked");
        }

        public void SelectDeliveredByBetBuyTechOption()
        {
            MoveToMyElement(DeliveredByList);
            DeliveredByBetBuyTechOption.ClickElement();
            Console.WriteLine("The <eMAG> Option Checked");
        }

        public void SelectDeliveredByVexioOption()
        {
            MoveToMyElement(DeliveredByList);
            DeliveredByVexioOption.ClickElement();
            Console.WriteLine("The <Vexio> Option Checked");
        }

        public string GetNumberOfPromotions()
        {
            string NumberOfPromotionalProducts = NumberOfPromotions.GetAttribute("innerText");
            string NumberWithBrackets = NumberOfPromotionalProducts;
            string NumberWithoutBrackets = NumberWithBrackets.Split('(', ')')[1];
            Console.WriteLine("The number for the <Promotii. option is " + NumberWithoutBrackets);
            return NumberWithoutBrackets;
        }

        public string GetNumberOfSearchedResults()
        {
            string NumberOfSearchResults = Driver.FindElement(By.XPath("//div[@class='listing-panel-heading']")).FindElement(By.XPath("//span[@class='title-phrasing title-phrasing-sm']")).GetAttribute("innerText");
            var TextOfSearchResults = NumberOfSearchResults;
            var FirstWord = TextOfSearchResults.Substring(0, TextOfSearchResults.IndexOf(" "));
            Console.WriteLine("The number of search results is " + FirstWord);
            return FirstWord;
        }

        public void MoveToMyElement(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public int GetNumberOfDeliveredByCheckedOptionsThree()
        {
            MoveToMyElement(DeliveredByList);
            int myCount = Driver.FindElements(By.CssSelector("div[data-name='Livrat de'] div div:nth-child(2) a[data-is-selected='1']")).Count();
            Console.WriteLine(myCount);
            return myCount;
        }

        public int GetNumberOfDeliveredBy()
        {
            MoveToMyElement(DeliveredByNumber);
            string DeliveredByText = DeliveredByNumber.GetAttribute("innerText");
            string DeliveredByNr = DeliveredByText.Split(' ')[0];
            int result = Int32.Parse(DeliveredByNr);
            Console.WriteLine(result);
            return result;
        }

        public void AcceptCookiesLater()
        {
            AcceptCookiesLaterBtn.ClickElement();
        }
    }
}