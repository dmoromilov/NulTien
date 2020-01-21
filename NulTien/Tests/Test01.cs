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

        [Test]
        public void test01()
        {
            UltimateQA test = new UltimateQA(this);
            test.populateName("test");
            test.populateMessage("test");
            test.populateResult("-1");
            test.clickSubmitBtn();
        }
    }
}