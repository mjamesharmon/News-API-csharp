using System;
using NewsAPI.Constants;
using NewsAPI.Tests.TestData;

namespace NewsAPI.Tests.TestData
{
	public class ErroredSourcesResultTestCases : TheoryData<string,ErrorCodes>
	{
		public ErroredSourcesResultTestCases()
		{
            Add(File.ReadAllText("TestData/error_code_response.json"),
				ErrorCodes.ApiKeyMissing);
        }
    }
}

