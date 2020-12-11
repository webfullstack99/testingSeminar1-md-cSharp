using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GeneralTest.PageMethods
{
    class Page
    {
        protected IWebDriver seleDriver;

        public Page(IWebDriver seleDriver)
        {
            this.seleDriver = seleDriver;
        }

        public void waitForElementByCssSelector(String cssSelector)
        {
            WebDriverWait wait = new WebDriverWait(seleDriver, TimeSpan.FromSeconds(1));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }

        public void waitForElementByLinkText(String linkTest)
        {
            WebDriverWait wait = new WebDriverWait(seleDriver, TimeSpan.FromSeconds(1));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkTest)));
        }

        public void closeBrowser()
        {
            seleDriver.Quit();
        }

    }
}
