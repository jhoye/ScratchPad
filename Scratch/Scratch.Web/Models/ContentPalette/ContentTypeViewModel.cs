using System;
using System.Collections.Generic;
using Scratch.Data.Core.ContentMetadata;

namespace Scratch.Web.Models.ContentPalette
{
    public class ContentTypeViewModel : ViewModelBase, IContentType
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
        
        public List<IField> Fields { get; set; }

        public ContentTypeViewModel() : base(MenuItems.PageEditing_ContentPalette)
        {
            Name = string.Empty;

            Fields = new List<IField>();
        }
    }
}