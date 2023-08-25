using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUITestFramework.PageObjects
{
    public class InventoryItemSection
    {
        private IWebDriver _driver;

        //Elements
        private IWebElement addToCartButton;

        private IWebElement removeFromCartButton;

        private IWebElement itemTitleLink;

        private IWebElement itemImageLink;

        private string _addToCartButtonId;

        private string _removeFromCartButtonId;


        public InventoryItemSection(IWebDriver driver, string addToCartButtonId, string removeFromCartButtonId, string itemTitleLinkId, string itemImageLinkId) 
        {
            _driver = driver;
            _addToCartButtonId = addToCartButtonId;
            _removeFromCartButtonId = removeFromCartButtonId;
            itemTitleLink = _driver.FindElement(By.Id(itemTitleLinkId));
            itemImageLink = _driver.FindElement(By.Id(itemImageLinkId));
        }

        //Methods
        /// <summary>
        /// Clicks the Add to cart button in the section
        /// </summary>
        public void ClickAddToCart()
        {
            addToCartButton = _driver.FindElement(By.Id(_addToCartButtonId));
            addToCartButton.Click();
        }

        /// <summary>
        /// Clicks the Remove button in the section
        /// </summary>
        public void ClickRemoveFromCart() 
        {
            removeFromCartButton = _driver.FindElement(By.Id(_removeFromCartButtonId));
            removeFromCartButton.Click(); 
        }

        /// <summary>
        /// Clicks the Title in the section
        /// </summary>
        public void ClickItemTitleLink()
        {  
            itemTitleLink.Click(); 
        }

        /// <summary>
        /// Clicks the Image in the section
        /// </summary>
        public void ClickItemImageLink() 
        {  
            itemImageLink.Click(); 
        }
    }
}
