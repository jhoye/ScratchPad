using Scratch.ConfigurationSections;
using Scratch.Settings;

namespace Scratch
{
    public interface IConfiguration
    {
        string ConnectionString { get; }

        IMailSettings MailSettings { get; }

        void Load(IConnectionString connectionString);
    }
}
