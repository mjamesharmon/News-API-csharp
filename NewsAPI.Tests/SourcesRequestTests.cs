using System.Net;
using NewsAPI.Tests.Mocks;
using NewsAPI.Tests.TestData;
using System.Net.Http.Json;
using NewsAPI.Models;

namespace NewsAPI.Tests;

public class SourcesRequestTest
{
    private MockHttpMessageHandler? _messageHandler;



    private MockHttpMessageHandler MessageHandler => _messageHandler ??
        throw new NullReferenceException("Message handler not congfigured");

    private static NewsApiClientOptions Options => new NewsApiClientOptions
    {
        ApiKey = "testkey"
    };

    [Theory]
    [ClassData(typeof(SourcesRequestTestCases))]
    public async void GetSources_ValidParameters_Ok(SourcesRequest request,
        string expectedUrl)
    {

        var newsApi = Arrange();

        var response = await newsApi.GetSourcesAsync(request);

        Assert.NotNull(response);
        Assert.Equal(expectedUrl, MessageHandler.RequestedUrl);
        Assert.Equal(Options.ApiKey, MessageHandler.SubmittedApiKey);

    }


    private NewsApiClient Arrange()
    {
        _messageHandler = new((request =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = JsonContent.Create(new SourcesResult());
            return response;
        }));
        HttpClient client = new HttpClient(_messageHandler);
        return new NewsApiClient(client, Options);        
    }
   
}