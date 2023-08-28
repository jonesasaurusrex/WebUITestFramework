using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebUITestFramework.PageObjects;
using WebUITestFramework.PageObjects.Checkout;
using WebUITestFramework.PageObjects.Inventory;

namespace WebUITestFramework.Tests
{
    [TestFixture, Order(5)]
    public class CheckoutStepOnePageTests
    {
        private IWebDriver _driver;
        private CartPage _cartPage;
        private string _firstName = "Micheal";
        private string _lastName = "McDoesntExist";
        private string _postalCode = "12345";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            LoginPage lp = new LoginPage(_driver);
            InventoryPage ip = lp.LoginWithCredentials(LoginPage.STANDARD_USER_USERNAME, LoginPage.PASSWORD);
            _cartPage = ip.AddAllItemsThenClickCartIcon();
        }

        [Test, Order(1)]
        [Author("Travis Schultz")]
        [Description("Checks that navigation to the Checkout Step One page from the Checkout button in the cart works")]
        [Category("SmokeTest")]
        [Category("CheckoutStepOnePage")]
        public void CheckoutStepOnePageShouldResultFromClickingCheckoutButtonInCart()
        {
            //Arrange

            //Act
            _cartPage.ClickCheckout();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(CheckoutStepOnePage.URL), "ERROR: URL mismatch");
        }

        [Test, Order(2)]
        [Author("Travis Schultz")]
        [Description("Checks that clicking the Cancel button navigates back to the cart page")]
        [Category("SmokeTest")]
        [Category("CheckoutStepOnePage")]
        public void CheckoutStepOnePageCancelShouldLeadBackToCartPage()
        {
            //Arrange
            var checkoutStepOnePage = _cartPage.ClickCheckout();

            //Act
            checkoutStepOnePage.ClickCancel();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(CartPage.URL), "ERROR: URL mismatch");
        }

        [Test, Order(3)]
        [Author("Travis Schultz")]
        [Description("Checks that clicking the Continue button without the First Name field filled results in appropriate error")]
        [Category("SmokeTest")]
        [Category("CheckoutStepOnePage")]
        public void CheckoutStepOnePageThrowsFirstNameErrorWithEmptyFirstNameField()
        {
            //Arrange
            var checkoutStepOnePage = _cartPage.ClickCheckout();

            //Act
            checkoutStepOnePage.ClickContinue();

            //Assert
            Assert.That(Globals.TextIsPresentOnPage(_driver, CheckoutStepOnePage.FIRST_NAME_REQUIRED_ERROR_MESSAGE), Is.True, "ERROR: First Name Error not present");
        }

        [Test, Order(4)]
        [Author("Travis Schultz")]
        [Description("Checks that clicking the Continue button without the Last Name field filled results in appropriate error")]
        [Category("SmokeTest")]
        [Category("CheckoutStepOnePage")]
        public void CheckoutStepOnePageThrowsLastNameErrorWithEmptyLastNameField()
        {
            //Arrange
            var checkoutStepOnePage = _cartPage.ClickCheckout();

            //Act
            checkoutStepOnePage.EnterFirstName(_firstName);
            checkoutStepOnePage.ClickContinue();

            //Assert
            Assert.That(Globals.TextIsPresentOnPage(_driver, CheckoutStepOnePage.LAST_NAME_REQUIRED_ERROR_MESSAGE), Is.True, "ERROR: Last Name Error not present");
        }

        [Test, Order(5)]
        [Author("Travis Schultz")]
        [Description("Checks that clicking the Continue button without the Postal Code field filled results in appropriate error")]
        [Category("SmokeTest")]
        [Category("CheckoutStepOnePage")]
        public void CheckoutStepOnePageThrowsPostalCodeErrorWithEmptyPostalCodeField()
        {
            //Arrange
            var checkoutStepOnePage = _cartPage.ClickCheckout();

            //Act
            checkoutStepOnePage.EnterFirstName(_firstName);
            checkoutStepOnePage.EnterLastName(_lastName);
            checkoutStepOnePage.ClickContinue();

            //Assert
            Assert.That(Globals.TextIsPresentOnPage(_driver, CheckoutStepOnePage.POSTAL_CODE_REQUIRED_ERROR_MESSAGE), Is.True, "ERROR: Postal Code Error not present");
        }

        [Test, Order(6)]
        [Author("Travis Schultz")]
        [Description("Checks that clicking the Continue button with all fields filled results in step two page")]
        [Category("SmokeTest")]
        [Category("CheckoutStepOnePage")]
        public void CheckoutStepOnePageContinuesToStepTwoPageWithAllFieldsFilled()
        {
            //Arrange
            var checkoutStepOnePage = _cartPage.ClickCheckout();

            //Act
            checkoutStepOnePage.EnterFirstName(_firstName);
            checkoutStepOnePage.EnterLastName(_lastName);
            checkoutStepOnePage.EnterPostalCode(_postalCode);
            checkoutStepOnePage.ClickContinue();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(CheckoutStepTwoPage.URL), "Error: URL mismatch");
        }

        [TearDown] public void Teardown()
        {
            _driver.Quit();
        }
    }
}