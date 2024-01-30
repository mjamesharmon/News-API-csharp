using System;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace NewsAPI.Extensions
{
	public static class ClientExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		/// <param name="query"></param>
		/// <param name="top"></param>
		/// <returns></returns>
		public static async Task<ArticlesResult> Query(
			this NewsApiClient client,string query, int top=25) =>
		 await client.GetEverythingAsync(
				new EverythingRequest { Query = query, PageSize = top });

		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		/// <param name="query"></param>
		/// <param name="top"></param>
		/// <returns></returns>
        public static async Task<ArticlesResult> MostRecent(
            this NewsApiClient client, string query, int top = 25) =>
         await client.GetEverythingAsync(
                new EverythingRequest {
					Query = query,
					PageSize = top,
					SortBy = SortBys.PublishedAt});

		/// <summary>
		/// 
		/// </summary>
		/// <param name="client"></param>
		/// <param name="query"></param>
		/// <param name="top"></param>
		/// <returns></returns>
        public static async Task<ArticlesResult> MostPopular(
           this NewsApiClient client, string query, int top = 25) =>
        await client.GetEverythingAsync(
               new EverythingRequest
               {
                   Query = query,
                   PageSize = top,
                   SortBy = SortBys.Popularity
               });


        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="query"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public static async Task<ArticlesResult> TopHeadlines(
			this NewsApiClient client, string query, int top=25) =>
		 await client.GetTopHeadlinesAsync(
				new TopHeadlinesRequest { Query = query, PageSize = top });
		
	}
}

