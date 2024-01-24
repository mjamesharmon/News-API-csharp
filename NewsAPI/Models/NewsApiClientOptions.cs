using System;
namespace NewsAPI.Models
{
	public class NewsApiClientOptions
	{
		/// <summary>
		/// The ApiKey provided by News API
		/// </summary>
		public string ApiKey { get; set; } = string.Empty;

		/// <summary>
		/// Base url address. Default is https://newsapi.org/v2/
		/// </summary>
		public string BaseAddress { get; set; } = "https://newsapi.org/v2/";

		/// <summary>
		/// The timeout in seconds of an API request. Default is 30 seconds.
		/// </summary>
		public int TimeoutInSeconds { get; set; } = 30;

		
    }
}

