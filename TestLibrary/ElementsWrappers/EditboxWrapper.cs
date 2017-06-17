using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestLibrary.BaseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestLibrary.ElementsWrappers
{
    public class EditboxWrapper : BaseElement
    {

        /// <summary>
        /// Sends text to an editbox
        /// </summary>
        /// <param name="ElementLocator"></param>
        /// <param name=""></param>
        /// <param name="TextToBeSent"></param>
        public void SendText(string ElementLocator, string TextToBeSent)
        {
            try
            {
                IWebElement elem = BaseElement.findElement(ElementLocator);
                elem.SendKeys(TextToBeSent);
                Console.WriteLine("Successfully sent " + TextToBeSent + " text to the element: " + ElementLocator);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to send text to the element" + ElementLocator);
                Assert.Fail("Failed to send text to the element" + ElementLocator);

            }
        }
    }
}
