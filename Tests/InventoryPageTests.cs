using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUITestFramework.PageObjects;

namespace WebUITestFramework.Tests
{
    [TestFixture, Order(2)]
    public class InventoryPageTests
    {
        private IWebDriver _driver;
        private InventoryPage _inventoryPage;

        [SetUp]
        public void SetUp(IWebDriver driver) {
            _driver = driver;
            LoginPage lp = new LoginPage(_driver);
            _inventoryPage = lp.LoginWithCredentials(LoginPage.STANDARD_USER_USERNAME, LoginPage.PASSWORD);
        }

        [Test, Order(1)]
        public void PlaceholderTest()
        {
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
