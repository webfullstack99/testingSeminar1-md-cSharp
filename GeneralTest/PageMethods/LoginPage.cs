using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace GeneralTest.PageMethods
{
    class LoginPage:Page
    {

        public String emailInput = "#email";
        public String passwordInput = "#password";
        public String authButton = ".btn-auth-main";
        public String trash = ".trash-item";


        public LoginPage(IWebDriver seleDriver) : base(seleDriver) { }

        public void navigateToLoginPage()
        {
            seleDriver.Navigate().GoToUrl("https://trangviet.web.app/auth/login");
        }

        public void sendEmail(String value)
        {
            seleDriver.FindElement(By.CssSelector(emailInput)).SendKeys(value);
        }

        public void checkEmail()
        {

            waitForElementByCssSelector(passwordInput);
        }

        public void sendPassword(String value)
        {
            seleDriver.FindElement(By.CssSelector(passwordInput)).SendKeys(value);
        }

        public void clickAuthButton()
        {

            seleDriver.FindElement(By.CssSelector(authButton)).Click();
        }

        public void checkLogged()
        {
            waitForElementByCssSelector(trash);

        }

    }
}

