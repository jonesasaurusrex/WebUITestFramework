using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUITestFramework.PageObjects
{
    public class InventoryPage
    {
        public const string URL = "https://www.saucedemo.com/inventory.html";
        public const string TITLE = "Swag Labs";

        private IWebDriver _driver;

        //Backpack Section Elements
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-backpack")]
        private IWebElement addBackpackToCartButton;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-backpack")]
        private IWebElement removeBackpackfromCartButton;

        [FindsBy(How = How.Id, Using = "item_4_title_link")]
        private IWebElement backpackTitleLink;

        [FindsBy(How = How.Id, Using = "item_4_img_link")]
        private IWebElement backpackImageLink;

        //Bike Light Section Elements
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-bike-light")]
        private IWebElement addBikeLightToCartButton;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-bike-light")]
        private IWebElement removeBikeLightFromCartButton;

        [FindsBy(How = How.Id, Using = "item_0_title_link")]
        private IWebElement bikeLightTitleLink;

        [FindsBy(How = How.Id, Using = "item_0_img_link")]
        private IWebElement bikeLightImageLink;

        //Bolt T-Shirt Section Elements
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-bolt-t-shirt")]
        private IWebElement addBoltTShirtToCartButton;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-bolt-t-shirt")]
        private IWebElement removeBoltTShirtFromCartButton;

        [FindsBy(How = How.Id, Using = "item_1_title_link")]
        private IWebElement boltTShirtTitleLink;

        [FindsBy(How = How.Id, Using = "item_1_img_link")]
        private IWebElement boltTShirtImageLink;

        //Fleece Jacket Section Elements
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-fleece-jacket")]
        private IWebElement addFleeceJacketToCartButton;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-fleece-jacket")]
        private IWebElement removeFleeceJacketFromCartButton;

        [FindsBy(How = How.Id, Using = "item_5_title_link")]
        private IWebElement fleeceJacketTitleLink;

        [FindsBy(How = How.Id, Using = "item_5_img_link")]
        private IWebElement fleeceJacketImageLink;

        //Onesie Section Elements
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-onesie")]
        private IWebElement addOnesieToCartButton;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-onesie")]
        private IWebElement removeOnesieFromCartButton;

        [FindsBy(How = How.Id, Using = "item_2_title_link")]
        private IWebElement onesieTitleLink;

        [FindsBy(How = How.Id, Using = "item_2_img_link")]
        private IWebElement onesieImageLink;

        //Test All The Things T-Shirt Section Elements
        [FindsBy(How = How.Id, Using = "add-to-cart-test.allthethings()-t-shirt-(red)")]
        private IWebElement addTestAllTheThingsTShirtToCartButton;

        [FindsBy(How = How.Id, Using = "remove-test.allthethings()-t-shirt-(red)")]
        private IWebElement removeTestAllTheThingsTShirtFromCartButton;

        [FindsBy(How = How.Id, Using = "item_3_title_link")]
        private IWebElement testAllTheThingsTShirtTitleLink;

        [FindsBy(How = How.Id, Using = "item_3_img_link")]
        private IWebElement testAllTheThingsTShirtImageLink;

        //Shopping Cart Section Elements
        [FindsBy(How = How.Id, Using = "shopping_cart_container")]
        private IWebElement shoppingCartContainer;

        [FindsBy(How = How.ClassName, Using = "shopping_cart_badge")]
        private IWebElement shoppingCartBadge;

        //Burger Menu Section Elements
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

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Backpack Section Methods
        /// <summary>
        /// Clicks the Add to cart button for the backpack
        /// </summary>
        public void ClickAddBackpackToCartButton()
        {
            addBackpackToCartButton.Click();
        }

        /// <summary>
        /// Clicks the Remove button for the backpack
        /// </summary>
        public void ClickRemoveBackpackFromCartButton()
        {
            removeBackpackfromCartButton.Click();
        }

        /// <summary>
        /// Clicks the Backpack Title link
        /// </summary>
        public void ClickBackpackTitle()
        {
            backpackTitleLink.Click();
        }

        /// <summary>
        /// Clicks the Backpack Image link
        /// </summary>
        public void ClickBackpackImage()
        {
            backpackImageLink.Click();
        }

        //Bike Light Section Methods
        /// <summary>
        /// Clicks the Add to cart button for the Bike Light
        /// </summary>
        public void ClickAddBikeLightToCartButton()
        {
            addBikeLightToCartButton.Click();
        }

        /// <summary>
        /// Clicks the Remove button for the Bike Light
        /// </summary>
        public void ClickRemoveBikeLightFromCartButton()
        {
            removeBikeLightFromCartButton.Click();
        }

        /// <summary>
        /// Clicks the Bike Light Title link
        /// </summary>
        public void ClickBikeLightTitle()
        {
            bikeLightTitleLink.Click();
        }

        /// <summary>
        /// Clicks the Bike Light Image link
        /// </summary>
        public void ClickBikeLightImage()
        {
            bikeLightImageLink.Click();
        }

        //Bolt T-Shirt Section Methods
        /// <summary>
        /// Clicks the Add to cart button for the Bolt T-Shirt
        /// </summary>
        public void ClickAddBoltTShirtToCartButton()
        {
            addBoltTShirtToCartButton.Click();
        }

        /// <summary>
        /// Clicks the Remove button for the Bolt T-Shirt
        /// </summary>
        public void ClickRemoveBoltTShirtFromCartButton()
        {
            removeBoltTShirtFromCartButton.Click();
        }

        /// <summary>
        /// Clicks the Bolt T-Shirt Title link
        /// </summary>
        public void ClickBoltTShirtTitle()
        {
            boltTShirtTitleLink.Click();
        }

        /// <summary>
        /// Clicks the Bolt T-Shirt Image link
        /// </summary>
        public void ClickBoltTShirtImage()
        {
            boltTShirtImageLink.Click();
        }

        //Fleece Jacket Section Methods
        /// <summary>
        /// Clicks the Add to cart button for the Fleece Jacket
        /// </summary>
        public void ClickAddFleeceJacketToCartButton()
        {
            addFleeceJacketToCartButton.Click();
        }

        /// <summary>
        /// Clicks the Remove button for the Fleece Jacket
        /// </summary>
        public void ClickRemoveFleeceJacketFromCartButton()
        {
            removeFleeceJacketFromCartButton.Click();
        }

        /// <summary>
        /// Clicks the Fleece Jacket Title link
        /// </summary>
        public void ClickFleeceJacketTitle()
        {
            fleeceJacketTitleLink.Click();
        }

        /// <summary>
        /// Clicks the Fleece Jacket Image link
        /// </summary>
        public void ClickFleeceJacketImage()
        {
            fleeceJacketImageLink.Click();
        }

        //Onesie Section Methods
        /// <summary>
        /// Clicks the Add to cart button for the Onesie
        /// </summary>
        public void ClickAddOnesieToCartButton()
        {
            addOnesieToCartButton.Click();
        }

        /// <summary>
        /// Clicks the Remove button for the Onesie
        /// </summary>
        public void ClickRemoveOnesieFromCartButton()
        {
            removeOnesieFromCartButton.Click();
        }

        /// <summary>
        /// Clicks the Onesie Title link
        /// </summary>
        public void ClickOnesieTitle()
        {
            onesieTitleLink.Click();
        }

        /// <summary>
        /// Clicks the Onesie Image link
        /// </summary>
        public void ClickOnesieImage()
        {
            onesieImageLink.Click();
        }

        //Test All The Things T-Shirt Section Methods
        /// <summary>
        /// Clicks the Add to cart button for the Test All The Things T-Shirt
        /// </summary>
        public void ClickAddTestAllTheThingsTShirtToCartButton()
        {
            addTestAllTheThingsTShirtToCartButton.Click();
        }

        /// <summary>
        /// Clicks the Remove button for the Test All The Things T-Shirt
        /// </summary>
        public void ClickRemoveTestAllTheThingsTShirtFromCartButton()
        {
            removeTestAllTheThingsTShirtFromCartButton.Click();
        }

        /// <summary>
        /// Clicks the Test All The Things T-Shirt Title link
        /// </summary>
        public void ClickTestAllTheThingsTShirtTitle()
        {
            testAllTheThingsTShirtTitleLink.Click();
        }

        /// <summary>
        /// Clicks the Test All The Things T-Shirt Image link
        /// </summary>
        public void ClickTestAllTheThingsTShirtImage()
        {
            testAllTheThingsTShirtImageLink.Click();
        }

        //Shopping Cart Section Methods
        /// <summary>
        /// Clicks the Shopping Cart icon
        /// </summary>
        public void ClickShoppingCartIcon()
        {
            shoppingCartContainer.Click();
        }

        /// <summary>
        /// Gets the contents of the Red Dot on the Shopping Cart icon
        /// </summary>
        /// <returns></returns>
        public string GetShoppingCartDotText()
        {
            return shoppingCartBadge.Text;
        }

        //Burger Menu Section Methods
        /// <summary>
        /// Clicks the Burger Menu button
        /// </summary>
        public void ClickBurgerMenuButton()
        {
            burgerMenuButton.Click();
        }

        /// <summary>
        /// Clicks the All Items sidebar link
        /// </summary>
        public void ClickAllItemsSidebarLink()
        {
            allItemsSidebarLink.Click();
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
    }
}