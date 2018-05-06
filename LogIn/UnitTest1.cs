using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace LogIn
{
    [TestClass]
    public class UnitTest1
    {
        private PageObject pageObject;
        private IWebDriver driver;
        private ChromeOptions options;

        private string baceUrl = "https://www.myscore.com.ua/";

        [TestInitialize]
        public void TestInitialize()
        {
            options = new ChromeOptions();
            options.AddArgument(@"C:\Users\Volodin\Documents\Visual Studio 2015\Projects\LogIn\LogIn\DriverOptions");

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(baceUrl);
            pageObject = new PageObject(driver);
        }


        [TestMethod]
        public void LogInTest()
        {
            pageObject.LogIn("https://www.myscore.com.ua/", "330419901512");
        }

        [TestMethod]
        public void ExeptionTest()
        {
            var testExeption = pageObject.NotExistinglement;
            var attr1 = testExeption.GetAttribute("class");
            var css = testExeption.GetCssValue("border-color");
            var size = testExeption.GetType();
            var one = testExeption.TagName;
            testExeption.Click();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
