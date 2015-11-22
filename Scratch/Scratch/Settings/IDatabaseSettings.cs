namespace Scratch.Settings
{
    public interface IDatabaseSettings : ISignal
    {
        bool Exists { get; set; }

        bool CreateIfNotExists { get; set; }
    }
}
