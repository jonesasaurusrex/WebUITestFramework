using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUITestFramework.Tests
{
    [TestFixture, Order(5)]
    public class CheckoutStepOnePageTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }


        [TearDown] public void Teardown()
        {
            _driver.Quit();
        }
    }
}
