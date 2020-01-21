using NulTien.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NulTien.Pages
{
    class UltimateQA
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public UltimateQA(DriverManager driverManager)
        {
            this.driver = driverManager.getDriver();
            this.wait = driverManager.getWait();
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "et_pb_contact_name_1")]
        private IWebElement name;

        [FindsBy(How = How.XPath, Using = "//*[@id='et_pb_contact_message_1']")]
        private IWebElement message;

        [FindsBy(How = How.XPath, Using = "//input[@class='input et_pb_contact_captcha']")]
        private IWebElement result;

        [FindsBy(How = How.XPath, Using = "//*[@id='et_pb_contact_form_1']/div[2]/form/div/button")]
        private IWebElement submit;

        public UltimateQA populateName(String n)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("et_pb_contact_name_1")));
            name.Click();
            name.SendKeys(n);
            return this;
        }

        public UltimateQA populateMessage(String m)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("et_pb_contact_name_1")));
            message.Click();
            message.SendKeys(m);
            return this;
        }

        public UltimateQA populateResult(String r)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='input et_pb_contact_captcha']")));
            result.Click();
            result.SendKeys(r);
            return this;
        }

        public UltimateQA clickSubmitBtn()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='et_pb_contact_form_1']/div[2]/form/div/button")));
            submit.Click();
            return this;
        }
    }
}
