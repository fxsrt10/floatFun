using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Tweetinvi;
using System.Linq;
using DevDefined.OAuth;
using System.Security.Cryptography.X509Certificates;

namespace ApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Twitter");
            TwitterTimelne();
            Console.WriteLine("Context.io");
            ContextIO().Wait();

            Console.ReadLine();

        }

        static void TwitterTimelne()
        {
            TwitterCredentials.SetCredentials("376789858-VbjlvtQNEgHkMOju8o9O5ZBhUD6mxxg0w2U1F4Pq", "A0doIHcmBGP52m0LeQ9PHnfcfCrxUfZ2M2aMai6cTSblp", "AW7a7Sf3j8AATr3y1BgLuOAxN", "Hq58FMoCRhISWtVGr0YAPjx4Xuy40GDHSIImHeZ9KntXGzHcBX");

            // Create a parameter for queries with specific parameters
            var timeline = Timeline.GetHomeTimeline();
            var results = Search.SearchTweets("@smeriwether714");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(timeline.ToArray()[i].Text);
            }
        }

        static async Task ContextIO()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.context.io/2.0/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("accounts");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Test");
                }
            }
        }

        public static void oAuth()
        {
            X509Certificate2 certificate = TestCertificates.OAuthTestCertificate();

            string requestUrl = "https://www.google.com/accounts/OAuthGetRequestToken";
            string userAuthorizeUrl = "https://www.google.com/accounts/accounts/OAuthAuthorizeToken";
            string accessUrl = "https://www.google.com/accounts/OAuthGetAccessToken";
            string callBackUrl = "http://www.mysite.com/callback";

            var consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = "weitu.googlepages.com",
                SignatureMethod = SignatureMethod.RsaSha1,
                Key = certificate.PrivateKey
            };

            var session = new OAuthSession(consumerContext, requestUrl, userAuthorizeUrl, accessUrl)
                .WithQueryParameters(new { scope = "http://www.google.com/m8/feeds" });

            // get a request token from the provider
            IToken requestToken = session.GetRequestToken();

            // generate a user authorize url for this token (which you can use in a redirect from the current site)
            string authorizationLink = session.GetUserAuthorizationUrlForToken(requestToken, callBackUrl);

            // exchange a request token for an access token
            IToken accessToken = session.ExchangeRequestTokenForAccessToken(requestToken);

            // make a request for a protected resource
            string responseText = session.Request().Get().ForUrl("http://www.google.com/m8/feeds/contacts/default/base").ToString();
        }
    }

    class Product
    {
        public string Name { get; set; }
    }
}
