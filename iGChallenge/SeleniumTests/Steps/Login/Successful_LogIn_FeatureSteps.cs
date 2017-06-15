using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using SeleniumTestLibrary.BaseFramework.BaseLayer;
using SeleniumTestLibrary.BaseFramework;
using SeleniumTestLibrary.StaticElementLayer;

namespace iGChallenge
{
    [Binding]
    public class Successful_LogIn_FeatureSteps : SeleniumTest
    {
        //public IWebDriver driver;
        TimeSpan t = new TimeSpan(0, 0, 0, 30);

        [Given(@"User is at the Home Page")]
        public void GivenUserIsAtTheHomePage()
        {
            BrowserManager.Navigate("https://evernote.com/");
        }

        [Given(@"Navigate to LogIn Page")]
        public void GivenNavigateToLogInPage()
        {
            /*
            if (driver.FindElement(By.XPath("/html/body/header/div[2]/a[1]")).Displayed)
            {
                driver.FindElement(By.XPath("/html/body/header/div[2]/a[1]")).Click();
            }
            else
            {
                driver.FindElement(By.XPath("//*[@class='login'")).Click();
            }
            */
        }

        [When(@"User enter UserName and Password")]
        public void WhenUserEnterUserNameAndPassword()
        {
            Editbox.SendText("//input[@id='username']", ""adrian.bartos92@gmail.com"")
            //driver.FindElement(By.XPath("//input[@id='username']")).SendKeys("adrian.bartos92@gmail.com");
            //driver.FindElement(By.XPath("//input[@id='loginButton']")).Click();



            WebDriverWait wait = new WebDriverWait(driver, t);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='password']")));

            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("dummypassword2.");
        }

        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {
            driver.FindElement(By.XPath("//input[@id='loginButton']")).Click();
        }

        [Then(@"Successful LogIN message should display")]
        public void ThenSuccessfulLogINMessageShouldDisplay()
        {
            //driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromMilliseconds(5000));
            WebDriverWait wait = new WebDriverWait(driver, t);
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#gwt-debug-AccountMenu-avatar > div > div.GOKB433CGG > div > img")));
            driver.FindElement(By.CssSelector("#gwt-debug-AccountMenu-avatar > div > div.GOKB433CGG > div > img")).Click();

            driver.Close();

        }
    }
}
