using System.Collections.Generic;

namespace Scratch.Web.Models.Settings
{
    public class IndexViewModel : ViewModelBase
    {
        public IndexViewModel() : base(MenuItems.WebsiteAdmin_WebsiteSettings)
        {
            Settings = new List<SettingsBase>
            {
                new DatabaseSettings(),
                new CacheSettings(),
                new EmailSettings()
            };
        }

        public List<SettingsBase> Settings { get; set; }
    }
}