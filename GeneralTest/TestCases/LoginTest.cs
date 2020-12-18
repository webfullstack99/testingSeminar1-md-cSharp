using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralTest.Config;
using GeneralTest.PageMethods;
using NUnit.Framework;

namespace GeneralTest.TestCases
{

    // TESTSCRIPT CUA PHAN YEU CAU RIENG
    class LoginTest : ExtentReport
    {

        LoginPage loginPage;

        [Test]
        [Category("Login")]
        public void test_validLogin()
        {
            String email = "nguyenvana@gmail.com";
            String password = "12345678";
            testLogin(email, password);
        }

        [Test]
        [Category("Login")]
        public void test_validLogin2()
        {
            String email = "nguyenvanb@gmail.com";
            String password = "12345678";
            testLogin(email, password);
        }

        [Test]
        [Category("Login")]
        public void test_invalidPassword()
        {
            String email = "nguyenvana@gmail.com";
            String password = "fakepass";
            try
            {
                testLogin(email, password);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }
        }

        [Test]
        [Category("Login")]
        public void test_invalidEmail()
        {
            String email = "fakeemail@gmai.com";
            String password = "12345678";
            try { testLogin(email, password); }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }
        }

        public void testLogin(String email, String password)
        {
            logInfo($"<p>" +
                        $"<b>email:</b> {email}<br/>" +
                        $"<b>password:</b> {password}" +
                    $"</p>");
            loginPage = new LoginPage(getDriver());
            loginPage.navigateToLoginPage();
            loginPage.sendEmail(email);
            loginPage.clickAuthButton();
            loginPage.checkEmail();
            loginPage.sendPassword(password);
            loginPage.clickAuthButton();
            loginPage.checkLogged();
        }
    }
}
