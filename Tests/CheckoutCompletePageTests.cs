using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUITestFramework.Tests
{
    [TestFixture, Order(7)]
    public class CheckoutCompletePageTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }


        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
