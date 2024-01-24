using System;
using System.Text.Json;

namespace NewsAPI.Tests.TestData
{
	public class InvalidSourcesResultTestCases : TheoryData<string,Type>
	{
		public InvalidSourcesResultTestCases()
		{
			Add("null", typeof(InvalidOperationException));
			Add("{\"code\":\"f\"}", typeof(JsonException));
			Add("{\"status\":\"ok\", }",
				typeof(JsonException));

		}
	}
}

