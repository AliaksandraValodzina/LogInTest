using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace LogIn
{
    [TestClass]
    public class UnitTest1
    {
        private PageObject pageObject;
        private IWebDriver driver;
        private ChromeOptions options;

        private string baceUrl = "https://www.gmail.com";

        [TestInitialize]
        public void TestInitialize()
        {
            options = new ChromeOptions();
            options.AddArgument(@"C:\Users\Volodin\Documents\Visual Studio 2015\Projects\LogIn\LogIn\DriverOptions");

            driver = new ChromeDriver(options);
            pageObject = new PageObject(driver);
            driver.Navigate().GoToUrl(baceUrl);        }


        [TestMethod]
        public void LogInTest()
        {
            pageObject.SetUserNameAndPassword("shura.volodina@gmail.com", "130419901512");
            Assert.IsTrue(pageObject.IsTableVisible(), "Check that table appears on the page");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
