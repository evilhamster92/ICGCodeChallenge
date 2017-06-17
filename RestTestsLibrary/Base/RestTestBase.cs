using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTestsLibrary.Base
{
    public class RestTestBase
    {
        public static RestClient restClient;
        public static RestRequest request;
        public static IRestResponse response;


        /// <summary>
        /// Does a Register request 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static IRestResponse SendRegisterRequest(Dictionary<string, string> a)
        {
            restClient = new RestClient("https://reqres.in/api/register");
            request = new RestRequest(Method.POST);

            foreach (KeyValuePair<string, string> entry in a)
            {
                request.AddParameter(entry.Key, entry.Value);
            }

            return restClient.Execute(request);
        }

        /// <summary>
        /// Requests a list of users
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static IRestResponse SendGetUserListRequest()
        {
            restClient = new RestClient("https://reqres.in/api/users");
            request = new RestRequest(Method.GET);
            return restClient.Execute(request);
        }

    }
}
