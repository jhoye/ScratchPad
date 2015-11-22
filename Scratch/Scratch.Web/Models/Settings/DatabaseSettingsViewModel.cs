using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Scratch.Data.Core;
using Scratch.Settings;

namespace Scratch.Web.Models.Settings
{
    public class DatabaseSettingsViewModel : SettingsViewModelBase, IDatabaseSettings
    {
        public string ExpectedConnectionStringName { get; set; }

        public string ExpectedConnectionStringProviderName { get; set; }

        public string ActualConnectionStringProviderName { get; set; }

        public string ActualConnectionString { get; set; }

        public bool Exists { get; set; }

        public bool CompatibleSchema { get; set; }

        [Display(Name = "Create Database On Save")]
        public bool CreateIfNotExists { get; set; }

        [Display(Name = "Drop and Create Database On Save")]
        public bool DropAndCreateIfNotCompatibleSchema { get; set; }

        public List<DatabaseTableInfoListItem> Tables { get; set; }

        public DatabaseSettingsViewModel()
        {
            Name = "Database";

            Tables = new List<DatabaseTableInfoListItem>();
        }
    }
}