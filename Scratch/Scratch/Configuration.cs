using System;
using System.Collections.Generic;
using System.Configuration;
using Scratch.ConfigurationSections;
using Scratch.Settings;

namespace Scratch
{
    public class Configuration : IConfiguration
    {
        private const string ConnectionStringName = "Scratch";

        public string ConnectionString
        {
            get
            {
                var settings = ConfigurationManager.ConnectionStrings[ConnectionStringName];

                return settings == null ? string.Empty : settings.ConnectionString;
            }
        }

        public IMailSettings MailSettings
        {
            get
            {
                return Get<Mail>();
            }
        }

        public void Load(IConnectionString connectionString)
        {
            #region addMessage action

            Action<string> addMessage = (message) =>
            {
                if (connectionString.Messages == null)
                {
                    connectionString.Messages = new List<string>();
                }

                connectionString.Andon = Enums.Andons.Red;
                connectionString.Messages.Add(message);
            };

            #endregion

            // set expected values
            connectionString.ExpectedName = ConnectionStringName;
            connectionString.ExpectedProviderName = "System.Data.SqlClient";

            // get connection string from config file
            var connectionStringSettings = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (connectionStringSettings == null)
            {
                addMessage("There is no configured connection string named \"" + ConnectionStringName + "\".");
                return;
            }

            // set actual values
            connectionString.ActualProviderName = connectionStringSettings.ProviderName;
            connectionString.ActualConnectionString = connectionStringSettings.ConnectionString;

            // validate provider name
            if (connectionString.ActualProviderName != connectionString.ExpectedProviderName)
            {
                addMessage("Provider name is not of the correct type.");
            }

            // validate connection string
            if (string.IsNullOrWhiteSpace(connectionString.ActualConnectionString))
            {
                addMessage("Connection string is empty.");
            }

            // add success message if necessary
            if (connectionString.Andon != Enums.Andons.Red)
            {
                connectionString.Andon = Enums.Andons.Green;
                connectionString.Messages.Add("Connection string is configured.");
            }
        }

        private T Get<T>() where T : ConfigurationSection
        {
            return (T)ConfigurationManager.GetSection(typeof(T).Name.ToLower());
        }
    }
}
