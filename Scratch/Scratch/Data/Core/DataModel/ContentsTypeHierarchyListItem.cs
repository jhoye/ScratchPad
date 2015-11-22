using System;
using System.Collections.Generic;

namespace Scratch.Data.Core.DataModel
{
    public class ContentsTypeHierarchyListItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<ContentsTypeHierarchyListItem> Children { get; set; }

        public ContentsTypeHierarchyListItem()
        {
            Children = new List<ContentsTypeHierarchyListItem>();
        }
    }
}
