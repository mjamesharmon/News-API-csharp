using System.Net;
using NewsAPI.Tests.Mocks;
using NewsAPI.Tests.TestData;
using System.Net.Http.Json;
using NewsAPI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewsAPI.Constants;

namespace NewsAPI.Tests;

public class SourcesTest : NewsApiTest
{
    
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
    [ClassData(typeof(ErroredResultTestCases))]
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
}