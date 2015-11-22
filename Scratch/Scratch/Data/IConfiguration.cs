using Scratch.Data.Core;

namespace Scratch.Data
{
    public interface IConfiguration
    {
        string ConnectionString { get; }

        void Load(IDatabaseSettings databaseSettings);
    }
}
