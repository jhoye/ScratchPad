using System.Collections.Generic;

namespace Scratch.Web.Models.Settings
{
    public abstract class SettingsBase : ISignal
    {
        public Enums.Andons Andon { get; set; }

        public List<string> Messages { get; set; }

        public readonly string Name;

        protected SettingsBase(string name)
        {
            Name = name;

            Andon = Enums.Andons.None;

            Messages = new List<string>();
        }
    }
}