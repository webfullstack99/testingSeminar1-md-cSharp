using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralTest.Config;
using GeneralTest.Defines;
using GeneralTest.PageMethods;
using NUnit.Framework;

namespace GeneralTest.TestCases
{

    // TESTSCRIPT CUA PHAN YEU CAU RIENG
    class SenDoTest : ExtentReport
    {

        SenDoPage sendoPage;

        [Test]
        public void test()
        {
            sendoPage = new SenDoPage(getDriver());
            sendoPage.navigateToLoginPage();
            sendoPage.moveToNavbar();
            sendoPage.clickProductBranch();
            sendoPage.checkFreeShipCheckbox();
            sendoPage.chooseBestSeller();

            // get filtered list
            List<Product> itemList = sendoPage.getFilteredItemList();

            // show info
            Console.WriteLine ("filtered: "+itemList.Count);
            foreach(Product item in itemList)
            {
                Console.WriteLine (item.showInfo());
            }
        }

    }
}
