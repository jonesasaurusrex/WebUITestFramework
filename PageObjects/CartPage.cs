using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebUITestFramework.PageObjects.Inventory;

namespace WebUITestFramework.PageObjects
{
    /// <summary>
    /// Provides methods for interacting with the specific product pages
    /// </summary>
    public class CartPage : SharedElements
    {
        IWebDriver _driver;

        //Elements
        [FindsBy(How = How.Id, Using = "checkout")]
        private IWebElement checkoutButton;

        [FindsBy(How = How.Id, Using = "continue-shopping")]
        private IWebElement continueShoppingButton;

        public CartPage(IWebDriver driver) : base(driver) 
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Clicks the Checkout button in the cart page
        /// </summary>
        public void ClickCheckout()
        {
            checkoutButton.Click();
        }

        /// <summary>
        /// Clicks the Continue Shopping button in the cart page
        /// </summary>
        /// <returns></returns>
        public InventoryPage ClickContinueShopping()
        {
            continueShoppingButton.Click();
            return new InventoryPage(_driver);
        }

        /// <summary>
        /// Clicks the Remove button for the Bike Light if available
        /// </summary>
        public void ClickRemoveBikeLightButton()
        {
            ClickRemoveButton("remove-sauce-labs-bike-light");
        }

        /// <summary>
        /// Clicks the Remove button for the Backpack if available
        /// </summary>
        public void ClickRemoveBackpackButton()
        {
            ClickRemoveButton("remove-sauce-labs-backpack");
        }

        /// <summary>
        /// Clicks the Remove button for the Bolt T-Shirt if available
        /// </summary>
        public void ClickRemoveBoltTShirtButton()
        {
            ClickRemoveButton("remove-sauce-labs-bolt-t-shirt");
        }

        /// <summary>
        /// Clicks the Remove button for the Fleece Jacket if available
        /// </summary>
        public void ClickRemoveFleeceJacketButton()
        {
            ClickRemoveButton("remove-sauce-labs-fleece-jacket");
        }

        /// <summary>
        /// Clicks the Remove button for the Test All The Things T-Shirt if available
        /// </summary>
        public void ClickRemoveTestAllTheThingsTShirtButton()
        {
            ClickRemoveButton("remove-test.allthethings()-t-shirt-(red)");
        }

        /// <summary>
        /// Clicks the Remove button for the Onesie if available
        /// </summary>
        public void ClickRemoveOnesieButton()
        {
            ClickRemoveButton("remove-sauce-labs-onesie");
        }

        public void ClickRemoveButton(string removeButtonId)
        {
            IWebElement removeButton = _driver.FindElement(By.Id(removeButtonId));
            if (removeButton != null)
            {
                removeButton.Click();
            }
        }
    }
}
