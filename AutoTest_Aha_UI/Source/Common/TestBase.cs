using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Ahasoft_Autionmation.Ahasoft_Autionmation.Source.Common
{
    public class TestBase
    {
        [ThreadStatic]
        public static IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            _driver.Manage().Window.Maximize();
            //set time for each step is 10s
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            //set time for load page
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                byte[] content = ((ITakesScreenshot)_driver).GetScreenshot().AsByteArray;
                AllureLifecycle.Instance.AddAttachment("Failed Screenshot", "image/png", content);
            }
            else 
            {
                byte[] content = ((ITakesScreenshot)_driver).GetScreenshot().AsByteArray;
                AllureLifecycle.Instance.AddAttachment("Passed Screenshot", "image/png", content);
            }
            Thread.Sleep(2000);
            _driver.Quit();
        }

        /* protected void WaitUntilElementVisible(By by)
         {
             var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
             wait.Until(ExpectedConditions.ElementToBeClickable(by));
         }*/

    }

}