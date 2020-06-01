using Emag_Tests_Site.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emag_Tests_Site.Tests
{
    public sealed class Test2 : BaseTests
    {
        [Test]
        public void PromotionNumberEqualToResultsNumber()
        {
            // Go to Emag
            InstanceOf<BasePage>().GoToEmag();
            System.Threading.Thread.Sleep(1000);

            // Search for the product
            InstanceOf<SearchPage>().SeachProduct("Card memorie SanDisk SDXC Extreme, 256GB, UHS-I");
            InstanceOf<SearchPage>().ClickSearch();
            System.Threading.Thread.Sleep(1000);

            // Get the number for the "Promotii" option
            System.Threading.Thread.Sleep(1000);
            InstanceOf<SearchPage>().SelectPromotions();
            System.Threading.Thread.Sleep(1000);
            string numberOfPromotions = InstanceOf<SearchPage>().GetNumberOfPromotions();
            System.Threading.Thread.Sleep(1000);

            // Get the number for the search results
            string numberOfSearchResults = InstanceOf<SearchPage>().GetNumberOfSearchedResults();

            //verify if the number of promotions equals the number of search results
            Assert.AreNotEqual(numberOfPromotions, numberOfSearchResults);
        }
    }
}
