using RestSharp;
using RestSharp.Authenticators.OAuth2;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

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
            // TMDBMovieList? movieList = 
            //     JsonSerializer.Deserialize<TMDBMovieList>(response.Content);
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