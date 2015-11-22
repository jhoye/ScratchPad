using System.Collections.Generic;

namespace Scratch.Web.Models.Settings
{
    public abstract class SettingsViewModelBase : ISignal
    {
        public Enums.Andons Andon { get; set; }

        public List<string> Messages { get; set; }

        public string Name { get; set; }

        protected SettingsViewModelBase()
        {
            Andon = Enums.Andons.None;

            Messages = new List<string>();
        }
    }
}