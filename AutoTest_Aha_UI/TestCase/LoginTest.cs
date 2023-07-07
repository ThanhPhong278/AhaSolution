using Ahasoft_Autionmation.Ahasoft_Autionmation.Source.Common;
using Ahasoft_Autionmation.Source.Pages;
using AutoTest_Aha_UI.LoginHelper;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahasoft_Autionmation.Testcase
{
    [AllureNUnit]
    [AllureSuite("Login Feature")]
    [AllureFeature("Login Feature")]
    [AllureEpic("Ahasoft website")]
    public class LoginTest : TestBase
    {
        private string urlLoginpage = "https://www.ahasoft.co.kr/login/login_form_salon.asp?env=staging";
        private string Expect = "img";

        [Test(Description = "Login with valid username and password")]
        [AllureStory("Login with valid")]
        public void testLogin()
        {
            /*LoginPage loginpage = new LoginPage();
            _driver.Navigate().GoToUrl(urlLoginpage);
            loginpage.Login("vpsalon1", "abcd@1234");
            Assert.AreEqual(Expect, loginpage._tagNameLogo.TagName);*/

            LoginPage loginPage = new LoginPage();
            SessionManager session = SessionManager.Instance;
            session.SetCredentials("vpsalon1", "abcd@1234");
            _driver.Navigate().GoToUrl(urlLoginpage);
            loginPage.Login();
        }
    }
}