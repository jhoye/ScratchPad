namespace Scratch.Settings
{
    public interface IConnectionString : ISignal
    {
        string ExpectedName { get; set; }

        string ExpectedProviderName { get; set; }

        string ActualProviderName { get; set; }

        string ActualConnectionString { get; set; }
    }
}
