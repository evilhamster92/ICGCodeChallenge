using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace iGChallenge
{
    [Binding]
    public class Successful_LogIn_FeatureSteps
    {
        public IWebDriver driver;
        [Given(@"User is at the Home Page")]
        public void GivenUserIsAtTheHomePage()
        {
            //System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"/path/to/geckodriver.exe"
            driver = new ChromeDriver();
            driver.Url = "https://evernote.com/";
        }
        
        [Given(@"Navigate to LogIn Page")]
        public void GivenNavigateToLogInPage()
        {
            driver.FindElement(By.XPath("/html/body/header/div[2]/a[1]")).Click();
        }
        
        [When(@"User enter UserName and Password")]
        public void WhenUserEnterUserNameAndPassword()
        {
            driver.FindElement(By.XPath("//input[@id='username']")).SendKeys("adrian.bartos92@gmail.com");
            driver.FindElement(By.XPath("//input[@id='loginButton']")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromMilliseconds(5000));

            driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("adrian.bartos92@gmail.com");
        }
        
        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {
            driver.FindElement(By.XPath("//input[@id='loginButton']")).Click();
        }
        
        [Then(@"Successful LogIN message should display")]
        public void ThenSuccessfulLogINMessageShouldDisplay()
        {
            driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromMilliseconds(5000));
            driver.FindElement(By.XPath("//*[@id='gwt - debug - AccountMenu - avatar']/div/div[1]/div/img[1]")).Click();

        }
    }
}
