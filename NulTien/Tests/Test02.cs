using NulTien.Drivers;
using NulTien.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NulTien.Tests
{
    class Test02 : DriverManager
    {
        String name = "test";
        String message = "test; test; test";

        //Test TASK2
        [Test]
        public void test02()
        {
            UltimateQA test = new UltimateQA(this);
            test.populateName(name); //populate filed [NAME]
            test.populateMessage(message); //populate filed [MESSAGE]
            test.sumNumbers(""); //sum numbers and populate the filed
            test.clickSubmitBtn(); //click [SUBMIT] btn
            test.checkSuccessMessage(); //check the 'SUCCESS' message
        }
    }
}
