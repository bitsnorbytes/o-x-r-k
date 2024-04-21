using RestSharp;
using RestSharp.Authenticators.OAuth2;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
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
            var path = "/" + _configuration.GetValue<string>("TMDB:apiVersion") + "/" + _configuration.GetValue<string>("TMDB:imageConfigurationPath");
            var response = await Authenticator().GetJsonAsync<TMDBConfiguration>(path);
            return response;
        }
        public async Task<Language[]> FetchLanguageConfigurationTMDB()
        {
            var path = "/" + _configuration.GetValue<string>("TMDB:apiVersion") + "/" + _configuration.GetValue<string>("TMDB:lanuageConfigurationPath");
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
            var path = "/" + _configuration.GetValue<string>("TMDB:apiVersion") + "/" + _configuration.GetValue<string>("TMDB:moviePath") + "/" + MovieId;
            var response = await Authenticator().GetJsonAsync<CinemaCatalogue>(path);
            return response;

        }
        public async Task<TMDBGenreList> FetchGenreList()
        {
            var path = "/" + _configuration.GetValue<string>("TMDB:apiVersion") + "/" + _configuration.GetValue<string>("TMDB:genreListPath");
            var response = await Authenticator().GetJsonAsync<TMDBGenreList>(path);
            return response;
        }
        public async Task AddGenreAsSync(TMDBGenre genre)
        {
            var genreEntry = _cinemaCatalogingContext.Genres.Any(e => e.Id == genre.Id);
            if (genreEntry is false)
            {
                await _cinemaCatalogingContext.Genres.AddAsync(
                    new Genre
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    }
                );
            }
        }
        public async Task AddLanguageAsSync(Language _language)
        {
            var languageEntry = _cinemaCatalogingContext.Languages.Any(e => e.iso639Code == _language.iso639Code);
            if (languageEntry is false)
            {
                await _cinemaCatalogingContext.Languages.AddAsync(
                    new Language
                    {
                        iso639Code = _language.iso639Code,
                        Name = _language.Name,
                        EnglishName = _language.EnglishName
                    }
                );
            }
        }
        List<string> GetGenreNames(List<int> genreIds)
        {

            List<string> genreNames = new List<string>();

            foreach (var genreId in genreIds)
            {
                genreNames.Add(_cinemaCatalogingContext.Genres.Single(e => e.Id == genreId).Name);
            }
            return genreNames;
        }
        string GetLanguageName(string OriginalLanguageCode)
        {

            return _cinemaCatalogingContext.Languages.Single(e => e.iso639Code == OriginalLanguageCode).EnglishName;
        }
        public async Task AddMovieAsSync(CinemaCatalogue movieDetails, List<int> genreIds, string mediaType, List<string> backdropSizes, List<string> posterSizes, string secureBaseImageUrl)
        {
            var IsMovieEntry = _cinemaCatalogingContext.Movies.Any(e => e.Id == movieDetails.Id);

            if (IsMovieEntry is false)
            {
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

            }

        }
        public async Task UpdateMovieAsSync(CinemaCatalogue movieDetails, List<int> genreIds, string mediaType, List<string> backdropSizes, List<string> posterSizes, string secureBaseImageUrl)
        {
            var IsMovieEntry = _cinemaCatalogingContext.Movies.Any(e => e.Id == movieDetails.Id);

            if (IsMovieEntry is true)
            {
                var movieEntry = _cinemaCatalogingContext.Movies.Where(e => e.Id == movieDetails.Id).ExecuteUpdate(setters => setters
                    .SetProperty(b => b.Id, movieDetails.Id)
                    .SetProperty(b => b.BackdropPath, movieDetails.BackdropPath)
                    .SetProperty(b => b.GenreIds, genreIds)
                    .SetProperty(b => b.GenreNames, GetGenreNames(genreIds))
                    .SetProperty(b => b.MediaType, mediaType)
                    .SetProperty(b => b.imdbId, movieDetails.imdbId)
                    .SetProperty(b => b.IsAdult, movieDetails.IsAdult)
                    .SetProperty(b => b.OriginalLanguage, movieDetails.OriginalLanguage)
                    .SetProperty(b => b.OriginalLanguageEnglishName, GetLanguageName(movieDetails.OriginalLanguage))
                    .SetProperty(b => b.OriginalTitle, movieDetails.OriginalTitle)
                    .SetProperty(b => b.Overview, movieDetails.Overview)
                    .SetProperty(b => b.PosterPath, movieDetails.PosterPath)
                    .SetProperty(b => b.ReleaseDate, movieDetails.ReleaseDate)
                    .SetProperty(b => b.Title, movieDetails.Title)
                    .SetProperty(b => b.RunTimeInMinutes, movieDetails.RunTimeInMinutes)
                    .SetProperty(b => b.BackdropSizes, backdropSizes)
                    .SetProperty(b => b.PosterSizes, posterSizes)
                    .SetProperty(b => b.SecureBaseImageURL, secureBaseImageUrl));
            }

        }
        public async Task SaveChangesAsSync()
        {
            await _cinemaCatalogingContext.SaveChangesAsync();
        }
    }
}