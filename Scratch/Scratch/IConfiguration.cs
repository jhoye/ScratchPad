using Scratch.ConfigurationSections;

namespace Scratch
{
    public interface IConfiguration
    {
        IMailSettings MailSettings { get; }
    }
}
