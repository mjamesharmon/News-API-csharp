using System;
namespace NewsAPI.Tests.TestData
{
	public class ValidArticlesResultTestCases : TheoryData<string>
	{
		public ValidArticlesResultTestCases()
		{
			Add(File.ReadAllText("TestData/valid_topheadlines_response.json"));
		}
	}
}