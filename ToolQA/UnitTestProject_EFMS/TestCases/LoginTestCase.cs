using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject_EFMS.PageObjects;
using UnitTestProject_EFMS.SeleniumHelpers;
using UnitTestProject_EFMS.TestDataAccess;

namespace UnitTestProject_EFMS.TestCases
{
    class LoginTestCase
    {
        [SetUp]
        public void StartUpTest()// This method fire at the start of the Test
        {
            Browsers.Init();
        }
        [Test]
        public void OpenBrowser()
        {
        }
        [Test]
        public void LoginWithWrongUserNameAndPassTest() {
            var loginPage = new LoginPage();
            var driver = Browsers.getDriver;
            //PageFactory.InitElements(driver, loginPage);
            loginPage.UserName.SendKeys("TestUser_1");
            loginPage.Password.SendKeys("Test@123");
            loginPage.Submit.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var element = driver.FindElement(By.CssSelector("div[class='toast-error toast ng-trigger ng-trigger-flyInOut']"));
            //var element = driver.FindElement(By.XPath("//*[@id='toast - container']/div/div"));
            var s = element.GetAttribute("innerText");
            //element.GetAttribute("innerText").Contains("UserName or password incorrect !");
            Assert.IsTrue(s.Contains("Username or password incorrect !"));
            //toast-error toast ng-trigger ng-trigger-flyInOut
        }

        [Test]
        public void LoginWithEmptyUserNameAndPassTest()
        {
            var loginPage = new LoginPage();
            var driver = Browsers.getDriver;
            //PageFactory.InitElements(driver, loginPage);
            loginPage.UserName.SendKeys("");
            loginPage.Password.SendKeys("");
            loginPage.Submit.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var uElement = driver.FindElement(By.CssSelector("#login-form > div:nth-child(1) > div"));
            var pElement = driver.FindElement(By.CssSelector("#login-form > div:nth-child(2) > div"));
            var userNameText = uElement.GetAttribute("innerText");
            var passText = pElement.GetAttribute("innerText");
            var isInvalid = userNameText.Contains("Enter username please !") && passText.Contains("Enter password please !");
            Assert.IsTrue(isInvalid);
        }
        [Test]
        public void LoginSuccess()
        {
            var loginPage = new LoginPage();
            var driver = Browsers.getDriver;
            loginPage.LoginToApplication("LoginSuccess");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='m_header_topbar']/div/ul/li[5]/a/span/i")));
            var urlHome = driver.Url;
            if (urlHome.Equals("http://test.efms.itlvn.com/en/#/home/dashboard"))
            {
                ExcelDataAccess.SetResultTestData("LoginSuccess", "Passed");
            }
            else
            {
                ExcelDataAccess.SetResultTestData("LoginSuccess", "Failed");
            }
        }

        [TearDown]
        public void EndTest()// This method will fire at the end of the Test
        {
            Browsers.Close();
        }
    }
}
