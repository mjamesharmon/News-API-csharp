using System;
using NewsAPI.Attributes;
using NewsAPI.Constants;
using NewsAPI.Serialization;

namespace NewsAPI.Models
{
	[Route("top-headlines/sources")]
	public sealed class SourcesRequest
	{
        /// <summary>
        ///  restricts sources to a specific news category
        /// </summary>
        [RequestParameter("category", typeof(EnumValueSerializer))]
        public Categories? Category { get; set; }
        /// <summary>
        /// The language to restrict sources to
        /// </summary>
        [RequestParameter("language", typeof(EnumValueSerializer))]
        public Languages? Language { get; set; }
        /// <summary>
        /// The country to limit sources to
        /// </summary>
        [RequestParameter("country", typeof(EnumValueSerializer))]
        public Countries? Country { get; set; }

    }
}

