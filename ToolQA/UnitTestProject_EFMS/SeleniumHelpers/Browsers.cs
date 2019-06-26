using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace UnitTestProject_EFMS.SeleniumHelpers
{
    public class Browsers
    {
        private static IWebDriver webDriver;

        public static void Init()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appconfig.json").Build();

            var baseURL = config["TargetUrl"];
            var browser = config["DriverToUse"];
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver(Environment.CurrentDirectory);
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver(Environment.CurrentDirectory);
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver(Environment.CurrentDirectory);
                    break;
            }
            webDriver.Manage().Window.Maximize();
            Goto(baseURL);
        }
        public static string Title
        {
            get { return webDriver.Title; }
        }
        public static IWebDriver getDriver
        {
            get
            {
                if (webDriver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return webDriver;
            }
        }

        public static IWebElement WaittimeFindElement(IWebDriver driver, By by, double? second = null)
        {
            if (second == null) second = 10;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds((double)second));
            IWebElement element = wait.Until<IWebElement>(d => d.FindElement(by));
            return element;
        }

        public static void Waitime(IWebDriver driver, double? second = null)
        {
            if (second == null) second = 10;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds((double)second));
        }

        public static void Goto(string url)
        {
            webDriver.Url = url;
        }
        public static void Close()
        {
            webDriver.Quit();
        }
    }
}
