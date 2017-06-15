using iGChallenge.WebpageLocators;
using SeleniumTestLibrary.StaticElementLayer;
using System;
using TechTalk.SpecFlow;

namespace iGChallenge.SeleniumTests.Steps.Login
{
    [Binding]
    public class Failed_Login_Without_Credentials_FeatureSteps
    {
        [When(@"User does not enter UserName and Password")]
        public void WhenUserDoesNotEnterUserNameAndPassword()
        {
            Button.Click(LoginPage.Login_Button);
        }
        
        [Then(@"Correct error message should display")]
        public void ThenCorrectErrorMessageShouldDisplay()
        {
            Button.Click(LoginPage.LoginError_Label);
        }
    }
}
