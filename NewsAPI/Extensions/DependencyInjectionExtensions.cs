using System;
using Microsoft.Extensions.DependencyInjection;
using NewsAPI.Models;

namespace NewsAPI.Extensions
{
	public static class DependencyInjectionExtensions
	{

		public static IServiceCollection AddNewsApiServices(
			this IServiceCollection services,
			Action<NewsApiClientOptions>? configuration = null)
		
		{
			services.ConfigureNewsApiService(configuration);
			services.AddHttpClient<NewsApiClient>();
			services.AddTransient<NewsApiClient>();
			return services;
		}

		private static IServiceCollection ConfigureNewsApiService(
			this IServiceCollection services,
			Action<NewsApiClientOptions>? configuration)
		{
			NewsApiClientOptions clientOptions = new();
			configuration?.Invoke(clientOptions);
			services.AddSingleton(clientOptions);
			return services;
		}
	}
}

