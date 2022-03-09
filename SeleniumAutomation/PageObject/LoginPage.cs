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
    /// Page object for SauceLabs Login page.
    /// </summary>
    class LoginPage : BasePage
    { 
    public LoginPage(IWebDriver driver) : base(driver)
    {
        PageFactory.InitElements(driver, this);
    }

    [FindsBy(How = How.Id, Using = "user-name")]
    [CacheLookup]
    private IWebElement userNameTxtBox;

    [FindsBy(How = How.Id, Using = "password")]
    [CacheLookup]
    public IWebElement passwordTxtBox;

    [FindsBy(How = How.Id, Using = "login-button")]
    [CacheLookup]
    private IWebElement loginButton;

        public void EnterUserName(string userName)
        {
            EnterText(userNameTxtBox, userName);
        }
       public void EnterPassword(string passWord)
        {
            EnterText(passwordTxtBox, passWord);
        }
        /// <summary>
        /// Enter the Username and password 
        /// Click on the login button
        /// In real scenario, I will be testing the Login by clicking on the Login button or by clicking "Enter" button on the keyboard 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="encryptedPassWord"></param>
        /// <returns></returns>
        public HomePage Login(string userName, string encryptedPassWord)
        {
            EnterUserName(userName);
            var password = Helper.Encryptor.Decrypt(encryptedPassWord);
            EnterPassword(password);
            ClickOn(loginButton);
            return new HomePage(driver);
        }
    }
}
