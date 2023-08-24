using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebUITestFramework.PageObjects;

namespace WebUITestFramework.Tests
{
    public class LoginPageTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void LoginPageShouldSuccessfullyLoginWithGoodCredentials()
        {
            //Arrange
            LoginPage loginPage = new LoginPage(_driver);
            _driver.Navigate().GoToUrl(LoginPage.URL);

            //Act
            loginPage.EnterUserName("standard_user");
            loginPage.EnterPassword("secret_sauce");
            loginPage.ClickLogin();

            //Assert
            Assert.That(_driver.Url.Contains("inventory"), Is.True, "ERROR: Url mismatch");
            _driver.Close();
        }
    }
}