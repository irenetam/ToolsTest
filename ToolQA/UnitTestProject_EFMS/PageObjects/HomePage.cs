using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject_EFMS.SeleniumHelpers;

namespace UnitTestProject_EFMS.PageObjects
{
    public class HomePage: BaseObject
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='m_header_topbar']/div/ul/li[5]/a/span/i")]
        public IWebElement LogoutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='m_ver_menu']/perfect-scrollbar/div/div[1]/ul")]
        public IWebElement MainMenu { get; set; }
        
        [FindsBy(How = How.Id, Using = "parent-0")]
        public IWebElement CatalogueMenu { get; set; }

        public void LoginSuccess()
        {
            var driver = Browsers.getDriver;
            var loginPage = new LoginPage();
            loginPage.LoginToApplication("LoginSuccess");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.XPath("//*[@id='m_header_topbar']/div/ul/li[5]/a/span/i")));
        }

        public void OpenCatalogueMenu()
        {
            this.CatalogueMenu.Click();
        }
    }
}
