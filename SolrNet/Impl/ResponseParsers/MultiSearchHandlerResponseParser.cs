using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SolrNet.Impl.ResponseParsers {


    /// <summary>
    /// MultiSearchHandler response parser.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MultiSearchHandlerResponseParser<T> : DefaultResponseParser<T>, ISolrMultiSearchHandlerResponseParser<T>
    { 
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiSearchHandlerResponseParser{T}"/> class.
        /// </summary>
        /// <param name="docParser">The document parser.</param>
        public MultiSearchHandlerResponseParser(ISolrDocumentResponseParser<T> docParser) : base(docParser) { }

        /// <summary>
        /// Parses a chunk of a query response into the results object
        /// </summary>
        /// <param name="xml">query response</param>
        /// <param name="results">results object</param>
        public void Parse(XDocument xml, ICollection<SolrQueryResults<T>> results)
        {
            var allGroupings = xml.XPathSelectElements("response/lst[@name='grouped']").ToList();
            var allResults = xml.XPathSelectElements("response/result[@name='response']").ToList();

            var elements = allResults.Any() ? allResults : allGroupings;
            if (elements.Any())
            {
                foreach (var resultXml in elements)
                {
                    var result = new SolrQueryResults<T>();

                    // wrap each result in a xml root element. This way we're able to reuse the AggregateResponseParser 
                    // for parsing each response - one by one: 
                    var xdoc = new XDocument(new XElement("response", resultXml));
                    parser.Parse(xdoc, result);

                    results.Add(result);
                }

            }
        }
    }
}