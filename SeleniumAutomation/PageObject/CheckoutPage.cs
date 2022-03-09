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
    /// Page object for SauceLabs Checkout page.
    /// </summary>
    class CheckoutPage : BasePage
    {
        IWebDriver _driver;
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "#first-name")]
        [CacheLookup]
        private IWebElement FirstNameTxtBox;

        [FindsBy(How = How.CssSelector, Using = "#last-name")]
        [CacheLookup]
        private IWebElement LastNameTxtBox;

        [FindsBy(How = How.CssSelector, Using = "#postal-code")]
        [CacheLookup]
        private IWebElement PostalCodeTxtBox;

        [FindsBy(How = How.CssSelector, Using = "#continue")]
        [CacheLookup]
        private IWebElement ContinueBtn;

        public void EnterFirstName(string firstName)
        {
            EnterText(FirstNameTxtBox, firstName);
        }

        public void EnterLastName(string lastName)
        {
            EnterText(LastNameTxtBox, lastName);
        }

        public void EnterPostalCode(string postalCode)
        {
            EnterText(PostalCodeTxtBox, postalCode);
        }

        /// <summary>
        /// Enter the Keywords into the Textbox
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        public OverViewPage CheckOut(string firstName, string lastName, string postalCode)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterPostalCode(postalCode);
            ClickOn(ContinueBtn);
            return new OverViewPage(driver);
        }
    }
}
