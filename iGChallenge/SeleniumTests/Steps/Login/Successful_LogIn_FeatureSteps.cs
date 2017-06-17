using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using SeleniumTestLibrary.BaseFramework.BaseLayer;
using SeleniumTestLibrary.BaseFramework;
using SeleniumTestLibrary.StaticElementLayer;
using iGChallenge.WebpageLocators;
using iGChallenge.UtilsFolder;
using NUnit.Framework;

namespace iGChallenge
{
    [Binding]
    public class Successful_LogIn_FeatureSteps : SeleniumTest
    {

        [Given(@"User is at the Home Page")]
        public void GivenUserIsAtTheHomePage()
        {
            BrowserManager.Navigate("https://evernote.com/");
        }

        [Given(@"Navigate to LogIn Page")]
        public void GivenNavigateToLogInPage()
        {

            //this is because the homepage varies and so does the name of the button
            // I guess this is because of cookies
            if (BaseElement.isDisplayed(LoginPage.HomePageLogIn_Button) == false)
            {
                Button.Click(LoginPage.HomePageSignIn_Button);
            }
            else
            {
                Button.Click(LoginPage.HomePageLogIn_Button);
            }
        }

        [When(@"User enter UserName and Password")]
        public void WhenUserEnterUserNameAndPassword()
        {
            Editbox.SendText(LoginPage.Email_EditBox, LoginDetails.User.Value);
            Button.Click(LoginPage.Login_Button);
            Editbox.SendText(LoginPage.Password_Editbox, LoginDetails.Pass.Value);
        }

        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {
            Button.Click(LoginPage.Login_Button);
        }

        [Then(@"Notes page should display")]
        public void ThenSuccessfulLogINMessageShouldDisplay()
        {
            Button.WaitForElementToBeDisplayed("//*[@id=\"gwt-debug-AccountMenuView-root\"]", 5);
            if (Button.isDisplayed("//*[@id=\"gwt-debug-AccountMenuView-root\"]") != true)
            {
                Assert.Fail("Image of logged user is not displayed");
            }

            NotesMenu.Logout();
            //BrowserManager.QuitBrowser();

        }
    }
}
