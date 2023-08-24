using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebUITestFramework.PageObjects;

namespace WebUITestFramework.Tests
{
    [TestFixture, Order(1)]
    [Author("Travis Schultz")]
    public class LoginPageTests
    {
        private IWebDriver _driver;
        private const string ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED = "ERROR: Error message is erroneously displayed";
        private const string ERROR_MESSAGE_IS_NOT_DISPLAYED = "ERROR: Error message is erroneously displayed";
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test, Order(1)]
        [Author("Travis Schultz")]
        [Description("Checks that the page can successfully log in")]
        [Category("Smoke Test")]
        public void LoginPageShouldSuccessfullyLoginWithGoodCredentials()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.STANDARD_USER_USERNAME);
            loginPage.EnterPassword(LoginPage.PASSWORD);
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.True, "ERROR: Url mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
        }

        [Test, Order(2)]
        [Author("Travis Schultz")]
        [Description("Checks that the page displays the correct error message with no username supplied")]
        [Category("Smoke Test")]
        public void LoginPageShouldDisplayErrorMessageWithoutUsername()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.True, ERROR_MESSAGE_IS_NOT_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
        }

        [Test, Order(3)]
        [Author("Travis Schultz")]
        [Description("Checks that the page displays the correct error message with no password supplied")]
        [Category("Smoke Test")]
        public void LoginPageShouldDisplayErrorMessageWithoutPassword()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.STANDARD_USER_USERNAME);
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.True, ERROR_MESSAGE_IS_NOT_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
        }

        [Test, Order(4)]
        [Author("Travis Schultz")]
        [Description("Checks that the page displays the correct error message with a bad password supplied")]
        [Category("Smoke Test")]
        public void LoginPageShouldDisplayErrorMessageWithBadPassword()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.STANDARD_USER_USERNAME);
            loginPage.EnterPassword("asdf");
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.True, ERROR_MESSAGE_IS_NOT_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
        }

        [Test, Order(5)]
        [Author("Travis Schultz")]
        [Description("Checks that the page displays the correct error message with a locked out user supplied")]
        [Category("Smoke Test")]
        public void LoginPageShouldDisplayErrorMessageWithLockedOutUser()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.LOCKED_OUT_USER_USERNAME);
            loginPage.EnterPassword(LoginPage.PASSWORD);
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.True, ERROR_MESSAGE_IS_NOT_DISPLAYED);
        }

        [Test, Order(6)]
        [Author("Travis Schultz")]
        [Description("Checks that the page displays the error message with bad password supplied and then clears it when the clear error button is clicked")]
        [Category("Smoke Test")]
        public void LoginPageShouldRemovePasswordAndUsernameMismatchErrorMessageAfterErrorButtonIsClicked()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.STANDARD_USER_USERNAME);
            loginPage.EnterPassword("asdf");
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.True, ERROR_MESSAGE_IS_NOT_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);

            loginPage.ClickErrorButton();

            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
        }

        [Test, Order(7)]
        [Author("Travis Schultz")]
        [Description("Checks that the page displays the error message with no password supplied and then clears it when the clear error button is clicked")]
        [Category("Smoke Test")]
        public void LoginPageShouldRemovePasswordRequiredErrorMessageAfterErrorButtonIsClicked()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.STANDARD_USER_USERNAME);
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.True, ERROR_MESSAGE_IS_NOT_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);

            loginPage.ClickErrorButton();

            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
        }

        [Test, Order(8)]
        [Author("Travis Schultz")]
        [Description("Checks that the page displays the error message with no username supplied and then clears it when the clear error button is clicked")]
        [Category("Smoke Test")]
        public void LoginPageShouldRemoveUsernameRequiredErrorMessageAfterErrorButtonIsClicked()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.True, ERROR_MESSAGE_IS_NOT_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);

            loginPage.ClickErrorButton();

            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
        }

        [Test, Order(9)]
        [Author("Travis Schultz")]
        [Description("Checks that the page displays the error message with locked out user supplied and then clears it when the clear error button is clicked")]
        [Category("Smoke Test")]
        public void LoginPageShouldRemoveLockedOutUserErrorMessageAfterErrorButtonIsClicked()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.LOCKED_OUT_USER_USERNAME);
            loginPage.EnterPassword(LoginPage.PASSWORD);
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.True, ERROR_MESSAGE_IS_NOT_DISPLAYED);

            loginPage.ClickErrorButton();

            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USERNAME_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_REQUIRED_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
            Assert.That(Globals.TextIsPresentOnPage(_driver, LoginPage.USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE), Is.False, ERROR_MESSAGE_IS_ERRONEOUSLY_DISPLAYED);
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}