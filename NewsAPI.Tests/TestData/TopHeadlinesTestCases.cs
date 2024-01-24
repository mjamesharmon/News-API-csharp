using System;
using System.Text;
using NewsAPI.Models;

namespace NewsAPI.Tests.TestData
{
	public class TopHeadlinesTestCases : TheoryData<TopHeadlinesRequest,string>
	{

        private NewsApiClientOptions _options = new();

        public TopHeadlinesTestCases()
		{
            Add(new TopHeadlinesRequest(),
                       ComposeQueryWith());

            Add(new TopHeadlinesRequest()
            {
                Category = Constants.Categories.Business
            },
            ComposeQueryWith("category=business"));

            Add(new TopHeadlinesRequest()
            {
                Language = Constants.Languages.EN
            },
            ComposeQueryWith("language=en"));
            
            Add(new TopHeadlinesRequest()
            {
                Country = Constants.Countries.US
            },
            $"{_options.BaseAddress}top-headlines?country=us");

            Add(new TopHeadlinesRequest()
            {
                Category = Constants.Categories.Business,
                Language = Constants.Languages.EN,
                Country = Constants.Countries.US
            },
                ComposeQueryWith("category=business&language=en&country=us"));

            AddSourcesTest();
        }

        private void AddSourcesTest()
        {
            var request = new TopHeadlinesRequest();
            request.Sources.Add("techcrunch");
            request.Sources.Add("cnn");

            Add(request, ComposeQueryWith("sources=techcrunch,cnn"));
        }

        private string ComposeQueryWith(string? parameters = null) =>
            new StringBuilder().
                Append($"{_options.BaseAddress}top-headlines").
                Append(
                    (string.IsNullOrWhiteSpace(parameters) ?
                    string.Empty :
                    $"?{parameters}")).
                ToString();

    }
}

