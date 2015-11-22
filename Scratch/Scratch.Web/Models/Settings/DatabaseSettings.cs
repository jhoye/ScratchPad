using System.ComponentModel.DataAnnotations;
using Scratch.Settings;

namespace Scratch.Web.Models.Settings
{
    public class DatabaseSettings : SettingsBase, IDatabaseSettings
    {
        public bool Exists { get; set; }

        [Display(Name = "Create Database On Save")]
        public bool CreateIfNotExists { get; set; }

        public DatabaseSettings() : base("Database")
        {
        }
    }
}