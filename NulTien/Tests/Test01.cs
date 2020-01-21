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
    class Test01 : DriverManager
    {
        String name = "test";
        String message = "test; test; test";
        String result = "-1";

        [Test]
        public void test01()
        {
            UltimateQA test = new UltimateQA(this);
            test.populateName(name);
            test.populateMessage(message);
            test.populateResult(result);
            test.clickSubmitBtn();
        }
    }
}