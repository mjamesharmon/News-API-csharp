using System;
namespace NewsAPI.Tests.TestData
{
	public class ValidSourcesResultTestCases : TheoryData<string>
	{
		public ValidSourcesResultTestCases()
		{
			Add(File.ReadAllText("TestData/valid_sources_response.json"));
		}
	}
}
