using NulTien.Drivers;
using NulTien.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NulTien.Tests
{
    class Test02SuccessMessage : DriverManager
    {
        String name = "test";
        String message = "test; test; test";

        //Test TestCase-2
        [Test]
        public void test02()
        {
            UltimateQA test = new UltimateQA(this);
            test.populateName(name); //populate filed [NAME]
            test.populateMessage(message); //populate filed [MESSAGE]
            test.sumNumbers(""); //sum numbers and populate the filed with result
            test.clickSubmitBtn(); //click [SUBMIT] btn
            test.checkSuccessMessage(); //check the 'SUCCESS' message
        }
    }
}
//TestCase-2
//1. Open https://www.ultimateqa.com/filling-out-forms/
//2. Fill out the form on the right, fill in the correct number
//3. Submit the form and confirm that a 'Success' message is displayed.
//4. Close the browser