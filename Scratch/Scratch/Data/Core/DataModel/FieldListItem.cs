using System;

namespace Scratch.Data.Core.DataModel
{
    public class FieldListItem : IField
    {
        public Guid? Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool IsNullable { get; set; }

        public Enums.FieldTypes FieldType { get; set; }
        
        public int? StorageBytes { get; set; }
        
        public int? Precision { get; set; }
        
        public int? Scale { get; set; }

        public int OrderOfAppearance { get; set; }

        public Guid ContentTypeId { get; set; }
    }
}
