using System.Linq;
using Cassandra;

namespace Scratch.Documents
{
    public class Documents : IDocuments
    {
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
        
        public string Get(string slug)
        {
            return Session
                .Execute(Session
                    .Prepare("SELECT content FROM pages WHERE slug=?")
                    .Bind(string.IsNullOrEmpty(slug) ? Constants.DefaultSlugKey : slug)
                )
                .GetRows()
                .Select(row => row[0].ToString())
                .FirstOrDefault();
        }

        public void Save(string slug, string content)
        {
            Session.Execute(
                Get(slug) == null
                    ? Session
                        .Prepare("INSERT INTO pages (slug, content) VALUES (?, ?)")
                        .Bind(string.IsNullOrEmpty(slug) ? Constants.DefaultSlugKey : slug, content)
                    : Session
                        .Prepare("UPDATE pages SET content=? WHERE slug=?")
                        .Bind(content, string.IsNullOrEmpty(slug) ? Constants.DefaultSlugKey : slug)
                );
        }

        public void Delete(string slug)
        {
            Session.Execute(
                Session
                    .Prepare("DELETE FROM pages WHERE slug=?")
                    .Bind(string.IsNullOrEmpty(slug) ? Constants.DefaultSlugKey : slug)
                );
        }
    }
}
