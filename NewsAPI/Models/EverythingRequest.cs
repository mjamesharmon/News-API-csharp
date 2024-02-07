using NewsAPI.Attributes;
using NewsAPI.Constants;
using NewsAPI.Serialization;

namespace NewsAPI.Models
{
    /// <summary>
    /// Params for making a request to the /everything endpoint.
    /// </summary>
    [Route("everything")]
    public class EverythingRequest
    {
        /// <summary>
        /// The keyword or phrase to search for. Boolean operators are supported.
        /// </summary>
        [Obsolete("This property is for backwards compatibility and has been" +
           " replaced with Query")]
        public string? Q
        {
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
        /// The fields to restrict your search to.
        /// </summary>
        [RequestParameter("searchIn", typeof(ListSerializer<Fields>))]
        public List<Fields> SearchIn { get; private set; } = new();

        /// <summary>
        /// If you want to restrict the search to specific sources,
        /// add their Ids here. You can find source Ids with the
        /// /sources endpoint or on newsapi.org.
        /// </summary>
        [RequestParameter("sources", typeof(ListSerializer<string>))]
        public List<string> Sources { get; private set; } = new();
        /// <summary>
        /// If you want to restrict the search to specific web
        /// domains, add these here. Example: nytimes.com.
        /// </summary>
        [RequestParameter("domains", typeof(ListSerializer<string>))]
        public List<string> Domains { get; private set; } = new();
        /// <summary>
        ///  Domains to remove from the results.
        /// </summary>
        [RequestParameter("excludedDomains", typeof(ListSerializer<string>))]
        public List<string> ExcludedDomains { get; private set; } = new();
        /// <summary>
        /// The earliest date to retrieve articles from.
        /// Note that how far back you can go is constrained by
        /// your plan type. See newsapi.org/pricing for plan details.
        /// </summary>
        [RequestParameter("from", typeof(DateValueSerializer))]
        public DateTime? From { get; set; }
        /// <summary>
        /// The latest date to retrieve articles from.
        /// </summary>
        [RequestParameter("to", typeof(DateValueSerializer))]
        public DateTime? To { get; set; }
        /// <summary>
        /// The language to restrict articles to.
        /// </summary>
        [RequestParameter("language", typeof(LanguageValueSerializer))]
        public Language? Language { get; set; }
        /// <summary>
        /// How should the results be sorted? Relevancy =
        /// articles relevant to the Q param come first.
        /// PublishedAt = most recent articles come first.
        /// Publisher = popular publishers come first.
        /// </summary>
        [RequestParameter("sortBy", typeof(EnumValueSerializer))]
        public SortBys? SortBy { get; set; }
        /// <summary>
        /// Each request returns a fixed amount of results.
        /// Page through them by increasing this.
        /// </summary>
        [RequestParameter("page", typeof(IntegerValueSerializer))]
        public int Page { get; set; }
        /// <summary>
        /// Set the max number of results to retrieve per request.
        /// The max is 100.
        /// </summary>
        [RequestParameter("pageSize", typeof(IntegerValueSerializer))]
        public int PageSize { get; set; }
    }
}
