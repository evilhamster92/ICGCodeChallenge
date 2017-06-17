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
    public class LabelWrapper : BaseElement
    {
        public String GetText(string ElementLocator)
        {
            String elementText = "";

            try
            {
                IWebElement elem = BaseElement.findElement(ElementLocator);
                elementText = elem.Text;
                Console.WriteLine("Text of the element + " + ElementLocator + " is: " + elementText);
                return elementText;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: " + e.ToString());
                Assert.Fail("Failed to find element: " + ElementLocator);
            }

            return elementText;
        }


        public void VerifyText(String ElementLocator, String ExpectedText)
        {
            String elementText = GetText(ElementLocator);
            Console.WriteLine("Text of the element + " + ElementLocator + " is: " + elementText);
            Console.WriteLine("Expected value is:" + ExpectedText);

            if (!elementText.Equals(ExpectedText))
            {
                Assert.Fail("Elements text are different." + ExpectedText + elementText);
            }


        }
    }
}
