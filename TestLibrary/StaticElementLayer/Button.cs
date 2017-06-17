using SeleniumTestLibrary.ElementsWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestLibrary.StaticElementLayer
{
    public class Button : ButtonWrapper
    {

        /// <summary>
        /// Clicks on a iWebElement.
        /// </summary>
        /// <param name="ElementLocator">String on how to find the element</param>
        /// <param name="LocatorType">It can be xpath, id, etc</param>
        public static void Click(string ElementLocator)
        {
            ButtonWrapper control = new ButtonWrapper();
            control.Click(ElementLocator);
        }
    }
}
