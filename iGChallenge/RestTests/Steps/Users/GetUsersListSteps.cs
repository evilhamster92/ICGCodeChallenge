using RestTestsLibrary.Base;
using RestTestsLibrary.Responses;
using System;
using TechTalk.SpecFlow;

namespace iGChallenge.RestTests.Steps.Users
{
    [Binding]
    public class GetUsersListSteps : RestTestBase
    {
        [Given(@"The rest API endoing for GetUserList")]
        public void GivenTheRestAPIEndoingForGetUserList()
        {
            response = RestTestBase.SendGetUserListRequest();
        }

        [Given(@"No payload is being sent")]
        public void GivenNoPayloadIsBeingSent()
        {
            Console.WriteLine("No payload is being sent.");
        }

        [Then(@"List with users is sent back")]
        public void ThenListWithUsersIsSentBack()
        {
            ResponsesHelper.VerifyResponseContentContainsToken(response, "first_name");
            ResponsesHelper.VerifyResponseContentContainsToken(response, "last_name");
        }
    }
}
