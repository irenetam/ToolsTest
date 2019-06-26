using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject_EFMS.SeleniumHelpers;

namespace UnitTestProject_EFMS.PageObjects
{
    public class WarehousePage : BaseObject
    {
        [FindsBy(How = How.Id, Using = "warehouse-data-master")]
        public IWebElement TableData { get; set; }
        
        [FindsBy(How = How.Id, Using = "children-0-0")]
        public IWebElement WarehouseMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='bodyElement']/app-root/app-master-page/div[1]/div/app-warehouse/div[1]/div/div[2]/app-default-button[1]")]
        public IWebElement AddNewButton { get; set; }

        [FindsBy(How = How.Id, Using = "add-ware-house-modal")]
        public IWebElement PopupAddWarehouse { get; set; }


        public void OpenWarehousePage()
        {
            this.WarehouseMenu.Click();
            Browsers.WaittimeFindElement(Browsers.getDriver, By.XPath("//*[@id='bodyElement']/app-root/app-master-page/div[1]/div/app-warehouse/div[1]/div/div[1]/app-breadcrumb/ul/li[3]/a/span"));
        }

        public void OpenAddNewPopup()
        {
            this.AddNewButton.Click();
            Browsers.WaittimeFindElement(Browsers.getDriver, By.Id("add-ware-house-modal"), 200);
        }
    }
}
