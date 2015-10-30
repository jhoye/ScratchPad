using System.Configuration;
using Scratch.ConfigurationSections;

namespace Scratch
{
    public class Configuration : IConfiguration
    {
        public IMailSettings MailSettings
        {
            get
            {
                return Get<Mail>();
            }
        }

        private T Get<T>() where T : ConfigurationSection
        {
            return (T)ConfigurationManager.GetSection(typeof(T).Name.ToLower());
        }
    }
}
