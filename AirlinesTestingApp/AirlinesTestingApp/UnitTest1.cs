using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AirlinesTestingApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Init driver
            var driver = new ChromeDriver();
            //Navigate to tab
            driver.Navigate().GoToUrl("https://www.aircaraibes.com/");
            //Close ads
            driver.FindElementByClassName("optanon-alert-box-close").Click();
            //Click checkbox for one-way ticket
            Thread.Sleep(1000);
            var chkBox = driver.FindElement(By.Id("departure-only"));
            chkBox.Click();
            //Assert that "date from" is disabled
            var el = driver.FindElementById("edit-b-date-2-booking-0");
            if (el.Enabled != false)
            {
                throw new AssertFailedException();
            }
            var el1 = driver.FindElementById("uniform-edit-date-range-value-2");
            var classNames = el1.GetAttribute("className");
            if (!classNames.Contains("disabled"))
            {
                throw new AssertFailedException();
            }
        }
    }
}
