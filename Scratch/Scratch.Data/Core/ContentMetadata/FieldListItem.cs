using System;

namespace Scratch.Data.Core.ContentMetadata
{
    internal class FieldListItem : IField
    {
        public Guid? Id { get; set; }
        
        public string Name { get; set; }
        
        public bool IsNullable { get; set; }
        
        public Enums.FieldTypes FieldType { get; set; }
        
        public int OrderOfAppearance { get; set; }
    }
}
