﻿using System;
using NewsAPI.Constants;
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
				 Category=Category.Business
			},
            $"{_options.BaseAddress}top-headlines/sources?category=business");

			Add(new SourcesRequest()
			{
				Language = Language.EN
			},
			$"{_options.BaseAddress}top-headlines/sources?language=en");

			Add(new SourcesRequest()
			{
				Country = Constants.Countries.US
			},
			$"{_options.BaseAddress}top-headlines/sources?country=us");

            Add(new SourcesRequest()
            {
                Category = Category.Business,
                Language = Language.EN,
                Country = Constants.Countries.US
            },
        $"{_options.BaseAddress}top-headlines/sources?" +
				"category=business&language=en&country=us");
        }
	}
}

