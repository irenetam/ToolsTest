using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace ToolsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver(Environment.CurrentDirectory)
            {
                Url = "https://www.google.com/"
            };
            driver.Close();
        }
    }
}
