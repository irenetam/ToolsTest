using eTMS.PageObjects;
using eTMS.SeleniumHelpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace eTMS.TestCases
{
    public class LoginTestCase
    {

        public IWebDriver driver;
        [SetUp]
        public void StartUpTest()// This method fire at the start of the Test
        {
            Browsers.Init();
        }

        [Test]
        public void OpenBrowser()
        {
            driver = Browsers.GetDriver;
            var login = new LoginPage();
            login.UserName.SendKeys("abc");
            login.Password.SendKeys("abc");
            login.LoginButton.Click();
            Thread.Sleep(100);
        }

        [TearDown]
        public void EndTest()// This method will fire at the end of the Test
        {
            Browsers.Close();
        }
    }
}
