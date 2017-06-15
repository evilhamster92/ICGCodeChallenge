using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using SeleniumTestLibrary.BaseFramework.BaseLayer;
using SeleniumTestLibrary.BaseFramework;
using SeleniumTestLibrary.StaticElementLayer;
using iGChallenge.WebpageLocators;

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
            Button.Click(LoginPage.HomePageSignIn_Button);
        }

        [When(@"User enter UserName and Password")]
        public void WhenUserEnterUserNameAndPassword()
        {
            Editbox.SendText(LoginPage.Email_EditBox, "adrian.bartos92@gmail.com");
            Button.Click(LoginPage.Login_Button);
            Editbox.SendText(LoginPage.Password_Editbox, "dummypassword2.");
        }

        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {
            Button.Click(LoginPage.Login_Button);
        }

        [Then(@"Successful LogIN message should display")]
        public void ThenSuccessfulLogINMessageShouldDisplay()
        {
            Button.Click("//*[@id=\"gwt-debug-AccountMenuView-root\"]");
            BrowserManager.QuitBrowser();

        }
    }
}
