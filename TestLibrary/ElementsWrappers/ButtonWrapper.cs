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
   public class ButtonWrapper : BaseElement
    {

        public void Click(string ElementLocator)
        {
            try
            {
                IWebElement elem = BaseElement.findElement(ElementLocator);
                elem.Click();
                Console.WriteLine("Succesfully clicked on the element + " + ElementLocator);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: " + e.ToString());
                Assert.Fail("Failed to click on the element: " + ElementLocator);
            }
        }
    }
}
