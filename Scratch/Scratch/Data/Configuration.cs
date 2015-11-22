using System;
using System.Collections.Generic;
using System.Configuration;
using Scratch.Data.Core;

namespace Scratch.Data
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

        public void Load(IDatabaseSettings databaseSettings)
        {
            #region addMessage action

            Action<string> addMessage = (message) =>
            {
                if (databaseSettings.Messages == null)
                {
                    databaseSettings.Messages = new List<string>();
                }

                databaseSettings.Andon = Enums.Andons.Red;
                databaseSettings.Messages.Add(message);
            };

            #endregion

            // set expected values
            databaseSettings.ExpectedConnectionStringName = ConnectionStringName;
            databaseSettings.ExpectedConnectionStringProviderName = "System.Data.SqlClient";

            // get connection string from config file
            var connectionStringSettings = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (connectionStringSettings == null)
            {
                addMessage("There is no configured connection string named \"" + ConnectionStringName + "\".");
                return;
            }

            // set actual values
            databaseSettings.ActualConnectionStringProviderName = connectionStringSettings.ProviderName;
            databaseSettings.ActualConnectionString = connectionStringSettings.ConnectionString;

            // validate provider name
            if (databaseSettings.ActualConnectionStringProviderName != databaseSettings.ExpectedConnectionStringProviderName)
            {
                addMessage("Provider name is not of the correct type.");
            }

            // validate connection string
            if (string.IsNullOrWhiteSpace(databaseSettings.ActualConnectionString))
            {
                addMessage("Connection string is empty.");
            }

            // add success message if necessary
            if (databaseSettings.Andon != Enums.Andons.Red)
            {
                databaseSettings.Andon = Enums.Andons.Green;
                databaseSettings.Messages.Add("Connection string is configured.");
            }
        }
    }
}
