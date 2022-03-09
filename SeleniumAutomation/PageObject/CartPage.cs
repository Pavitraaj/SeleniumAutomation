using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.PageObject
{
    /// <summary>
    /// Page object for SauceLabs Cart page.
    /// </summary>
    class CartPage : BasePage
    {
        IWebDriver _driver;
        public CartPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Sauce Labs Fleece Jacket']")]
        [CacheLookup]
        public IWebElement FleeceJacketText;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Sauce Labs Onesie']")]
        [CacheLookup]
        public IWebElement OnesieText;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Sauce Labs Bike Light']")]
        [CacheLookup]
        public IWebElement BikeLightText;


        [FindsBy(How = How.Id, Using = "checkout")]
        [CacheLookup]
        private IWebElement CheckoutBtn;

        /// <summary>
        /// Click on the Checkout button
        /// </summary>
        /// <returns></returns>
        public CheckoutPage Checkout()
        {
            ClickOn(CheckoutBtn);
            return new CheckoutPage(driver);
        }

    }
}
