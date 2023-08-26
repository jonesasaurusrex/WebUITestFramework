using OpenQA.Selenium;

namespace WebUITestFramework
{
    public static class Globals
    {
        /// <summary>
        /// Searches the page the driver is currently on for the supplied text
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool TextIsPresentOnPage(IWebDriver driver, string text)
        {
            return driver.PageSource.Contains(text);
        }
    }
}