using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebUITestFramework.PageObjects;
using WebUITestFramework.PageObjects.Checkout;
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

        [Test, Order(2)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for each section and checks that the item ends up in the cart")]
        [TestCase("add-to-cart-sauce-labs-backpack", "Sauce Labs Backpack")]
        [TestCase("add-to-cart-sauce-labs-bike-light", "Sauce Labs Bike Light")]
        [TestCase("add-to-cart-sauce-labs-bolt-t-shirt", "Sauce Labs Bolt T-Shirt")]
        [TestCase("add-to-cart-sauce-labs-fleece-jacket", "Sauce Labs Fleece Jacket")]
        [TestCase("add-to-cart-sauce-labs-onesie", "Sauce Labs Onesie")]
        [TestCase("add-to-cart-test.allthethings()-t-shirt-(red)", "Test.allTheThings() T-Shirt (Red)")]
        [Category("SmokeTest")]
        [Category("CartPage")]
        public void CartPageShouldUpdateToIncludeEachProductWhenAddedToCart(string addToCartId, string productName)
        {
            //Arrange

            //Act
            _inventoryPage.ClickButtonById(addToCartId);
            var cartPage = _inventoryPage.ClickShoppingCartIcon();

            //Assert
            Assert.That(cartPage.GetShoppingCartDotText(), Is.EqualTo("1"), "ERROR: Cart Badge count mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, productName), Is.True, "ERROR: Product Name not found on cart page");
        }

        [Test, Order(3)]
        [Author("Travis Schultz")]
        [Description("Clicks Add to cart button for all items and validates that they're all added to cart")]
        [Category("SmokeTest")]
        [Category("CartPage")]
        public void CartPageShouldUpdateToIncludeAllProductsWhenAllAddedToCart()
        {
            //Arrange

            //Act
            _inventoryPage.BackpackSection.ClickAddToCart();
            _inventoryPage.BikeLightSection.ClickAddToCart();
            _inventoryPage.BoltTShirtSection.ClickAddToCart();
            _inventoryPage.FleeceJacketSection.ClickAddToCart();
            _inventoryPage.OnesieSection.ClickAddToCart();
            _inventoryPage.TestAllTheThingsTShirtSection.ClickAddToCart();
            var cartPage = _inventoryPage.ClickShoppingCartIcon();

            //Assert
            Assert.That(cartPage.GetShoppingCartDotText(), Is.EqualTo("6"), "ERROR: Cart Badge count mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Sauce Labs Backpack"), Is.True, "ERROR: Backpack Product Name not found on cart page");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Sauce Labs Bike Light"), Is.True, "ERROR: Bike Light Product Name not found on cart page");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Sauce Labs Bolt T-Shirt"), Is.True, "ERROR: Bolt T-Shirt Product Name not found on cart page");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Sauce Labs Fleece Jacket"), Is.True, "ERROR: Fleece Jacket Product Name not found on cart page");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Sauce Labs Onesie"), Is.True, "ERROR: Onesie Product Name not found on cart page");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Test.allTheThings() T-Shirt (Red)"), Is.True, "ERROR: Test.allTheThings T-Shirt Product Name not found on cart page");
        }

        [Test, Order(4)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for each section and checks that the cart updates, then clicks remove for each and checks that the item is removed")]
        [TestCase("add-to-cart-sauce-labs-backpack", "remove-sauce-labs-backpack", "Sauce Labs Backpack")]
        [TestCase("add-to-cart-sauce-labs-bike-light", "remove-sauce-labs-bike-light", "Sauce Labs Bike Light")]
        [TestCase("add-to-cart-sauce-labs-bolt-t-shirt", "remove-sauce-labs-bolt-t-shirt", "Sauce Labs Bolt T-Shirt")]
        [TestCase("add-to-cart-sauce-labs-fleece-jacket", "remove-sauce-labs-fleece-jacket", "Sauce Labs Fleece Jacket")]
        [TestCase("add-to-cart-sauce-labs-onesie", "remove-sauce-labs-onesie", "Sauce Labs Onesie")]
        [TestCase("add-to-cart-test.allthethings()-t-shirt-(red)", "remove-test.allthethings()-t-shirt-(red)", "Test.allTheThings() T-Shirt (Red)")]
        [Category("SmokeTest")]
        [Category("CartPage")]
        public void CartPageShouldAddIncludeItemInCartWhenAddedAndShouldRemoveWhenRemoveButtonClicked(string addToCartId, string removeFromCartId, string productName)
        {
            //Arrange

            //Act
            _inventoryPage.ClickButtonById(addToCartId);
            var cartPage = _inventoryPage.ClickShoppingCartIcon();
            bool productNameOnPagePreRemove = Globals.TextIsPresentOnPage(_driver, productName);
            cartPage.ClickButtonById(removeFromCartId);
            bool productNameOnPagePostRemove = Globals.TextIsPresentOnPage(_driver, productName);

            //Assert
            Assert.That(productNameOnPagePreRemove, Is.True, "ERROR: Product Name not present on page after add but before remove");
            Assert.That(productNameOnPagePostRemove, Is.False, "ERROR: Product Name still present on page after remove");
        }

        [Test, Order(5)]
        [Author("Travis Schultz")]
        [Description("Clicks the cart, then clicks the continue shopping button and checks that the user is brought back to the inventory page")]
        [Category("SmokeTest")]
        [Category("CartPage")]
        public void CartPageShouldReturnToInventoryPageWhenContinueShoppingButtonClicked()
        {
            //Arrange
            var cartPage = _inventoryPage.ClickShoppingCartIcon();
            string urlPreButtonClick = _driver.Url;

            //Act
            var newPage = cartPage.ClickContinueShopping();
            string urlPostButtonClick = _driver.Url;

            //Assert
            Assert.That(urlPreButtonClick, Is.EqualTo(CartPage.URL), "ERROR: URL mismatch before button is clicked");
            Assert.That(urlPostButtonClick, Is.EqualTo(InventoryPage.URL), "ERROR: URL mismatch after button is clicked");
        }

        [Test, Order(6)]
        [Author("Travis Schultz")]
        [Description("Clicks the cart, then clicks the checkout button and checks that the user is brought to the checkout step one page")]
        [Category("SmokeTest")]
        [Category("CartPage")]
        public void CartPageShouldLeadToCheckoutStepOnePageWhenCheckoutButtonClicked()
        {
            //Arrange
            var cartPage = _inventoryPage.ClickShoppingCartIcon();
            string urlPreButtonClick = _driver.Url;

            //Act
            cartPage.ClickCheckout();
            string urlPostButtonClick = _driver.Url;

            //Assert
            Assert.That(urlPreButtonClick, Is.EqualTo(CartPage.URL), "ERROR: URL mismatch before button is clicked");
            Assert.That(urlPostButtonClick, Is.EqualTo(CheckoutStepOnePage.URL), "ERROR: URL mismatch after button is clicked");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}