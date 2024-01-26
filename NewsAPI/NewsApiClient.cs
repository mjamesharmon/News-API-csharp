using NewsAPI.Attributes;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI.Serialization;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text.Json;

namespace NewsAPI
{
    /// <summary>
    /// Use this to get results from NewsAPI.org.
    /// </summary>
    public class NewsApiClient
    {
        private readonly HttpClient _http;

        public NewsApiClient(HttpClient client, NewsApiClientOptions options)
        {
            _http = client;
            _http.BaseAddress = new Uri(options.BaseAddress);
            _http.DefaultRequestHeaders.Add("user-agent", "News-API-csharp/1.0");
            _http.DefaultRequestHeaders.Add("x-api-key", options.ApiKey);
            _http.Timeout = TimeSpan.FromSeconds(options.TimeoutInSeconds);
        }

        /// <summary>
        /// Use this to get results from NewsAPI.org.
        /// </summary>
        /// <param name="apiKey">Your News API key. You can create one for free at https://newsapi.org.</param>
        public NewsApiClient(string apiKey) :
            this(new HttpClient(), new NewsApiClientOptions { ApiKey = apiKey })
        { }

        /// <summary>
        ///
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<SourcesResult> GetSourcesAsync(SourcesRequest request) {

            return await GetResultOrErrorAsync(request,
                SourcesResult.Errored());
        }

     
        /// <summary>
        /// Query the /v2/top-headlines endpoint for live top news headlines.
        /// </summary>
        /// <param name="request">The params and filters for the request.</param>
        /// <returns></returns>
        public async Task<ArticlesResult> GetTopHeadlinesAsync(
            TopHeadlinesRequest request)
        {
            return await GetResultOrErrorAsync(request,
                ArticlesResult.Errored());    
        }

        [Obsolete]
        /// <summary>
        /// Query the /v2/top-headlines endpoint for live top news headlines.
        /// </summary>
        /// <param name="request">The params and filters for the request.</param>
        /// <returns></returns>
        public ArticlesResult GetTopHeadlines(TopHeadlinesRequest request)
        {
            return GetTopHeadlinesAsync(request).Result;
        }

        /// <summary>
        /// Query the /v2/everything endpoint for recent articles all over the web.
        /// </summary>
        /// <param name="request">The params and filters for the request.</param>
        /// <returns></returns>
        public async Task<ArticlesResult> GetEverythingAsync(EverythingRequest request)
        {
            return await GetResultOrErrorAsync(request,
                ArticlesResult.Errored());
        }

        [Obsolete]
        /// <summary>
        /// Query the /v2/everything endpoint for recent articles all over the web.
        /// </summary>
        /// <param name="request">The params and filters for the request.</param>
        /// <returns></returns>
        public ArticlesResult GetEverything(EverythingRequest request)
        {
            return GetEverythingAsync(request).Result;
        }

        // ***

        private async Task<TResult> GetResultOrErrorAsync<TRequest, TResult>(
    TRequest request, TResult defaultError)
    where TResult : IResponse
        {
            string path = GetPath(
                GetRoute<TRequest>(),
                GetQuery(request));

            var httpResponse = await _http.GetAsync(path);
            return await ParseResultOrError(httpResponse, defaultError);
        }

        private async Task<TResult>
            ParseResultOrError<TResult>(HttpResponseMessage httpResponse,
            TResult result)
            where TResult : IResponse
        {
            return (httpResponse.IsSuccessStatusCode) ?
               await OnHttpSuccess(httpResponse, result) :
               OnHttpError(httpResponse, result);
        }

        private async Task<TResult> OnHttpSuccess<TResult>(
            HttpResponseMessage message, TResult result)
            where TResult : IResponse
        {
            string json = await message.Content.ReadAsStringAsync();
            ApiResponse response = JsonSerializer.Deserialize<ApiResponse>(json) ??
                throw new InvalidOperationException();

            return (response.Status == Statuses.Ok) ?
                OnApiSuccess<TResult>(json) :
                OnApiError(response, result);
        }

        private TResult OnApiError<TResult>(
          ApiResponse response,
          TResult result)
          where TResult : IResponse
        {
            result.Error = new Error();
            result.Error.Code = response.Code ?? ErrorCodes.UnknownError;
            result.Error.Message = response.Message;
            return result;
        }

        private TResult OnApiSuccess<TResult>(string json)
           where TResult : IResponse
        {
            return JsonSerializer.Deserialize<TResult>(json) ??
               throw new InvalidOperationException();
        }

        private TResult OnHttpError<TResult>(
            HttpResponseMessage httpResponse,
            TResult result)
            where TResult : IResponse
        {
            result.Status = Statuses.Error;
            result.Error = new Error
            {
                Code = ErrorCodes.UnexpectedError,
                Message = httpResponse.ReasonPhrase ?? "Unknown failure"
            };
            return result;
        }

        private string GetPath(string route, string? query) =>
            (string.IsNullOrWhiteSpace(query)) ?
                route : $"{route}?{query}";

        private string? GetQuery<T>(T? request)
        {

            return (request == null) ? string.Empty :
                request.GetType().
                GetProperties().
                Aggregate(new QueryParametersBuilder(), (builder, property) =>
                    builder.AppendParameter(request, property)).
                    ToString();
        }

        private string GetRoute<T>()
        {
            RouteAttribute? routing = Attribute.GetCustomAttribute(typeof(T),
                 typeof(RouteAttribute)) as RouteAttribute;

            return (routing == null) ? string.Empty :
                routing.Route;
        }
    }
}
