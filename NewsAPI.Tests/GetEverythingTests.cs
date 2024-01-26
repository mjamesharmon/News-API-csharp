using System;
using NewsAPI.Constants;
using NewsAPI.Models;
using NewsAPI.Tests.TestData;

namespace NewsAPI.Tests
{
	public class GetEverythingTests : NewsApiTest
	{


        [Theory]
        [ClassData(typeof(ValidArticlesResultTestCases))]
        public async Task GetEverything_ValidResponse_Ok(string payload)
        {
            var newsApi = ArrangeWithJsonResponse(payload);
            var request = new EverythingRequest();

            var response = await newsApi.GetEverythingAsync(request);

            Assert.NotNull(response);
            Assert.Equal("Ok", response.Status.ToString());
            Assert.NotNull(response.Articles);
            Assert.NotEmpty(response.Articles);
        }

        [Theory]
        [ClassData(typeof(ErroredResultTestCases))]
        public async Task GetEverything_ErrorResponse_Ok(string payload,
        ErrorCodes expectedError)
        {
            var newsApi = ArrangeWithJsonResponse(payload);
            var request = new EverythingRequest();

            var response = await newsApi.GetEverythingAsync(request);

            Assert.NotNull(response);
            Assert.Equal("Error", response.Status.ToString());
            Assert.NotNull(response.Error);
            Assert.NotNull(response.Error.Message);
            Assert.Equal(expectedError, response.Error.Code);
        }

        [Theory]
        [ClassData(typeof(InvalidSourcesResultTestCases))]
        public async Task GetEverything_InvalidJson_ThrowsException(
            string payload, Type expectedType)
        {
            var newsApi = ArrangeWithJsonResponse(payload);
            var request = new EverythingRequest();

            await Assert.ThrowsAsync(expectedType, async () =>
                    await newsApi.GetEverythingAsync(request));
        }
    }
}

