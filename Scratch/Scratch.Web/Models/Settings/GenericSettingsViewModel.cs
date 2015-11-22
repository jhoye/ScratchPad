using Scratch.Data.Core;

namespace Scratch.Web.Models.Settings
{
    public class GenericSettingsViewModel : SettingsViewModelBase
    {
        public GenericSettings Settings { get; set; }

        public GenericSettingsViewModel()
        {
            Settings = new GenericSettings();
        }
    }
}