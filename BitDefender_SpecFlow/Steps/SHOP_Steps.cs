using Contexts;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Steps
{
    [Binding]
    public class SHOP_Steps
    {
        private readonly IWebDriver driver;
        private ProductInCartPage _productCart;
        private int quantity;
        private decimal price; 


        public SHOP_Steps(IWebDriver driver, ProductInCartPage productCart)
        {
            this.driver = driver;
            _productCart = productCart;
        }

        [Given(@"I am checking the cart which contains a PREMIUM SECURITY Multiplatform Solution")]
        public void GivenIAmCheckingTheCartWhichContainsAPREMIUMSECURITYMultiplatformSolution()
        {
            driver.Navigate().GoToUrl(_productCart.URL);
        }

        [When(@"I set the quantity to (.*) and I click Update")]
        public void WhenISetTheQuantityToAndIClickUpdate(int qty)
        {
            //storing quantity for later use
            quantity = qty;

            //extract price per item and store it
           var priceString = driver.FindElement(By.CssSelector(_productCart.selectors["productPriceTimesQuantity"])).Text;
            //removing " RON" from extracted value
           priceString = priceString.Remove(priceString.Length - 2);
           price = Convert.ToDecimal(priceString);

            var qualityInputSelector = driver.FindElement(By.CssSelector(_productCart.selectors["quantityInput"]));
            qualityInputSelector.Clear();
            qualityInputSelector.SendKeys(qty.ToString());


            //click the update button
            driver.FindElement(By.CssSelector(_productCart.selectors["updateButton"])).Click();

        }

        [Then(@"I check the the price has updated accordingly")]
        public void ThenICheckTheThePriceHasUpdatedAccordingly()
        {
            var newPriceString = driver.FindElement(By.CssSelector(_productCart.selectors["productPriceTimesQuantity"])).Text;
            newPriceString = newPriceString.Remove(newPriceString.Length - 2);
            var newPrice = Convert.ToDecimal(newPriceString);

            Assert.True(newPrice == price * 2);
        }

        [When(@"I click the remove item button")]
        public void WhenIClickTheRemoveItemButton()
        {
            driver.FindElement(By.CssSelector(_productCart.selectors["removeItemButton"])).Click();
        }

    }
}
