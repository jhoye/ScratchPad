using Scratch.Settings;

namespace Scratch.Web.Models.Settings
{
    public class ConnectionStringSettings : SettingsBase, IConnectionString
    {
        public string ExpectedName { get; set; }
        
        public string ExpectedProviderName { get; set; }
        
        public string ActualProviderName { get; set; }
        
        public string ActualConnectionString { get; set; }

        public ConnectionStringSettings() : base("Connection String")
        {
        }
    }
}