using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGChallenge.WebpageLocators
{
    public class NotesMenu
    {
        public static string NewNoteButton = "//*[@id = 'gwt-debug-Sidebar-newNoteButton-container']";
        public static string NoteTitle_Editbox = "//input[contains(@id,'NoteTitleView')]";
        public static string NoteDescription_Editbox = "//div[contains(@class,'en-note-is-empty')]";
        public static string AccountIcon_button = "//div [@id='gwt-debug-AccountMenu-avatar']//img[1]";
        public static string Logout_Label = "//div[contains(text(), 'Log out')]";
        public static string CreatedNoteTitle_Label = "//div[@class='focus-NotesView-Note-noteTitle qa-title']";
    }
}
