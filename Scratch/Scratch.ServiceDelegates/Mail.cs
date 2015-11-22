using Scratch.Data.Core;

namespace Scratch.ServiceDelegates
{
    public class Mail : DependentBase, IMail
    {
        private readonly GenericSettings _settingsInstance;

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

        public Mail()
        {
            _settingsInstance = new GenericSettings
                {
                    Section = "Mail",
                    Description = "AWS SES (Simple Email Service)"
                }
                .WithSetting("AccessKey", "Access Key", "Amazon Web Services account access key")
                .WithSetting("SecretKey", "Secret Key", "Amazon Web Services account secret key")
                .WithSetting("Enabled", "Enabled", "Set to \"true\" to enable or \"false\" to disable the service.");
        }

        public void TestSettings(ISignal signal)
        {
            signal.SetSignal("Service is not implemented", Enums.Andons.None);
        }
    }
}
