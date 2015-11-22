namespace Scratch.Data.Core
{
    public interface ISettingsConsumer
    {
        GenericSettings Settings { get; }

        void TestSettings(ISignal signal);
    }
}
