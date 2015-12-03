using System;

namespace Scratch.Data.Core.DataModel
{
    public interface IField
    {
        Guid? Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        bool IsNullable { get; set; }

        Enums.FieldTypes FieldType { get; set; }

        int? StorageBytes { get; set; }

        int? Precision { get; set; }

        int? Scale { get; set; }

        int OrderOfAppearance { get; set; }

        Guid ContentTypeId { get; set; }
    }
}
