using System.Linq;
using Cassandra;

namespace Scratch.ServiceDelegates
{
    /// <summary>
    /// Apache Cassandra implementation of document data store / cache
    /// </summary>
    public class Cache : ICache
    {
        private const string DefaultKey = "default";

        private static Cluster _cluster;

        private static ISession _session;

        private Cluster Cluster
        {
            get { return _cluster ?? (_cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build()); }
        }

        private ISession Session
        {
            get { return _session ?? (_session = Cluster.Connect("scratch")); }
        }

        /// <summary>
        /// Gets document
        /// </summary>
        /// <param name="slug">content key</param>
        /// <returns>content string</returns>
        public string Get(string slug)
        {
            return Session
                .Execute(Session
                    .Prepare("SELECT content FROM pages WHERE slug=?")
                    .Bind(string.IsNullOrEmpty(slug) ? DefaultKey : slug)
                )
                .GetRows()
                .Select(row => row[0].ToString())
                .FirstOrDefault();
        }

        /// <summary>
        /// Saves document, either creating or overwriting it
        /// </summary>
        /// <param name="slug">content key</param>
        /// <param name="content">content string</param>
        public void Save(string slug, string content)
        {
            Session.Execute(
                Get(slug) == null
                    ? Session
                        .Prepare("INSERT INTO pages (slug, content) VALUES (?, ?)")
                        .Bind(string.IsNullOrEmpty(slug) ? DefaultKey : slug, content)
                    : Session
                        .Prepare("UPDATE pages SET content=? WHERE slug=?")
                        .Bind(content, string.IsNullOrEmpty(slug) ? DefaultKey : slug)
                );
        }

        /// <summary>
        /// Deletes a document if it exists
        /// </summary>
        /// <param name="slug">content key</param>
        public void Delete(string slug)
        {
            Session.Execute(
                Session
                    .Prepare("DELETE FROM pages WHERE slug=?")
                    .Bind(string.IsNullOrEmpty(slug) ? DefaultKey : slug)
                );
        }
    }
}
