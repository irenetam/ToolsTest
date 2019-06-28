using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace eTMS.PageObjects
{
    public class LoginPage: BaseObject
    {
        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='formLogin']/div/div/div[3]/button")]
        public IWebElement LoginButton { get; set; }
    }
}
