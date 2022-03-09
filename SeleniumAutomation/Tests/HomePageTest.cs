using NUnit.Framework;
using SeleniumAutomation.PageObject;
using System.Configuration;

namespace SeleniumAutomation.Tests
{
    [TestFixture]
    class HomePageTest : BaseTest
    {
        /// <summary>
        /// Parametrized test to verify the items added in the cart is displayed in Overviewpage by the passed keyword ${oneSie, fleeceJacket, bikeLight, fleecejacketprice, bikeLightPrice, onesiePrice, totalPrice}
        /// Please note I used  the best practice test naming convention "UnitOfWork_StateUnderTest_ExpectedBehavior"
        /// </summary>
        /// <param name="onesie"></param>
        /// <param name="fleeceJacket"></param>
        /// <param name="bikeLight"></param>
        /// <param name="fleecejacketprice"></param>
        /// <param name="bikeLightPrice"></param>
        /// <param name="onesiePrice"></param>
        /// <param name="totalPrice"></param>
        /// <param name="checkoutComplete"></param>

        [TestCase("Sauce Labs Onesie", "Sauce Labs Fleece Jacket", "Sauce Labs Bike Light", "$49.99", "$9.99", "$7.99", "Total: $73.41", "CHECKOUT: COMPLETE!"), Description("Verify the Items details mentioned in the overview page is correct")]
        public void LoginPage_AddItemsToTheCart_ValidItems_CheckoutAndCheckTheDetailsInTheOverViewPage(string onesie, string fleeceJacket, string bikeLight, string fleecejacketprice, string bikeLightPrice, string onesiePrice, string totalPrice, string checkoutComplete)
        {
            //Arrange
            string? userName = ConfigurationManager.AppSettings.Get("User");
            string? passWord = ConfigurationManager.AppSettings.Get("Password");

            //Act
            LoginPage loginPage = new(driver);
            HomePage homePage = loginPage.Login(userName, passWord);           
            CartPage cartPage = homePage.Addcart();
          
            //Assert
            Assert.AreEqual(onesie, cartPage.OnesieText.Text);
            Assert.AreEqual(fleeceJacket, cartPage.FleeceJacketText.Text);
            Assert.AreEqual(bikeLight, cartPage.BikeLightText.Text);
            CheckoutPage checkoutPage = cartPage.Checkout();
            OverViewPage overviewPage =checkoutPage.CheckOut("John", "Doe", "1010");
            Assert.AreEqual(fleeceJacket, overviewPage.fleeceJacketTxt.Text);
            Assert.AreEqual(fleecejacketprice, overviewPage.jacketPrice.Text);
            Assert.AreEqual(bikeLight, overviewPage.bikeLightTxt.Text);
            Assert.AreEqual(bikeLightPrice, overviewPage.bikeLightPrice.Text);
            Assert.AreEqual(onesie, overviewPage.onesieTxt.Text);
            Assert.AreEqual(onesiePrice, overviewPage.onesiePrice.Text);
            Assert.AreEqual(totalPrice, overviewPage.totalPrice.Text);
            overviewPage.FinishShopping();
            Assert.AreEqual(checkoutComplete, overviewPage.titleTxt.Text);
        }
    }
}
