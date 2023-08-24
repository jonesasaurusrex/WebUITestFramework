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
        private const string ERROR_MESSAGEISERRONEOUSLYDISPLAYED = "ERROR: Error message is erroneously displayed";
        private const string ERROR_MESSAGEISNOTDISPLAYED = "ERROR: Error message is erroneously displayed";
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test, Order(1)]
        [Author("Travis Schultz")]
        [Category("Smoke Test")]
        public void LoginPageShouldSuccessfullyLoginWithGoodCredentials()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.STANDARDUSERUSERNAME);
            loginPage.EnterPassword(LoginPage.PASSWORD);
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.True, "ERROR: Url mismatch");
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
        }

        [Test, Order(2)]
        [Author("Travis Schultz")]
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
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.True, ERROR_MESSAGEISNOTDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
        }

        [Test, Order(3)]
        [Author("Travis Schultz")]
        [Category("Smoke Test")]
        public void LoginPageShouldDisplayErrorMessageWithoutPassword()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.STANDARDUSERUSERNAME);
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.True, ERROR_MESSAGEISNOTDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
        }

        [Test, Order(4)]
        [Author("Travis Schultz")]
        [Category("Smoke Test")]
        public void LoginPageShouldDisplayErrorMessageWithBadPassword()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.STANDARDUSERUSERNAME);
            loginPage.EnterPassword("asdf");
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.True, ERROR_MESSAGEISNOTDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
        }

        [Test, Order(5)]
        [Author("Travis Schultz")]
        [Category("Smoke Test")]
        public void LoginPageShouldDisplayErrorMessageWithLockedOutUser()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.LOCKEDOUTUSERUSERNAME);
            loginPage.EnterPassword(LoginPage.PASSWORD);
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.True, ERROR_MESSAGEISNOTDISPLAYED);
        }

        [Test, Order(6)]
        [Author("Travis Schultz")]
        [Category("Smoke Test")]
        public void LoginPageShouldRemovePasswordAndUsernameMismatchErrorMessageAfterErrorButtonIsClicked()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.STANDARDUSERUSERNAME);
            loginPage.EnterPassword("asdf");
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.True, ERROR_MESSAGEISNOTDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);

            loginPage.ClickErrorButton();

            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
        }

        [Test, Order(7)]
        [Author("Travis Schultz")]
        [Category("Smoke Test")]
        public void LoginPageShouldRemovePasswordRequiredErrorMessageAfterErrorButtonIsClicked()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.STANDARDUSERUSERNAME);
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.True, ERROR_MESSAGEISNOTDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);

            loginPage.ClickErrorButton();

            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
        }

        [Test, Order(8)]
        [Author("Travis Schultz")]
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
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.True, ERROR_MESSAGEISNOTDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);

            loginPage.ClickErrorButton();

            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
        }

        [Test, Order(9)]
        [Author("Travis Schultz")]
        [Category("Smoke Test")]
        public void LoginPageShouldRemoveLockedOutUserErrorMessageAfterErrorButtonIsClicked()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName(LoginPage.LOCKEDOUTUSERUSERNAME);
            loginPage.EnterPassword(LoginPage.PASSWORD);
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.False, "ERROR: Url mismatch");
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.True, ERROR_MESSAGEISNOTDISPLAYED);

            loginPage.ClickErrorButton();

            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERNAMEREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDREQUIREDERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
            Assert.That(loginPage.TextIsPresentOnPage(LoginPage.USERHASBEENLOCKEDOUTERRORMESSAGE), Is.False, ERROR_MESSAGEISERRONEOUSLYDISPLAYED);
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}