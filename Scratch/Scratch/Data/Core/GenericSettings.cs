using System;
using System.Collections.Generic;

namespace Scratch.Data.Core
{
    public class GenericSettings
    {
        public string Section { get; set; }

        public string Description { get; set; }

        public Dictionary<string, GenericSettingsListItem> Settings { get; private set; }

        public bool IsLoaded { get; set; }

        public Exception LoadException { get; set; }

        public GenericSettings()
        {
            Settings = new Dictionary<string, GenericSettingsListItem>();
        }

        public GenericSettings WithSetting(string key, string name, string description = "")
        {
            Settings.Add(
                key, 
                new GenericSettingsListItem
                {
                    Name = name, 
                    Description = description
                });

            return this;
        }
    }
}
