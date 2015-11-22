using System.Collections.Generic;

namespace Scratch.Data.Core.DataModel
{
    public interface IContentTypeHierarchy
    {
        List<ContentsTypeHierarchyListItem> ContentTypes { get; set; }
    }
}
