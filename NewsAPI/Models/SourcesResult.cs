using System;
using NewsAPI.Constants;

namespace NewsAPI.Models
{
	public class SourcesResponse
	{
        public Statuses Status { get; set; }
        public Error Error { get; set; } = new();
        public List<Source> Sources { get; set; } = new();
    }
}

