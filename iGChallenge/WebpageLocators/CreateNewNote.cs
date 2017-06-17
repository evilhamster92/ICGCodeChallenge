using SeleniumTestLibrary.StaticElementLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGChallenge.WebpageLocators
{
    public class CreateNewNote
    {
        public static string Done_Button = "//button[@id='gwt-debug-NoteAttributes-doneButton']";
        public static string CreateTable_Button = "//div[contains(@id,'tableButton')]";


        #region BusinessLogic

        public static void CreateTableByDimension(int height, int length)
        {
            string composedXpath = "//div[contains(@class,'col" + height + "-row" + length + "')]";
            Button.Click(composedXpath);
        }

        #endregion
    }
}
