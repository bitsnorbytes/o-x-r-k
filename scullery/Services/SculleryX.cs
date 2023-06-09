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
        public async Task<TMDBConfiguration> FetchImageConfigurationTMDB()
        {
            var path =   "/" + _configuration.GetValue<string>("TMDB:apiVersion") + "/" +_configuration.GetValue<string>("TMDB:imageConfigurationPath");
            var response = await Authenticator().GetJsonAsync<TMDBConfiguration>(path);
            return response;
        }
        public async Task<Language[]> FetchLanguageConfigurationTMDB()
        {
            var path =   "/" + _configuration.GetValue<string>("TMDB:apiVersion") + "/" +_configuration.GetValue<string>("TMDB:lanuageConfigurationPath");
            var response = await Authenticator().GetJsonAsync<Language[]>(path);
            return response;
        }
        public async Task<TMDBMovieList> FetchProdListTMDB()
        {
            var path = "/" + _configuration.GetValue<string>("TMDB:apiVersion") + "/" + _configuration.GetValue<string>("TMDB:ProdListPath");
            var response = await Authenticator().GetJsonAsync<TMDBMovieList>(path);
            return response;
        }
        public async Task<CinemaCatalogue> FetchMovieDetailsTMDB(int MovieId)
        {
            var path = "/" + _configuration.GetValue<string>("TMDB:apiVersion") + "/"+ _configuration.GetValue<string>("TMDB:moviePath") +"/" + MovieId;
            var response = await Authenticator().GetJsonAsync<CinemaCatalogue>(path);
            return response;

        }
        public async Task<TMDBGenreList> FetchGenreList()
        {            
            var path = "/" + _configuration.GetValue<string>("TMDB:apiVersion") + "/"+ _configuration.GetValue<string>("TMDB:genreListPath");
            var response = await Authenticator().GetJsonAsync<TMDBGenreList>(path);
            return response;
        }
        public async Task SeedGenreAsSync(TMDBGenre genre)
        {
            var genreEntry = _cinemaCatalogingContext.Genres.Any(e => e.Id == genre.Id);
            if(genreEntry is false){
            await _cinemaCatalogingContext.Genres.AddAsync(
                new Genre
                {
                    Id = genre.Id,
                    Name = genre.Name
                }
            );
            await _cinemaCatalogingContext.SaveChangesAsync();
            }
        }
        public async Task SeedLanguageAsSync(Language _language)
        {
            var languageEntry = _cinemaCatalogingContext.Languages.Any(e => e.iso639Code == _language.iso639Code);
            if(languageEntry is false){
            await _cinemaCatalogingContext.Languages.AddAsync(
                new Language
                {
                    iso639Code = _language.iso639Code,
                    Name = _language.Name,
                    EnglishName = _language.EnglishName
                }
            );
            await _cinemaCatalogingContext.SaveChangesAsync();
            }
        }
        List<string> GetGenreNames(List<int> genreIds) {

            List<string> genreNames = new List<string>();
            
            foreach(var genreId in genreIds)
            {
            genreNames.Add(_cinemaCatalogingContext.Genres.Single(e => e.Id == genreId).Name) ;
            }
            return genreNames;
        }
        string GetLanguageName(string OriginalLanguageCode) {

            return _cinemaCatalogingContext.Languages.Single(e => e.iso639Code == OriginalLanguageCode).EnglishName;
        }
        public async Task SeedMovieAsSync(CinemaCatalogue movieDetails, List<int> genreIds, string mediaType, List<string> backdropSizes, List<string> posterSizes, string secureBaseImageUrl)
        {
            var IsMovieEntry = _cinemaCatalogingContext.Movies.Any(e => e.Id == movieDetails.Id);
            
            if(IsMovieEntry is false){
                await _cinemaCatalogingContext.Movies.AddAsync(
                new CinemaCatalogue
                {
                    Id = movieDetails.Id,
                    BackdropPath = movieDetails.BackdropPath,
                    GenreIds = genreIds,
                    GenreNames = GetGenreNames(genreIds),
                    MediaType = mediaType,
                    imdbId = movieDetails.imdbId,
                    IsAdult = movieDetails.IsAdult,
                    OriginalLanguage = movieDetails.OriginalLanguage,
                    OriginalLanguageEnglishName = GetLanguageName(movieDetails.OriginalLanguage),
                    OriginalTitle = movieDetails.OriginalTitle,
                    Overview = movieDetails.Overview,
                    PosterPath = movieDetails.PosterPath,
                    ReleaseDate = movieDetails.ReleaseDate,
                    Title = movieDetails.Title,
                    RunTimeInMinutes = movieDetails.RunTimeInMinutes,
                    BackdropSizes = backdropSizes,
                    PosterSizes = posterSizes,
                    SecureBaseImageURL = secureBaseImageUrl
                }
            );
            await _cinemaCatalogingContext.SaveChangesAsync();
            } 
            // else {
            //     var movieEntry = _cinemaCatalogingContext.Movies.Single(e => e.Id == movieDetails.Id);
            //     movieEntry.OriginalLanguageEnglishName = GetLanguageName(movieDetails.OriginalLanguage);
            //     movieEntry.GenreNames = GetGenreNames(genreIds);
            //     await _cinemaCatalogingContext.SaveChangesAsync();
            // }
           
        }
    }
}