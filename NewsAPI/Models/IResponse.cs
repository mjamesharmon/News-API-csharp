using System;
using NewsAPI.Constants;

namespace NewsAPI.Models
{
	internal interface IResponse
	{
		public Statuses? Status { get; set; }

		public Error? Error { get; set; }
	}
}

