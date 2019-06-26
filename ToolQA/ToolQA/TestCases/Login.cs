using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using ToolQA.PageObjects;

namespace ToolQA.TestCases
{
    class Login
    {
        [Test]
        public void Test()
        {

            IWebDriver driver = new FirefoxDriver(Environment.CurrentDirectory);
            driver.Url = "http://www.store.demoqa.com";

            var homePage = new HomePage();
            PageFactory.InitElements(driver, homePage);
            homePage.MyAccount.Click();

            var loginPage = new LoginPage();
            PageFactory.InitElements(driver, loginPage);
            loginPage.UserName.SendKeys("TestUser_1");
            loginPage.Password.SendKeys("Test@123");
            loginPage.Submit.Submit();
        }
    }
}
