namespace Scratch.Web.Models.Settings
{
    public abstract class SettingsBase
    {
        public enum Statuses
        {
            None,
            Green,
            Yellow,
            Red
        }

        public Statuses Status { get; set; }

        public readonly string Name;

        public string StatusMessage { get; set; }

        protected SettingsBase(string name)
        {
            Name = name;

            Status = Statuses.None;

            StatusMessage = "Loading...";
        }
    }
}