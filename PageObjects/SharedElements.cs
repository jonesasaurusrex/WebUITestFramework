using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using WebUITestFramework.PageObjects.Inventory;

namespace WebUITestFramework.PageObjects
{
    /// <summary>
    /// Provides methods for interacting with the hamburger menu and the cart icon
    /// </summary>
    public class SharedElements
    {
        private IWebDriver _driver;

        //Hamburger Menu Section Elements
        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
        private IWebElement burgerMenuButton;

        [FindsBy(How = How.Id, Using = "inventory_sidebar_link")]
        private IWebElement allItemsSidebarLink;

        [FindsBy(How = How.Id, Using = "about_sidebar_link")]
        private IWebElement aboutSidebarLink;

        [FindsBy(How = How.Id, Using = "logout_sidebar_link")]
        private IWebElement logoutSidebarLink;

        [FindsBy(How = How.Id, Using = "reset_sidebar_link")]
        private IWebElement resetAppStateSidebarLink;

        //Shopping Cart Section Elements
        [FindsBy(How = How.Id, Using = "shopping_cart_container")]
        private IWebElement shoppingCartContainer;

        [FindsBy(How = How.ClassName, Using = "shopping_cart_badge")]
        private IWebElement shoppingCartBadge;


        //Shopping Cart Section Methods
        /// <summary>
        /// Clicks the Shopping Cart icon
        /// </summary>
        public CartPage ClickShoppingCartIcon()
        {
            shoppingCartContainer.Click();
            return new CartPage(_driver);
        }

        /// <summary>
        /// Gets the contents of the Red Dot on the Shopping Cart icon
        /// </summary>
        /// <returns></returns>
        public string GetShoppingCartDotText()
        {
            return shoppingCartBadge.Text;
        }

        /// <summary>
        /// Checks to see if the badge is present
        /// </summary>
        /// <returns></returns>
        public bool CheckForShoppingCartBadge()
        {
            return _driver.FindElements(By.ClassName("shopping_cart_badge")).Count > 0;
        }

        //Burger Menu Section Methods
        /// <summary>
        /// Clicks the Burger Menu button
        /// </summary>
        public void ClickBurgerMenuButton()
        {
            burgerMenuButton.Click();
            Thread.Sleep(100);
        }

        /// <summary>
        /// Clicks the All Items sidebar link
        /// </summary>
        public InventoryPage ClickAllItemsSidebarLink()
        {
            allItemsSidebarLink.Click();
            return new InventoryPage(_driver);
        }

        /// <summary>
        /// Clicks the About sidebar link
        /// </summary>
        public void ClickAboutSidebarLink()
        {
            aboutSidebarLink.Click();
        }

        /// <summary>
        /// Clicks the Logout sidebar link
        /// </summary>
        public void ClickLogoutSidebarLink()
        {
            logoutSidebarLink.Click();
        }

        /// <summary>
        /// Clicks the Reset App State sidebar link
        /// </summary>
        public void ClickResetAppStateSidebarLink()
        {
            resetAppStateSidebarLink.Click();
        }

        /// <summary>
        /// Clicks the button with the given id
        /// </summary>
        /// <param name="id"></param>
        public void ClickButtonById(string id)
        {
            IWebElement button = _driver.FindElement(By.Id(id));
            button.Click();
        }

        public SharedElements(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}