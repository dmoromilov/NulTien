using NulTien.Drivers;
using NulTien.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NulTien.Tests
{
    class Test01WrongMessage : DriverManager
    {
        String name = "test";
        String message = "test; test; test";
        String result = "-1";

        //Test TestCase-1
        [Test]
        public void test01()
        {
            UltimateQA test = new UltimateQA(this);
            test.populateName(name);  //populate filed [NAME]
            test.populateMessage(message); //populate filed [MESSAGE]
            test.populateResult(result); //populate filed from question
            String FIRST_NUMBER = test.getFirstNumber(); //get first number to string
            String SECOND_NUMBER = test.getSecondNumber(); //get second number to string
            test.clickSubmitBtn(); //click [SUBMIT] button
            test.compareNumbers(FIRST_NUMBER, SECOND_NUMBER); //compare string with new first and second numbers
            test.checkFailMessage(); //check 'Fail' message

        }
    }
}
//TestCase-1
//1. Open https://www.ultimateqa.com/filling-out-forms/
//2. Fill out the form on the right, but intentionally enter -1 as a result of addition
//3. Submit the form and confirm that the numbers have changed
//4. Close the browser