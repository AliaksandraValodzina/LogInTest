using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    public class PageObject
    {
        private IWebDriver driver;

        #region Selectors

        By signInBy = By.Id("signIn");
        By emailBy = By.Id("email");
        By passwordBy = By.Id("passwd");
        By submitBy = By.Id("login");
        By accountNameBy = By.ClassName("email");

        By notExistingElementBy = By.Id("signIn");
        #endregion

        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
            NotExistinglement = driver.FindElement(notExistingElementBy);
        }

        public IWebElement NotExistinglement { get; set; }

        public PageObject LogIn(string userName, string password)
        {
            driver.FindElement(signInBy).Click();
            driver.FindElement(emailBy).SendKeys(userName);
            driver.FindElement(passwordBy).SendKeys(password);
            driver.FindElement(submitBy).Click();

            WaitUntilElementExists(accountNameBy);

            return this;
        }

        public IWebElement WaitUntilElementExists(By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(ExpectedConditions.ElementExists(elementLocator));
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
    }
}
