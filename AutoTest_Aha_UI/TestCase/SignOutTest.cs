using Ahasoft_Autionmation.Ahasoft_Autionmation.Source.Common;
using Ahasoft_Autionmation.Source.Pages;
using AutoTest_Aha_UI.LoginHelper;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahasoft_Autionmation.Testcase
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    [AllureSuite("SignOut Feature")]
    [AllureFeature("SignOut Feature")]
    [AllureEpic("Ahasoft website")]
    public class SignOutTest : TestBase
    {
        private string urlHomepage = "https://ahasoft-ui-salon-admin-staging.azurewebsites.net/#/";
        private string ExpectConfirmAlert = "아하소프트 플러스 로그인";
        private string ExpectCancelAlert = "img";

        [Test(Description = "SignOut when clicking Conform button on SignOut modal")]
        [AllureStory("Confirm signout")]
        public void ConfirmSignOut()
        {
            /* HomePage homepage = new HomePage();
             LoginPage loginPage = new LoginPage();
             _driver.Navigate().GoToUrl(urlHomepage);
             homepage.ConfirmSignOut();
             Assert.AreEqual(ExpectConfirmAlert, loginPage.titleLoginPage.Text);*/

            HomePage homepage = new HomePage();
            LoginPage loginPage = new LoginPage();
            SessionManager session = SessionManager.Instance;
            session.SetCredentials("vpsalon1", "abcd@1234");
            _driver.Navigate().GoToUrl(urlHomepage);
            homepage.ConfirmSignOut();
            Assert.AreEqual(ExpectConfirmAlert, loginPage.titleLoginPage.Text);
        }

        [Test(Description = "SignOut when clicking Cancel button on SignOut modal")]
        [AllureStory("Cancel signout")]
        public void CancelSignOut()
        {
            HomePage homePage = new HomePage();
            LoginPage loginPage = new LoginPage();
            SessionManager session = SessionManager.Instance;
            session.SetCredentials("vpsalon1", "abcd@1234");
            _driver.Navigate().GoToUrl(urlHomepage);
            homePage.CancelSignOut();
            Assert.AreEqual(ExpectCancelAlert, loginPage._tagNameLogo.TagName);
        }
    }
}