using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using UnitTestProject_EFMS.PageObjects;
using UnitTestProject_EFMS.SeleniumHelpers;
using UnitTestProject_EFMS.TestDataAccess;
using System.Linq;

namespace UnitTestProject_EFMS.TestCases
{
    class WarehouseTestCase
    {
        [SetUp]
        public void StartUpTest()// This method fire at the start of the Test
        {
            Browsers.Init();
        }

        [Test]
        public void AccessWarehousePage()
        {
            var loginPage = new LoginPage();
            var driver = Browsers.getDriver;
            loginPage.LoginToApplication("LoginSuccess");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='m_header_topbar']/div/ul/li[5]/a/span/i")));
            var urlHome = driver.Url;
            if (urlHome.Equals("http://test.efms.itlvn.com/en/#/home/dashboard"))
            {
                var homePage = new HomePage();
                homePage.CatalogueMenu.Click();
                var warehouse = new WarehousePage();
                warehouse.WarehouseMenu.Click();
                IWebElement warehouseBreadcrum = wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='bodyElement']/app-root/app-master-page/div[1]/div/app-warehouse/div[1]/div/div[1]/app-breadcrumb/ul/li[3]/a/span")));
                if(warehouseBreadcrum.Text == "Ware House")
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Test]
        public void ShowPopupAddWarehouse()
        {
            var driver = Browsers.getDriver;
            var homePage = new HomePage();
            homePage.LoginSuccess();
            homePage.OpenCatalogueMenu();
            var warehouse = new WarehousePage();
            warehouse.OpenWarehousePage();
            warehouse.OpenAddNewPopup();
        }

        [Test]
        public void AddWarehouse()
        {
            var homePage = new HomePage();
            homePage.LoginSuccess();
            homePage.OpenCatalogueMenu();
            var warehousePage = new WarehousePage();
            warehousePage.OpenWarehousePage();
            warehousePage.OpenAddNewPopup();
            Thread.Sleep(100);
            WarehouseModal modal = new WarehouseModal();
            modal.AddNewWarehouse();
        }

        [TearDown]
        public void EndTest()// This method will fire at the end of the Test
        {
            Browsers.Close();
        }
    }
}
