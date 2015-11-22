using System.Collections.Generic;
using Scratch.Settings;

namespace Scratch.Data.Core
{
    public interface IDatabaseSettings : ISignal
    {
        string ExpectedConnectionStringName { get; set; }

        string ExpectedConnectionStringProviderName { get; set; }

        string ActualConnectionStringProviderName { get; set; }

        string ActualConnectionString { get; set; }

        bool Exists { get; set; }

        bool CompatibleSchema { get; set; }

        bool CreateIfNotExists { get; set; }

        bool DropAndCreateIfNotCompatibleSchema { get; set; }

        List<DatabaseTableInfoListItem> Tables { get; set; } 
    }
}
