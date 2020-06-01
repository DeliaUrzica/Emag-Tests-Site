using Emag_Tests_Site.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emag_Tests_Site.Tests
{
    public sealed class Test1 : BaseTests
    {
        [Test]
        public void ProductAvailableInStock()
        {
            // Go to Emag
            InstanceOf<BasePage>().GoToEmag();
            System.Threading.Thread.Sleep(1000);

            // Search for the product
            InstanceOf<SearchPage>().SeachProduct("Card memorie SanDisk SDXC Extreme, 256GB, UHS-I");
            InstanceOf<SearchPage>().ClickSearch();
            System.Threading.Thread.Sleep(1000);

            // Verify that tha product is in Stock
            string displayedProductStatus = InstanceOf<SearchPage>().GetProductStatus();
            Assert.AreEqual("în stoc", displayedProductStatus);

            InstanceOf<SearchPage>().VerifyAddToBacketEnabled();
            System.Threading.Thread.Sleep(5000);
        }
    }
}
