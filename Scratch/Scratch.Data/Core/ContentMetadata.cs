using System.Data.Entity;
using Scratch.Data.Core.ContentMetadataModel;

namespace Scratch.Data.Core
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
    }
}