using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomation.PageObject;
using System.Configuration;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumAutomation.Tests
{
    class BaseTest
    {
    public IWebDriver driver;
       
        [SetUp]
        public void Setup()
        {
            _ = new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("ApplicationUrl"));
            driver.Manage().Window.Maximize();          
        }      

        [TearDown]
        public void TestEnding()
        {
            driver.Quit();
        }
    }
}
