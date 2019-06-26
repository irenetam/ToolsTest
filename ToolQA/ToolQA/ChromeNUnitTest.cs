using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolQA
{
    class ChromeNUnitTest
    {
        IWebDriver driver;
        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }
        [Test]
        public void OpenTestApp()
        {
            driver.Url = "https://www.facebook.com/";
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
