using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject_EFMS.SeleniumHelpers;
using System.Linq;
using System.Threading;

namespace UnitTestProject_EFMS.PageObjects
{
    public class WarehouseModal: BaseObject
    {

        [FindsBy(How = How.Name, Using = "code")]
        public IWebElement Code { get; set; }
        
        [FindsBy(How = How.Name, Using = "warewhouseNameEN")]
        public IWebElement NameEn { get; set; }

        [FindsBy(How = How.Name, Using = "warewhouseNameLocal")]
        public IWebElement NameLocal { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='add-ware-house-modal']/div/div/form/div[2]/div/div[2]/div[1]/div/ng-select")]
        public IWebElement CountryDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='add-ware-house-modal']/div/div/form/div[2]/div/div[2]/div[2]/div/ng-select")]
        public IWebElement ProvinceDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='add-ware-house-modal']/div/div/form/div[2]/div/div[2]/div[3]/div/ng-select")]
        public IWebElement DistrictDropdown { get; set; }

        [FindsBy(How = How.Name, Using = "address")]
        public IWebElement Address { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='add-ware-house-modal']/div/div/form/div[3]/app-default-button[1]/button")]
        public IWebElement SaveButton { get; set; }

        public void AddNewWarehouse()
        {
            Code.SendKeys("a");
            NameEn.SendKeys("b");
            NameLocal.SendKeys("d");
            CountryDropdown.Click();
            IWebElement countryElementResults = Browsers.getDriver.FindElement(By.XPath("//*[@id='add-ware-house-modal']/div/div/form/div[2]/div/div[2]/div[1]/div/ng-select/div/ul"));
            List<IWebElement> countries = countryElementResults.FindElements(By.TagName("li")).ToList();
            if (countries.Count != 0)
            {
                countries.Find(x => x.Text == "Viet Nam").Click();
            }
            Thread.Sleep(100);
            ProvinceDropdown.Click();
            IWebElement provinceElementResults = Browsers.getDriver.FindElement(By.XPath("//*[@id='add-ware-house-modal']/div/div/form/div[2]/div/div[2]/div[2]/div/ng-select/div/ul"));
            List<IWebElement> provinces = provinceElementResults.FindElements(By.TagName("li")).ToList();
            if (provinces.Count != 0)
            {
                provinces.Find(x => x.Text == "Đồng Nai").Click();
            }

            Thread.Sleep(200);
            DistrictDropdown.Click();
            IWebElement districtElementResults = Browsers.getDriver.FindElement(By.XPath("//*[@id='add-ware-house-modal']/div/div/form/div[2]/div/div[2]/div[3]/div/ng-select/div/ul"));
            List<IWebElement> districts = districtElementResults.FindElements(By.TagName("li")).ToList();
            if (districts.Count != 0)
            {
                districts.Find(x => x.Text == "Biên Hòa").Click();
            }
            Address.SendKeys("âfafaf");
            Thread.Sleep(100);
            SaveButton.Click();
            var element = Browsers.WaittimeFindElement(Browsers.getDriver, By.Id("add-ware-house-modal"));
        }
    }
}
