using System.Data.Entity;

namespace Scratch.Data.Content.DataModel
{
    public class ContentData : DbContext
    {
        public ContentData() : base("name=ContentData")
        {
        }
    }
}
