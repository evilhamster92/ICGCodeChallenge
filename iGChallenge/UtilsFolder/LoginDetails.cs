using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iGChallenge.UtilsFolder
{
    public class LoginDetails
    {
        
            private LoginDetails(string value) { Value = value; }

            public string Value { get; set; }

            public static LoginDetails User { get { return new LoginDetails("adrian.bartos92@gmail.com"); } }
            public static LoginDetails Pass { get { return new LoginDetails("dummypassword2."); } }


    }
}
