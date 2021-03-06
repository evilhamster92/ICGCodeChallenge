﻿using iGChallenge.UtilsFolder;
using iGChallenge.WebpageLocators;
using OpenQA.Selenium;
using SeleniumTestLibrary.BaseFramework;
using SeleniumTestLibrary.BaseFramework.BaseLayer;
using SeleniumTestLibrary.StaticElementLayer;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace iGChallenge
{
    [Binding]
    public class NoteIsSavedWhenLoggingOutSteps : SeleniumTest
    {
        [Given(@"The user logs into the application")]
        public void GivenTheUserLogsIntoTheApplication()
        {
            BrowserManager.Navigate("https://www.evernote.com/Login.action?targetUrl=%2FHome.action");

            Editbox.SendText(LoginPage.Email_EditBox, LoginDetails.User.Value);
            Button.Click(LoginPage.Login_Button);
            Editbox.SendText(LoginPage.Password_Editbox, LoginDetails.Pass.Value);
            Button.Click(LoginPage.Login_Button);
            BrowserManager.ImplicitWait(3);
        }

        [Given(@"User clicks on the create new note button")]
        public void GivenUserClicksOnTheCreateNewNoteButton()
        {
            Button.Click(NotesMenu.NewNoteButton);
        }

        [When(@"Note '(.*)' and '(.*)' is entered")]
        public void WhenNoteTesttitleAndTestdescriptionIsEntered(string title, string description)
        {
            Editbox.SendText(NotesMenu.NoteTitle_Editbox, title);
            Editbox.SendText(NotesMenu.NoteTitle_Editbox, Keys.Tab);
            //Editbox.SendText(NotesMenu.NoteDescription_Editbox, description);

        }

        [When(@"Done button is clicked")]
        public void WhenDoneButtonIsClicked()
        {
            Button.Click(CreateNewNote.Done_Button);
            BrowserManager.ImplicitWait(2);
        }

        [When(@"User logs out and back in")]
        public void WhenUserLogsOutAndBackIn()
        {

            Button.Click(NotesMenu.AccountIcon_button);
            Button.Click(NotesMenu.Logout_Label);

            BrowserManager.Navigate("https://www.evernote.com/Login.action?targetUrl=%2FHome.action");
            Editbox.SendText(LoginPage.Email_EditBox, LoginDetails.User.Value);
            Button.Click(LoginPage.Login_Button);
            Editbox.SendText(LoginPage.Password_Editbox, LoginDetails.Pass.Value);
            Button.Click(LoginPage.Login_Button);
        }

        [Then(@"Note '(.*)' should be saved")]
        public void ThenNoteShouldBeSaved(string title)
        {
            BrowserManager.ImplicitWait(3);
            Label.VerifyText(NotesMenu.CreatedNoteTitle_Label, title);
            Console.WriteLine("test finished.");
            NotesMenu.Logout();
            //BrowserManager.QuitBrowser();
        }
    }
}
