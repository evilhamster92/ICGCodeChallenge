using SeleniumTestLibrary.ElementsWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestLibrary.StaticElementLayer
{
    public class Label : LabelWrapper
    {

        /// <summary>
        /// Verifies text of a label.
        /// </summary>
        /// <param name="ElementLocator"></param>
        /// <param name="ExpectedText"></param>
        public static void VerifyText (string ElementLocator, string ExpectedText)
        {
            LabelWrapper control = new LabelWrapper();
            control.VerifyText(ElementLocator, ExpectedText);
        }
    }
}
