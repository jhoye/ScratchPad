using System.Data.Entity;

namespace Scratch.Data.Core.ContentMetadata.DataModel
{
    /// <summary>
    /// DbContext for content metadata (content types, properties, etc.)
    /// </summary>
    public class ContentMetadata : DbContext
    {
        public ContentMetadata() : base("name=ContentMetadata")
        {
        }

        public virtual DbSet<ContentType> ContentTypes { get; set; }

        public virtual DbSet<Field> Fields { get; set; }
    }
}