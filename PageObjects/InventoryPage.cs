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

        //Backpack Section
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-backpack")]
        private IWebElement addBackpackToCartButton;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-backpack")]
        private IWebElement removeBackpackfromCartButton;

        [FindsBy(How = How.Id, Using = "item_4_title_link")]
        private IWebElement backpackTitleLink;

        [FindsBy(How = How.Id, Using = "item_4_img_link")]
        private IWebElement backpackImageLink;

        //Bike Light Section
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-bike-light")]
        private IWebElement addBikeLightToCartButton;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-bike-light")]
        private IWebElement removeBikeLightFromCartButton;

        [FindsBy(How = How.Id, Using = "item_0_title_link")]
        private IWebElement bikeLightTitleLink;

        [FindsBy(How = How.Id, Using = "item_0_img_link")]
        private IWebElement bikeLightImageLink;

        //Bolt T-Shirt Section
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-bolt-t-shirt")]
        private IWebElement addBoltTShirtToCartButton;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-bolt-t-shirt")]
        private IWebElement removeBoltTShirtFromCartButton;

        [FindsBy(How = How.Id, Using = "item_1_title_link")]
        private IWebElement boltTShirtTitleLink;

        [FindsBy(How = How.Id, Using = "item_1_img_link")]
        private IWebElement boltTShirtImageLink;

        //Fleece Jacket Section
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-fleece-jacket")]
        private IWebElement addFleeceJacketToCartButton;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-fleece-jacket")]
        private IWebElement removeFleeceJacketFromCartButton;

        [FindsBy(How = How.Id, Using = "item_5_title_link")]
        private IWebElement fleeceJacketTitleLink;

        [FindsBy(How = How.Id, Using = "item_5_img_link")]
        private IWebElement fleeceJacketImageLink;

        //Onesie Section
        [FindsBy(How = How.Id, Using = "add-to-cart-sauce-labs-onesie")]
        private IWebElement addOnesieToCartButton;

        [FindsBy(How = How.Id, Using = "remove-sauce-labs-onesie")]
        private IWebElement removeOnesieFromCartButton;

        [FindsBy(How = How.Id, Using = "item_2_title_link")]
        private IWebElement onesieTitleLink;

        [FindsBy(How = How.Id, Using = "item_2_img_link")]
        private IWebElement onesieImageLink;

        //Test All The Things T-Shirt Section
        [FindsBy(How = How.Id, Using = "add-to-cart-test.allthethings()-t-shirt-(red)")]
        private IWebElement addTestAllTheThingsTShirtToCartButton;

        [FindsBy(How = How.Id, Using = "remove-test.allthethings()-t-shirt-(red)")]
        private IWebElement removeTestAllTheThingsTShirtFromCartButton;

        [FindsBy(How = How.Id, Using = "item_3_title_link")]
        private IWebElement testAllTheThingsTShirtTitleLink;

        [FindsBy(How = How.Id, Using = "item_3_img_link")]
        private IWebElement testAllTheThingsTShirtImageLink;

        //Shopping Cart Section
        [FindsBy(How = How.Id, Using = "shopping_cart_container")]
        private IWebElement shoppingCartContainer;

        [FindsBy(How = How.ClassName, Using = "shopping_cart_badge")]
        private IWebElement shoppingCartBadge;

        //Burger Menu Section
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
    }
}
