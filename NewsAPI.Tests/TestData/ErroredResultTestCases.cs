using System;
using NewsAPI.Constants;
using NewsAPI.Tests.TestData;

namespace NewsAPI.Tests.TestData
{
	public class ErroredResultTestCases : TheoryData<string,ErrorCodes>
	{
		public ErroredResultTestCases()
		{
            Add(File.ReadAllText("TestData/error_code_response.json"),
				ErrorCodes.ApiKeyMissing);
        }
    }
}

