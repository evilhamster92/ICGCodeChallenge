using OpenQA.Selenium;
using SeleniumTestLibrary.BaseFramework.BaseLayer;


namespace SeleniumTestLibrary.BaseFramework
{
    public abstract class SeleniumTest
    {
        public IWebDriver driver = BrowserManager.GetDriverInstance();
    }
}
