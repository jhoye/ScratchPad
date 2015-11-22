using System.Collections.Generic;
using Scratch.Data.Core.DataModel;

namespace Scratch.Web.Models.ContentPalette
{
    public class IndexViewModel : ViewModelBase, IContentTypeHierarchy
    {
        public IndexViewModel() : base(MenuItems.WebsiteAdmin_EditContentPalette)
        {
            ContentTypes = new List<ContentsTypeHierarchyListItem>();
        }

        public List<ContentsTypeHierarchyListItem> ContentTypes { get; set; }
    }
}