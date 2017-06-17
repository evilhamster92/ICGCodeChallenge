using iGChallenge.WebpageLocators;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestLibrary.BaseFramework;
using SeleniumTestLibrary.BaseFramework.BaseLayer;
using SeleniumTestLibrary.StaticElementLayer;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace iGChallenge.SeleniumTests.Steps.Notes
{
    [Binding]
    public class CreateTableInTheNoteSteps : SeleniumTest
    {
        [When(@"The add table button is pressed")]
        public void WhenTheAddTableButtonIsPressed()
        {
            //BrowserManager.ImplicitWait(10);

            Button.Click(NotesMenu.NoteTitle_Editbox);
            Editbox.SendText(NotesMenu.NoteTitle_Editbox, Keys.Tab);
            Button.Click(CreateNewNote.CreateTable_Button);
        }

        [Then(@"Table is created inside the note body")]
        public void ThenTableIsCreatedInsideTheNoteBody()
        {
            CreateNewNote.CreateTableByDimension(3, 3);
        }

        [Then(@"Table is of the correct '(.*)'")]
        public void ThenTableIsOfCorrectDimension(string dimension)
        {
            Button.Click(CreateNewNote.Done_Button);
            BrowserManager.ImplicitWait(2);

            // get the number of table cells - they should be 9 for a 3x3 table
            LinkedList<IWebElement> list = BaseElement.findElements("//table[contains(@style, 'evernote-table')]//td", "xpath");
            Console.WriteLine(list.Count);

            //calculate the number of cells given in the string argument
            int cells = int.Parse(dimension.Substring(0, 1)) * int.Parse(dimension.Substring(2, 1));

            //compare the numbers
            if (cells != list.Count)
            {
                Assert.Fail("Table created was not of the correct dimension.");
            }

            BrowserManager.QuitBrowser();
        }
    }
}
