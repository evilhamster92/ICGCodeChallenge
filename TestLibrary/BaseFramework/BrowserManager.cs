﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Automation.BaseFramework.BaseLayer
{
    public class BrowserManager
    {
        private static IWebDriver browser;

        public BrowserManager()
        {
            //implicit constructor;
            browser.Manage().Window.Maximize();

        }

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

        public BrowserManager(string driver, string startingPage)
        {
            if (driver.Contains("chrome"))
            {
                browser = new ChromeDriver();
                Console.WriteLine("Started chromedriver instance.");
            }

            if (driver.Contains("firefox") || driver.Contains("Firefox"))
            {
                Console.WriteLine("Started firefoxdriver instance.");
                browser = new FirefoxDriver();
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
