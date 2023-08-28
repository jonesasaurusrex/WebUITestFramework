using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebUITestFramework.PageObjects.Checkout;
using WebUITestFramework.PageObjects;
using WebUITestFramework.PageObjects.Inventory;

namespace WebUITestFramework.Tests
{
    [TestFixture, Order(7)]
    public class CheckoutCompletePageTests
    {
        private IWebDriver _driver;
        private CheckoutStepTwoPage _stepTwoPage;
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
            CheckoutStepOnePage csop = cp.ClickCheckout();
            _stepTwoPage = csop.EnterInfoClickContinue(_firstName, _lastName, _postalCode);
        }

        [Test, Order(1)]
        [Author("Travis Schultz")]
        [Description("Checks that navigation to the Checkout Complete page from the Finish button in step two works")]
        [Category("SmokeTest")]
        [Category("CheckoutCompletePage")]
        public void CheckoutCompletePageShouldResultFromContinueButtonInStageOne()
        {
            //Arrange

            //Act
            _stepTwoPage.ClickFinish();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(CheckoutCompletePage.URL), "ERROR: URL mismatch");
        }

        [Test, Order(2)]
        [Author("Travis Schultz")]
        [Description("Clicks the Back to home button and checks that it navigates to Inventory page")]
        [Category("SmokeTest")]
        [Category("CheckoutCompletePage")]
        public void CheckoutCompletePageShouldNavigateToInventoryPageWhenBackToHomeClicked()
        {
            //Arrange
            var completePage = _stepTwoPage.ClickFinish();

            //Act
            completePage.ClickBackHome();

            //Assert
            Assert.That(_driver.Url, Is.EqualTo(InventoryPage.URL), "ERROR: URL mismatch");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}