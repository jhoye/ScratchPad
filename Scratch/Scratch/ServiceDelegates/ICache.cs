using Scratch.Data.Core;

namespace Scratch.ServiceDelegates
{
    public interface ICache : ISettingsConsumer
    {
        string Get(string slug);

        void Save(string slug, string content);

        void Delete(string slug);
    }
}
