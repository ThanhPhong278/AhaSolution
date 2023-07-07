using Ahasoft_Autionmation.Ahasoft_Autionmation.Source.Common;
using AutoTest_Aha_UI.LoginHelper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahasoft_Autionmation.Source.Pages
{
    public class LoginPage : TestBase
    {
        [FindsBy(How = How.XPath, Using = "html[1]/body[1]/main[1]/section[1]/div[1]/form[1]/p[4]/button[1]")]
        private IWebElement _buttonLogin;

        [FindsBy(How = How.Id, Using = "salon_id")]
        private IWebElement _fieldUsername;

        [FindsBy(How = How.Id, Using = "salon_pass")]
        private IWebElement _fieldPassword;

        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/header[1]/div[1]/div[2]/div[1]/div[1]/a[1]/img[1]")]
        public IWebElement _tagNameLogo;

        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'아하소프트 플러스 로그인')]")]
        public IWebElement titleLoginPage;

        public LoginPage()
        {
            PageFactory.InitElements(_driver, this);
        }

        public void Login(/*string usernaname, string password*/)
        {
            /*_fieldUsername.Clear();
            _fieldUsername.SendKeys(usernaname);
            _fieldPassword.Clear();
            _fieldPassword.SendKeys(password);
            _buttonLogin.Click();*/

            SessionManager session = SessionManager.Instance;
            _fieldUsername.Clear();
            _fieldUsername.SendKeys(session.GetUsername());
            _fieldPassword.Clear();
            _fieldPassword.SendKeys(session.GetPassword());
            _buttonLogin.Click();

        }
    }
}