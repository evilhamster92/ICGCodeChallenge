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
        private static IWebDriver browser = GetDriverInstance();


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

             else (BrowserName.Contains("firefox") || BrowserName.Contains("Firefox"))
            {
                Console.WriteLine("Started firefoxdriver instance.");
                browser = new FirefoxDriver();
                return browser;
             }
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
//________________



        public static void WaitForElementToBeDisplayed(string Element, int Timeout)
        {
            try
            {
                Console.WriteLine("Waiting " + Timeout.ToString() + " for the " + Element + "to become displayed");
                TimeSpan t = new TimeSpan(0, 0, 0, Timeout);
                WebDriverWait wait = new WebDriverWait(browser, t);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Element)));

                Console.WriteLine("Element " + Element + " became visible.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail("Element " + Element + "failed to become displayed.");
            }
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
                browser.Navigate().GoToUrl(pageToNavigate);
                Console.WriteLine("Navigated to: ." + pageToNavigate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public static LinkedList<IWebElement> findElements(string ElementLocator, string LocatorType)
        {
            LinkedList<IWebElement> list;

            if (LocatorType.Equals("xpath"))
            {
                try
                {
                    IReadOnlyCollection<IWebElement> rawList = browser.FindElements(By.XPath(ElementLocator));
                    list = new LinkedList<IWebElement>(rawList);
                    Console.WriteLine("Successfully found " + list.Count + " elements with the locator" + ElementLocator);
                }
                catch (Exception e)
                {
                    list = null;
                    Assert.Fail("Failed to find elements " + ElementLocator);
                }
            }
            else
            {
                list = new LinkedList<IWebElement>();
            }

            return list;
        }

        public static IWebElement findElement(string ElementLocator)
        {
            IWebElement element;
            try
            {
                element = browser.FindElement(By.XPath(ElementLocator));
                Console.WriteLine("Successfully found the element" + ElementLocator);
            }
            catch (Exception e)
            {
                element = null;
                Assert.Fail("Failed to find element " + ElementLocator);
                Console.WriteLine("Exception reached" + e.Message);
            }

            return element;
        }

        public static void QuitBrowser()
        {
            Console.WriteLine("Closed the driver instance.");
            //LoggerHelper.CloseLogger();
            browser.Quit();
        }
    }
}
