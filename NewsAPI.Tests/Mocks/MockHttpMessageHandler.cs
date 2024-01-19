using System;

namespace NewsAPI.Tests.Mocks
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        public string RequestedUrl { get; private set; } = string.Empty;

        public string SubmittedApiKey { get; private set; } = string.Empty;
        
        private readonly Func<HttpRequestMessage,HttpResponseMessage>
            _getResult;

		public MockHttpMessageHandler(Func<HttpRequestMessage,
            HttpResponseMessage>
            configureResult)
		{
            _getResult = configureResult;
		}

        protected override async Task<HttpResponseMessage>
            SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            RequestedUrl = (request.RequestUri != null) ?
                request.RequestUri.ToString() : string.Empty;
            SubmittedApiKey = request.Headers.GetValues("x-api-key").
                FirstOrDefault(string.Empty);
            await Task.CompletedTask;
            return _getResult(request);
        }

        
    }
}

