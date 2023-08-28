using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebUITestFramework.PageObjects.Checkout
{
    /// <summary>
    /// Provides methods for interacting with the page for step one of the checkout process
    /// </summary>
    public class CheckoutStepOnePage : SharedElements
    {
        public const string URL = "https://www.saucedemo.com/checkout-step-one.html";
        public const string FIRST_NAME_REQUIRED_ERROR_MESSAGE = "Error: First Name is required";
        public const string LAST_NAME_REQUIRED_ERROR_MESSAGE = "Error: Last Name is required";
        public const string POSTAL_CODE_REQUIRED_ERROR_MESSAGE = "Error: Postal Code is required";

        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "first-name")]
        private IWebElement _firstNameTextBox;

        [FindsBy(How = How.Id, Using = "last-name")]
        private IWebElement _lastNameTextBox;

        [FindsBy(How = How.Id, Using = "postal-code")]
        private IWebElement _postalCodeTextBox;

        [FindsBy(How = How.Id, Using = "continue")]
        private IWebElement _continueButton;

        [FindsBy(How = How.Id, Using = "cancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.ClassName, Using = "error-button")]
        private IWebElement _errorButton;

        public CheckoutStepOnePage(IWebDriver driver) : base(driver) 
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Clicks the Cancel button
        /// </summary>
        public CartPage ClickCancel()
        {
            _cancelButton.Click();
            return new CartPage(_driver);
        }

        /// <summary>
        /// Clicks the continue button
        /// </summary>
        public void ClickContinue()
        {
            _continueButton.Click();
        }

        /// <summary>
        /// Clicks the red x in an error bar
        /// </summary>
        public void ClickErrorButton()
        {
            _errorButton.Click();
        }

        /// <summary>
        /// Enters the given first name into the First Name field
        /// </summary>
        /// <param name="firstName"></param>
        public void EnterFirstName(string firstName)
        {
            _firstNameTextBox.SendKeys(firstName);
        }

        /// <summary>
        /// Enters the given last name into the Last Name field
        /// </summary>
        /// <param name="lastName"></param>
        public void EnterLastName(string lastName)
        {
            _lastNameTextBox.SendKeys(lastName);
        }

        /// <summary>
        /// Enters the given postal code into the Zip/Postal Code field
        /// </summary>
        /// <param name="postalCode"></param>
        public void EnterPostalCode(string postalCode)
        {
            _postalCodeTextBox.SendKeys(postalCode);
        }

        /// <summary>
        /// Enters the given information into the form and clicks the Continue button
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        public CheckoutStepTwoPage EnterInfoClickContinue(string firstName, string lastName, string postalCode)
        {
            EnterFirstName(firstName);
            EnterLastName(lastName);
            EnterPostalCode(postalCode);
            ClickContinue();
            return new CheckoutStepTwoPage(_driver);
        }
    }
}