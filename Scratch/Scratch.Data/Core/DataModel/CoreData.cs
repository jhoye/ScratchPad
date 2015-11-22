using System.Data.Entity;

namespace Scratch.Data.Core.DataModel
{
    internal class CoreData : DbContext
    {
        public CoreData(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }

        public virtual DbSet<Setting> Settings { get; set; }

        public virtual DbSet<ContentType> ContentTypes { get; set; }

        public virtual DbSet<Field> Fields { get; set; }
    }
}
