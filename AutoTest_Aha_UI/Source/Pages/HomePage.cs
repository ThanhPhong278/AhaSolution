using Ahasoft_Autionmation.Ahasoft_Autionmation.Source.Common;
using AutoTest_Aha_UI.LoginHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahasoft_Autionmation.Source.Pages
{
    public class HomePage : TestBase
    {
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/header[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/button[1]")] 
        private IWebElement _buttonSignOut;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/header[1]/div[1]/div[2]/div[1]/div[3]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/button[1]")]
        private IWebElement _confirmAlertSignOut;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/header[1]/div[2]/div[1]/div[3]/dl[1]/dd[3]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/button[2]")]
        private IWebElement _cancelAlertSignOut;

        public string _modalSignOut = "/html[1]/body[1]/div[1]/div[1]/header[1]/div[2]/div[1]/div[3]/dl[1]/dd[3]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]";

        public string _modalSignOut1 = "__BVID__61";

        public string _spinner = "#v-spinner";
        public HomePage()
        {
            PageFactory.InitElements(_driver, this);
        }

        public void ConfirmSignOut()
        {
            //LoginPage loginPage = new LoginPage();
            //loginPage.Login(/*"vpsalon1", "abcd@1234"*/);
            LoginPage loginPage = new LoginPage();
            loginPage.Login();
/*            _buttonSignOut.Click();
            _confirmAlertSignOut.Click();*/
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);

            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);

            fluentWait.IgnoreExceptionTypes(typeof(ElementNotSelectableException));

            _buttonSignOut.Click();
            // IWebElement ComposeButton = fluentWait.Until(dom => dom.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/header[1]/div[2]/div[1]/div[3]/dl[1]/dd[3]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/button[1]")));
            //ComposeButton.Click();

            fluentWait.Until(ExpectedConditions.ElementToBeClickable(_confirmAlertSignOut)).Click();
        }

        public void CancelSignOut()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Login(/*"vpsalon1", "abcd@1234"*/);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(250));
            //_buttonSignOut.Click();
            var result = wait.Until(ExpectedConditions.ElementToBeClickable(_buttonSignOut));
            result.Click();
            //_cancelAlertSignOut.Click();
            //var result1 = wait.Until(ExpectedConditions.ElementToBeClickable(_cancelAlertSignOut));
            //result.Click();

            Actions actions = new Actions(_driver);
            actions.MoveToElement(_cancelAlertSignOut).Click().Build().Perform();


        }
    }
}