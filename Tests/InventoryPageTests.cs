using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUITestFramework.PageObjects;

namespace WebUITestFramework.Tests
{
    [TestFixture, Order(2)]
    public class InventoryPageTests
    {
        private IWebDriver _driver;
        private InventoryPage _inventoryPage;

        [SetUp]
        public void SetUp() {
            _driver = new ChromeDriver();
            LoginPage lp = new LoginPage(_driver);
            _inventoryPage = lp.LoginWithCredentials(LoginPage.STANDARD_USER_USERNAME, LoginPage.PASSWORD);
        }

        [Test, Order(1)]
        [Author("Travis Schultz")]
        [Description("Checks that the inventory page can successfully load")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldLoadOnLogin()
        {
            //Arrange

            //Act

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(InventoryPage.URL), "ERROR: URL MISMATCH");
        }

        [Test, Order(2)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Backpack and checks that the cart badge updates")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenBackpackAddToCartButtonIsPushed()
        {
            //Arrange

            //Act
            _inventoryPage.ClickAddBackpackToCartButton();

            //Assert
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());
        }

        [Test, Order(3)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Backpack and checks that the cart badge updates, then clicks remove and checks that the badge disappears")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenBackpackAddedToCartAndThenRemoved()
        {
            //Arrange
            _inventoryPage.ClickAddBackpackToCartButton();
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());

            //Act
            _inventoryPage.ClickRemoveBackpackFromCartButton();

            //Assert
            Assert.That(_inventoryPage.CheckForShoppingCartBadge, Is.False, "ERROR, Badge is still displayed");
        }

        [Test, Order(4)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Bike Light and checks that the cart badge updates")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenBikeLightAddToCartButtonIsPushed()
        {
            //Arrange

            //Act
            _inventoryPage.ClickAddBikeLightToCartButton();

            //Assert
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());
        }

        [Test, Order(5)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Bike Light and checks that the cart badge updates, then clicks remove and checks that the badge disappears")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenBikeLightAddedToCartAndThenRemoved()
        {
            //Arrange
            _inventoryPage.ClickAddBikeLightToCartButton();
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());

            //Act
            _inventoryPage.ClickRemoveBikeLightFromCartButton();

            //Assert
            Assert.That(_inventoryPage.CheckForShoppingCartBadge, Is.False, "ERROR, Badge is still displayed");
        }

        [Test, Order(6)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Bolt T-Shirt and checks that the cart badge updates")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenBoltTShirtAddToCartButtonIsPushed()
        {
            //Arrange

            //Act
            _inventoryPage.ClickAddBoltTShirtToCartButton();

            //Assert
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());
        }

        [Test, Order(7)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Bolt T-Shirt and checks that the cart badge updates, then clicks remove and checks that the badge disappears")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenBoltTShirtAddedToCartAndThenRemoved()
        {
            //Arrange
            _inventoryPage.ClickAddBoltTShirtToCartButton();
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());

            //Act
            _inventoryPage.ClickRemoveBoltTShirtFromCartButton();

            //Assert
            Assert.That(_inventoryPage.CheckForShoppingCartBadge, Is.False, "ERROR, Badge is still displayed");
        }

        [Test, Order(8)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Fleece Jacket and checks that the cart badge updates")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenFleeceJacketAddToCartButtonIsPushed()
        {
            //Arrange

            //Act
            _inventoryPage.ClickAddFleeceJacketToCartButton();

            //Assert
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());
        }

        [Test, Order(9)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Fleece Jacket and checks that the cart badge updates, then clicks remove and checks that the badge disappears")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenFleeceJacketAddedToCartAndThenRemoved()
        {
            //Arrange
            _inventoryPage.ClickAddFleeceJacketToCartButton();
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());

            //Act
            _inventoryPage.ClickRemoveFleeceJacketFromCartButton();

            //Assert
            Assert.That(_inventoryPage.CheckForShoppingCartBadge, Is.False, "ERROR, Badge is still displayed");
        }

        [Test, Order(10)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Onesie and checks that the cart badge updates")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenOnesieAddToCartButtonIsPushed()
        {
            //Arrange

            //Act
            _inventoryPage.ClickAddBoltTShirtToCartButton();

            //Assert
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());
        }

        [Test, Order(11)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Onesie and checks that the cart badge updates, then clicks remove and checks that the badge disappears")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenOnesieAddedToCartAndThenRemoved()
        {
            //Arrange
            _inventoryPage.ClickAddOnesieToCartButton();
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());

            //Act
            _inventoryPage.ClickRemoveOnesieFromCartButton();

            //Assert
            Assert.That(_inventoryPage.CheckForShoppingCartBadge, Is.False, "ERROR, Badge is still displayed");
        }

        [Test, Order(12)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Test All The Things T-Shirt and checks that the cart badge updates")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenTestAllTheThingsTShirtAddToCartButtonIsPushed()
        {
            //Arrange

            //Act
            _inventoryPage.ClickAddTestAllTheThingsTShirtToCartButton();

            //Assert
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());
        }

        [Test, Order(13)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for the Bolt T-Shirt and checks that the cart badge updates, then clicks remove and checks that the badge disappears")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenTestAllTheThingsTShirtAddedToCartAndThenRemoved()
        {
            //Arrange
            _inventoryPage.ClickAddTestAllTheThingsTShirtToCartButton();
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());

            //Act
            _inventoryPage.ClickRemoveTestAllTheThingsTShirtFromCartButton();

            //Assert
            Assert.That(_inventoryPage.CheckForShoppingCartBadge, Is.False, "ERROR, Badge is still displayed");
        }

        [Test, Order(14)]
        [Author("Travis Schultz")]
        [Description("Adds multiple items to the cart and checks that the cart badge updates the count of the numbers in the cart")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeCountWhenMultipleItemsAreAdded()
        {
            //Arrange
            
            //Act
            _inventoryPage.ClickAddBackpackToCartButton();
            string afterOneItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.ClickAddBikeLightToCartButton();
            string afterTwoItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.ClickAddBoltTShirtToCartButton();
            string afterThreeItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.ClickAddFleeceJacketToCartButton();
            string afterFourItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.ClickAddOnesieToCartButton();
            string afterFiveItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.ClickAddTestAllTheThingsTShirtToCartButton();
            string afterSixItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.ClickRemoveBackpackFromCartButton();
            string afterSixITemAddOneItemRemovedCount = _inventoryPage.GetShoppingCartDotText();

            //Assert
            Assert.That(afterOneItemAddCount, Is.EqualTo("1"), "ERROR: Expected 1, received " + afterOneItemAddCount);
            Assert.That(afterTwoItemAddCount, Is.EqualTo("2"), "ERROR: Expected 2, received " + afterTwoItemAddCount);
            Assert.That(afterThreeItemAddCount, Is.EqualTo("3"), "ERROR: Expected 3, received " + afterThreeItemAddCount);
            Assert.That(afterFourItemAddCount, Is.EqualTo("4"), "ERROR: Expected 4, received " + afterFourItemAddCount);
            Assert.That(afterFiveItemAddCount, Is.EqualTo("5"), "ERROR: Expected 5, received " + afterFiveItemAddCount);
            Assert.That(afterSixItemAddCount, Is.EqualTo("6"), "ERROR: Expected 6, received " + afterSixItemAddCount);
            Assert.That(afterSixITemAddOneItemRemovedCount, Is.EqualTo("5"), "Expected 5, received " + afterSixITemAddOneItemRemovedCount);
        }

        [Test, Order(15)]
        [Author("Travis Schultz")]
        [Description("Clicks the About Link in the hamburger menu and validates the URL and Title")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldNavigateToSauceLabsPageWhenAboutLinkIsClickedInHamburgerMenu()
        {
            //Arrange
            _inventoryPage.ClickBurgerMenuButton();

            //Act
            _inventoryPage.ClickAboutSidebarLink();
            Thread.Sleep(100);

            //Assert
            Assert.That(_driver.Title, Is.EqualTo("Sauce Labs: Cross Browser Testing, Selenium Testing & Mobile Testing"), "ERROR: Title Mismatch");
            Assert.That(_driver.Url, Is.EqualTo("https://saucelabs.com/"), "ERROR: URL Mismatch");
        }

        [Test, Order(16)]
        [Author("Travis Schultz")]
        [Description("Adds three items to the cart, clicks the hamburger menu, clicks Reset App State, then checks that the cart is reset")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldResetTheCartWhenResetAppStateIsClickedInHamburgerMenu()
        {
            //Arrange
            _inventoryPage.ClickAddBackpackToCartButton();
            _inventoryPage.ClickAddBikeLightToCartButton();
            _inventoryPage.ClickAddOnesieToCartButton();
            string preResetCartCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.ClickBurgerMenuButton();

            //Act
            _inventoryPage.ClickResetAppStateSidebarLink();
            bool cartBadgeIsEnabled = _inventoryPage.CheckForShoppingCartBadge();

            //Assert
            Assert.That(preResetCartCount, Is.EqualTo("3"), "ERROR: Expected 3, received " +  preResetCartCount);
            Assert.That(cartBadgeIsEnabled, Is.False, "ERROR: Cart Badge Still displayed");
        }

        [Test, Order(17)]
        [Author("Travis Schultz")]
        [Description("Clicks the hamburger menu then clicks Logout, then checks that the URL is correct")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldNavigateToLoginScreenWhenLogoutIsClickedInHamburgerMenu()
        {
            //Arrange
            _inventoryPage.ClickBurgerMenuButton();

            //Act
            _inventoryPage.ClickLogoutSidebarLink();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(LoginPage.URL), "ERROR: URL Mismatch");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}