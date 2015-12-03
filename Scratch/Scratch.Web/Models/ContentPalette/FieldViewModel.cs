using System;
using System.ComponentModel.DataAnnotations;
using Scratch.Data.Core.DataModel;

namespace Scratch.Web.Models.ContentPalette
{
    public class FieldViewModel : ViewModelBase, IField
    {
        public Guid? Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        
        [Display(Name = "Is Nullable")]
        public bool IsNullable { get; set; }

        [Display(Name = "Field Type")]
        public Enums.FieldTypes FieldType { get; set; }

        [Display(Name = "Storage Bytes")]
        public int? StorageBytes { get; set; }

        public int? Precision { get; set; }

        public int? Scale { get; set; }

        [Required]
        [Display(Name = "Order of Appearance")]
        public int OrderOfAppearance { get; set; }

        public Guid ContentTypeId { get; set; }

        public FieldViewModel() : base(MenuItems.WebsiteAdmin_EditContentPalette)
        {
        }
    }
}