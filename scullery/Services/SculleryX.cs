using RestSharp;
using RestSharp.Authenticators.OAuth2;
using Microsoft.Extensions.Configuration;

namespace Scullery.Services
{
    class SculleryX
    {
        private readonly IConfiguration _configuration;
        public SculleryX(IConfiguration configuration) {
           _configuration = configuration;
        }
        public async void FetchProdListTMDB(string path)
        {
            var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_configuration.GetValue<string>("TMDB:BearerToken"), "Bearer");
            var options = new RestClientOptions(_configuration.GetValue<string>("TMDB:baseURL"))
            {
                Authenticator = authenticator
            };
            var client = new RestClient(options);
            var request = new RestRequest(path, Method.Get);
            request.AddHeader("accept", "application/json");
            var response = await client.GetAsync(request);
            Console.WriteLine(response.Content);
        }
        public async void FetchMovieDetailsTMDB(string path)
        {
            var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_configuration.GetValue<string>("TMDB:BearerToken"), "Bearer");
            var options = new RestClientOptions(_configuration.GetValue<string>("TMDB:baseURL"))
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