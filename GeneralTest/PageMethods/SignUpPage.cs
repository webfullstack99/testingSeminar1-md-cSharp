using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GeneralTest.PageMethods
{
    class SignUpPage:Page
    {
        public SignUpPage(IWebDriver seleDriver) : base(seleDriver) { }

        public void navigateToLoginPage()
        {
            seleDriver.Navigate().GoToUrl("http://id.zing.vn/");
        }

        public void clickSignUp()
        {
            seleDriver.FindElement(By.LinkText("Đăng ký ngay")).Click();
        }

        public void enterFullName(String value)
        {
            seleDriver.FindElement(By.CssSelector("#regacc_fullname")).SendKeys(value);
        }

        public void enterAccount(String value)
        {
            seleDriver.FindElement(By.CssSelector("#regacc_account")).SendKeys(value);
        }

        public void enterPassword(String value)
        {
            seleDriver.FindElement(By.Id("regacc_pwd")).SendKeys(value);
        }

        public void enterRePassword(String value)
        {
            seleDriver.FindElement(By.Name("re_pwd")).SendKeys(value);
        }

        public void chooseBirthday(int d, int m, int y)
        {
            IWebElement element1 = seleDriver.FindElement(By.CssSelector("select[id='dob']"));
            SelectElement objectSelect1 = new SelectElement(element1);
            objectSelect1.SelectByValue($"{d}");

            IWebElement element2 = seleDriver.FindElement(By.Id("mob"));
            SelectElement objectSelect2 = new SelectElement(element2);
            objectSelect2.SelectByValue($"{m}");

            IWebElement element3 = seleDriver.FindElement(By.Id("yob"));
            SelectElement objectSelect3 = new SelectElement(element3);
            objectSelect3.SelectByValue($"{y}");
        }

        public void solveRadioButton()
        {
            IList<IWebElement> radioButton = seleDriver.FindElements(By.Name("gender"));
            int Size = radioButton.Count;
            for (int i = 0; i < Size; i++)
            {
                // Store the raidobutton name to the string variable, using 'Value' attribute
                String Value = radioButton.ElementAt(i).GetAttribute("value");

                // Select the radio box for female where value = 0
                if (Value.Equals("0"))
                {
                    radioButton.ElementAt(i).Click();
                    // This will take the execution out of for loop
                    break;
                }
            }

        }

        public void clickSubmit()
        {
            seleDriver.FindElement(By.LinkText("Đăng ký")).Submit();
        }

    }
}
