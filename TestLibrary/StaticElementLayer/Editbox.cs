using SeleniumTestLibrary.ElementsWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestLibrary.StaticElementLayer
{
    public class Editbox : AbstractEditbox
    {
        /// <summary>
        /// Sends text to a IWebElement
        /// </summary>
        /// <param name="ElementLocator">Locator of the element</param>
        /// <param name="LocatorType"> Type of the element. It can be: xpath, id</param>
        /// <param name="Text">Text to be send to the element</param>
        public static void SendText(string ElementLocator, string Text)
        {
            AbstractEditbox control = new AbstractEditbox();
            control.SendText(ElementLocator, Text);
        }
    }
}
}
