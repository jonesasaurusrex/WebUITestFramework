using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUITestFramework.PageObjects.Inventory;

namespace WebUITestFramework.PageObjects.Checkout
{
    /// <summary>
    /// Provides methods for interacting with step two of the checkout process
    /// </summary>
    public class CheckoutStepTwoPage : SharedElements
    {
        public const string URL = "https://www.saucedemo.com/checkout-step-two.html";

        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "cancel")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.Id, Using = "finish")]
        private IWebElement _finishButton;

        public CheckoutStepTwoPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Clicks the cancel button
        /// </summary>
        /// <returns></returns>
        public InventoryPage ClickCancel()
        {
            _cancelButton.Click();
            return new InventoryPage(_driver);
        }

        /// <summary>
        /// Clicks the Finish button
        /// </summary>
        /// <returns></returns>
        public CheckoutCompletePage ClickFinish()
        {
            _finishButton.Click();
            return new CheckoutCompletePage(_driver);
        }
    }
}
