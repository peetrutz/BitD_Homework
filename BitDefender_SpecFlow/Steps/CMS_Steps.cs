using Contexts;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using Utility;

namespace Steps
{
    [Binding]
    public class CMS_Steps
    {
        private readonly IWebDriver driver;
        private HomePage _homepage;
        private HomeSolutionsPage _homeSolutionsPage;
        private CartPage _cartPage;
        private Helper _helper;



        public CMS_Steps(IWebDriver driver, HomePage homepage, HomeSolutionsPage homeSolutionsPage, CartPage cartPage, Helper helper)
        {
            this.driver = driver;
            _homepage = homepage;
            _homeSolutionsPage = homeSolutionsPage;
            _cartPage = cartPage;
            _helper = helper;
        }

        public void AcceptCookies()
        {
            var cookieSelector = _homepage.selectors["cookies_accept"];
            _helper.WaitForElement(cookieSelector);
            driver.FindElement(By.CssSelector(cookieSelector)).Click();


        }

        [Given("I am on the (.*) page using Chrome")]
        public void TestWithChromeDriver(string page)
        {
            string url;
            switch (page)
            {
                case "home":
                    url = _homepage.URL;
                    break;
                case "home_solutions":
                    url = _homeSolutionsPage.URL;

                    break;
                default:
                    url = "URL CANNOT BE FOUND";
                    break;
            }
            driver.Navigate().GoToUrl(url);

            // If cookies are already accepted we shouldn't throw an error
            try
            { AcceptCookies(); }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        [Given(@"I click the (.*) button on the (.*) page")]
        [When(@"I click the (.*) button on the (.*) page")]
        public void WhenIclickTheButton(string button, string page)
        {
            string buttonSelector;
            switch (page)
            {
                case "home":
                    buttonSelector = _homepage.selectors[button];
                    _helper.WaitForElement(buttonSelector);
                    break;
                case "home_solutions":
                    buttonSelector = _homeSolutionsPage.selectors[button];
                    _helper.WaitForElement(buttonSelector);
                    var buttonScroll = driver.FindElement(By.CssSelector(buttonSelector));
                    var jsToBeExecuted = $"window.scroll(0, {buttonScroll.Location.Y});";
                    ((IJavaScriptExecutor)driver).ExecuteScript(jsToBeExecuted);
                    _helper.WaitForElement(buttonSelector);

                    break;
                default:
                    buttonSelector = "Context not found";
                    break;
            }
                    driver.FindElement(By.CssSelector(buttonSelector)).Click();
        }

 
        // Based on the page on which I should be I compare the current URL to the desired URL
        [Then(@"I should be on the (.*) URL")]
        public void ThenTheURLSouldBe(string desiredUrl)
        {
            switch (desiredUrl)
            {
                case "/solutions":
                    var awaitForElement = _homeSolutionsPage.selectors["services"];
                    _helper.WaitForElement(awaitForElement);
                    desiredUrl = _homeSolutionsPage.URL; ;
                    break;
                //Before I assert the URL I want to ensure that the SHOP page has loaded
                case "cart":
                    desiredUrl = _cartPage.URL;
                    var mainDivOnCartPage = _cartPage.selectors["mainDiv"];
                    _helper.WaitForElement(mainDivOnCartPage);
                    break;
                default:
                    desiredUrl = "Context not found";
                    break;
            }
            var curentUrl = driver.Url;
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            Assert.IsTrue(curentUrl.Contains(desiredUrl));
        }

        // Whe we click a solution type on the "/solutions" page, we get a highlight in the fixed menu
        [Then(@"I should see the ""(.*)"" fixed menu button highlighted")]
        public void ThenIShouldSeeTheButtonHighlighted(string button)
        {
            string highlight;
            switch (button)
            {
                case "multiplatform":
                    highlight = _homeSolutionsPage.selectors["multiplatforHighlighted"];
                    break;
                default:
                    highlight = "Invalid highlight";
                    break;
            }
            //We need to wait for the hilight to appear before we check it actually exists
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(highlight)));
            bool isDisplayed = driver.FindElement(By.CssSelector(highlight)).Displayed; 
            Assert.IsTrue(isDisplayed);
        }
        [Given(@"I click the BUY NOW button for the Multiplatform Premium Security solution")]
        [When(@"I click the BUY NOW button for the Multiplatform Premium Security solution")]
        public void ClickTheBUYNOWButtonForTheMultiplatformPremiumSecuritySolution()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(_homeSolutionsPage.selectors["multiplatformPremiumSecurity"]))).Click();
        }



    }
}