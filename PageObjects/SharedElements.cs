﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUITestFramework.PageObjects
{
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

        public SharedElements(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}