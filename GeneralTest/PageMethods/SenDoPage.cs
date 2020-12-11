using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralTest.Defines;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace GeneralTest.PageMethods
{
    class SenDoPage : Page
    {

        public String emailInput = "#email";
        public String passwordInput = "#password";
        public String authButton = ".btn-auth-main";
        public String trash = ".trash-item";


        public SenDoPage(IWebDriver seleDriver) : base(seleDriver) { }

        public void navigateToLoginPage()
        {
            seleDriver.Navigate().GoToUrl("https://www.sendo.vn/");
        }

        public void moveToNavbar()
        {
            //IWebElement gmailLink = seleDriver.FindElement(By.LinkText(".megaMenuContainer a[href=\"/cong-nghe\I"]"));
            IWebElement gmailLink = seleDriver.FindElement(By.LinkText("Điện thoại"));
            Actions actionProvider = new Actions(seleDriver);
            // Performs mouse move action onto the element
            actionProvider.MoveToElement(gmailLink).Build().Perform();
        }

        public void clickProductBranch()
        {
            String linkText = "Samsung";
            waitForElementByLinkText(linkText);
            seleDriver.FindElement(By.LinkText(linkText)).Click();
            //IWebElement gmailLink = seleDriver.FindElement(By.LinkText(".megaMenuContainer a[href=\"/cong-nghe\I"]"));

        }

        public void checkFreeShipCheckbox()
        {
            String slt = ".container_iKiQ label:last-child";
            waitForElementByCssSelector(slt);
            var cb = seleDriver.FindElement(By.CssSelector(slt));
            cb.Click();
        }

        public void chooseBestSeller()
        {
            var element = seleDriver.FindElement(By.XPath("//li[text()='Bán chạy']"));
            element.Click();
        }

        public List<Product> getFilteredItemList()
        {
            System.Threading.Thread.Sleep(2000);
            // list_1VuX grid5_gtk- item_3KnU discountBadge_1GZz
            String discountClassName = ".discountBadge_1GZz";
            IList<IWebElement> itemList = seleDriver.FindElements(By.ClassName("item_3KnU"));
            List<Product> filteredItemList = new List<Product>();
            Console.WriteLine("\n\nTotal: " + itemList.Count);
            int i = 0;
            foreach (IWebElement item in itemList)
            {
                try
                {
                    IWebElement discountElem = item.FindElement(By.CssSelector(discountClassName));
                    String discountPercentString = discountElem.Text;
                    int discountPercent = Int32.Parse(discountPercentString.Replace("%", "").Trim());
                    if (discountPercent > 35)
                    {
                        String title = item.FindElement(By.CssSelector(".truncateMedium_Tofh")).Text;
                        String price = item.FindElement(By.CssSelector(".currentPrice_2hr9")).Text;
                        String oldPrice = item.FindElement(By.CssSelector(".oldPrice_itl0")).Text;
                        filteredItemList.Add(new Product(title, price, oldPrice, discountPercent));
                    }
                }
                catch (Exception ex) { }
            }
            return filteredItemList;
        }
    }
}
