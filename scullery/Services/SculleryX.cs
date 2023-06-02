using RestSharp;
using RestSharp.Authenticators.OAuth2;
using Microsoft.Extensions.Configuration;

namespace Scullery.Services
{
    class SculleryX
    {
        private string _baseURL { get; set;}
        private string _token { get; set;}
        public SculleryX()
        {
           IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .Build();
    _baseURL = config.GetValue<string>("TMDB:baseURL");
_token = config.GetValue<string>("TMDB:BearerToken");
        }
        public async void FetchMovieDetailsTMDB(string path)
        {
            var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_token, "Bearer");
            var options = new RestClientOptions(_baseURL)
            {
                Authenticator = authenticator
            };
            var client = new RestClient(options);
            var request = new RestRequest(path, Method.Get);
            request.AddHeader("accept", "application/json");
            var response = await client.GetAsync(request);
            Console.WriteLine(response.Content);
        }
    }
}