using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestTestsLibrary.Responses
{
    public class ResponsesHelper
    {

        public static string GetHttpCodeFromResponse(IRestResponse response)
        {
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Console.WriteLine("Status code is: " + numericStatusCode);
            return numericStatusCode.ToString();
        }

        public static void VerifyResponseContentContainsToken(IRestResponse response, string text)
        {
            Console.WriteLine("Response token is: " + response.Content.ToString());
            if (!response.Content.ToString().Contains(text))
            {
                Assert.Fail("Response does not contain the token");
            }
        }

        public static void VerifyResponseHttpCode(IRestResponse response, string code)
        {
            string codeFromResponse = GetHttpCodeFromResponse(response);
            Console.WriteLine("Response code is: " + codeFromResponse);
            if (!codeFromResponse.ToString().Equals(code))
            {
                Assert.Fail("Response does not contain the correct code");
            }
        }
    }
}
