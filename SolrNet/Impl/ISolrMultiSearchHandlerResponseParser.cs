using System.Collections.Generic;
using System.Xml.Linq;

namespace SolrNet.Impl {

    /// <summary>
    /// Interface for parsing multiple solr results into multiple responses.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISolrMultiSearchHandlerResponseParser<T> 
    {
        /// <summary>
        /// Parses a chunk of a query response into a collection of <see cref="SolrQueryResults{T}"/> results.
        /// </summary>
        /// <param name="xml">The query response returned by solr</param>
        /// <param name="results">results object</param>
        void Parse(XDocument xml, ICollection<SolrQueryResults<T>> results);
    }
}