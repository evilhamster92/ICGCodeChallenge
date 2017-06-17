using RestTestsLibrary.Base;
using RestTestsLibrary.Responses;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace iGChallenge
{
    [Binding]
    public class UnsuccessfulRegistrationSteps : RestTestBase
    {
        Dictionary<string, string> requestValues = new Dictionary<string, string>();

        [Given(@"No password is sent")]
        public void GivenNoPasswordIsSent()
        {
            Console.WriteLine("Not sending any password.");
            response = SendRegisterRequest(requestValues);
        }
        
        [Then(@"Response with (.*) is sent back")]
        public void ThenResponseWithIsSentBack(int p0)
        {
            ResponsesHelper.VerifyResponseHttpCode(response, p0.ToString());
        }
        
        [Then(@"Error message is sent back")]
        public void ThenErrorMessageIsSentBack()
        {
            ResponsesHelper.VerifyResponseContentContainsToken(response, "Missing email or username");
        }
    }
}
