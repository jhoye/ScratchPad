using Scratch.Settings;

namespace Scratch.Data.Core
{
    public interface ITableSchema
    {
        void Load(IDatabaseSettings databaseSettings);
    }
}
