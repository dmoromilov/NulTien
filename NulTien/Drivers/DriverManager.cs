using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NulTien.Drivers
{
    class DriverManager
    {
        private static IWebDriver driver;
        private static WebDriverWait wait;

        [SetUp]
        public static void setup()
        {
            setupDriverChrome();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public IWebDriver getDriver()
        {
            return driver;
        }

        public WebDriverWait getWait()
        {
            return wait;
        }

        public static void setupDriverChrome()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.ultimateqa.com/filling-out-forms/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
