using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebUITestFramework.PageObjects;
using WebUITestFramework.PageObjects.Inventory;

namespace WebUITestFramework.Tests
{
    [TestFixture, Order(3)]
    public class ProductPageTests
    {
        private IWebDriver _driver;
        private InventoryPage _inventoryPage;
        private const string PRODUCT_PAGE_BASE_URL = "https://www.saucedemo.com/inventory-item.html?id=";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            LoginPage lp = new LoginPage(_driver);
            _inventoryPage = lp.LoginWithCredentials(LoginPage.STANDARD_USER_USERNAME, LoginPage.PASSWORD);
        }

        [Test, Order(1)]
        [Author("Travis Schultz")]
        [Description("Checks that navigation from inventory page to product pages works via title links")]
        [TestCase("Sauce Labs Backpack", 4, "$29.99", "add-to-cart-sauce-labs-backpack", "remove-sauce-labs-backpack")]
        [TestCase("Sauce Labs Bike Light", 0, "$9.99", "add-to-cart-sauce-labs-bike-light", "remove-sauce-labs-bike-light")]
        [TestCase("Sauce Labs Bolt T-Shirt", 1, "$15.99", "add-to-cart-sauce-labs-bolt-t-shirt", "remove-sauce-labs-bolt-t-shirt")]
        [TestCase("Sauce Labs Fleece Jacket", 5, "$49.99", "add-to-cart-sauce-labs-fleece-jacket", "remove-sauce-labs-fleece-jacket")]
        [TestCase("Sauce Labs Onesie", 2, "$7.99", "add-to-cart-sauce-labs-onesie", "remove-sauce-labs-onesie")]
        [TestCase("Test.allTheThings() T-Shirt (Red)", 3, "$15.99", "add-to-cart-test.allthethings()-t-shirt-(red)", "remove-test.allthethings()-t-shirt-(red)")]
        [Category("SmokeTest")]
        [Category("ProductPage")]
        public void ProductPageShouldResultFromClickingTitleLinkInInventoryPage(string productName, int productId, string productPrice, string addButtonId, string removeButtonId)
        {
            //Arrange
            IWebElement titleLink = _driver.FindElement(By.Id("item_" + productId + "_title_link"));
            
            //Act
            titleLink.Click();
            ProductPage productPage = new ProductPage(_driver, addButtonId, removeButtonId);

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(PRODUCT_PAGE_BASE_URL + productId), "ERROR: URL mismatch");
            Assert.That(productPage.GetProductNameTextFromPage(), Is.EqualTo(productName), "ERROR: Product Name mismatch");
            Assert.That(productPage.GetProductPriceTextFromPage(), Is.EqualTo(productPrice), "ERROR: Product Price mismatch");
        }

        [Test, Order(2)]
        [Author("Travis Schultz")]
        [Description("Checks that navigation from inventory page to product pages works via image links")]
        [TestCase("Sauce Labs Backpack", 4, "$29.99", "add-to-cart-sauce-labs-backpack", "remove-sauce-labs-backpack")]
        [TestCase("Sauce Labs Bike Light", 0, "$9.99", "add-to-cart-sauce-labs-bike-light", "remove-sauce-labs-bike-light")]
        [TestCase("Sauce Labs Bolt T-Shirt", 1, "$15.99", "add-to-cart-sauce-labs-bolt-t-shirt", "remove-sauce-labs-bolt-t-shirt")]
        [TestCase("Sauce Labs Fleece Jacket", 5, "$49.99", "add-to-cart-sauce-labs-fleece-jacket", "remove-sauce-labs-fleece-jacket")]
        [TestCase("Sauce Labs Onesie", 2, "$7.99", "add-to-cart-sauce-labs-onesie", "remove-sauce-labs-onesie")]
        [TestCase("Test.allTheThings() T-Shirt (Red)", 3, "$15.99", "add-to-cart-test.allthethings()-t-shirt-(red)", "remove-test.allthethings()-t-shirt-(red)")]
        [Category("SmokeTest")]
        [Category("ProductPage")]
        public void ProductPageShouldResultFromClickingImageLinkInInventoryPage(string productName, int productId, string productPrice, string addButtonId, string removeButtonId)
        {
            //Arrange
            IWebElement imageLink = _driver.FindElement(By.Id("item_" + productId + "_img_link"));

            //Act
            imageLink.Click();
            ProductPage productPage = new ProductPage(_driver, addButtonId, removeButtonId);

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(PRODUCT_PAGE_BASE_URL + productId), "ERROR: URL mismatch");
            Assert.That(productPage.GetProductNameTextFromPage(), Is.EqualTo(productName), "ERROR: Product Name mismatch");
            Assert.That(productPage.GetProductPriceTextFromPage(), Is.EqualTo(productPrice), "ERROR: Product Price mismatch");
        }

        [Test, Order(3)]
        [Author("Travis Schultz")]
        [Description("Checks that navigation from product pages to Inventory page works via Return To Products button")]
        [TestCase("Sauce Labs Backpack", 4, "$29.99", "add-to-cart-sauce-labs-backpack", "remove-sauce-labs-backpack")]
        [TestCase("Sauce Labs Bike Light", 0, "$9.99", "add-to-cart-sauce-labs-bike-light", "remove-sauce-labs-bike-light")]
        [TestCase("Sauce Labs Bolt T-Shirt", 1, "$15.99", "add-to-cart-sauce-labs-bolt-t-shirt", "remove-sauce-labs-bolt-t-shirt")]
        [TestCase("Sauce Labs Fleece Jacket", 5, "$49.99", "add-to-cart-sauce-labs-fleece-jacket", "remove-sauce-labs-fleece-jacket")]
        [TestCase("Sauce Labs Onesie", 2, "$7.99", "add-to-cart-sauce-labs-onesie", "remove-sauce-labs-onesie")]
        [TestCase("Test.allTheThings() T-Shirt (Red)", 3, "$15.99", "add-to-cart-test.allthethings()-t-shirt-(red)", "remove-test.allthethings()-t-shirt-(red)")]
        [Category("SmokeTest")]
        [Category("ProductPage")]
        public void ProductPageShouldNavigateToInventoryPageWhenBackToProductsButtonClicked(string productName, int productId, string productPrice, string addButtonId, string removeButtonId)
        {
            //Arrange
            IWebElement titleLink = _driver.FindElement(By.Id("item_" + productId + "_title_link"));
            titleLink.Click();
            ProductPage productPage = new ProductPage(_driver, addButtonId, removeButtonId);

            //Act
            productPage.ClickReturnToProducts();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(InventoryPage.URL), "ERROR: URL mismatch");
        }

        [Test, Order(4)]
        [Author("Travis Schultz")]
        [Description("Checks that navigation from product pages to Inventory page works via hamburger menu All Items button")]
        [TestCase("Sauce Labs Backpack", 4, "$29.99", "add-to-cart-sauce-labs-backpack", "remove-sauce-labs-backpack")]
        [TestCase("Sauce Labs Bike Light", 0, "$9.99", "add-to-cart-sauce-labs-bike-light", "remove-sauce-labs-bike-light")]
        [TestCase("Sauce Labs Bolt T-Shirt", 1, "$15.99", "add-to-cart-sauce-labs-bolt-t-shirt", "remove-sauce-labs-bolt-t-shirt")]
        [TestCase("Sauce Labs Fleece Jacket", 5, "$49.99", "add-to-cart-sauce-labs-fleece-jacket", "remove-sauce-labs-fleece-jacket")]
        [TestCase("Sauce Labs Onesie", 2, "$7.99", "add-to-cart-sauce-labs-onesie", "remove-sauce-labs-onesie")]
        [TestCase("Test.allTheThings() T-Shirt (Red)", 3, "$15.99", "add-to-cart-test.allthethings()-t-shirt-(red)", "remove-test.allthethings()-t-shirt-(red)")]
        [Category("SmokeTest")]
        [Category("ProductPage")]
        public void ProductPageShouldNavigateToInventoryPageWhenAllItemsIsClickedInBurgerMenu(string productName, int productId, string productPrice, string addButtonId, string removeButtonId)
        {
            //Arrange
            IWebElement titleLink = _driver.FindElement(By.Id("item_" + productId + "_title_link"));
            titleLink.Click();
            ProductPage productPage = new ProductPage(_driver, addButtonId, removeButtonId);

            //Act
            productPage.ClickBurgerMenuButton();
            productPage.ClickAllItemsSidebarLink();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(InventoryPage.URL), "ERROR: URL mismatch");
        }

        [Test, Order(4)]
        [Author("Travis Schultz")]
        [Description("Checks that navigation from product pages to Inventory page works via hamburger menu All Items button")]
        [TestCase("Sauce Labs Backpack", 4, "$29.99", "add-to-cart-sauce-labs-backpack", "remove-sauce-labs-backpack")]
        [TestCase("Sauce Labs Bike Light", 0, "$9.99", "add-to-cart-sauce-labs-bike-light", "remove-sauce-labs-bike-light")]
        [TestCase("Sauce Labs Bolt T-Shirt", 1, "$15.99", "add-to-cart-sauce-labs-bolt-t-shirt", "remove-sauce-labs-bolt-t-shirt")]
        [TestCase("Sauce Labs Fleece Jacket", 5, "$49.99", "add-to-cart-sauce-labs-fleece-jacket", "remove-sauce-labs-fleece-jacket")]
        [TestCase("Sauce Labs Onesie", 2, "$7.99", "add-to-cart-sauce-labs-onesie", "remove-sauce-labs-onesie")]
        [TestCase("Test.allTheThings() T-Shirt (Red)", 3, "$15.99", "add-to-cart-test.allthethings()-t-shirt-(red)", "remove-test.allthethings()-t-shirt-(red)")]
        [Category("SmokeTest")]
        [Category("ProductPage")]
        public void ProductPageShouldAddItemToCartWhenAddToCartButtonClicked(string productName, int productId, string productPrice, string addButtonId, string removeButtonId)
        {
            //Arrange
            IWebElement titleLink = _driver.FindElement(By.Id("item_" + productId + "_title_link"));
            titleLink.Click();
            ProductPage productPage = new ProductPage(_driver, addButtonId, removeButtonId);

            //Act
            productPage.ClickAddToCart();

            //Assert
            Assert.That(productPage.GetShoppingCartDotText, Is.EqualTo("1"), "ERROR: Cart Dot text mismatch");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}