using System;
using System.Linq;
using Cassandra;
using Scratch.Data.Core;

namespace Scratch.ServiceDelegates
{
    /// <summary>
    /// Apache Cassandra implementation of document data store / cache
    /// </summary>
    public class Cache : DependentBase, ICache
    {
        private const string DefaultKey = "default";

        private const string ContactPointsSettingKey = "ContactPoints";

        private const string KeyspaceSettingKey = "Keyspace";

        private readonly GenericSettings _settingsInstance;

        private static Cluster _cluster;

        private static ISession _session;

        private string[] ContactPoints
        {
            get { return Settings.Settings[ContactPointsSettingKey].Value.Split(",".ToCharArray()); }
        }

        private string Keyspace
        {
            get { return Settings.Settings[KeyspaceSettingKey].Value; }
        }

        public GenericSettings Settings
        {
            get
            {
                if (!_settingsInstance.IsLoaded)
                {
                    Components.Settings.Load(_settingsInstance);
                }

                return _settingsInstance;
            }
        }

        private Cluster Cluster
        {
            get
            {
                return _cluster ?? (
                    _cluster = Cluster.Builder()
                        .WithDefaultKeyspace(Keyspace)
                        .AddContactPoints(ContactPoints)
                        .Build());
            }
        }

        private ISession Session
        {
            get { return _session ?? (_session = Cluster.Connect()); }
        }

        public Cache()
        {
            _settingsInstance = new GenericSettings
                {
                    Section = "Cache",
                    Description = "Apache Cassandra Database Settings"
                }
                .WithSetting(
                    ContactPointsSettingKey,
                    "Contact Points",
                    "A comma-separated list of Cassandra node addresses")
                .WithSetting(
                    KeyspaceSettingKey,
                    "Keyspace",
                    "The Cassandra cluster keyspace for the cache");
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

        public void TestSettings(ISignal signal)
        {
            // used cluster address "127.0.0.1" locally
            // used keyspace "scratch" locally
            // TODO: test connection to cluster, test for keyspace existence, and create keyspace (and pages) if needed

            try
            {
                var document = Get(DefaultKey);

                if (String.IsNullOrWhiteSpace(document))
                {
                    Save(DefaultKey, "Default Document");

                    signal.SetSignal("Default cached document was created.");
                }
                else
                {
                    signal.SetSignal("Default cached document was found.");
                }
            }
            catch (Exception exception)
            {
                signal.SetSignal(exception.Message, Enums.Andons.Red);
            }
        }
    }
}
