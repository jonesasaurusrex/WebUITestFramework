using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUITestFramework.PageObjects;
using WebUITestFramework.PageObjects.Inventory;

namespace WebUITestFramework.Tests
{
    [TestFixture, Order(4)]
    public  class CartPageTests
    {
        private IWebDriver _driver;
        private InventoryPage _inventoryPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            LoginPage lp = new LoginPage(_driver);
            _inventoryPage = lp.LoginWithCredentials(LoginPage.STANDARD_USER_USERNAME, LoginPage.PASSWORD);
        }

        [Test, Order(1)]
        [Author("Travis Schultz")]
        [Description("Checks that navigation to the cart via the cart icon works")]
        [Category("SmokeTest")]
        [Category("CartPage")]
        public void CartPageShouldResultFromClickingCartIconInTopBar()
        {
            //Arrange

            //Act
            _inventoryPage.ClickShoppingCartIcon();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(CartPage.URL));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
