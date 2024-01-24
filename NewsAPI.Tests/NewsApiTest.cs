using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using NewsAPI.Models;
using NewsAPI.Tests.Mocks;

namespace NewsAPI.Tests
{
	public abstract class NewsApiTest
	{
        private MockHttpMessageHandler? _messageHandler;

        private NewsApiClientOptions? _options;

        protected MockHttpMessageHandler MessageHandler => _messageHandler ??
            throw new NullReferenceException("Message handler not congfigured");

        protected NewsApiClientOptions Options => _options ??
            new NewsApiClientOptions { ApiKey = "testkey" };

        protected virtual Func<HttpRequestMessage,HttpResponseMessage>
            MessageHandlerConfiguration(string payload) => (request) =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(payload);
                return response;
            };

        protected NewsApiClient ArrangeWithJsonResponse(string json,
            NewsApiClientOptions? options = null)
        {
            _options = options;
            _messageHandler = new(MessageHandlerConfiguration(json));
            HttpClient client = new HttpClient(_messageHandler);
            return new NewsApiClient(client, Options);
        }

        protected NewsApiClient Arrange(NewsApiClientOptions? options = null) 
        {
            return ArrangeWithJsonResponse(
                JsonSerializer.Serialize(new SourcesResult(),
                SerializationOptions));
        }

        private JsonSerializerOptions SerializationOptions => new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

    }
}

