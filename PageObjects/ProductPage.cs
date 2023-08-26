using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebUITestFramework.PageObjects
{
    /// <summary>
    /// Provides methods for interacting with the specific product pages
    /// </summary>
    public class ProductPage : SharedElements
    {
        private IWebDriver _driver;

        private string _addToCartButtonId;

        private string _removeFromCartButtonId;

        //Elements
        private IWebElement addToCartButton;

        private IWebElement removeFromCartButton;

        [FindsBy(How = How.ClassName, Using = "inventory_details_name")]
        private IWebElement productNameElement;

        [FindsBy(How = How.ClassName, Using = "inventory_details_desc")]
        private IWebElement productDescriptionElement;

        [FindsBy(How = How.ClassName, Using = "inventory_details_price")]
        private IWebElement productPriceElement;

        [FindsBy(How = How.Id, Using = "back-to-products")]
        private IWebElement backToProductsButton;

        public ProductPage(IWebDriver driver, string addToCartId, string removeFromCartId) : base(driver)
        {
            _driver = driver;
            _addToCartButtonId = addToCartId;
            _removeFromCartButtonId = removeFromCartId;
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Clicks the Add to cart button in the product page
        /// </summary>
        public void ClickAddToCart()
        {
            addToCartButton = _driver.FindElement(By.Id(_addToCartButtonId));
            addToCartButton.Click();
        }

        /// <summary>
        /// Clicks the Remove from cart button in the product page
        /// </summary>
        public void ClickRemoveFromCart()
        {
            removeFromCartButton = _driver.FindElement(By.Id(_removeFromCartButtonId));
            removeFromCartButton.Click();
        }

        /// <summary>
        /// Clicks the Return to products button in the product page
        /// </summary>
        public void ClickReturnToProducts()
        {
            backToProductsButton.Click();
        }

        /// <summary>
        /// Gets the text content from the product name off the page
        /// </summary>
        /// <returns></returns>
        public string GetProductNameTextFromPage()
        {
            return productNameElement.Text;
        }

        /// <summary>
        /// Gets the text content from the product description off the page
        /// </summary>
        /// <returns></returns>
        public string GetProductDescriptionFromPage()
        {
            return productDescriptionElement.Text;
        }

        /// <summary>
        /// Gets the text content from the product price off the page
        /// </summary>
        /// <returns></returns>
        public string GetProductPriceTextFromPage()
        {
            return productPriceElement.Text;
        }
    }
}
