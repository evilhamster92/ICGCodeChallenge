using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace SeleniumTestLibrary.BaseFramework.BaseLayer
{
    public class BrowserManager
    {
        //private static BrowserManager browser = new BrowserManager();
        private static IWebDriver browser;


        public BrowserManager()
        {
            GetDriverInstance();
        }

        /// <summary>
        /// For the moment only chrome will be supported. 
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        private static IWebDriver CreateWebdriverInstance(string BrowserName)
        {
            if (BrowserName.Contains("chrome"))
            {
                browser = new ChromeDriver();
                Console.WriteLine("Started chrome instance.");
                return browser;
            }

            return browser;
        }



        /// <summary>
        /// Returns the instance of the webdriver. Only chrome supported for the demo
        /// </summary>
        /// <param name="BrowserName"></param>
        /// <returns></returns>
        public static IWebDriver GetDriverInstance()
        {
            if (browser == null)
            {
                CreateWebdriverInstance("chrome");
            }
            if (browser != null)
            {
                // maximize the window, before any action is to be done on it.
                browser.Manage().Window.Maximize();
                return browser;
            }
            else
            {
                //throw new exception as something is wrong with the current instance
            }

            return browser;
        }

        public static void Refresh()
        {
            try
            {
                browser.Navigate().Refresh();
                Console.WriteLine("Successfully refreshed the page.");
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                Console.Write("Failed to refresh the page" + e.Message);
            }
        }



        public static void Navigate(string pageToNavigate)
        {
            try
            {
                browser.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, 0, 5));
                browser.Navigate().GoToUrl(pageToNavigate);
                Console.WriteLine("Navigated to: ." + pageToNavigate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        public static void QuitBrowser()
        {
            Console.WriteLine("Closed the driver instance.");
            //LoggerHelper.CloseLogger();
            browser.Quit();
        }

        public static void WaitForPageToLoad()
        {
            Console.WriteLine("Waiting for page to load.");
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            wait.Until(driver1 => ((IJavaScriptExecutor)browser).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void ImplicitWait(int seconds)
        {
            Console.WriteLine("Waiting " + seconds + " seconds.");
            browser.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }
    }
}
