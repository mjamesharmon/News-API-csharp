using System;
using NewsAPI.Attributes;
using NewsAPI.Constants;

namespace NewsAPI.Models
{
	[Route("top-headlines/sources")]
	public class SourcesRequest
	{
        /// <summary>
        ///  restricts sources to a specific news category
        /// </summary>
        public Categories? Category { get; set; }
        /// <summary>
        /// The language to restrict sources to
        /// </summary>
        public Languages? Language { get; set; }
        /// <summary>
        /// The country to limit sources to
        /// </summary>
        public Countries? Country { get; set; }

    }
}

