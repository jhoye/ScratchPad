using System.Configuration;

namespace Scratch.ConfigurationSections
{
    public class Mail : ConfigurationSection, IMailSettings
    {
        [ConfigurationProperty("defaultSenderAddress", IsRequired = true)]
        public string DefaultSenderAddress
        {
            get
            {
                return this["defaultSenderAddress"].ToString();
            }
        }
    }
}
