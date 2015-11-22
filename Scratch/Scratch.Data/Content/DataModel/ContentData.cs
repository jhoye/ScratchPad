using System.Data.Entity;

namespace Scratch.Data.Content.DataModel
{
    internal class ContentData : DbContext
    {
        public ContentData(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }
    }
}
