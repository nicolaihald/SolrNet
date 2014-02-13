using SolrNet.Commands.Parameters;

namespace SolrNet
{
    /// <summary>
    /// Represents a MultiHandlerQuery sub-query.
    /// </summary>
    public class SolrMultiHandlerQueryPart
    {
        /// <summary>
        /// Gets or sets the actual query.
        /// </summary>
        /// <value>The query.</value>
        public ISolrQuery Query { get; set; }

        /// <summary>
        /// Gets or sets the query options.
        /// </summary>
        /// <value>The query options.</value>
        public QueryOptions QueryOptions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SolrMultiHandlerQueryPart"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="options">The options for this specific sub-query.</param>
        public SolrMultiHandlerQueryPart(ISolrQuery query, QueryOptions options = null)
        {
            Query = query;
            QueryOptions = options ?? new QueryOptions { };
        }
    }
}