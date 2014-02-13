using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SolrNet {

    /// <summary>
    /// Standard MultiHandler query (handler multiple queries in a single batch)
    /// </summary>
    public class SolrMultiHandlerQuery  {

        private readonly ICollection<SolrMultiHandlerQueryPart> queryParts;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolrMultiHandlerQuery"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public SolrMultiHandlerQuery(Collection<SolrMultiHandlerQueryPart> queries = null)
        {
            this.queryParts =  queries ?? new Collection<SolrMultiHandlerQueryPart>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SolrMultiHandlerQuery"/> class.
        /// </summary>
        public SolrMultiHandlerQuery() : this(new Collection<SolrMultiHandlerQueryPart>())
        {
        }


        public ICollection<SolrMultiHandlerQueryPart> Parts
        {
            get { return queryParts; }
        }

    }


    /// <summary>
    /// A few helpers for setting common query params.
    /// </summary>
    public static class SolrMultiSearchHandleQueryPartExtensions
    {
        public static SolrMultiHandlerQueryPart WithFilter(this SolrMultiHandlerQueryPart queryPart, params ISolrQuery[] filters)
        {
            queryPart.QueryOptions.FilterQueries = filters;
            return queryPart;
        }

        public static SolrMultiHandlerQueryPart Skip(this SolrMultiHandlerQueryPart queryPart, int start)
        {
            queryPart.QueryOptions.Start = start;
            return queryPart;
        }

        public static SolrMultiHandlerQueryPart Take(this SolrMultiHandlerQueryPart queryPart, int rows)
        {
            queryPart.QueryOptions.Rows = rows;
            return queryPart;
        }

    }


}