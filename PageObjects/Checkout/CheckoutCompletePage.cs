using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUITestFramework.PageObjects.Checkout
{
    /// <summary>
    /// Provides methods for interacting with the checkout complete page
    /// </summary>
    public class CheckoutCompletePage : SharedElements
    {
        private IWebDriver _driver;

        public const string URL = "https://www.saucedemo.com/checkout-complete.html";
        public CheckoutCompletePage(IWebDriver driver) : base(driver) 
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
