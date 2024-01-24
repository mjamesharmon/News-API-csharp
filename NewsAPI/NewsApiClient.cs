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
                new ArticlesResult());     
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
            // build the querystring
            var queryParams = new List<string>();

            // q
            if (!string.IsNullOrWhiteSpace(request.Q))
            {
                queryParams.Add("q=" + request.Q);
            }

            // sources
            if (request.Sources.Count > 0)
            {
                queryParams.Add("sources=" + string.Join(",", request.Sources));
            }

            // domains
            if (request.Domains.Count > 0)
            {
                queryParams.Add("domains=" + string.Join(",", request.Sources));
            }

            // from
            if (request.From.HasValue)
            {
                queryParams.Add("from=" + string.Format("{0:s}", request.From.Value));
            }

            // to
            if (request.To.HasValue)
            {
                queryParams.Add("to=" + string.Format("{0:s}", request.To.Value));
            }

            // language
            if (request.Language.HasValue)
            {
                queryParams.Add("language=" + request.Language.Value.ToString().ToLowerInvariant());
            }

            // sortBy
            if (request.SortBy.HasValue)
            {
                queryParams.Add("sortBy=" + request.SortBy.Value.ToString());
            }

            // page
            if (request.Page > 1)
            {
                queryParams.Add("page=" + request.Page);
            }

            // page size
            if (request.PageSize > 0)
            {
                queryParams.Add("pageSize=" + request.PageSize);
            }

            // join them together
            var querystring = string.Join("&", queryParams.ToArray());

            return await MakeRequest("everything", querystring);
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

        private async Task<ArticlesResult> MakeRequest(string endpoint, string querystring)
        {
            // here's the return obj
            var articlesResult = new ArticlesResult();

            // make the http request
            var httpResponse = await _http.GetAsync(endpoint + "?" + querystring);

            httpResponse.EnsureSuccessStatusCode();
            var json = await httpResponse.Content.ReadAsStringAsync();
            if (!string.IsNullOrWhiteSpace(json))
            {
                // convert the json to an obj
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(json)
                    ?? throw new InvalidOperationException();
                articlesResult.Status = apiResponse.Status;
                if (articlesResult.Status == Statuses.Ok)
                {
                    articlesResult.TotalResults = apiResponse.TotalResults;
                    articlesResult.Articles = apiResponse.Articles;
                }
                else
                {
                    ErrorCodes errorCode = ErrorCodes.UnknownError;
                    try
                    {
                        errorCode = apiResponse.Code ??
                            throw new InvalidOperationException();
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine("The API returned an error code that wasn't expected: " + apiResponse.Code);
                    }

                    articlesResult.Error = new Error
                    {
                        Code = errorCode,
                        Message = apiResponse.Message
                    };
                }
            }
            else
            {
                articlesResult.Status = Statuses.Error;
                articlesResult.Error = new Error
                {
                    Code = ErrorCodes.UnexpectedError,
                    Message = "The API returned an empty response. Are you connected to the internet?"
                };
            }

            return articlesResult;
        }

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
