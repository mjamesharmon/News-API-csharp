using System;
using System.Text;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace NewsAPI.Tests.TestData
{
	public class TopHeadlinesTestCases : TheoryData<TopHeadlinesRequest,string>
	{

        private NewsApiClientOptions _options = new();

        public TopHeadlinesTestCases()
		{ 
            AddComplextTest();
            AddCountriesTest();
            AddLanguagesTest();
            AddCategoryTest();
            AddSimpleTest();
            AddSourcesTest();
            AddPagingTest();
            AddPageSizeTest();
        }


        private void AddComplextTest() {

            Add(new TopHeadlinesRequest()
            {
                Category = Constants.Categories.Business,
                Language = Language.EN,
                Country = Constants.Countries.US
            },
                ComposeQueryWith("category=business&language=en&country=us"));

        }
        private void AddCountriesTest() {
             Add(new TopHeadlinesRequest()
            {
                Country = Constants.Countries.US
            },
            $"{_options.BaseAddress}top-headlines?country=us");
        }

        private void AddLanguagesTest() {
             Add(new TopHeadlinesRequest()
            {
                Language = Language.EN
            },
            ComposeQueryWith("language=en"));
        }


        private void AddCategoryTest() {
             Add(new TopHeadlinesRequest()
            {
                Category = Constants.Categories.Business
            },
            ComposeQueryWith("category=business"));
        }

        private void AddSimpleTest() {
            Add(new TopHeadlinesRequest(),
                       ComposeQueryWith());
        }

        private void AddPagingTest() {
            var request = new TopHeadlinesRequest {
                 Page=4
            };

            Add(request, ComposeQueryWith("page=4"));
        }

        private void AddPageSizeTest() {
             var request = new TopHeadlinesRequest {
                PageSize=25
            };

            Add(request, ComposeQueryWith("pageSize=25"));
        }

        private void AddSourcesTest()
        {
            var request = new TopHeadlinesRequest();
            request.Sources.Add("techcrunch");
            request.Sources.Add("cnn");

            Add(request, ComposeQueryWith("sources=techcrunch%2ccnn"));
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

