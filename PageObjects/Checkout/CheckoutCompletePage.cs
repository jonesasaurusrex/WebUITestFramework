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
    /// Provides methods for interacting with the checkout complete page
    /// </summary>
    public class CheckoutCompletePage : SharedElements
    {
        public const string URL = "https://www.saucedemo.com/checkout-complete.html";

        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "back-to-products")]
        private IWebElement _backHomeButton;

        public CheckoutCompletePage(IWebDriver driver) : base(driver) 
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Clicks the Back Home button
        /// </summary>
        /// <returns></returns>
        public InventoryPage ClickBackHome()
        {
            _backHomeButton.Click();
            return new InventoryPage(_driver);
        }
    }
}
