using Scullery.Models;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scullery.Services
{
    class SculleryX
    {
        private string _baseURL;
        private string _token;
        public SculleryX(string baseURL, string token)
        {
            _baseURL = baseURL;
            _token = token;
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