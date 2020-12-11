using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GeneralTest.Config;
using GeneralTest.Defines;
using GeneralTest.PageMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace GeneralTest.TestCases
{
    // TESTSCRIPT CUA PHAN YEU CAU CHUNG
    class SignUpTest : ExtentReport
    {
        // paths
        public String uploadFilePath = $"{Helper.getRootPath()}GeneralTest\\Assets\\truc.jpg";

        // page
        SignUpPage signUpPage;

        [Test]
        [Category("SignUp")]
        public void signUpTest()
        {
            signUpPage = new SignUpPage(getDriver());
            signUpPage.navigateToLoginPage();

            //
            signUpPage.clickSignUp();
            logPass("button, click passed");
            //
            signUpPage.enterFullName("seleniumdemo01");
            signUpPage.enterAccount("seleniumdemo01");
            signUpPage.enterPassword("Ahihi123");
            signUpPage.enterRePassword("Ahihi123");
            logPass("Name, Id, TextBox, Linktext passed");
            // 
            signUpPage.chooseBirthday(29, 3, 2000);
            logPass("Dropdown, CssSelector passed");
            //
            signUpPage.solveRadioButton();
            logPass("Radio button passed");
            //
            //signUpPage.clickSubmit();
            //logPass("Submitbutton passed);
        }

        [Test]
        [Category("OtherEvent")]
        public void dragAndDropTest()
        {
            IWebDriver seleDriver = getDriver();
            seleDriver.Url = "http://demo.guru99.com/test/drag_drop.html";

            //Element which needs to drag.    		
            var from = seleDriver.FindElement(By.XPath("//*[@id='credit2']/a"));

            //Wait 1s, then we start drag bank to droppable area
            Thread.Sleep(1000);

            //Element on which need to drop.		
            var to = seleDriver.FindElement(By.XPath("//*[@id='bank']/li"));

            //Using Action class for drag and drop.		
            Actions act = new Actions(seleDriver);

            //Dragged and dropped.		
            act.DragAndDrop(from, to).Build().Perform();
        }

        [Test]
        [Category("OtherEvent")]
        public void checkboxTest()
        {
            IWebDriver seleDriver = getDriver();
            seleDriver.Url = "http://the-internet.herokuapp.com";
            seleDriver.FindElement(By.LinkText("Checkboxes")).Click();
            IList<IWebElement> checkbox = seleDriver.FindElements(By.CssSelector("input[type='checkbox']"));
            int size = checkbox.Count();
            bool selected = checkbox.ElementAt(1).Selected;
            for (int i = 0; i < size; i++)
            {
                if (selected == true && i == 0)
                {
                    checkbox[0].Click();
                }
            }
        }

        [Test]
        [Category("OtherEvent")]
        public void tableTest()
        {
            getDriver().Url = "https://ncov.moh.gov.vn/";
            String prefix = "//table[@id='sailorTable']/tbody/tr[1]/";
            String pacient = getDriver().FindElement(By.XPath($"{prefix}td[1]")).Text.ToString();
            String age = getDriver().FindElement(By.XPath($"{prefix}td[2]")).Text.ToString();
            String location = getDriver().FindElement(By.XPath($"{prefix}td[4]")).Text.ToString();
            String status = getDriver().FindElement(By.XPath($"{prefix}td[5]")).Text.ToString();
            String nation = getDriver().FindElement(By.XPath($"{prefix}td[6]")).Text.ToString();
            logInfo($"pacient: {pacient}; age: {age}; location: {location}; status: {status}; nation: {nation}\n");
        }

        [Test]
        [Category("OtherEvent")]
        public void clickOnImageTest()
        {
            getDriver().Url = "https://www.facebook.com/login/identify?ctx=recover";

            // find facebook image
            var facebookImage = getDriver().FindElement(By.CssSelector("a[title=\"Vào Trang chủ Facebook\"]"));

            //"Wait 1s, then we click on facebook image"
            Thread.Sleep(1000);

            // click on image
            facebookImage.Click();
        }

        [Test]
        [Category("OtherEvent")]
        public void downloadTest()
        {
            getDriver().Navigate().GoToUrl("http://the-internet.herokuapp.com");
            initEnvironmentVeriable();
            getDriver().FindElement(By.LinkText("File Download")).Click();
            getDriver().FindElement(By.CssSelector(".example a[href=\"download/some-file.txt\"]")).Click();
        }

        [Test]
        [Category("OtherEvent")]
        public void uploadTest()
        {
            getDriver().Url = "http://the-internet.herokuapp.com";
            initEnvironmentVeriable();
            getDriver().FindElement(By.LinkText("File Upload")).Click();
            getDriver().FindElement(By.Id("file-upload")).SendKeys(uploadFilePath);
            getDriver().FindElement(By.Id("file-submit")).Submit();
        }

    }
}
