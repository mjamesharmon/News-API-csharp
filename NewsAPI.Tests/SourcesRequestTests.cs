using System.Net;
using NewsAPI.Tests.Mocks;
using NewsAPI.Tests.TestData;
using System.Net.Http.Json;
using NewsAPI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewsAPI.Constants;

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
    public async Task GetSources_ValidParameters_Ok(SourcesRequest request,
        string expectedUrl)
    {
        var newsApi = Arrange();

        var response = await newsApi.GetSourcesAsync(request);

        Assert.NotNull(response);
        Assert.Equal(expectedUrl, MessageHandler.RequestedUrl);
        Assert.Equal(Options.ApiKey, MessageHandler.SubmittedApiKey);
    }

    [Theory]
    [ClassData(typeof(ValidSourcesResultTestCases))]
    public async Task GetSources_ValidResponse_Ok(string payload)
    {
        var newsApi = ArrangeWithJsonResponse(payload);
        var request = new SourcesRequest();

        var response = await newsApi.GetSourcesAsync(request);

        Assert.NotNull(response);
        Assert.Equal("Ok", response.Status.ToString());
      
    }

    [Theory]
    [ClassData(typeof(ErroredSourcesResultTestCases))]
    public async Task GetSources_ErrorResponse_Ok(string payload,
        ErrorCodes expectedError )
    {
        var newsApi = ArrangeWithJsonResponse(payload);
        var request = new SourcesRequest();

        var response = await newsApi.GetSourcesAsync(request);

        Assert.NotNull(response);
        Assert.Equal("Error", response.Status.ToString());
        Assert.NotNull(response.Error);
        Assert.NotNull(response.Error.Message);
        Assert.Equal(expectedError, response.Error.Code);
    }

    [Theory]
    [ClassData(typeof(InvalidSourcesResultTestCases))]
    public async Task GetSources_InvalidJson_ThrowsException(string payload,
        Type expectedType)
    {
        var newsApi = ArrangeWithJsonResponse(payload);
        var request = new SourcesRequest();

     await Assert.ThrowsAsync(expectedType, async () =>
             await newsApi.GetSourcesAsync(request));
   
    }

    private NewsApiClient ArrangeWithJsonResponse(string json)
    {
        _messageHandler = new((request =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(json);
            return response;
        }));
        HttpClient client = new HttpClient(_messageHandler);
        return new NewsApiClient(client, Options);
    }

    private NewsApiClient Arrange()
    {
        return ArrangeWithJsonResponse(
            JsonSerializer.Serialize(new SourcesResult(),SerializationOptions));     
    }

    private JsonSerializerOptions SerializationOptions => new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

}