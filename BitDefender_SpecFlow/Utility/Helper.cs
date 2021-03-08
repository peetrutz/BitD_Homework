using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Helper
    {
        private readonly IWebDriver driver;

        public Helper(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void WaitForElement(string cssElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(cssElement)));
        }
    }
}
