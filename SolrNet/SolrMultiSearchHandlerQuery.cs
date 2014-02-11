using System;

namespace SolrNet {

    /// <summary>
    /// Standard MultiHandler query (handler multiple queries in a single batch)
    /// </summary>
    public class SolrMultiSearchHandlerQuery  {
        private readonly ISolrQuery query;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolrMultiSearchHandlerQuery"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public SolrMultiSearchHandlerQuery(ISolrQuery query)
        {
            this.query = query;
        }

        public ISolrQuery Query {
            get { return query; }
        }

    }
}