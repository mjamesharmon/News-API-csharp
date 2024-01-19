using System;
namespace NewsAPI.Models
{
	public class NewsApiClientOptions
	{
		public string ApiKey { get; set; } = string.Empty;

		public string BaseAddress { get; set; } = "https://newsapi.org/v2/";

		public int TimeoutInSeconds { get; set; } = 30;

		
    }
}

