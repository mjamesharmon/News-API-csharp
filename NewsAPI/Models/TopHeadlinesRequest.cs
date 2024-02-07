using NewsAPI.Attributes;
using NewsAPI.Constants;
using NewsAPI.Serialization;

namespace NewsAPI.Models
{
    /// <summary>
    /// Params for making a request to the /top-headlines endpoint.
    /// </summary>
    [Route("top-headlines")]
    public sealed class TopHeadlinesRequest
    {
        /// <summary>
        /// The keyword or phrase to search for. Boolean operators are supported.
        /// </summary>
        [Obsolete("This property is for backwards compatibility and has been" +
            " replaced with Query")]
        public string? Q {
            get
            {
                return Query;
            }
            set
            {
                Query = value;
            }
        }
        /// <summary>
        /// The keyword or phrase to search for. Boolean operators are supported.
        /// </summary>
        [RequestParameter("q")]
        public string? Query { get; set; }
        /// <summary>
        /// If you want to restrict the results to specific sources, add their Ids here. You can find source Ids with the /sources endpoint or on newsapi.org.
        /// </summary>
        [RequestParameter("sources", typeof(ListSerializer<string>))]
        public List<string> Sources { get; private set; } = new List<string>();
        /// <summary>
        /// If you want to restrict the headlines to a specific news category, add these here.
        /// </summary>
        [RequestParameter("category", typeof(EnumValueSerializer))]
        public Categories? Category { get; set; }
        /// <summary>
        /// The language to restrict articles to.
        /// </summary>
        [RequestParameter("language", typeof(LanguageValueSerializer))]
        public Language? Language { get; set; }
        /// <summary>
        /// The country of the source to restrict articles to.
        /// </summary>
        [RequestParameter("country", typeof(EnumValueSerializer))]
        public Countries? Country { get; set; }
        /// <summary>
        /// Each request returns a fixed amount of results. Page through them by increasing this.
        /// </summary>
        [RequestParameter("page", typeof(IntegerValueSerializer))]
        public int? Page { get; set; }
        /// <summary>
        /// Set the max number of results to retrieve per request. The max is 100.
        /// </summary>
        [RequestParameter("pageSize",typeof(IntegerValueSerializer))]
        public int? PageSize { get; set; }
    }
}
