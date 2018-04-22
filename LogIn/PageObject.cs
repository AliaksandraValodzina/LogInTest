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

        By userNameBy = By.CssSelector("input[type = 'email']");
        By nextButtonBy = By.CssSelector("div[role = 'button']");
        By passwordBy = By.CssSelector("input[type = 'password']");
        By tableBy = By.Id("div[role = 'tabpanel']/tbody']");
        #endregion

        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public PageObject SetUserNameAndPassword(string userName, string password)
        {
            driver.FindElement(userNameBy).Clear();
            driver.FindElement(userNameBy).SendKeys(userName);
            driver.FindElement(nextButtonBy).Click();

            this.WaitUntilElementExists(passwordBy);
            driver.FindElement(passwordBy).Clear();
            driver.FindElement(passwordBy).SendKeys(password);
            driver.FindElement(nextButtonBy).Click();

            this.WaitUntilElementExists(tableBy);

            return this;
        }

        public bool IsTableVisible()
        {
            return driver.FindElement(tableBy).Displayed;
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
