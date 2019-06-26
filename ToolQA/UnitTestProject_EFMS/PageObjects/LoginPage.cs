using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject_EFMS.SeleniumHelpers;
using UnitTestProject_EFMS.TestDataAccess;

namespace UnitTestProject_EFMS.PageObjects
{
    public class LoginPage : BaseObject
    {
        [FindsBy(How = How.Name, Using = "u_name")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "u_password")]
        public IWebElement Password { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "button[class='btn btn-danger btn-block m-btn--uppercase m-btn--square']")]
        public IWebElement Submit { get; set; }

        [FindsBy(How = How.XPath, Using = "button[@type='button'][@class='btn btn-danger btn-block m-btn--uppercase m-btn--square']")]
        public IWebElement RememberMe { get; set; }

        public void LoginToApplication(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            UserName.SendKeys(userData.Username);
            Password.SendKeys(userData.Password);
            Submit.Click();
        }
    }
}
