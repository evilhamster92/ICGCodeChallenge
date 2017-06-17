using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGChallenge.WebpageLocators
{
    public class LoginPage
    {

        #region locators
        //HERE WE WILL STORE XPATHS FOR ALL ELEMENTS IN LOGIN THE PAGE

        public static string HomePageSignIn_Button = "//a[contains(text(), 'Sign In')]";
        public static string Email_EditBox = "//input[@id='username']";
        public static string Login_Button = "//input[@id='loginButton']";
        public static string Password_Editbox = "//input[@id='password']";
        public static string LoginError_Label = "//div[@id='responseMessage']";

        #endregion



        #region UiStrings
        public static string LoginError_Text = "Required data missing";

        #endregion
    }
}
