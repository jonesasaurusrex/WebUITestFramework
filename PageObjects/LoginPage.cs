using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUITestFramework.PageObjects
{
    /// <summary>
    /// Provides methods for interacting with the Login Page
    /// </summary>
    public class LoginPage
    {
        public const string URL = "https://www.saucedemo.com/";
        public const string TITLE = "Swag Labs";
        public const string USERNAME_REQUIRED_ERROR_MESSAGE = "Epic sadface: Username is required";
        public const string PASSWORD_REQUIRED_ERROR_MESSAGE = "Epic sadface: Password is required";
        public const string PASSWORD_AND_USERNAME_MISMATCH_ERROR_MESSAGE = "Epic sadface: Username and password do not match any user in this service";
        public const string USER_HAS_BEEN_LOCKED_OUT_ERROR_MESSAGE = "Epic sadface: Sorry, this user has been locked out.";
        public const string USER_HAS_TIMED_OUT_ERROR_MESSAGE = "Epic sadface: You can only access '/inventory-item.html' when you are logged in.";
        public const string STANDARD_USER_USERNAME = "standard_user";
        public const string LOCKED_OUT_USER_USERNAME = "locked_out_user";
        public const string PASSWORD = "secret_sauce";

        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement userNameTextBox;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordTextBox;

        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement loginButton;

        [FindsBy(How = How.ClassName, Using = "error-button")]
        private IWebElement errorButton;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Enters the given username into the username field
        /// </summary>
        /// <param name="userName"></param>
        public void EnterUserName (string userName)
        {
            userNameTextBox.SendKeys(userName);
        }

        /// <summary>
        /// Enters the given password into the password field
        /// </summary>
        /// <param name="password"></param>
        public void EnterPassword(string password)
        {
            passwordTextBox.SendKeys(password);
        }

        /// <summary>
        /// Clicks the login button
        /// </summary>
        public void ClickLogin()
        {
            loginButton.Click();
        }

        /// <summary>
        /// Clicks the error button
        /// </summary>
        public void ClickErrorButton()
        {
            errorButton.Click();
        }

        /// <summary>
        /// Logs in with the provided credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public InventoryPage LoginWithCredentials(string username, string password)
        {
            _driver.Navigate().GoToUrl(URL);
            EnterUserName(username);
            EnterPassword(password);
            ClickLogin();
            return new InventoryPage(_driver);
        }
    }
}