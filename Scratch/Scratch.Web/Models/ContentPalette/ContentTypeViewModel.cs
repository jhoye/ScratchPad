using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Scratch.Data.Core.DataModel;

namespace Scratch.Web.Models.ContentPalette
{
    public class ContentTypeViewModel : ViewModelBase, IContentType, IContentTypeHierarchy
    {
        public Guid? Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        
        public List<IField> Fields { get; set; }

        [Display(Name = "Parent")]
        public Guid? ParentId { get; set; }

        public List<ContentsTypeHierarchyListItem> ContentTypes { get; set; }

        private List<SelectListItem> _parentOptionsInstance;

        public List<SelectListItem> ParentOptions
        {
            get
            {
                if (_parentOptionsInstance == null)
                {
                    _parentOptionsInstance = new List<SelectListItem>
                    {
                        new SelectListItem
                        {
                            Text = "None",
                            Value = string.Empty
                        }
                    };

                    AddChildren(ContentTypes);
                }

                return _parentOptionsInstance;
            }
        }

        public ContentTypeViewModel() : base(MenuItems.WebsiteAdmin_EditContentPalette)
        {
            Name = string.Empty;

            Fields = new List<IField>();

            ContentTypes = new List<ContentsTypeHierarchyListItem>();
        }

        public ContentTypeViewModel(bool isAdmin = true) : base(isAdmin ? MenuItems.WebsiteAdmin_EditContentPalette : MenuItems.PageEditing_ContentPalette)
        {
            Name = string.Empty;

            Fields = new List<IField>();

            ContentTypes = new List<ContentsTypeHierarchyListItem>();
        }

        private void AddChildren(List<ContentsTypeHierarchyListItem> children, string prefixes = "")
        {
            for (var i = 0; i < children.Count; i++)
            {
                var contentType = children[i];
                
                _parentOptionsInstance.Add(
                    new SelectListItem
                    {
                        Text = prefixes + (i < children.Count - 1 ? "├" : "└") + contentType.Name,
                        Value = contentType.Id.ToString(),
                        Disabled = contentType.Id == Id,
                        Selected = contentType.Id == ParentId
                    });

                AddChildren(contentType.Children, prefixes + (i < children.Count - 1 ? "│" : " "));
            }
        }
    }
}