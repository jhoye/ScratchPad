namespace Scratch.Data.Core
{
    public class GenericSettingsListItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public GenericSettingsListItem()
        {
            Value = string.Empty;
        }
    }
}
