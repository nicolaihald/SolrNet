using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SolrNet.Commands.Parameters;

namespace SolrNet {

    /// <summary>
    /// Standard MultiHandler query (handler multiple queries in a single batch)
    /// </summary>
    public class SolrMultiSearchHandlerQuery  {

        private readonly ICollection<SolrMultiSearchHandlerQueryPart> queryParts;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolrMultiSearchHandlerQuery"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public SolrMultiSearchHandlerQuery(Collection<SolrMultiSearchHandlerQueryPart> queries = null)
        {
            this.queryParts =  queries ?? new Collection<SolrMultiSearchHandlerQueryPart>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SolrMultiSearchHandlerQuery"/> class.
        /// </summary>
        public SolrMultiSearchHandlerQuery() : this(new Collection<SolrMultiSearchHandlerQueryPart>())
        {
        }


        public ICollection<SolrMultiSearchHandlerQueryPart> Parts
        {
            get { return queryParts; }
        }

    }

    public class SolrMultiSearchHandlerQueryPart
    {
        public ISolrQuery Query { get; set; }
        
        public QueryOptions QueryOptions { get; set; }

        public SolrMultiSearchHandlerQueryPart(ISolrQuery query, QueryOptions options = null) {
            Query = query;
            QueryOptions = options ?? new QueryOptions {};
        }
    }

    public static class SolrMultiSearchHandleQueryPartExtensions
    {
        public static SolrMultiSearchHandlerQueryPart WithFilter(this SolrMultiSearchHandlerQueryPart queryPart, params ISolrQuery[] filters)
        {            
            queryPart.QueryOptions.FilterQueries = filters;
            return queryPart;
        }
      
        public static SolrMultiSearchHandlerQueryPart Skip(this SolrMultiSearchHandlerQueryPart queryPart, int start)
        {
            queryPart.QueryOptions.Start = start;
            return queryPart;
        }

        public static SolrMultiSearchHandlerQueryPart Take(this SolrMultiSearchHandlerQueryPart queryPart, int rows)
        {
            queryPart.QueryOptions.Rows = rows;
            return queryPart;
        }

    }



}