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
        public const string URL = "https://www.saucedemo.com";
        public const string TITLE = "Swag Labs";
        public const string USERNAMEREQUIREDERRORMESSAGE = "Epic sadface: Username is required";
        public const string PASSWORDREQUIREDERRORMESSAGE = "Epic sadface: Password is required";
        public const string PASSWORDANDUSERNAMEMISMATCHERRORMESSAGE = "Epic sadface: Username and password do not match any user in this service";
        public const string USERHASBEENLOCKEDOUTERRORMESSAGE = "Epic sadface: Sorry, this user has been locked out.";
        public const string STANDARDUSERUSERNAME = "standard_user";
        public const string LOCKEDOUTUSERUSERNAME = "locked_out_user";
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
        public void LoginWithCredentials(string username, string password)
        {
            EnterUserName(username);
            EnterPassword(password);
            ClickLogin();
        }

        public bool TextIsPresentOnPage(string text)
        {
            //var elements = _driver.FindElements(By.XPath("//*[contains(text(), '" + text + "')]"));
            var pageSource = _driver.PageSource;
            return _driver.PageSource.Contains(text);
        }
    }
}