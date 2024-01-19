using System;
using NewsAPI.Models;
using Xunit;
namespace NewsAPI.Tests.TestData 
{
	public class SourcesRequestTestCases : TheoryData<SourcesRequest,string>
	{

		private NewsApiClientOptions _options = new();

        public SourcesRequestTestCases()
		{	
			Add(new SourcesRequest(),
				$"{_options.BaseAddress}top-headlines/sources");

			Add(new SourcesRequest()
			{
				 Category=Constants.Categories.Business
			},
            $"{_options.BaseAddress}top-headlines/sources?category=business");
        }
	}
}

