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
    /// Page object for SauceLabs OverView page.
    /// </summary>
    class OverViewPage : BasePage
    {
        IWebDriver _driver;
        public OverViewPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Sauce Labs Fleece Jacket']")]
        [CacheLookup]
        public IWebElement fleeceJacketTxt;


        [FindsBy(How = How.XPath, Using = "//div[@class='inventory_item_price'][normalize-space()='$49.99']")]
        [CacheLookup]
        public IWebElement jacketPrice;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Sauce Labs Bike Light']")]
        [CacheLookup]
        public IWebElement bikeLightTxt;

        [FindsBy(How = How.XPath, Using = "//div[@class='inventory_item_price'][normalize-space()='$9.99']")]
        [CacheLookup]
        public IWebElement bikeLightPrice;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Sauce Labs Onesie']")]
        [CacheLookup]
        public IWebElement onesieTxt;

        [FindsBy(How = How.XPath, Using = "//div[@class='inventory_item_price'][normalize-space()='$7.99']")]
        [CacheLookup]
        public IWebElement onesiePrice;

        [FindsBy(How = How.XPath, Using = "//div[@class='summary_total_label']")]
        [CacheLookup]
        public IWebElement totalPrice;

        [FindsBy(How = How.CssSelector, Using = "#finish")]
        [CacheLookup]
        private IWebElement finishBtn;

        [FindsBy(How = How.CssSelector, Using = ".title")]
        [CacheLookup]
        public IWebElement titleTxt;
        
        public void FinishShopping()
        {
            ClickOn(finishBtn);
        }
    }
}
