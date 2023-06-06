using RestSharp;
using RestSharp.Authenticators.OAuth2;
using Microsoft.Extensions.Configuration;
using Scullery.Models;

namespace Scullery.Services
{
    class SculleryX
    {
        private readonly IConfiguration _configuration;
        private readonly CinemaCatalogingContext _cinemaCatalogingContext;
        public SculleryX(IConfiguration configuration, CinemaCatalogingContext cinemaCatalogingContext)
        {
            _configuration = configuration;
            _cinemaCatalogingContext = cinemaCatalogingContext;
        }
        RestClient Authenticator()
        {
            var authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_configuration.GetValue<string>("TMDB:BearerToken"), "Bearer");
            var options = new RestClientOptions(_configuration.GetValue<string>("TMDB:baseURL"))
            {
                Authenticator = authenticator
            };
            var client = new RestClient(options);
            return client;
        }
        public async Task<TMDBMovieList> FetchProdListTMDB(string path)
        {

            var response = await Authenticator().GetJsonAsync<TMDBMovieList>(path);
            return response;
        }
        public async Task<CinemaCatalogue> FetchMovieDetailsTMDB(string path)
        {
            var response = await Authenticator().GetJsonAsync<CinemaCatalogue>(path);
            return response;

        }
        public async Task<TMDBGenreList> FetchGenreList(string path)
        {
            var response = await Authenticator().GetJsonAsync<TMDBGenreList>(path);
            return response;
        }
        public async Task SeedDatabase(CinemaCatalogue movieDetails)
        {
            _cinemaCatalogingContext.Movies.Add(
                new CinemaCatalogue
                {
                    Id = movieDetails.Id,
                    BackdropPath = movieDetails.BackdropPath,
                    Genres = movieDetails.Genres,
                    imdbId = movieDetails.imdbId,
                    IsAdult = movieDetails.IsAdult,
                    OriginalLanguage = movieDetails.OriginalLanguage,
                    OriginalTitle = movieDetails.OriginalTitle,
                    Overview = movieDetails.Overview,
                    PosterPath = movieDetails.PosterPath,
                    ReleaseDate = movieDetails.ReleaseDate,
                    Title = movieDetails.Title,
                    RunTimeInMinutes = movieDetails.RunTimeInMinutes
                }
            );
            await _cinemaCatalogingContext.SaveChangesAsync();
        }
    }
}