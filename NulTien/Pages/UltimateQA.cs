using NulTien.Drivers;
using NUnit.Framework;
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

        //Constructor
        public UltimateQA(DriverManager driverManager)
        {
            this.driver = driverManager.getDriver();
            this.wait = driverManager.getWait();
            PageFactory.InitElements(driver, this);
        }

        //Locator for HTML element
        [FindsBy(How = How.Id, Using = "et_pb_contact_name_1")]
        private IWebElement name;

        //Locator for HTML element
        [FindsBy(How = How.XPath, Using = "//*[@id='et_pb_contact_message_1']")]
        private IWebElement message;

        //Locator for HTML element
        [FindsBy(How = How.XPath, Using = "//input[@class='input et_pb_contact_captcha']")]
        private IWebElement result;

        //Locator for HTML element
        [FindsBy(How = How.XPath, Using = "//*[@id='et_pb_contact_form_1']/div[2]/form/div/button")]
        private IWebElement submit;

        //Locator for HTML element
        [FindsBy(How = How.ClassName, Using = "et_pb_contact_captcha_question")]
        private IWebElement numbers;

        //Locator for HTML element
        [FindsBy(How = How.XPath, Using = "//*[@id='et_pb_contact_form_1']/div/p[1]")]
        private IWebElement successMessage;

        //Locator for HTML element
        [FindsBy(How = How.XPath, Using = "//div[@class='et-pb-contact-message']/ul[1]/li[1]")]
        private IWebElement wrongMessage;


        //Method to populate filed NAME
        public UltimateQA populateName(String n)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("et_pb_contact_name_1")));
            name.Click();
            name.SendKeys(n);
            return this;
        }

        //Method to populate filed MESSAGE
        public UltimateQA populateMessage(String m)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("et_pb_contact_name_1")));
            message.Click();
            message.SendKeys(m);
            return this;
        }

        //Method to populate filed captcha_question
        public UltimateQA populateResult(String r)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='input et_pb_contact_captcha']")));
            result.Click();
            result.SendKeys(r);
            return this;
        }

        //Method to click on [SUBMIT] btn
        public UltimateQA clickSubmitBtn()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='et_pb_contact_form_1']/div[2]/form/div/button")));
            submit.Click();
            return this;
        }

        //Method to get firstNumber from captcha_question
        public String getFirstNumber()
        {
            String numbers1 = numbers.Text;
            String firstNumber = numbers1.Substring(0, numbers1.IndexOf(' '));
            return firstNumber;
        }

        //Method to get secondNumber from captcha_question
        public String getSecondNumber()
        {
            String numbers2 = numbers.Text;
            String secondNumber = numbers2.Substring(numbers2.IndexOf('+'));
            secondNumber = secondNumber.Replace(" ", string.Empty).Replace("+", string.Empty);
            return secondNumber;
        }

        //Method to compare numbers from captcha_question
        public UltimateQA compareNumbers(String firstNumber, String secondNumbers)
        {
            String firsNumber2 = getFirstNumber();
            String secondNumber2 = getSecondNumber();
            getExceptionMessage(firstNumber.Equals(firsNumber2), secondNumbers.Equals(secondNumber2));
            return this;
        }

        //Method to write exception message
        public UltimateQA getExceptionMessage (Boolean firstNumberCompare, Boolean secondNumberCompare)
        {
            if ((firstNumberCompare == true) && (secondNumberCompare == true))
            {
                throw new Exception("Both Digits did not change after submit");
            }
            else if ((firstNumberCompare == true) && (secondNumberCompare == false))
            {
                throw new Exception("First Digit did not change after submit");
            }
            else if ((firstNumberCompare == false) && (secondNumberCompare == true))
            {
                throw new Exception("Second Digit did not change after submit");
            }
            else
            {
                Console.WriteLine("Both Digits changed after submit");
            }
            return this;
        }

        //Method to sumNumbers from captcha_question
        public UltimateQA sumNumbers(String t)
        {
            String firstNumber = getFirstNumber();
            String secondNumber = getSecondNumber();
            int SUM = int.Parse(firstNumber) + int.Parse(secondNumber);
            String total = Convert.ToString(SUM);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='input et_pb_contact_captcha']")));
            result.Click();
            result.SendKeys(total);
            return this;
        }

        //Method to get element with 'SUCCESS' message
        public String getSuccessMessage()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='et_pb_contact_form_1']/div/p[1]")));
            String successMess = successMessage.Text;
            return successMess;
        }

        //Method to get element with 'FAIL' message
        public String getWrongMessage() 
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='et-pb-contact-message']/ul[1]/li[1]")));
            String wrongMess = wrongMessage.Text;
            return wrongMess;
        }

        //Method to check "Success" text
        public UltimateQA checkSuccessMessage()
        {
            if (!((getSuccessMessage()).Equals("Success")))
            {
                throw new Exception("Expected Success Message is not displayed");
            }
            else
            {
                Console.WriteLine("Expected Success Message is displayed");
            }
            return this;
        }

        //Method to check "You entered the wrong number in captcha." text
        public UltimateQA checkFailMessage ()
        {
            if(!((getWrongMessage()).Equals("You entered the wrong number in captcha.")))
            {
                throw new Exception("Expected fail message is not displayed");
            }
            else
            {
                Console.WriteLine("Expected fail message is displayed");
            }
            return this;
        }
    }
}
