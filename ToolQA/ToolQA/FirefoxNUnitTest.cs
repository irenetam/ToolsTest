using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolQA
{
    class FirefoxNUnitTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver(Environment.CurrentDirectory);
        }

        [Test]
        public void OpenTestApp()
        {
            driver.Url = "http://test.efms.itlvn.com";
            driver.FindElement(By.XPath(".//*[@id='0']/a/i[2]")).Click();
            driver.FindElement(By.Id("0-0")).Click();
            var pageName = driver.FindElement(By.XPath(".//*[@id='m_header_nav']/div[1]/h3")).Text;
            Assert.AreEqual("Warehouse", pageName);
            //driver.FindElement(By.ClassName("icon-plus7")).Click();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
