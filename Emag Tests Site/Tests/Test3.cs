using Emag_Tests_Site.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emag_Tests_Site.Tests
{
    public sealed class Test3 : BaseTests
    {
        [Test]
        public void CheckFiterNumber()
        {
            // Go to Emag
            InstanceOf<BasePage>().GoToEmag();
            System.Threading.Thread.Sleep(1000);

            // Search for the product
            InstanceOf<SearchPage>().SeachProduct("Card memorie SanDisk SDXC Extreme, 256GB, UHS-I");
            InstanceOf<SearchPage>().ClickSearch();

            // Select Promotions option
            System.Threading.Thread.Sleep(1000);
            InstanceOf<SearchPage>().SelectPromotions();
            System.Threading.Thread.Sleep(2000);

            // Check the "eMAG ", "Best Buy Tech" and "VEXIO" options under the "Livrat de" filter option
            InstanceOf<SearchPage>().AcceptCookiesLater();
            System.Threading.Thread.Sleep(4000);
            InstanceOf<SearchPage>().SelectDelivereByEmagOption();
            System.Threading.Thread.Sleep(4000);
            InstanceOf<SearchPage>().SelectDeliveredByBetBuyTechOption();
            System.Threading.Thread.Sleep(4000);
            InstanceOf<SearchPage>().SelectDeliveredByVexioOption();
            System.Threading.Thread.Sleep(4000);

            // Verify if the number of Delivered by options match the expectations
            int numberOfDeliveredByOptionsSelected = InstanceOf<SearchPage>().GetNumberOfDeliveredByCheckedOptionsThree();
            int numberOfDeliveredBy = InstanceOf<SearchPage>().GetNumberOfDeliveredBy();
            System.Threading.Thread.Sleep(2000);
            Assert.AreEqual(3, numberOfDeliveredByOptionsSelected);
            Assert.AreEqual(numberOfDeliveredBy, numberOfDeliveredByOptionsSelected);
            System.Threading.Thread.Sleep(6000);
        }
    }
}
