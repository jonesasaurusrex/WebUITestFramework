using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebUITestFramework.PageObjects.Inventory;
using WebUITestFramework.PageObjects;
using WebUITestFramework.PageObjects.Checkout;

namespace WebUITestFramework.Tests
{
    [TestFixture, Order(6)]
    public class CheckoutStepTwoPageTests
    {
        private IWebDriver _driver;
        private CheckoutStepOnePage _stepOnePage;
        private string _firstName = "Micheal";
        private string _lastName = "McDoesntExist";
        private string _postalCode = "12345";

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            LoginPage lp = new LoginPage(_driver);
            InventoryPage ip = lp.LoginWithCredentials(LoginPage.STANDARD_USER_USERNAME, LoginPage.PASSWORD);
            CartPage cp = ip.AddAllItemsThenClickCartIcon();
            _stepOnePage = cp.ClickCheckout();
        }

        [Test, Order(1)]
        [Author("Travis Schultz")]
        [Description("Checks that navigation to the Checkout Step Two page from the Continue button in step one works")]
        [Category("SmokeTest")]
        [Category("CheckoutStepTwoPage")]
        public void CheckoutStepTwoPageShouldResultFromContinueButtonInStageOne()
        {
            //Arrange

            //Act
            _stepOnePage.EnterInfoClickContinue(_firstName, _lastName, _postalCode);

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(CheckoutStepTwoPage.URL), "ERROR: URL mismatch");
        }

        [Test, Order(2)]
        [Author("Travis Schultz")]
        [Description("Clicks the Cancel button and checks that it navigates to the Inventory page")]
        [Category("SmokeTest")]
        [Category("CheckoutStepTwoPage")]
        public void CheckoutStepTwoPageShouldNavigateToInventoryPageWhenCancelButtonClicked()
        {
            //Arrange
            var stepTwoPage = _stepOnePage.EnterInfoClickContinue(_firstName, _lastName, _postalCode);

            //Act
            stepTwoPage.ClickCancel();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(InventoryPage.URL), "ERROR: URL mismatch");
        }

        [Test, Order(3)]
        [Author("Travis Schultz")]
        [Description("Clicks the Finish button and checks that it navigates to the Checkout Complete page")]
        [Category("SmokeTest")]
        [Category("CheckoutStepTwoPage")]
        public void CheckoutStepTwoPageShouldNavigateToCheckoutCompletePageWhenFinishButtonClicked()
        {
            //Arrange
            var stepTwoPage = _stepOnePage.EnterInfoClickContinue(_firstName, _lastName, _postalCode);

            //Act
            stepTwoPage.ClickFinish();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(CheckoutCompletePage.URL), "ERROR: URL mismatch");
        }

        [Test, Order(4)]
        [Author("Travis Schultz")]
        [Description("Checks that the totals and product names are present on the step two page")]
        [Category("SmokeTest")]
        [Category("CheckoutStepTwoPage")]
        public void CheckoutStepTwoPageShouldHaveProductDataAndTotals()
        {
            //Arrange

            //Act
            var stepTwoPage = _stepOnePage.EnterInfoClickContinue(_firstName, _lastName, _postalCode);

            //Assert
            Assert.That(Globals.TextIsPresentOnPage(_driver, "$140.34"), Is.True, "ERROR: total not correct");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Sauce Labs Backpack"), Is.True, "ERROR: Backpack product name not found");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Sauce Labs Bike Light"), Is.True, "ERROR: Bike Light product name not found");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Sauce Labs Bolt T-Shirt"), Is.True, "ERROR: Bolt T-Shirt product name not found");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Sauce Labs Fleece Jacket"), Is.True, "ERROR: Fleece Jacket product name not found");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Sauce Labs Onesie"), Is.True, "ERROR: Onesie product name not found");
            Assert.That(Globals.TextIsPresentOnPage(_driver, "Test.allTheThings() T-Shirt (Red)"), Is.True, "ERROR: Test.allTheThings() T-Shirt product name not found");
        }

        [Test, Order(5)]
        [Author("Travis Schultz")]
        [Description("Clicks the Finish button and checks that the cart badge count resets")]
        [Category("SmokeTest")]
        [Category("CheckoutStepTwoPage")]
        public void CheckoutStepTwoPageShouldResetCartBadgeWhenFinishButtonClicked()
        {
            //Arrange
            var stepTwoPage = _stepOnePage.EnterInfoClickContinue(_firstName, _lastName, _postalCode);

            //Act
            string badgeCountBeforeFinishClicked = stepTwoPage.GetShoppingCartDotText();
            stepTwoPage.ClickFinish();

            //Assert
            Assert.That(badgeCountBeforeFinishClicked, Is.EqualTo("6"), "ERROR: Cart badge count mismatch");
            Assert.That(stepTwoPage.CheckForShoppingCartBadge, Is.False, "ERROR: Cart badge still displayed");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}