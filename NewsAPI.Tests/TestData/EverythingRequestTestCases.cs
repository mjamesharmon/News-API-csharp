using System;
using System.Text;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace NewsAPI.Tests.TestData
{
	public class EverythingRequestTestCases :
		TheoryData<EverythingRequest,string>
	{

        private NewsApiClientOptions _options = new();

        public EverythingRequestTestCases()
		{
            AddBasicCase();
            AddAdvancedCase();
            AddDateRangeCase();
            AddLanguageAndSortCase();
		}

        public void AddBasicCase()
        {
            Add(new EverythingRequest()
            {
                Query = "example search query",
                Language = Constants.Languages.EN,
                Page = 1,
                PageSize = 20
            },
            ComposeQueryWith("q=example+search+query&language=en&page=1&pageSize=20"));
        }

        public void AddLanguageAndSortCase()
        {
            Add(new EverythingRequest()
            {
                Language = Languages.ES,
                SortBy = SortBys.Popularity
            },
            ComposeQueryWith("language=es&sortBy=popularity"));
        }

        public void AddAdvancedCase()
        {
            var request = new EverythingRequest
            {
                Query="advanced query",
                From = DateTime.Parse("2022-01-01"),
                To = DateTime.Parse("2022-12-31"),
                Language = Constants.Languages.FR,
                SortBy = SortBys.Relevancy,
                Page = 2,
                PageSize = 30
            };
            request.SearchIn.Add(Fields.Title);
            request.SearchIn.Add(Fields.Description);
            request.Sources.Add("source1");
            request.Sources.Add("source2");
            request.Domains.Add("domain1.com");
            request.Domains.Add("domain2.com");
            request.ExcludedDomains.Add("excluded.com");

            Add(request, ComposeQueryWith(
                "q=advanced+query&searchIn=title,description&sources=source1%2c" +
                "source2&domains=domain1.com%2cdomain2.com&excludedDomains=" +
                "excluded.com&from=2022-01-01&to=2022-12-31&language=fr" +
                "&sortBy=relevancy&page=2&pageSize=30"));
        }

        public void AddDateRangeCase()
        {
            var request = new EverythingRequest
            {
                From = DateTime.Parse("2022-01-01"),
                To = DateTime.Parse("2022-12-31"),
                Page = 1,
                PageSize = 10
            };

            Add(request, ComposeQueryWith(
                "from=2022-01-01&to=2022-12-31&page=1&pageSize=10"));
        }


        private string ComposeQueryWith(string? parameters = null) =>
           new StringBuilder().
               Append($"{_options.BaseAddress}everything").
               Append(
                   (string.IsNullOrWhiteSpace(parameters) ?
                   string.Empty :
                   $"?{parameters}")).
               ToString();
    }
}

