using OpenQA.Selenium;
using SeleniumTestLibrary.BaseFramework.BaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestLibrary.BaseFramework
{
    public abstract class SeleniumTest
    {
        public IWebDriver browser = BrowserManager.GetDriverInstance();
    }
}
