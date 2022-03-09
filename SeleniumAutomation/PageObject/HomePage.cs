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
    /// Page object for SauceLabs Home page.
    /// </summary>
    class HomePage : BasePage
    {
        IWebDriver _driver;
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-onesie")]
        [CacheLookup]
        private IWebElement addcartOneSieButton;

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-bike-light")]
        [CacheLookup]
        private IWebElement addcartBikeLightButton;

        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-fleece-jacket")]
        [CacheLookup]
        private IWebElement addcartFleeceJacketButton;

        [FindsBy(How = How.CssSelector, Using = ".shopping_cart_link")]
        [CacheLookup]
        private IWebElement CartButton;

        /// <summary>
        /// Click on the AddToCartButton in the Sauce labs onesie, Sauce labs Bike Light and Sauce labs fleecejacket Items
        /// Click on the Cartbutton
        /// </summary>
        /// <returns></returns>
        public CartPage Addcart()
        { 
            ClickOn(addcartFleeceJacketButton);
            ClickOn(addcartOneSieButton);
            ClickOn(addcartBikeLightButton);
            ClickOn(CartButton);
            return new CartPage(driver);
        }
    }
}
