using System;
namespace NewsAPI.Tests.TestData
{
	public class ValidTopHeadlinesResultTestCases : TheoryData<string>
	{
		public ValidTopHeadlinesResultTestCases()
		{
			Add(File.ReadAllText("TestData/valid_topheadlines_response.json"));
		}
	}
}