using System.Collections.Generic;

namespace Scratch.Web.Models.Settings
{
    public class IndexViewModel : ViewModelBase
    {
        public List<SettingsViewModelBase> Settings { get; set; }

        public IndexViewModel() : base(MenuItems.WebsiteAdmin_WebsiteSettings)
        {
            Settings = new List<SettingsViewModelBase>();
        }
    }
}