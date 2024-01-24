using System;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI.Tests.TestData;

namespace NewsAPI.Tests
{
	public class TopHeadlinesTests : NewsApiTest
	{
        [Theory]
        [ClassData(typeof(TopHeadlinesTestCases))]
        public async Task GetTopHeadlines_ValidParameters_Ok(
            TopHeadlinesRequest request, string expectedUrl)
        {
            var newsApi = Arrange();

            var response = await newsApi.GetTopHeadlinesAsync(request);

            Assert.NotNull(response);
            Assert.Equal(expectedUrl, MessageHandler.RequestedUrl);
            Assert.Equal(Options.ApiKey, MessageHandler.SubmittedApiKey);
        }

        [Theory]
        [ClassData(typeof(ValidTopHeadlinesResultTestCases))]
        public async Task TopHeadlines_ValidResponse_Ok(string payload)
        {
            var newsApi = ArrangeWithJsonResponse(payload);
            var request = new TopHeadlinesRequest();

            var response = await newsApi.GetTopHeadlinesAsync(request);

            Assert.NotNull(response);
            Assert.Equal("Ok", response.Status.ToString());  
        }
    }
}
