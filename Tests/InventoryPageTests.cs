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
        [Description("Clicks the Add to cart button for each section and checks that the cart badge updates")]
        [TestCase("add-to-cart-sauce-labs-backpack", "remove-sauce-labs-backpack", "item_4_title_link", "item_4_img_link")]
        [TestCase("add-to-cart-sauce-labs-bike-light", "remove-sauce-labs-bike-light", "item_0_title_link", "item_0_img_link")]
        [TestCase("add-to-cart-sauce-labs-bolt-t-shirt", "remove-sauce-labs-bolt-t-shirt", "item_1_title_link", "item_1_img_link")]
        [TestCase("add-to-cart-sauce-labs-fleece-jacket", "remove-sauce-labs-fleece-jacket", "item_5_title_link", "item_5_img_link")]
        [TestCase("add-to-cart-sauce-labs-onesie", "remove-sauce-labs-onesie", "item_2_title_link", "item_2_img_link")]
        [TestCase("add-to-cart-test.allthethings()-t-shirt-(red)", "remove-test.allthethings()-t-shirt-(red)", "item_3_title_link", "item_3_img_link")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenAddToCartButtonIsPushed(string add_id, string remove_id, string image_id, string title_id)
        {
            //Arrange
            InventoryItemSection section = new InventoryItemSection(_driver, add_id, remove_id, image_id, title_id);

            //Act
            section.ClickAddToCart();

            //Assert
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR, Expected 1, received " + _inventoryPage.GetShoppingCartDotText());
        }

        [Test, Order(3)]
        [Author("Travis Schultz")]
        [Description("Clicks the Add to cart button for each section and checks that the cart badge updates, then clicks remove and checksk that the badge disappears")]
        [TestCase("add-to-cart-sauce-labs-backpack", "remove-sauce-labs-backpack", "item_4_title_link", "item_4_img_link")]
        [TestCase("add-to-cart-sauce-labs-bike-light", "remove-sauce-labs-bike-light", "item_0_title_link", "item_0_img_link")]
        [TestCase("add-to-cart-sauce-labs-bolt-t-shirt", "remove-sauce-labs-bolt-t-shirt", "item_1_title_link", "item_1_img_link")]
        [TestCase("add-to-cart-sauce-labs-fleece-jacket", "remove-sauce-labs-fleece-jacket", "item_5_title_link", "item_5_img_link")]
        [TestCase("add-to-cart-sauce-labs-onesie", "remove-sauce-labs-onesie", "item_2_title_link", "item_2_img_link")]
        [TestCase("add-to-cart-test.allthethings()-t-shirt-(red)", "remove-test.allthethings()-t-shirt-(red)", "item_3_title_link", "item_3_img_link")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeWhenAddToCartButtonIsPushedAndWhenRemoveIsPushed(string add_id, string remove_id, string image_id, string title_id)
        {
            //Arrange
            InventoryItemSection section = new InventoryItemSection(_driver, add_id, remove_id, image_id, title_id);
            section.ClickAddToCart();
            Assert.That(_inventoryPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Expected 1, received " + _inventoryPage.GetShoppingCartDotText());

            //Act
            section.ClickRemoveFromCart();
            //Assert
            Assert.That(_inventoryPage.CheckForShoppingCartBadge, Is.False, "ERROR: Badge is still displayed");
        }

        [Test, Order(4)]
        [Author("Travis Schultz")]
        [Description("Adds multiple items to the cart and checks that the cart badge updates the count of the numbers in the cart")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        public void InventoryPageShouldUpdateCartBadgeCountWhenMultipleItemsAreAdded()
        {
            //Arrange
            
            //Act
            _inventoryPage.BackpackSection.ClickAddToCart();
            string afterOneItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.BikeLightSection.ClickAddToCart();
            string afterTwoItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.BoltTShirtSection.ClickAddToCart();
            string afterThreeItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.FleeceJacketSection.ClickAddToCart();
            string afterFourItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.OnesieSection.ClickAddToCart();
            string afterFiveItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.TestAllTheThingsTShirtSection.ClickAddToCart();
            string afterSixItemAddCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.BackpackSection.ClickRemoveFromCart();
            string afterSixItemAddOneItemRemovedCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.BikeLightSection.ClickRemoveFromCart();
            string afterSixItemAddTwoItemRemovedCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.BoltTShirtSection.ClickRemoveFromCart();
            string afterSixItemAddThreeItemRemovedCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.FleeceJacketSection.ClickRemoveFromCart();
            string afterSixItemAddFourItemRemovedCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.OnesieSection.ClickRemoveFromCart();
            string afterSixItemAddFiveItemRemovedCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.TestAllTheThingsTShirtSection.ClickRemoveFromCart();
            bool afterAllItemsRemovedBadgeVisable = _inventoryPage.CheckForShoppingCartBadge();

            //Assert
            Assert.That(afterOneItemAddCount, Is.EqualTo("1"), "ERROR: Expected 1, received " + afterOneItemAddCount);
            Assert.That(afterTwoItemAddCount, Is.EqualTo("2"), "ERROR: Expected 2, received " + afterTwoItemAddCount);
            Assert.That(afterThreeItemAddCount, Is.EqualTo("3"), "ERROR: Expected 3, received " + afterThreeItemAddCount);
            Assert.That(afterFourItemAddCount, Is.EqualTo("4"), "ERROR: Expected 4, received " + afterFourItemAddCount);
            Assert.That(afterFiveItemAddCount, Is.EqualTo("5"), "ERROR: Expected 5, received " + afterFiveItemAddCount);
            Assert.That(afterSixItemAddCount, Is.EqualTo("6"), "ERROR: Expected 6, received " + afterSixItemAddCount);
            Assert.That(afterSixItemAddOneItemRemovedCount, Is.EqualTo("5"), "ERROR: Expected 5, received " + afterSixItemAddOneItemRemovedCount);
            Assert.That(afterSixItemAddTwoItemRemovedCount, Is.EqualTo("4"), "ERROR: Expected 4, received " + afterSixItemAddOneItemRemovedCount);
            Assert.That(afterSixItemAddThreeItemRemovedCount, Is.EqualTo("3"), "ERROR: Expected 3, received " + afterSixItemAddOneItemRemovedCount);
            Assert.That(afterSixItemAddFourItemRemovedCount, Is.EqualTo("2"), "ERROR: Expected 2, received " + afterSixItemAddOneItemRemovedCount);
            Assert.That(afterSixItemAddFiveItemRemovedCount, Is.EqualTo("1"), "ERROR: Expected 1, received " + afterSixItemAddOneItemRemovedCount);
            Assert.That(afterAllItemsRemovedBadgeVisable, Is.False, "ERROR: Badge still visable");
        }

        [Test, Order(5)]
        [Author("Travis Schultz")]
        [Description("Clicks the About Link in the hamburger menu and validates the URL and Title")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        [Category("SharedElements")]
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

        [Test, Order(6)]
        [Author("Travis Schultz")]
        [Description("Adds three items to the cart, clicks the hamburger menu, clicks Reset App State, then checks that the cart is reset")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        [Category("SharedElements")]
        public void InventoryPageShouldResetTheCartWhenResetAppStateIsClickedInHamburgerMenu()
        {
            //Arrange
            _inventoryPage.BackpackSection.ClickAddToCart();
            _inventoryPage.BikeLightSection.ClickAddToCart();
            _inventoryPage.OnesieSection.ClickAddToCart();
            string preResetCartCount = _inventoryPage.GetShoppingCartDotText();
            _inventoryPage.ClickBurgerMenuButton();

            //Act
            _inventoryPage.ClickResetAppStateSidebarLink();
            bool cartBadgeIsEnabled = _inventoryPage.CheckForShoppingCartBadge();

            //Assert
            Assert.That(preResetCartCount, Is.EqualTo("3"), "ERROR: Expected 3, received " +  preResetCartCount);
            Assert.That(cartBadgeIsEnabled, Is.False, "ERROR: Cart Badge Still displayed");
        }

        [Test, Order(7)]
        [Author("Travis Schultz")]
        [Description("Clicks the hamburger menu then clicks Logout, then checks that the URL is correct")]
        [Category("SmokeTest")]
        [Category("InventoryPage")]
        [Category("SharedElements")]
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