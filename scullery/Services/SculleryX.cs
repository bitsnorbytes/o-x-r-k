using RestSharp;
using RestSharp.Authenticators.OAuth2;
using Microsoft.Extensions.Configuration;
using Scullery.Models;

namespace Scullery.Services
{
    class SculleryX
    {
        private List<int> movieIdList { get; set;}
        private readonly IConfiguration _configuration;
        public SculleryX(IConfiguration configuration) {
           _configuration = configuration;
        }
        public async Task<List<int>> FetchProdListTMDB(string path)
        {
            var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_configuration.GetValue<string>("TMDB:BearerToken"), "Bearer");
            var options = new RestClientOptions(_configuration.GetValue<string>("TMDB:baseURL"))
            {
                Authenticator = authenticator
            };
            var client = new RestClient(options);
            var response = await client.GetJsonAsync<TMDBMovieList>(path);
            movieIdList = new List<int>();
            foreach(var item in response.Items) {
                movieIdList.Add(item.Id);
            }
            return movieIdList;
        }
        public async void FetchMovieDetailsTMDB(string path)
        {
            var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_configuration.GetValue<string>("TMDB:BearerToken"), "Bearer");
            var options = new RestClientOptions(_configuration.GetValue<string>("TMDB:baseURL"))
            {
                Authenticator = authenticator
            };
            var client = new RestClient(options);
            var response = await client.GetJsonAsync<CinemaCatalogue>(path);
            
        }
    }
}