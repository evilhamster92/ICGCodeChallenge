using iGChallenge.UtilsFolder;
using NUnit.Framework;
using RestSharp;
using RestTestsLibrary.Base;
using RestTestsLibrary.Responses;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace iGChallenge.RestTests.Steps.Login
{
    [Binding]
    public class SuccessfulRegistrationSteps : RestTestBase
    {
        Dictionary<string, string> requestValues = new Dictionary<string, string>();


        [Given(@"The user sends a correct email")]
        public void GivenTheUserSendsACorrectEmail()
        {
            requestValues.Add("email", LoginDetails.User.Value);
        }

        [Given(@"A correct password for the email is sent")]
        public void GivenACorrectPasswordForTheEmailIsSent()
        {
            requestValues.Add("password", "2");
            response = SendRegisterRequest(requestValues);

        }

        [Then(@"Response with '(.*)' code is sent back")]
        public void ThenResponseWithCodeIsSentBack(int p0)
        {
            string statuscode = ResponsesHelper.GetHttpCodeFromResponse(response);
            if (!statuscode.Equals(p0.ToString()))
            {
                Assert.Fail("No correct response.");
            }
        }

        [Then(@"Token is sent back")]
        public void ThenResponseWithCodeIsSentBack()
        {
            ResponsesHelper.VerifyResponseContentContainsToken(response, "token");
        }
    }
}
