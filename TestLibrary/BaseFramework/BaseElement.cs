using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTestLibrary.BaseFramework.BaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestLibrary.BaseFramework
{
    public abstract class BaseElement
    {
        public const int DEFAULT_WAIT_TIME = 10;
        public static IWebDriver browser = BrowserManager.GetDriverInstance();
        static TimeSpan timeout = new TimeSpan(0, 0, 0, DEFAULT_WAIT_TIME);

        public static void WaitForElementToBeDisplayed(string Element, int Timeout)
        {
            try
            {
                Console.WriteLine("Waiting " + Timeout.ToString() + " for the " + Element + "to become displayed");

                WebDriverWait wait = new WebDriverWait(browser, timeout);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Element)));

                Console.WriteLine("Element " + Element + " became visible.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Assert.Fail("Element " + Element + "failed to become displayed.");
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
                WebDriverWait wait = new WebDriverWait(browser, timeout);
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(ElementLocator)));
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

    }
}
