using System.Data.Entity;
//using Scratch.Data.ContentDataModel;

namespace Scratch.Data
{
    public class ContentData : DbContext
    {
        public ContentData() : base("name=ContentData")
        {
        }
    }
}
